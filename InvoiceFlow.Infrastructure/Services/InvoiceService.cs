using AutoMapper;
using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Application.DTOs.Item;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Application.Service.Contract;
using InvoiceFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IItemRepo _itemRepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbcontext;

        public InvoiceService(IInvoiceRepo invoiceRepo, IItemRepo itemRepo, IMapper mapper, AppDbContext dbcontext)
        {
            _invoiceRepo = invoiceRepo;
            _itemRepo = itemRepo;
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public async Task<InvoiceHeader?> CreateInvoiceAsync(CreateInvoiceHeaderDto dto)
        {
            if (dto.items == null || !dto.items.Any())
                return null;

            var invoice = _mapper.Map<InvoiceHeader>(dto);
            invoice.InvoiceDetails = new List<InvoiceDetail>();

            double total = 0;

            foreach (var detailDto in dto.items)
            {
                var item = await _itemRepo.GetAsync(detailDto.ItemID);
                if (item == null)
                    return null;

                var detail = new InvoiceDetail
                {
                    ItemID = item.ID,
                    ItemCount = detailDto.ItemCount
                };

                total += item.Price * detailDto.ItemCount;
                invoice.InvoiceDetails.Add(detail);
            }

            invoice.TotalPrice = total;
            invoice.Invoicedate = DateTime.Now;

            return await _invoiceRepo.AddAsync(invoice);
        }


        public async Task<InvoiceHeader?> UpdateInvoiceAsync(UpdateInvoiceHeaderDto dto, long id)
        {
            if (dto.Items == null || !dto.Items.Any())
                return null;

            var existingInvoice = await _dbcontext.InvoiceHeaders
        .Include(i => i.InvoiceDetails)
        .FirstOrDefaultAsync(i => i.ID == id && !i.IsDeleted);
            if (existingInvoice == null)
                return new InvoiceHeader { ID = 0 };

            double total = 0;
            var newDetails = new List<InvoiceDetail>();

   

            foreach (var detailDto in dto.Items)
            {
                var item = await _itemRepo.GetAsync(detailDto.ItemID);
                if (item == null)
                    return null;

                total += item.Price * detailDto.ItemCount;

                newDetails.Add(new InvoiceDetail
                {
                    ItemID = item.ID,
                    ItemCount = detailDto.ItemCount,
                    InvoiceHeaderID = existingInvoice.ID // important if not using cascade
                });
            }

         
            existingInvoice.CustomerName = dto.CustomerName;
            existingInvoice.CashierID = dto.CashierID;
            existingInvoice.BranchID = dto.BranchID;
            existingInvoice.Invoicedate = DateTime.Now;
            existingInvoice.TotalPrice = total;


            _dbcontext.InvoiceDetails.RemoveRange(existingInvoice.InvoiceDetails);
            existingInvoice.InvoiceDetails = newDetails;

            await _dbcontext.SaveChangesAsync();
            return existingInvoice;

          

           
          
        }



    }
}


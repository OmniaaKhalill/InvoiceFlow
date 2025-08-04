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

            var groupedItems = dto.items
         .GroupBy(i => i.ItemID)
         .Select(g => new
         {
             ItemID = g.Key,
             TotalCount = g.Sum(x => x.ItemCount)
         });

            foreach (var detailDto in groupedItems)
            {
                var item = await _itemRepo.GetAsync(detailDto.ItemID);
                if (item == null)
                    return null;

                var detail = new InvoiceDetail
                {
                    ItemID = item.ID,
                    ItemCount = detailDto.TotalCount
                };

                total += item.Price * detailDto.TotalCount;
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

            var groupedItems = dto.Items
                .GroupBy(i => i.ItemID)
                .Select(g => new
                {
                    ItemID = g.Key,
                    TotalCount = g.Sum(x => x.ItemCount)
                });

            foreach (var groupedItem in groupedItems)
            {
                var item = await _itemRepo.GetAsync(groupedItem.ItemID);
                if (item == null)
                    return null;

                total += item.Price * groupedItem.TotalCount;

                newDetails.Add(new InvoiceDetail
                {
                    ItemID = item.ID,
                    ItemCount = groupedItem.TotalCount,
                    InvoiceHeaderID = existingInvoice.ID
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


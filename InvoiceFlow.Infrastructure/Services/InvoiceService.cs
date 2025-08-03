using AutoMapper;
using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Application.Service.Contract;
using InvoiceFlow.Domain.Entities;
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

        public InvoiceService(IInvoiceRepo invoiceRepo, IItemRepo itemRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo;
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        public async Task<InvoiceHeader?> CreateInvoiceAsync(CreateInvoiceHeaderDto dto)
        {
            if (dto.InvoiceDetails == null || !dto.InvoiceDetails.Any())
                return null;

            var invoice = _mapper.Map<InvoiceHeader>(dto);
            invoice.InvoiceDetails = new List<InvoiceDetail>();

            double total = 0;

            foreach (var detailDto in dto.InvoiceDetails)
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
            if (dto.InvoiceDetails == null || !dto.InvoiceDetails.Any())
                return null;

            var existingInvoice = await _invoiceRepo.GetWithDetailsAsync(id); 
            if (existingInvoice == null)
                return new InvoiceHeader { ID = 0 };

            double total = 0;

            foreach (var detailDto in dto.InvoiceDetails)
            {
                var item = await _itemRepo.GetAsync(detailDto.ItemID);
                if (item == null)
                    return null;

                var existingDetail = existingInvoice.InvoiceDetails
                    .FirstOrDefault(d => d.ItemID == detailDto.ItemID);

                if (existingDetail != null)
                {
                    existingDetail.ItemCount = detailDto.ItemCount;
                }
                else
                {
                    existingInvoice.InvoiceDetails.Add(new InvoiceDetail
                    {
                        ItemID = item.ID,
                        ItemCount = detailDto.ItemCount
                    });
                }

                total += item.Price * detailDto.ItemCount;
            }

            existingInvoice.TotalPrice = total;
            existingInvoice.Invoicedate = DateTime.Now;
            existingInvoice.CustomerName = dto.CustomerName;

            return await _invoiceRepo.UpdateAsync(id, existingInvoice);
        }



    }
}


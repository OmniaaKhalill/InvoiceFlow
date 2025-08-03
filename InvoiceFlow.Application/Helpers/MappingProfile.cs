using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceFlow.Application.DTOs.Branch;
using InvoiceFlow.Application.DTOs.Cashier;
using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Application.DTOs.Item;
using InvoiceFlow.Domain.Entities;

namespace InvoiceFlow.Application.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CashierCreateDto, Cashier>();
            CreateMap<CashierUpdateDto, Cashier>();
            CreateMap<Cashier, CashierDetailsDto>()
           .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
           .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Branch.City.CityName));



            CreateMap<Branch, BranchDetailsDto>();

            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();


            CreateMap<CreateInvoiceDetailDto, InvoiceDetail>();
            CreateMap<CreateInvoiceHeaderDto, InvoiceHeader>();
            CreateMap<UpdateInvoiceHeaderDto, InvoiceHeader>();




        }
    }
}

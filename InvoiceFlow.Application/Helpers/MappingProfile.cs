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
           .ForMember(dest => dest.CashierID, opt => opt.MapFrom(src => src.ID))
           .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
           .ForMember(dest => dest.BranchID, opt => opt.MapFrom(src => src.Branch.ID))
           .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Branch.City.CityName));


            CreateMap<Item, ItemDetailsDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));



            CreateMap<Branch, BranchDetailsDto>().
                  ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BranchName))
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID));




            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<Item, ItemDetails>()
                .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));   


            CreateMap<CreateInvoiceDetailDto, InvoiceDetail>();
            CreateMap<CreateInvoiceHeaderDto, InvoiceHeader>();
            CreateMap<UpdateInvoiceHeaderDto, InvoiceHeader>();

            CreateMap<InvoiceHeader, InvoiceDetailsDto>()
    .ForMember(dest => dest.CashierName, opt => opt.MapFrom(src => src.Cashier.CashierName))
    .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
    .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
        src.InvoiceDetails.Select(d => new ItemInvoiceDto
        {
            Id = d.ID,
            Name = d.Item.Name,
            Price = d.Item.Price,
           Count  = d.ItemCount
        }).ToList()
    ));





        }
    }
}

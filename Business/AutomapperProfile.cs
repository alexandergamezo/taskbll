using AutoMapper;
using Business.Models;
using Data.Entities;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Receipt, ReceiptModel>()
                .ForMember(rm => rm.ReceiptDetailsIds, r => r.MapFrom(x => x.ReceiptDetails.Select(rd => rd.Id)))
                .ReverseMap();

            CreateMap<Product, ProductModel>()
                .ForMember(pm => pm.CategoryName, p => p.MapFrom(x => x.Category.CategoryName))
                .ReverseMap();

            CreateMap<ReceiptDetail, ReceiptDetailModel>()
                .ReverseMap();

            CreateMap<Customer, CustomerModel>()
                .ForMember(cm => cm.Name, c => c.MapFrom(x => x.Person.Name))
                .ForMember(cm => cm.Surname, c => c.MapFrom(x => x.Person.Surname))
                .ForMember(cm => cm.BirthDate, c => c.MapFrom(x => x.Person.BirthDate))
                .ForMember(cm => cm.ReceiptsIds, c => c.MapFrom(x => x.Receipts.Select(r => r.Id)))
                .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryModel>()
                .ForMember(pcm => pcm.ProductIds, p => p.MapFrom(pc => pc.Products.Select(x => x.Id)))
                .ReverseMap();


            //TODO: Create mapping for Product and ProductModel

            //TODO: Create mapping for ReceiptDetail and ReceiptDetailModel

            //TODO: Create mapping that combines Customer and Person into CustomerModel

            //TODO: Create mapping for ProductCategory and ProductCategoryModel
        }
    }
}
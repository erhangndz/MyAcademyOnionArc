using AutoMapper;
using Product.Application.Features.CQRS.Commands.ProductCommands;
using Product.Application.Features.CQRS.Results.CategoryResults;
using Product.Application.Features.CQRS.Results.ProductResults;
using ent = Product.Domain.Entities;
using Product.Domain.Entities;


namespace Product.WebUI.Mappings
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetProductQueryResult, ent.Product>().ReverseMap();
            CreateMap<GetProductByIdQueryResult, ent.Product>().ReverseMap();
            CreateMap<CreateProductCommand, ent.Product>().ReverseMap();
            CreateMap<UpdateProductCommand, ent.Product>().ReverseMap();

            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
        }
    }
}

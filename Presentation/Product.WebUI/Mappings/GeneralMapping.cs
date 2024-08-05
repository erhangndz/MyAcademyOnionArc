using AutoMapper;
using Product.Application.Features.CQRS.Commands.ProductCommands;
using Product.Application.Features.CQRS.Results.CategoryResults;
using Product.Application.Features.CQRS.Results.ProductResults;
using ent = Product.Domain.Entities;
using Product.Domain.Entities;
using Product.Application.Features.Mediator.Results.CustomerResults;
using Product.Application.Features.Mediator.Commands.CustomerCommands;


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

            CreateMap<Customer, GetCustomerQueryResult>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdQueryResult>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }
    }
}

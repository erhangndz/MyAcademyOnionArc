using AutoMapper;
using Product.Application.Features.CQRS.Commands.ProductCommands;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(IProductRepository repository,IMapper mapper)
    {
        
        public async Task Handle(CreateProductCommand command)
        {
            var product = mapper.Map<Domain.Entities.Product>(command);
            await repository.CreateAsync(product);
        }

    }
}

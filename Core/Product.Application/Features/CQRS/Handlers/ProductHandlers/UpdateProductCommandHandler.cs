using AutoMapper;
using Product.Application.Features.CQRS.Commands.ProductCommands;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Product.Domain.Entities;

namespace Product.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(IProductRepository _repository,IMapper _mapper)
    {

        public async Task Handle(UpdateProductCommand command)
        {
            var product = _mapper.Map<ent.Product>(command);
            await _repository.UpdateAsync(product);
        }



    }
}

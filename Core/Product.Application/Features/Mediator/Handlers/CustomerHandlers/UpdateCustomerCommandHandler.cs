using AutoMapper;
using MediatR;
using Product.Application.Features.Mediator.Commands.CustomerCommands;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            await _repository.UpdateAsync(customer);
        }
    }
}

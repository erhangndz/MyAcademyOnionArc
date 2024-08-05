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
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;

        public RemoveCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}

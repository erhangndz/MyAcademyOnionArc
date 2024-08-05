using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Commands.CustomerCommands
{
    public class RemoveCustomerCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }
    }
}

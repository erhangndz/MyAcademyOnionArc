using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
    }
}

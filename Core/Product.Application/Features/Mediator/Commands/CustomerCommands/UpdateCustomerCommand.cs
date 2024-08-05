using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
    }
}

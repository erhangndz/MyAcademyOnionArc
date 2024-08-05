using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Results.CustomerResults
{
    public class GetCustomerByIdQueryResult
    {
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }

    }
}

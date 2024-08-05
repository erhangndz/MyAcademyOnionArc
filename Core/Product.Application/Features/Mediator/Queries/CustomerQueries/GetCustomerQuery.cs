using MediatR;
using Product.Application.Features.Mediator.Results.CustomerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Mediator.Queries.CustomerQueries
{
    public class GetCustomerQuery: IRequest<IList<GetCustomerQueryResult>>
    {
    }
}

using AutoMapper;
using Product.Application.Features.CQRS.Queries.ProductQueries;
using Product.Application.Features.CQRS.Results.ProductResults;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            return _mapper.Map<GetProductByIdQueryResult>(value);
        }

    }
}

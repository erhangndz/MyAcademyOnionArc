using AutoMapper;
using Product.Application.Features.CQRS.Results.ProductResults;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly IRepository<Domain.Entities.Product> _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Domain.Entities.Product> repository, IMapper mapper, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _productRepository.GetAllProductsWithCategoryAsync();
            return _mapper.Map<List<GetProductQueryResult>>(values);
           
        }
    }
}

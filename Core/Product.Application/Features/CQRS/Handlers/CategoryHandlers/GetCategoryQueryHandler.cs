using Product.Application.Features.CQRS.Results.CategoryResults;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetCategoryQueryResult>> Handle()
        {
           var values =  await _repository.GetListAsync();
            var categories = (from x in values
                              select new GetCategoryQueryResult
                              {
                                  CategoryId = x.CategoryId,
                                  CategoryName = x.CategoryName
                              }).ToList();
            return categories;
        }

    }
}

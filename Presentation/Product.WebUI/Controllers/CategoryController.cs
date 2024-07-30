using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.CQRS.Handlers.CategoryHandlers;

namespace Product.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }
    }
}

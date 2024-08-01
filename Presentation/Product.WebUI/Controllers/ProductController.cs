using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product.Application.Features.CQRS.Commands.ProductCommands;
using Product.Application.Features.CQRS.Handlers.CategoryHandlers;
using Product.Application.Features.CQRS.Handlers.ProductHandlers;
using Product.Application.Features.CQRS.Queries.ProductQueries;

namespace Product.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public ProductController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
        }

        public async Task CategoryDropdownAsync()
        {
            var categoryList = await _getCategoryQueryHandler.Handle();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;
        }



        public async Task<IActionResult> Index()
        {
            var values = await _getProductQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CreateProduct()
        {
            await CategoryDropdownAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await CategoryDropdownAsync();
            var value = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}

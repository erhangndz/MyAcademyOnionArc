using Product.Application.Features.CQRS.Handlers.CategoryHandlers;

namespace Product.WebUI.Extensions
{
    public static class ServiceExtension
    {

        public static void AddServiceHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
        }


    }
}

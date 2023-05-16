using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.WebAPI.Filters
{
    // Фильтр действий для скрытия товаров с нулевым количеством и проверки наличия товара
    public class ProductActionFilter : IActionFilter
    {
        private readonly IStoreDbContext _ctx;

        public ProductActionFilter(IStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Ничего не делаем при входе в действие
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

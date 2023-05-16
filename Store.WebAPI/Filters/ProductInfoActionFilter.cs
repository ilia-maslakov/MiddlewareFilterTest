using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.DataContext.Entities;

namespace Store.WebAPI.Middleware
{
    // ‘ильтр действий дл€ скрыти€ товаров с нулевым количеством и проверки наличи€ товара
    public class ProductInfoActionFilter : IActionFilter
    {
        private readonly IStoreDbContext _ctx;

        public ProductInfoActionFilter(IStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Ќичего не делаем при входе в действие
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // ѕровер€ем, €вл€етс€ ли текущий пользователь анонимным пользователем
            if (context.HttpContext.User?.Identity?.IsAuthenticated == false)
            {
                if (context.Result is ObjectResult objectResult && objectResult.Value is Product product)
                {
                    var existingProduct = _ctx.Products.Find(product.Id);
                    if (existingProduct == null || existingProduct.Count == 0)
                    {
                        context.Result = new NotFoundResult();
                    }
                }
            }
        }
    }
}

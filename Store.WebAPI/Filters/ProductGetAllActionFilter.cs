using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.DataContext.Entities;

namespace Store.WebAPI.Filters
{
    // Фильтр действий для скрытия товаров с нулевым количеством и проверки наличия товара
    public class ProductGetAllActionFilter : IActionFilter
    {
        public ProductGetAllActionFilter()
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Ничего не делаем при входе в действие
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Проверяем, является ли текущий пользователь анонимным пользователем
            if (context.HttpContext.User?.Identity?.IsAuthenticated == false)
            {
                if (context.Result is ObjectResult objectResult && objectResult.Value is List<Product> products)
                {
                    var filteredProducts = products.Where(p => p.Count > 0).ToList();
                    objectResult.Value = filteredProducts;
                }
            }
        }
    }
}
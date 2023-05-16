using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.DataContext.Entities;

namespace Store.WebAPI.Middleware
{
    // ������ �������� ��� ������� ������� � ������� ����������� � �������� ������� ������
    public class ProductGetAllActionFilter : IActionFilter
    {
        private readonly IStoreDbContext _ctx;

        public ProductGetAllActionFilter(IStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // ������ �� ������ ��� ����� � ��������
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // ���������, �������� �� ������� ������������ ��������� �������������
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
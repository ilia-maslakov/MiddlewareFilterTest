using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.WebAPI.Filters
{
    // ������ �������� ��� ������� ������� � ������� ����������� � �������� ������� ������
    public class ProductActionFilter : IActionFilter
    {
        private readonly IStoreDbContext _ctx;

        public ProductActionFilter(IStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // ������ �� ������ ��� ����� � ��������
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

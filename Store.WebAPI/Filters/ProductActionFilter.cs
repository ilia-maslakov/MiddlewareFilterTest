using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.WebAPI.Filters
{
    // ������ �������� ��� ������� ������� � ������� ����������� � �������� ������� ������
    public class ProductActionFilter : IActionFilter
    {
        public ProductActionFilter()
        {

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

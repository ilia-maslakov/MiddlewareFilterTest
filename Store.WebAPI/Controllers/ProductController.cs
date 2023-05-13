using Microsoft.AspNetCore.Mvc;
using Store.DataContext.Entities;

namespace Store.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Product product)
        {
            // ���������, ��� ���������� ������������� ��������� � ��������������� ������ � ���� �������
            if (id != product.Id)
            {
                return BadRequest();
            }

            // ��������� ���������� � ������ � ���� ������
            // ...

            return NoContent();
        }
    }





}
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
            // Проверяем, что переданный идентификатор совпадает с идентификатором товара в теле запроса
            if (id != product.Id)
            {
                return BadRequest();
            }

            // Обновляем информацию о товаре в базе данных
            // ...

            return NoContent();
        }
    }





}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.DataContext.Entities;
using Store.WebAPI.Middleware;
using System.Threading.Tasks;

namespace Store.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/products")]
    [ServiceFilter(typeof(ProductActionFilter))]
    public class ProductsController : ControllerBase
    {
        private readonly IStoreDbContext _ctx;

        public ProductsController(IStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product product)
        {
            // Проверяем, что переданный идентификатор совпадает с идентификатором товара в теле запроса
            if (id != product.Id)
            {
                return BadRequest();
            }

            // Получаем товар из базы данных
            var existingProduct = await _ctx.Products.FindAsync(id);

            // Если товар не найден, возвращаем ошибку 404
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Обновляем свойства товара
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Count = product.Count;

            // Сохраняем изменения в базе данных
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {

            // Обновляем свойства товара
            _ctx.Products.Add(product);

            // Сохраняем изменения в базе данных
            await _ctx.SaveChangesAsync();

            return Ok(product);
        }

        [HttpGet]
        [TypeFilter(typeof(ProductGetAllActionFilter))]
        public IActionResult GetAll()
        {
            var products = _ctx.Products.ToList();
            return Ok(products);
        }

        [HttpGet("info/{id}")]
        [TypeFilter(typeof(ProductInfoActionFilter))]
        public IActionResult Info(Guid id)
        {
            // Получаем товар из базы данных
            var product = _ctx.Products.Find(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
    }
}

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
            // ���������, ��� ���������� ������������� ��������� � ��������������� ������ � ���� �������
            if (id != product.Id)
            {
                return BadRequest();
            }

            // �������� ����� �� ���� ������
            var existingProduct = await _ctx.Products.FindAsync(id);

            // ���� ����� �� ������, ���������� ������ 404
            if (existingProduct == null)
            {
                return NotFound();
            }

            // ��������� �������� ������
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Count = product.Count;

            // ��������� ��������� � ���� ������
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {

            // ��������� �������� ������
            _ctx.Products.Add(product);

            // ��������� ��������� � ���� ������
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
            // �������� ����� �� ���� ������
            var product = _ctx.Products.Find(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
    }
}

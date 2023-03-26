using Microsoft.AspNetCore.Mvc;
using static CatalogDemo.Common.Dtos;

namespace CatalogDemo.Controllers
{
    // Que no se les olvide que un Controlador hereda de ControllerBase
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // Inyección de dependencias
        private readonly IRepository repository;
        public ProductController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            return repository.GetProducts().Select(e => e.AsDto());
        }

        // Get/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProducById(Guid id)
        {
            try
            {
                var product = repository.GetById(id);

                // Dtos Mantener seguro nuestro model
                return product.AsDto();
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR: {ex.Message}");
            }
        }

        // Delete/Products/{id}
        [HttpDelete("{id}")]
        public ActionResult RemoveProduct(Guid id)
        {
            try
            {
                repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR: {ex.Message}");
            }
        }

        // Post/Products/{id}
        [HttpPost]
        public ActionResult CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                var product = createProductDto.AsPoco();
                repository.Create(product);

                //Cuando se crea un producto se mostrará en Swagger
                return CreatedAtAction(nameof(GetProducById), new { id = product.Id }, product.AsDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = repository.GetById(id);
                product.Name = updateProductDto.Name;
                product.Price = updateProductDto.Price;
                repository.Update(id, product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR: {ex.Message}");
            }
        }
    }
}
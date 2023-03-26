using CatalogDemo.Extensions;
using Microsoft.AspNetCore.Mvc;
using static CatalogDemo.Common.Dtos;

namespace CatalogDemo.Controllers;

// localhost:5850/Product/GetProduct
[ApiController]
[Route("[Controller]")]
public class ProductController
{
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

    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(Guid id)
    {
        try
        {
            var product = repository.GetById(id);
            return product.AsDto();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public void Create(CreateProductDto productDto)
    {
        try
        {
            repository.Create(productDto.AsPoco());
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    [HttpPut]
    public void Update(Guid id, CreateProductDto update)
    {
        Product product = new()
        {
            Name = update.Name,
            Description = update.Description,
            Quantity = update.Quantity,
            Price = update.price
        };

        repository.Update(id, product);
    }

    [HttpDelete]
    public void Delete(Guid id)
    {
        repository.Delete(id);
    }
}
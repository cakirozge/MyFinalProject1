using Business.Abstract;
using Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE:Bir class ile ilgili bilgi verme ve onu imzalama yöntemidir. for C# ------ ANNOTATION: for Java ControllerBase'den inherit edilmesi
    public class ProductsController : ControllerBase
    {
        //Loosely coupled --gevşek bağlılık: soyuta bağlılık.
        //naming convention
        //IoC Container -- Inversion of Control : Değişimin kontrolü
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]   
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpPost("add")] //
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success) 
            {
                return Ok(result);  
            }
            return BadRequest(result);
        }
    }
}

using DotStarkProjectBLL.Interface;
using DotStarkProjectData.Context;
using Microsoft.AspNetCore.Mvc;

namespace DotStarkProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IProduct _product;
        public ApiController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("GetTime")]
        public IActionResult GetTime()
        {
            try
            {
                var res = _product.GetTime();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest("Something went Wrong");
            }
        }

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Products model)
        {
            try
            {
                var res = _product.SaveProduct(model);
                return Ok(new { result = res });
            }
            catch (Exception)
            {
                return BadRequest("Something went Wrong");
            }
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList()
        {
            try
            {
                var res = _product.GetProductList();
                return Ok(new { result = res.Item1, Status = res.Item2.IsSuccess });
            }
            catch (Exception)
            {
                return BadRequest("Something went Wrong");
            }
        }
        
        [HttpGet("GetPostsList")]
        public IActionResult GetPostsList()
        {
            try
            {
                var res = _product.GetPostsList();
                return Ok(new { result = res.Item1, Status = res.Item2.IsSuccess });
            }
            catch (Exception)
            {
                return BadRequest("Something went Wrong");
            }
        }
    }
}

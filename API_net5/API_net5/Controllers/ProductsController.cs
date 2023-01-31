﻿using API_net5.Model;
using API_net5.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IHangHoaRepository _hangHoaRepository;

        public ProductsController(IHangHoaRepository hangHoaRepository) { _hangHoaRepository = hangHoaRepository; }
        [HttpGet]
        public IActionResult GettAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                var result = _hangHoaRepository.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
      
    }
}

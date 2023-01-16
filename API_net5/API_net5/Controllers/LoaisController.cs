﻿using API_net5.Data;
using API_net5.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime;

namespace API_net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaisController(MyDbContext myDbContext)
        {
            _context = myDbContext;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel loaiModel)
        {
            try
            {
                var loai = new Loai { TenLoai = loaiModel.TenLoai };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel loaiModel)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);

            try
            {
                if (loai != null)
                {
                    loai.TenLoai = loaiModel.TenLoai;
                    _context.SaveChanges();

                    return NoContent(); 
                }
                else
                {
                    return NotFound();
                }             
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

using API_net5.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);// return ok status and  data

        }
        [HttpGet("{id}")]
        public IActionResult GetByid(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(h => h.MaHang == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hanghoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHang = Guid.NewGuid(),
                TenHang = hangHoaVM.TenHang,
                DonGia = hangHoaVM.DonGia
            };
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });


        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaedit)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(h => h.MaHang == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                else if (id != hanghoa.MaHang.ToString())
                {
                    return BadRequest();
                }
                else // update data
                {
                    hanghoa.TenHang = hangHoaedit.TenHang;
                    hanghoa.DonGia = hangHoaedit.DonGia;
                    return Ok();

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(h => h.MaHang == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
               
                else // delete data
                {
                   hanghoas.Remove(hanghoa);
                    return Ok();

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

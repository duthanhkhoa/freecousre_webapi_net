using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        // Lấy ra danh sách
        [HttpGet]
        public IActionResult GetAll()
        {
            // Trả về danh sách hàng hóa nếu thành công Ok()
            return Ok(hangHoas);
        }

        // Lấy thêm phần id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    // NotFound trả về status 404
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        // Thêm mới
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            // Tạo object hàng hóa
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            // object vào danh sách đã tạo ở trên 
            hangHoas.Add(hanghoa);

            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }

        // Cập nhật
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                // LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    // NotFound trả về status 404
                    return NotFound();
                }

                if(id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;

                return Ok();
            }
            catch
            {
                // Kiểm tra id theo chuỗi Guid 
                return BadRequest();
            }
        }

        // Xóa 
        [HttpDelete("{id}")]
        public IActionResult Remove(string id) 
        {
            try
            {
                // LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    // NotFound trả về status 404
                    return NotFound();
                }

                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update
                hangHoas.Remove(hangHoa);

                return Ok();
            }
            catch
            {
                // Kiểm tra id theo chuỗi Guid 
                return BadRequest();
            }
        }

    }
}

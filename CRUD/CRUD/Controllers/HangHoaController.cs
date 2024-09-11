using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };
            hangHoas.Add(hangHoa);
            return Ok(new
            {
                success = true,
                data = hangHoa,
            });
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                
                return Ok(hangHoa);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

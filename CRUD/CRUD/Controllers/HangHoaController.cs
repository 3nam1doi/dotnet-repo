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
        public async Task<IActionResult> Create(HangHoa hangHoaVM)
        {
            var hangHoa = new HangHoaVM
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };

            return Ok(new
            {
                success = true,
                data = hangHoa,
            });
        }
    }
}

using AppBusiness.Interface;
using AppBusiness.Interface.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private readonly ITransaksiService _transaksiService;

        public TransaksiController(IBusiness business)
        {
            _transaksiService = business.ITransaksiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new JsonResult(await _transaksiService.Get());
        }
    }
}

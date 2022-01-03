using AppBusiness.Data.DTOs.Parameters;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return new JsonResult(await _transaksiService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ParamTransaksiDto param)
        {
            return new JsonResult(await _transaksiService.Add(param));
        }
    }
}

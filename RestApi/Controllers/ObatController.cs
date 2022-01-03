using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Interface;
using AppBusiness.Interface.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers.Param;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObatController : ControllerBase
    {
        private readonly IObatService _obatService;

        public ObatController(IBusiness business)
        {
            _obatService = business.IObatService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new JsonResult(await _obatService.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return new JsonResult(await _obatService.Get(id));
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] ParamObatWithFotoDto param)
        {
            string fileName = UploadFile(param.Foto).Result.ToString();

            return new JsonResult(await _obatService.Add(new ParamObatDto
            {
                Kode = param.Kode,
                Harga = param.Harga,
                Nama = param.Nama,
                Stok = param.Stok,
                Foto = fileName
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ParamObatDto param)
        {
            return new JsonResult(await _obatService.Update(param));
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(ParamObatDto param)
        {
            return new JsonResult(await _obatService.Delete(param));
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            string fileName;
            string result = null;
            try
            {
                var folderName = Path.Combine("Storage", "Obat");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;

                result = fileName;

                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            catch (Exception)
            {
                //log error
            }

            return result;
        }
    }
}

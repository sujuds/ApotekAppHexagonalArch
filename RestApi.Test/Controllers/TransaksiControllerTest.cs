using AppBusiness.Data.DTOs.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RestApi.Test.Controllers
{
    public class TransaksiControllerTest : BaseTest
    {
        public TransaksiController CUT { get; }
        public HttpResponse response { get; }

        public TransaksiControllerTest()
        {
            CUT = new TransaksiController(Business);
            CUT.ControllerContext = new ControllerContext();
            CUT.ControllerContext.HttpContext = new DefaultHttpContext();
            response = CUT.ControllerContext.HttpContext.Response;
        }


        [Fact]
        public void CanGetTransaksi()
        {
            var JsonResult = CUT.GetAll().Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void CanGetTransaksiById()
        {
            var JsonResult = CUT.GetById((int)1).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void CanAddObat()
        {
            var JsonResult = CUT.Add(new ParamTransaksiDto() { 
                Id = 1,
                Kode = "Ttest1",
                TransaksiDetails = new List<ParamTransaksiDetailDto>()
                    {
                        new ParamTransaksiDetailDto(){
                            Id = 1,
                            Jumlah = 2,
                            ObatId = 1,
                            Obat = new ParamObatDto()
                            {
                                Id = 1,
                                Nama = "Paracetamol",
                                Kode = "111",
                                Stok = 20,
                                Harga = 500,
                                Foto = "test1.jpg"
                            }
                        }
                    }
            }).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }
    }
}

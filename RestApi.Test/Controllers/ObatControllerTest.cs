using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Data.Responses;
using AppBusiness.Interface.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using RestApi.Controllers;
using RestApi.Controllers.Param;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestApi.Test.Controllers
{
    public class ObatControllerTest : BaseTest
    {
        public ObatController CUT { get; }
        public HttpResponse response { get; }

        public ObatControllerTest()
        {
            CUT = new ObatController(Business);
            CUT.ControllerContext = new ControllerContext();
            CUT.ControllerContext.HttpContext = new DefaultHttpContext();
            response = CUT.ControllerContext.HttpContext.Response;
        }


        [Fact]
        public void CanGetObat()
        {
            var JsonResult = CUT.GetAll().Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void CanGetObatById()
        {
            var JsonResult = CUT.GetById((int) 1).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void CanAddObat()
        {
            var JsonResult = CUT.Add(new ParamObatWithFotoDto() {
                Kode = "111",
                Nama = "Paracetamol",
                Harga = 500,
                Stok = 10
            }).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void CanUpdateObat()
        {
            var JsonResult = CUT.Edit(new ParamObatDto() {
                Id  = 1,
                Kode = "111",
                Nama = "Paracetamol",
                Harga = 500,
                Stok = 10
            }).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }
        
        [Fact]
        public void CanDeleteObat()
        {
            var JsonResult = CUT.Delete(new ParamObatDto() {
                Id  = 1,
                Kode = "111",
                Nama = "Paracetamol",
                Harga = 500,
                Stok = 10
            }).Result as JsonResult;

            var result = JObject.FromObject(JsonResult.Value);

            Assert.True((bool)result.GetValue("Status"));
            Assert.Equal(200, response.StatusCode);
        }




    }
}

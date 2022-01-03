using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Impl.Services;
using AppBusiness.Interface;
using AppBusiness.Interface.Interfaces;
using AppPersistence.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AppBusiness.Impl.Test.Services
{
    public class ObatServiceTest
    {
        public ObatService SUT { get; }

        public ObatServiceTest()
        {
            SUT = new ObatService(new TestPersistence());
        }


        [Fact]
        public void CanGetObat()
        {
            // arrange
            var expected = new ObatDto()
            {
                Id = 1,
                Kode = "111",
                Nama = "Paracetamol",
                Stok = 10,
                Harga = 500,
                Foto = null
            };

            //act
            var result = SUT.Get().Result.Data.FirstOrDefault();

            //assert
            Assert.Equal(expected.Kode, result.Kode);
        }

        [Fact]
        public void CanAddObat()
        {
            var param = new ParamObatDto()
            {
                Id = 10,
                Nama = "tes1",
                Stok = 11,
                Foto = "test1.jpg",
                Harga = 500,
                Kode = "123tes"
            };

            var result = SUT.Add(param);

            Assert.True(true);
            Assert.True(result.Result.Status);
            Assert.Equal("Tambah data berhasil", result.Result.Message);
        }

        [Fact]
        public void CanDeleteObat()
        {
            var param = new ParamObatDto()
            {
                Id = 10,
                Nama = "tes1",
                Stok = 11,
                Foto = "test1.jpg",
                Harga = 500,
                Kode = "123tes"
            };

            var result = SUT.Delete(param);

            Assert.True(true);
            Assert.True(result.Result.Status);
            Assert.Equal("Data berhasil dihapus !", result.Result.Message);
        }


        [Fact]
        public void CanUpdateObat()
        {
            var param = new ParamObatDto()
            {
                Id = 10,
                Nama = "tes1",
                Stok = 11,
                Foto = "test1.jpg",
                Harga = 500,
                Kode = "123tes"
            };

            var result = SUT.Update(param);

            Assert.True(true);
            Assert.True(result.Result.Status);
            Assert.Equal("Update data berhasil !", result.Result.Message);
        }

    }
}

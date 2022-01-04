using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Impl.Services;
using AppPersistence.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AppBusiness.Impl.Test.Services
{
    public class TransaksiServiceTest
    {
        public TransaksiService SUT { get; }

        public TransaksiServiceTest()
        {
            SUT = new TransaksiService(new TestPersistence());
        }


        [Fact]
        public void CanGetObat()
        {
            // arrange
            var expected = new TransaksiDto()
            {
                Id = 1,
                Kode = "Ttest1",
                Total = 50000,
                TransaksiDetails = new List<TransaksiDetailDto>()
                    {
                        new TransaksiDetailDto(){
                            Id = 1,
                            Jumlah = 2,
                            Obat = new ObatDto()
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
            };

            //act
            var result = SUT.Get().Result.Data.FirstOrDefault();

            //assert
            Assert.Equal(expected.Kode, result.Kode);
        }

        [Fact]
        public void CanGetObatById()
        {
            // arrange
            var expected = new TransaksiDto()
            {
                Id = 1,
                Kode = "Ttest1",
                Total = 50000,
                TransaksiDetails = new List<TransaksiDetailDto>()
                    {
                        new TransaksiDetailDto(){
                            Id = 1,
                            Jumlah = 2,
                            Obat = new ObatDto()
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
            };

            //act
            var result = SUT.Get((int)1).Result.Value;

            //assert
            Assert.Equal(expected.Kode, result.Kode);
        }

        [Fact]
        public void CanAddObat()
        {
            var param = new ParamTransaksiDto()
            {
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
            };

            var result = SUT.Add(param);

            Assert.True(true);
            Assert.True(result.Result.Status);
            Assert.Equal("Tambah data berhasil !", result.Result.Message);
        }
    }
}

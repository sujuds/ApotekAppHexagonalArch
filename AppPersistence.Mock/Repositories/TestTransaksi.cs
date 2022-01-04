using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Data.Responses;
using AppPersistence.Interface.Interfaces;
using AppPersistence.MySql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Mock.Repositories
{
    public class TestTransaksi : ITransaksi
    {
        public Task<RepositoryResponse> AddData(ParamTransaksiDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {

                var data = new Transaksi()
                {
                    Id = 1,
                    Kode = "Ttest1",
                    Total = 50000,
                    TransaksiDetails = new List<TransaksiDetail>()
                    {
                        new TransaksiDetail(){
                            Id = 1,
                            Jumlah = 2,
                            ObatId = 1,
                            TransaksiId = 1,
                            Obat = new Obat()
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

                if (data != null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = true,
                        Message = "Tambah data berhasil !"
                    };
                }

            }

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> Delete(ParamTransaksiDto param)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse> GetData()
        {
            var data = new List<TransaksiDto>()
            {
                new TransaksiDto()
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
                }
            };

            var response = new RepositoryResponse()
            {
                Status = true,
                Data = data,
            };

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> GetData(int id)
        {
            var data = new TransaksiDto()
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

            var response = new RepositoryResponse()
            {
                Status = false,
                Message = "Data transaksi tidak ditemukan !"
            };

            if (data != null)
            {
                response = new RepositoryResponse()
                {
                    Status = true,
                    Value = data
                };
            }

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> UpdateData(ParamTransaksiDto param)
        {
            throw new NotImplementedException();
        }


        private string Validasi(ParamTransaksiDto param)
        {
            //if (!param.Id.HasValue)
            //    return "Id tidak boleh kosong !";

            if (string.IsNullOrWhiteSpace(param.Kode))
                return "Kode tidak boleh kosong !";


            if (param.TransaksiDetails == null)
                return "Detail transaksi tidak boleh kosong !";


            return null;
        }
    }
}

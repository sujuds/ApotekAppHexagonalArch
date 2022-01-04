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
    public class TestObat : IObat
    {
        public Task<RepositoryResponse> AddData(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                var data = new Obat()
                {
                    Id = param.Id,
                    Kode = param.Kode,
                    Nama = param.Nama,
                    Harga = param.Harga,
                    Stok = param.Stok,
                    Foto = param.Foto
                };

                if (data != null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = true,
                        Message = "Tambah data berhasil"
                    };
                }
            }

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> Delete(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                var data = new ObatDto()
                {
                    Id = param.Id,
                    Kode = param.Kode,
                    Nama = param.Nama,
                    Harga = param.Harga,
                    Stok = param.Stok,
                    Foto = param.Foto
                };

                if (data == null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = false,
                        Message = "Data obat tidak ditemukan !"
                    };
                }
                else
                {
                    response = new RepositoryResponse()
                    {
                        Status = true,
                        Message = "Data berhasil dihapus !"
                    };
                }
            }

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> GetData()
        {
            var data = new List<ObatDto>()
            {
                new ObatDto()
                {
                    Id = 1,
                    Kode = "111",
                    Nama = "Paracetamol",
                    Harga = 500,
                    Stok = 10,
                    Foto = null
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
            var obats = new ObatDto() { 
                Id = 1,
                Nama = "Paracetamol",
                Kode = "111",
                Stok = 10,
                Harga = 500,
                Foto = "test1.jpg"
            };

            var response = new RepositoryResponse()
            {
                Status = false,
                Message = "Data obat tidak ditemukan !"
            };

            if (obats != null)
            {
                response = new RepositoryResponse()
                {
                    Status = true,
                    Value = obats
                };
            }

            return Task.FromResult(response);
        }

        public Task<RepositoryResponse> UpdateData(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {

                var data = new ObatDto()
                {
                    Id = param.Id,
                    Kode = param.Kode,
                    Nama = param.Nama,
                    Harga = param.Harga,
                    Stok = param.Stok,
                    Foto = param.Foto
                };


                if (data == null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = false,
                        Message = "Data obat tidak ditemukan !"
                    };
                }
                else
                {
                    response = new RepositoryResponse()
                    {
                        Status = true,
                        Message = "Update data berhasil !"
                    };
                }
            }

            return Task.FromResult(response);
        }

        private string Validasi(ParamObatDto param)
        {
            //if (!param.Id.HasValue)
            //    return "Id tidak boleh kosong !";

            if (string.IsNullOrWhiteSpace(param.Kode))
                return "Kode tidak boleh kosong !";

            if (string.IsNullOrWhiteSpace(param.Nama))
                return "Nama tidak boleh kosong !";

            if (!param.Stok.HasValue)
                return "Stok tidak boleh kosong !";

            if (!param.Harga.HasValue)
                return "Harga tidak boleh kosong !";


            return null;
        }
    }
}

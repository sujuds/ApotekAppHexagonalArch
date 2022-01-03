using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Data.Responses;
using AppPersistence.Interface.Interfaces;
using AppPersistence.MySql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.MySql.Repositories
{
    public class ObatRepository : IObat
    {
        private readonly IMapper _mapper;
        //private readonly AppDbContext _context;

        public ObatRepository(IMapper mapper)
        {
            _mapper = mapper;
            //_context = context;
        }

        public async Task<RepositoryResponse> AddData(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                using var _context = new AppDbContext();

                var data = await _context.Obats.AsNoTracking().FirstOrDefaultAsync(o => o.Kode == param.Kode);
                if (data != null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = false,
                        Message = $"Kode obat '{param.Kode}' sudah ada !"
                    };
                }
                else
                {
                    await _context.Obats.AddAsync(_mapper.Map<Obat>(param));
                    var createdRowCount = await _context.SaveChangesAsync();

                    if (createdRowCount > 0)
                    {
                        response = new RepositoryResponse()
                        {
                            Status = true,
                            Message = "Tambah data berhasil !"
                        };
                    }
                    else
                    {
                        response = new RepositoryResponse()
                        {
                            Status = false,
                            Message = "Terjadi kesalahan !"
                        };
                    }
                }
            }

            return response;
        }

        public async Task<RepositoryResponse> Delete(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                using var _context = new AppDbContext();

                var data = await _context.Obats.AsNoTracking().FirstOrDefaultAsync(o => o.Kode == param.Kode);
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
                    _context.Obats.Remove(_mapper.Map<Obat>(param));

                    try
                    {
                        await _context.SaveChangesAsync();
                        response = new RepositoryResponse()
                        {
                            Status = true,
                            Message = "Hapus data berhasil !"
                        };
                    }
                    catch (Exception e)
                    {
                        response = new RepositoryResponse()
                        {
                            Status = false,
                            Message = $"Terjadi kesalahan ! { e.InnerException }"
                        };
                    }
                }
            }

            return response;
        }

        public async Task<RepositoryResponse> GetData()
        {
            using var _context = new AppDbContext();

            var obats = await _context.Obats.ToListAsync();

            var response = new RepositoryResponse()
            {
                Status = true,
                Data = _mapper.Map<IEnumerable<ObatDto>>(obats)
            };         

            return response;
        }

        public async Task<RepositoryResponse> GetData(int id)
        {
            using var _context = new AppDbContext();
            var obats = await _context.Obats.SingleOrDefaultAsync(o => o.Id == id);
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
                    Value = _mapper.Map<ObatDto>(obats)
                };
            }

            return response;
        }

        public async Task<RepositoryResponse> UpdateData(ParamObatDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                using var _context = new AppDbContext();
                var data = await _context.Obats.AsNoTracking().FirstOrDefaultAsync(o => o.Kode == param.Kode);
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
                    _context.Entry(_mapper.Map<Obat>(param)).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                        response = new RepositoryResponse()
                        {
                            Status = true,
                            Message = "Update data berhasil !"
                        };
                    }
                    catch (Exception)
                    {
                        response = new RepositoryResponse()
                        {
                            Status = false,
                            Message = "Terjadi kesalahan !"
                        };
                    }
                }
            }

            return response;
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

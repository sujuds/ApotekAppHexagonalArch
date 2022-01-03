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
    public class TransaksiRepository : ITransaksi
    {
        private readonly IMapper _mapper;

        public TransaksiRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<RepositoryResponse> AddData(ParamTransaksiDto param)
        {
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = Validasi(param)
            };

            if (response.Message == null)
            {
                using var _context = new AppDbContext();

                var data = await _context.Transaksis.AsNoTracking().FirstOrDefaultAsync(o => o.Kode == param.Kode);
                if (data != null)
                {
                    response = new RepositoryResponse()
                    {
                        Status = false,
                        Message = $"Kode transaksi '{param.Kode}' sudah ada !"
                    };
                }
                else
                {
                    int? total = 0;
                    foreach (var item in param.TransaksiDetails)
                    {
                        total += (item.Jumlah * item.Obat.Harga);
                        item.ObatId = item.Obat.Id;
                        item.Obat = null;
                    }

                    Transaksi tr = _mapper.Map<Transaksi>(param);
                    tr.Total = total;

                    await _context.Transaksis.AddAsync(tr);
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

        public Task<RepositoryResponse> Delete(ParamTransaksiDto param)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryResponse> GetData()
        {
            using var _context = new AppDbContext();

            var transaksi = await _context.Transaksis
                                .Include(t => t.TransaksiDetails)
                                    .ThenInclude(td => td.Obat)
                                .ToListAsync();

            var response = new RepositoryResponse()
            {
                Status = true,
                Data = _mapper.Map<IEnumerable<TransaksiDto>>(transaksi)
            };

            return response;
        }

        public async Task<RepositoryResponse> GetData(int id)
        {
            using var _context = new AppDbContext();
            var transaksi = await _context.Transaksis
                                .Include(t => t.TransaksiDetails)
                                    .ThenInclude(td => td.Obat)
                                .SingleOrDefaultAsync(o => o.Id == id);
            var response = new RepositoryResponse()
            {
                Status = false,
                Message = "Data transaksi tidak ditemukan !"
            };

            if (transaksi != null)
            {
                response = new RepositoryResponse()
                {
                    Status = true,
                    Value = _mapper.Map<TransaksiDto>(transaksi)
                };
            }

            return response;
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

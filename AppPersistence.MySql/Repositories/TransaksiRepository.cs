using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppBusiness.Data.Responses;
using AppPersistence.Interface.Interfaces;
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

        public Task<RepositoryResponse> AddData(ParamTransaksiDto param)
        {
            throw new NotImplementedException();
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

        public Task<RepositoryResponse> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse> UpdateData(ParamTransaksiDto param)
        {
            throw new NotImplementedException();
        }
    }
}

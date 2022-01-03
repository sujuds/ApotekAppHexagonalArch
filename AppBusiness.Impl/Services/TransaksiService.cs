using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using AppBusiness.Interface.Interfaces;
using AppPersistence.Interface;
using AppPersistence.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Impl.Services
{
    public class TransaksiService : ITransaksiService
    {
        private readonly ITransaksi _service;

        public TransaksiService(IPersistence persistence)
        {
            _service = persistence.Transaksi;
        }

        public async Task<RepositoryResponse> Add(ParamTransaksiDto param)
        {
            return await _service.AddData(param);
        }

        public async Task<RepositoryResponse> Delete(ParamTransaksiDto param)
        {
            return await _service.Delete(param);
        }

        public async Task<RepositoryResponse> Get()
        {
            return await _service.GetData();
        }

        public async Task<RepositoryResponse> Get(int id)
        {
            return await _service.GetData(id);
        }

        public async Task<RepositoryResponse> Update(ParamTransaksiDto param)
        {
            return await _service.UpdateData(param);
        }
    }
}

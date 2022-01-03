using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using AppBusiness.Interface.Interfaces;
using AppPersistence.Interface;
using AppPersistence.Interface.Interfaces;
using AppPersistence.MySql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Impl.Services
{
    public class ObatService : IObatService
    {
        private readonly IObat _service;

        public ObatService(IPersistence persistence)
        {
            _service = persistence.Obat;
        }

        public async Task<RepositoryResponse> Add(ParamObatDto param)
        {
            return await _service.AddData(param);
        }

        public async Task<RepositoryResponse> Delete(ParamObatDto param)
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

        public async Task<RepositoryResponse> Update(ParamObatDto param)
        {
            return await _service.UpdateData(param);
        }
    }
}

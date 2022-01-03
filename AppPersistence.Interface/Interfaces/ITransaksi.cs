using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Interface.Interfaces
{
    public interface ITransaksi
    {
        Task<RepositoryResponse> GetData();
        Task<RepositoryResponse> GetData(int id);
        Task<RepositoryResponse> AddData(ParamTransaksiDto param);
        Task<RepositoryResponse> UpdateData(ParamTransaksiDto param);
        Task<RepositoryResponse> Delete(ParamTransaksiDto param);
    }
}

using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Interface.Interfaces
{
    public interface ITransaksiService
    {
        Task<RepositoryResponse> Get();
        Task<RepositoryResponse> Get(int id);
        Task<RepositoryResponse> Add(ParamTransaksiDto param);
        Task<RepositoryResponse> Update(ParamTransaksiDto param);
        Task<RepositoryResponse> Delete(ParamTransaksiDto param);
    }
}

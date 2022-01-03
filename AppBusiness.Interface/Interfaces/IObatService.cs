using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBusiness.Interface.Interfaces
{
    public interface IObatService
    {
        Task<RepositoryResponse> Get();
        Task<RepositoryResponse> Get(int id);
        Task<RepositoryResponse> Add(ParamObatDto param);
        Task<RepositoryResponse> Update(ParamObatDto param);
        Task<RepositoryResponse> Delete(ParamObatDto param);
    }
}

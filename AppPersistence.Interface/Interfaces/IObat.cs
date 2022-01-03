using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Interface.Interfaces
{
    public interface IObat
    {
        Task<RepositoryResponse> GetData();
        Task<RepositoryResponse> GetData(int id);
        Task<RepositoryResponse> AddData(ParamObatDto param);
        Task<RepositoryResponse> UpdateData(ParamObatDto param);
        Task<RepositoryResponse> Delete(ParamObatDto param);
    }
}

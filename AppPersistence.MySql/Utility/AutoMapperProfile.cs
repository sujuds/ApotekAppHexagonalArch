using AppBusiness.Data.DTOs.Parameters;
using AppBusiness.Data.DTOs.Views;
using AppPersistence.MySql.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.MySql.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ParamObatDto, Obat>().ReverseMap();
            CreateMap<ParamTransaksiDto, Transaksi>().ReverseMap();
            CreateMap<ParamTransaksiDetailDto, TransaksiDetail>().ReverseMap();

            CreateMap<Obat, ObatDto>().ReverseMap();
            CreateMap<Transaksi, TransaksiDto>().ReverseMap();
            CreateMap<TransaksiDetail, TransaksiDetailDto>().ReverseMap();
        }
    }
}

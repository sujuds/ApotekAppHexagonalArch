using AppPersistence.Interface;
using AppPersistence.Interface.Interfaces;
using AppPersistence.MySql.Repositories;
using AppPersistence.MySql.Utility;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.MySql
{
    public class Persistence : IPersistence
    {
        public IObat Obat { get; protected set; }
        public ITransaksi Transaksi { get; protected set; }


        public Persistence()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Obat = new ObatRepository(new Mapper(configuration));
            Transaksi = new TransaksiRepository(new Mapper(configuration));
        }
    }
}

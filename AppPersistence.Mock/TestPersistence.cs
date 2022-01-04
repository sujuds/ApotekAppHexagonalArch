using AppPersistence.Interface;
using AppPersistence.Interface.Interfaces;
using AppPersistence.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.Mock
{
    public class TestPersistence : IPersistence
    {
        public IObat Obat => new TestObat();

        public ITransaksi Transaksi => new TestTransaksi();
    }
}

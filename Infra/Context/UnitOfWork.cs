using Business.Entities;
using Business.Interfaces;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public HttpClient Client { get; set; }

        public UnitOfWork()
        {
            Client = new HttpClient();
            Word = new Repository<Word>
            {
                UnitOfWork = this
            };
        }

        public IRepository<Word> Word { get; set; }
    }
}

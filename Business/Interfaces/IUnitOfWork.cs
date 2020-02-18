using Business.Entities;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Business.Interfaces
{
    public interface IUnitOfWork
    {
        HttpClient Client { get; set; }
        IRepository<Word> Word { get; set; }
    }
}
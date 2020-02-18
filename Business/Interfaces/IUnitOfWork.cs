using Business.Entities;
using System.Collections.Generic;
using System.IO;

namespace Business.Interfaces
{
    public interface IUnitOfWork
    {
        string[] FileStream { get; set; }
        IRepository<Word> Word { get; set; }
    }
}
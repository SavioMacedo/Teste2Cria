using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IUnitOfWork UnitOfWork { get; set; }
        IQueryable<string> GetAll();
        string Get(int index);
        string FirstOrDefault();
    }
}

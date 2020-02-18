using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IUnitOfWork UnitOfWork { get; set; }
        Task<string> GetAsync(int index);
    }
}

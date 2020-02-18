using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public string FirstOrDefault()
        {
            return GetAll().FirstOrDefault();
        }

        public string Get(int index)
        {
            return UnitOfWork.FileStream[index];
        }

        public IQueryable<string> GetAll()
        {
            return UnitOfWork.FileStream.AsQueryable();
        }
    }

}

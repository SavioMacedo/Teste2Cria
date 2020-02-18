using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public async Task<string> GetAsync(int index)
        {
            try
            {
                var response = await UnitOfWork.Client.GetAsync($"http://teste.criainovacao.com.br/api/Dicionario/{index}");

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                throw new Exception("Out of Index");
            }
            catch
            {
                throw;
            }
        }
    }

}

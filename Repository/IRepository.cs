using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity>
    {
        TEntity Insert(TEntity e);
        void Update(TEntity e);
        void Delete(TEntity e);
        List<TEntity> GetAll();
        TEntity GetById(Guid id); 
    }
}

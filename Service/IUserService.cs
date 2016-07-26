using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService<TEntity>
    {
        TEntity Insert(TEntity e);
        void Update(TEntity e);
        void Delete(TEntity e);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
    }
}

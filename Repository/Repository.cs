using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:EntityBase
    {
        protected DbContext ctx;
        protected IMongoCollection<TEntity> collection;

        public Repository(string collection,string database)
        {
            ctx =new DbContext(database);
            this.collection = ctx.db.GetCollection<TEntity>(collection);
        } 
        public void Delete(TEntity e)
        {
            if (collection.AsQueryable().Count(x => x.Id.Equals(e.Id)) > 0)
            {
                collection.DeleteOne(x => e.Id.Equals(x.Id));
            }
            else
            {
                throw new NotFoundEntityEx("Wrong request, ");
            }
        }

        public List<TEntity> GetAll()
        {
            if (collection.AsQueryable().Count(x => true) > 0)
            {
                return collection.Find(x => true).ToList();
            }
            else
            {
                throw new NotFoundEntityEx("Wrong request, ");
            }
        }

        public TEntity GetById(Guid id)
        {
            TEntity t;
            if (collection.AsQueryable().Count(x => x.Id.Equals(id)) > 0)
            {
                t = collection.Find(x => x.Id.Equals(id)).First();
            }
            else
            {
                throw new NotFoundEntityEx("Wrong request, ");
            }


            return t;
        }

        public TEntity Insert(TEntity e)
        {
            e.Id = Guid.NewGuid();
            collection.InsertOne(e);
            return e;
        }

        public void Update(TEntity e)
        {
            if (collection.AsQueryable().Count(x => x.Id.Equals(e.Id)) > 0)
            {
                collection.ReplaceOne(x => e.Id.Equals(x.Id), e);
            }
            else
            {
                throw new NotFoundEntityEx("Wrong request, ");
            }
        }
    }
}

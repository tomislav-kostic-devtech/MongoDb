using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository:Repository<User>
    {
        public UserRepository(string collection, string database):base(collection,database)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(string collection, string database) : base(collection, database)
        {
        }
    }
}

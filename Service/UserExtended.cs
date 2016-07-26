using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserExtended
    {
        public User user { get; set; }
        public List<UserAddress> address { get; set; }
    }
}

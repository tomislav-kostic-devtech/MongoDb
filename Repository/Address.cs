using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Address:EntityBase
    {
        public Guid UserId { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}

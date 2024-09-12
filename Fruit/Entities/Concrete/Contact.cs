using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact : BaseEntity
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Sosial { get; set; }
        public string Facebook { get; set; }
        public string Location { get; set; }
    }
}

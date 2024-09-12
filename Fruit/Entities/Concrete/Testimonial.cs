using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Testimonial: BaseEntity
    {
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}

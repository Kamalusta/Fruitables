using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserComment : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public int ProductId { get; set; }
    }
}

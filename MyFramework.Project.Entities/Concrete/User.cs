using MyFramework.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public List<Role> Roles { get; set; }
    }
}

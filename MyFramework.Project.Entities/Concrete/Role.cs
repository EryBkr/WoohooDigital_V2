using MyFramework.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

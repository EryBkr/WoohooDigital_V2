using MyFramework.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyFramework.Project.Entities.Concrete
{
    public class Haber:IEntity
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string Resim { get; set; }
        public int SiraNo { get; set; }
        public DateTime IslemZamani { get; set; }
        public bool Aktiflik { get; set; }
    }
}

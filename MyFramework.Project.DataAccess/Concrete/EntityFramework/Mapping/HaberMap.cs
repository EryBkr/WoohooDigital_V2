using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework.Mapping
{
    public class HaberMap:EntityTypeConfiguration<Haber>
    {
        public HaberMap()
        {
            ToTable(@"Habers", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Baslik).HasColumnName("Baslik");
            Property(x => x.Detay).HasColumnName("Detay");
            
        }
    }
}

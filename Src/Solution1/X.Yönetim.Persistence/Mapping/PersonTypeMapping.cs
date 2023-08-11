using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Persistence.Mapping
{
    public class PersonTypeMapping : AudiTableEntityMapping<PersonType>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<PersonType> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(40)")
                .HasColumnName("NAME")
                .HasColumnOrder(2);

            builder.ToTable("PERSONTYPE");
        }
    }
}

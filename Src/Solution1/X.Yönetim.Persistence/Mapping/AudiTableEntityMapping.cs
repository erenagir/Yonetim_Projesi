using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Persistence.Mapping
{
    public abstract class AudiTableEntityMapping<T> : IEntityTypeConfiguration<T> where T : AudiTableEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1);


            ConfigureDerivedEntityMapping( builder);
           
            builder.Property(x => x.CreateDate)
              .HasColumnName("CREATE_DATE")
              .HasColumnOrder(26);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CREATED_BY")
                .HasColumnType("nvarchar(10)")
                .IsRequired(false)
                .HasColumnOrder(27);

            builder.Property(x => x.ModifiedDate)
                .HasColumnName("MODIFIED_DATE")
                .HasColumnOrder(28);

            builder.Property(x => x.ModifiedBy)
                .HasColumnName("MODIFIED_BY")
                .HasColumnType("nvarchar(10)")
                .IsRequired(false)
                .HasColumnOrder(29);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0")
                .HasColumnOrder(30);
        }
    }
}

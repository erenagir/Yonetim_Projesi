using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Persistence.Mapping
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
             builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .HasColumnOrder(1);
           
            
            
            ConfigureDerivedEntityMapping(builder);
            
            
            builder.Property(x => x.IsDeleted)
               .HasColumnName("IS_DELETED")
               .HasDefaultValueSql("0")
               .HasColumnOrder(40);

        }
    }
}

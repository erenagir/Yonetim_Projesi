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
    public class OrderMapping : AudiTableEntityMapping<Order>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.PersonId)
                .HasColumnName("PERSON_ID")
                .HasColumnOrder(3);
           
            builder.Property(x => x.OrderDetail)
                .HasColumnName("ORDER_DETAIL")
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.OrderDate)
                .HasColumnName("ORDER_DATE")
                .HasDefaultValueSql("getdate()")
                .HasColumnOrder(5);

            builder.Property(x => x.OrderType)
                .HasColumnName("ORDER_TYPE")
                .HasColumnOrder(5);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName("ORDER_PERSON_PERSON_ID")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("ORDER");

        }
    }
}

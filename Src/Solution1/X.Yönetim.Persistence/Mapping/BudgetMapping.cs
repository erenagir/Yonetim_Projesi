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
    public class BudgetMapping : AudiTableEntityMapping<Budget>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Budget> builder)
        {
            builder.Property(x => x.UserId)
                 .HasColumnName("PERSONID")
                 .HasColumnOrder(2);
            
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("NAME")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AMOUNT")
                .HasColumnOrder(4)
                .IsRequired();
            
            builder.Property(x => x.StartDate)
                .HasColumnType("date")
                .HasColumnName("STARTDATE")
                .HasColumnOrder(5)
                .IsRequired();
            
            builder.Property(x => x.EndDate)
                .HasColumnType("date")
                .HasColumnName("ENDDATE")
                .HasColumnOrder (6)
                .IsRequired();

            builder.HasOne(x => x.User)
            .WithMany(x => x.Budgets)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("BUDGETS");
        }
    }
}

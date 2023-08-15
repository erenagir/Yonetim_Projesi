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
    public class GoalMapping : AudiTableEntityMapping<Goal>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Goal> builder)
        {
            builder.Property(x=>x.personId) 
                .HasColumnName("PERSONID")
                .HasColumnOrder(2)
                .IsRequired();
            
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(50)")
                .HasColumnName ("NAME")
                .HasColumnOrder (3)
                .IsRequired();

            builder.Property(x => x.TargetAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TARGET_AMOUNT")
                .HasColumnOrder(4)
                .IsRequired();
           
            builder.Property(x => x.TargetDate)
                .HasColumnType("date")
                .HasColumnName("TARGET_DATE")
                .HasColumnOrder(5)
                .IsRequired();
           
            builder.Property(x => x.Description)
                .HasColumnType ("nvarchar(100)")
                .HasColumnName("DESCRİPTİON")
                .HasColumnOrder(6)
                .IsRequired();
           
            builder.HasOne(x => x.Person)
                .WithMany(x => x.Goals)
                .HasForeignKey(x => x.personId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("GOALS");
        }
    }
}

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
    public class TransactionMapping : AudiTableEntityMapping<Transaction>
    {
        
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x=>x.PersonId)
              .HasColumnName("PERSONID")
              .HasColumnOrder(2)
              .IsRequired();
            
            builder.Property(x=>x.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AMOUNT")
                .HasColumnOrder(3)
                .IsRequired();
        
            builder.Property(x=>x.TransactionDate)
                .HasColumnType("date")
                .HasColumnName("TRANSACTİON_DATE")
                .HasColumnOrder(4)
                .IsRequired();
           
            builder.Property(x=>x.Type)
               .HasColumnName("TYPE")
               .HasColumnOrder(5)
               .IsRequired();
           
            builder.Property(x=>x.Description)
              .HasColumnType ("nvarchar100")
              .HasColumnName("DESCRİPTON")
              .HasColumnOrder(6)
              .IsRequired();
        
            builder.HasOne(x=>x.Person)
              .WithMany(x=>x.Transactions)
              .HasForeignKey(x=>x.PersonId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("TRANSACTİON");
        }
    }
}

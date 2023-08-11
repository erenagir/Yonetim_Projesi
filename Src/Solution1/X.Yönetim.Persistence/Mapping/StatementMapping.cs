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
    public class StatementMapping : BaseEntityMapping<Statement>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Statement> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("TITLE")
                .HasColumnType("nvarchar(30)")
                .HasColumnOrder(2);
            builder.Property(x => x.Detail)
               .IsRequired()
               .HasColumnName("DETAIL")
               .HasColumnType("nvarchar(max)")
               .HasColumnOrder(3);


            builder.HasOne(x => x.PersonType)
             .WithMany(x => x.Statements)
             .HasForeignKey(x => x.PersonTypeId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("STATEMENT_PERSONTYPE_PERSONTYPEID");
            builder.ToTable("STATEMENTS");
        }
    }
}

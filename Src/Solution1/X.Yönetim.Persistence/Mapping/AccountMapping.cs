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
    public class AccountMapping : AudiTableEntityMapping<Account>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.PersonID)
               .HasColumnName("PERSON_ID")
               .HasColumnOrder(2);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasColumnType("nvarchar(10)")
                .HasColumnName("USER_NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("PASSWORD")
                .HasColumnOrder(4);

            builder.Property(x => x.LastLoginDate)
                .HasColumnName("LAST_LOGIN_DATE")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(x => x.LastUserIp)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("LAST_LOGIN_IP")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder.Property(x => x.Role)
                .HasColumnName("ROLE_ID")
                .HasColumnOrder(7);

            builder.HasOne(x => x.Person)
                .WithOne(x=>x.Account)
                .HasForeignKey<Account>(x => x.PersonID);

            builder.ToTable("ACCOUNTS");
        }
    }
}

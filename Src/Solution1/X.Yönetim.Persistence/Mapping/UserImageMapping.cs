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
    public class UserImageMapping : BaseEntityMapping<UserImage>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<UserImage> builder)
        {
            builder.Property(x => x.UserId)
               .HasColumnName("PRODUCT_ID")
               .HasColumnOrder(2);

            builder.Property(x => x.Path)
                .HasColumnName("PATH")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(3);
            builder.HasOne(x => x.User)
               .WithMany(x => x.UserImage)
               .HasForeignKey(x => x.UserId)
               .HasConstraintName("USER_IMAGE_USER_USER_ID");

            builder.ToTable("USER_IMAGES");
        }
    }
}

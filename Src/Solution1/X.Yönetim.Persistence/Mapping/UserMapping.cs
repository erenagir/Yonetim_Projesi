﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Persistence.Mapping
{
    public class UserMapping : AudiTableEntityMapping<User>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<User> builder)
        {
            
           
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(30)")
                .IsRequired()
                .HasColumnOrder(3);
            builder.Property(x => x.SurName)
                .HasColumnName("SURNAME")
                .HasColumnType("nvarchar(30)")
                .IsRequired()
                .HasColumnOrder(4);
            builder.Property(x => x.IdentityNumber)
               .HasColumnName("IDENTITY_NUMBER")
               .HasColumnType("nchar(11)")
               .IsRequired()
               .HasColumnOrder(5);
            builder.Property(x => x.Birtdate)
               .HasColumnName("BIRTHDATE")
               .IsRequired()
               .HasColumnOrder(6);
            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(150)")
                .IsRequired()
                .HasColumnOrder(7);
            builder.Property(x => x.PhoneNumber)
              .HasColumnName("PHONE_NUMBER")
              .HasColumnType("nchar(13)")
              .IsRequired()
              .HasColumnOrder(8);
            builder.Property(x => x.Gender)
                .HasColumnName("GENDER")
                .IsRequired()
                .HasColumnOrder(9);

           
                




            builder.ToTable("USER");
        }
    }
}

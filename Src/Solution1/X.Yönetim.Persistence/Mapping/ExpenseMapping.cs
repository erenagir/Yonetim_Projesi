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
    public class ExpenseMapping : AudiTableEntityMapping<Expense>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Expense> builder)
        { 
            builder.Property(x=>x.UserId)
                .HasColumnName("PERSONID")
                .HasColumnOrder(2)
                .IsRequired();
            builder.Property(x => x.BudgetId)
                .HasColumnName("BUDGETID")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AMOUNT")
                .HasColumnOrder (4)
                .IsRequired();

            builder.Property(x => x.TransactionDate)
                .HasColumnType("date")
                .HasColumnName("TRANSACTİON_DATE")
                .HasColumnOrder (5)
                .IsRequired();

           

            builder.Property(x => x.Description)
                .HasColumnType ("nvarchar(100)")
                .HasColumnName("DESCRİPTİON")
                .HasColumnOrder(6)
                .IsRequired();

           

            builder.HasOne(x => x.User)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Budget)
               .WithMany(u => u.Expenses)
               .HasForeignKey(x => x.BudgetId)
               .OnDelete(DeleteBehavior.NoAction);



            builder.ToTable("EXPENSES");

        }
    }
}

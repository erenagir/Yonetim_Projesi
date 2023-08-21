using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.Services.Abstraction;
using X.Yönetim.Domain.Services.Implementation;
using X.Yönetim.Persistence.Mapping;

namespace X.Yönetim.Persistence.Context
{
    public class XContext : DbContext
    {
        private readonly ILoggedUserService _loggedUserService;

        public XContext(DbContextOptions<XContext> options, ILoggedUserService loggedUserService) : base(options)
        {
            _loggedUserService = loggedUserService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new BudgetMapping());
            modelBuilder.ApplyConfiguration(new ExpenseMapping());
            modelBuilder.ApplyConfiguration(new GoalMapping());
            modelBuilder.ApplyConfiguration(new IncomeMapping());
         
            modelBuilder.ApplyConfiguration(new UserImageMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

            //entity türleri için is deleted bilgisi false olanları otomatik filtreleme yapar
            modelBuilder.Entity<Account>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Budget>().HasQueryFilter(x =>x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Expense>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Goal>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Income>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
          
            modelBuilder.Entity<UserImage>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));

           


        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Herhangi bir kayıt işleminde yapılan işlem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.
            //Herhangi bir kayıt işleminde yapılan işlem güncelleme ise ModifiedDate ve ModifiedBy bilgileri otomatik olarak set edilir.
            var entries = ChangeTracker.Entries<BaseEntity>().ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
                if (entry.Entity is AudiTableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy = _loggedUserService.Username ?? "admin";
                            break;
                        //insert
                        case EntityState.Added:
                            auditableEntity.CreateDate = DateTime.Now;
                            auditableEntity.CreatedBy = _loggedUserService.Username ?? "admin";
                            break;
                        //delete
                        //case EntityState.Deleted:
                        //    auditableEntity.ModifiedDate = DateTime.Now;
                        //    auditableEntity.ModifiedBy =  "admin";
                        //    break;
                        default:
                            break;
                    }


                }                
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

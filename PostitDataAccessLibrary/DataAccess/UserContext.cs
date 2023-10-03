using Microsoft.EntityFrameworkCore;
using PostitDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PostitDataAccessLibrary.DataAccess
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("uuid").ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("char varying").HasColumnName("Fullname").HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("char varying").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("char varying").HasMaxLength(320).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Birthday).IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.CreatedOn).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UpdatedOn).IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.DeletedOn).IsRequired(false);

        }
        #endregion
    }
}

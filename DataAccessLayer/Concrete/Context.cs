using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Admin tablosu için şifre alanının hash'lenmesi
            modelBuilder.Entity<Admin>()
            .Property(a => a.AdminPasswordHash)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
            .HasColumnName("PasswordHash")
            .HasColumnType("string")
            .HasColumnOrder(4)
            .IsRequired();
        }

    }
}

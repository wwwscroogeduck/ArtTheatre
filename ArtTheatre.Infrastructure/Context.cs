using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ArtTheatre.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ClientEntity> client { get; set; }
        public virtual DbSet<ArtTheatre> artTheatre { get; set; }
        public virtual DbSet<RoleEntity> role { get; set; }
        public virtual DbSet<UserEntity> user { get; set; }
        public virtual DbSet<UslugiEntity> uslugi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.user)
                .WithRequired(e => e.role)
                .HasForeignKey(e => e.idrole)
                .WillCascadeOnDelete(false);

        }
    }
}

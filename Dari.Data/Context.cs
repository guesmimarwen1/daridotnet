//using Dari.Data.Configurations;
//using Dari.Data.Conventions;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Dari.Data.Configurations;

namespace Dari.Data
{
    public class Context : IdentityDbContext<Client, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public Context() : base("name=MaChaine")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        public static Context Create()
        {
            return new Context();
        }

        public virtual DbSet<Annonce> Annonces { get; set; }

        public virtual DbSet<Meuble> Meuble { get; set; }
        public virtual DbSet<Abonnement> Abonnements { get; set; }
        public virtual DbSet<TyAbo> TyAbos { get; set; }

        public virtual DbSet<RDV> RDV { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            // RDV Entity 
            modelBuilder.Entity<RDV>()
                .HasRequired<Annonce>(a => a.annonce)
                .WithMany(d => d.RDVS)
                .HasForeignKey(d => d.annonceID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Annonce>()
                .HasRequired<Client>(a => a.client)
                .WithMany(d => d.Annonces)
                .HasForeignKey(d => d.clientId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RDV>()
                .HasRequired<Client>(a => a.visiteur)
                .WithMany(d => d.RDVS)
                .HasForeignKey(d => d.visiteurID).WillCascadeOnDelete(false);
        }




        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {

             modelBuilder.Conventions.Add(new DateTime2());
             modelBuilder.Conventions.Add(new StringConvention());
             modelBuilder.Configurations.Add(new CategoryConfiguration());
             modelBuilder.Configurations.Add(new ProductConfiguration());
             modelBuilder.Configurations.Add(new FactureConfiguration());
         }*/
        public class ContexInit : DropCreateDatabaseIfModelChanges<Context>
        {
            protected override void Seed(Context context)
            {

            }
        }

    }


}

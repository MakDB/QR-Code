using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Goods_Receipt> tran_GR_Information { get; set; }
        public DbSet<Delivery_Receipt> tran_Delivery_Information { get; set; }

        public DbSet<Material_Master> material_master { get; set; }
        public DbSet<Material_Transaction> material_transaction { get; set; }

        public DbSet<Result_Material> result_Material { get; set; }

        public DbSet<Dashboard_Chart> dashboard_chart { get; set; }

        public DbSet<PushSubscription> push { get; set; }

        public DbSet<Return_PushSubscription> return_push { get; set; }


        public DbSet<Retailer_Status> retailer_Status { get; set; }

        public DbSet<EmailID> GetEmailId { get; set; }

        public DbSet<Middleware_Retailer> GetRetailer { get; set; }



        public DbSet<Status> UpdateFlagMaster { get; set; }
        public DbSet<Status> UpdateFlagTransaction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Goods_Receipt>().HasKey(gr => new { gr.belnr, gr.ebelp });
            modelBuilder.Entity<Delivery_Receipt>().HasKey(dr => new { dr.vbeln, dr.posnr });

            modelBuilder.Entity<Material_Master>().HasKey(dr => new { dr.GERNR, dr.MATNR, dr.LIFNR });

            modelBuilder.Entity<Material_Transaction>().HasKey(dr => new { dr.GERNR, dr.ESART, dr.EBELN, dr.DZETILE });

            modelBuilder.Entity<Dashboard_Chart>().HasNoKey();
        }
    }
}
 

using InvoiceFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace InvoiceFlow.Infrastructure
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set;  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<City>().HasData(
                new City { ID = 1, CityName = "القاهرة - مدينة نصر", IsDeleted = false },
                new City { ID = 2, CityName = "القاهرة - القاهرة الجديدة ", IsDeleted = false },
                new City { ID = 3, CityName = "القاهرة - الشروق ", IsDeleted = false },
                new City { ID = 4, CityName = "القاهرة - العبور ", IsDeleted = false },
                new City { ID = 5, CityName = "الاسكندرية - سموحة", IsDeleted = false }
            );



            modelBuilder.Entity<Branch>().HasData(
                          new Branch { ID = 1, BranchName = "فرع العبور", CityID = 4, IsDeleted = false },

          new Branch { ID = 2, BranchName = "فرع الحي السابع", CityID = 1, IsDeleted = false },
          new Branch { ID = 3, BranchName = "فرع عباس العقاد", CityID = 1, IsDeleted = false },
          new Branch { ID = 4, BranchName = "فرع التجمع الاول", CityID = 2, IsDeleted = false },
          new Branch { ID = 5, BranchName = "فرع سموحه", CityID = 5, IsDeleted = false },
          new Branch { ID = 6, BranchName = "فرع الشروق", CityID = 3, IsDeleted = false }
      );




            modelBuilder.Entity<Cashier>().HasData(
                new Cashier { ID = 1, CashierName = "محمد احمد", BranchID = 2, IsDeleted = false },
                new Cashier { ID = 2, CashierName = "محمود احمد ", BranchID = 3, IsDeleted = false },
                new Cashier { ID = 3, CashierName = "مصطفي عبد السميع", BranchID = 2, IsDeleted = false },
                new Cashier { ID = 4, CashierName = "احمد عبد الرحمن", BranchID = 6, IsDeleted = false },
                new Cashier { ID = 5, CashierName = "ساره عبد الله", BranchID = 4, IsDeleted = false },
                new Cashier { ID = 6, CashierName = "ساره محمد ", BranchID = 1, IsDeleted = false }
            );




            modelBuilder.Entity<InvoiceHeader>().HasData(
             new InvoiceHeader
             {
                 ID = 2,
                 CustomerName = "محمد عبد الله",
                 Invoicedate = DateTime.Parse("2022-02-22"),
                 CashierID = 1,
                 BranchID = 2,
                 TotalPrice = 150,
                 IsDeleted = false
             },
             new InvoiceHeader
             {
                 ID = 3,
                 CustomerName = "محمود احمد",
                 Invoicedate = DateTime.Parse("2022-02-23"),
                 CashierID = 2,
                 BranchID = 3,
                 TotalPrice =  5,
                 IsDeleted = false
             }
         );



            modelBuilder.Entity<Item>().HasData(
         new Item { ID = 1, Name = "بيبسي 1 لتر", Price = 20 },
         new Item { ID = 2, Name = "ساندوتش برجر", Price = 50 },
         new Item { ID = 3, Name = "ايس كريم", Price = 10 },
         new Item { ID = 4, Name = "سفن اب كانز", Price = 5 }
     );

            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail { ID = 2, InvoiceHeaderID = 2, ItemID = 1, ItemCount = 2, IsDeleted = false },
                new InvoiceDetail { ID = 3, InvoiceHeaderID = 2, ItemID = 2, ItemCount = 2, IsDeleted = false },
                new InvoiceDetail { ID = 4, InvoiceHeaderID = 2, ItemID = 3, ItemCount = 1, IsDeleted = false },
                new InvoiceDetail { ID = 6, InvoiceHeaderID = 3, ItemID = 4, ItemCount = 1, IsDeleted = false }
            );





        }
    } }


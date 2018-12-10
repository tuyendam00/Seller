namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlanketShopDbContext : DbContext
    {
        public BlanketShopDbContext()
            : base("name=BlanketShopDbContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Contries> Contries { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Slides> Slides { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.Category_id);

            modelBuilder.Entity<Comments>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Contries>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Contries)
                .HasForeignKey(e => e.Contry_id);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slides>()
                .Property(e => e.CreatedDate)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);
        }
    }
}

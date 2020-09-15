using Microsoft.EntityFrameworkCore;
using NoWind.Core.Models;

namespace NoWind.Data.Configurations
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlphabeticalListOfProducts> AlphabeticalListOfProducts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; }
        public virtual DbSet<CurrentProductList> CurrentProductList { get; set; }
        public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCity { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailsExtended> OrderDetailsExtended { get; set; }
        public virtual DbSet<OrderSubtotals> OrderSubtotals { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersQry> OrdersQry { get; set; }
        public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrice { get; set; }
        public virtual DbSet<ProductsByCategory> ProductsByCategory { get; set; }
        public virtual DbSet<QuarterlyOrders> QuarterlyOrders { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SalesByCategory> SalesByCategory { get; set; }
        public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmount { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarter { get; set; }
        public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYear { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<TerritoriesConfigurations> Territories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlphabeticalListOfProductsConfigurations());

            modelBuilder.ApplyConfiguration(new CategoriesConfigurations());

            modelBuilder.ApplyConfiguration(new CategorySalesFor1997Configurations());

            modelBuilder.ApplyConfiguration(new CurrentProductListConfigurations());

            modelBuilder.ApplyConfiguration(new CustomerAndSuppliersByCityConfigurations());

            modelBuilder.ApplyConfiguration(new CustomerCustomerDemoConfigurations());

            modelBuilder.ApplyConfiguration(new CustomerDemographicsConfigurations());

            modelBuilder.ApplyConfiguration(new CustomersConfigurations());

            modelBuilder.ApplyConfiguration(new EmployeeTerritoriesConfigurations());

            modelBuilder.ApplyConfiguration(new EmployeesConfigurations());

            modelBuilder.ApplyConfiguration(new InvoicesConfigurations());

            modelBuilder.ApplyConfiguration(new OrderDetailsConfigurations());

            modelBuilder.ApplyConfiguration(new OrderDetailsExtendedConfigurations());

            modelBuilder.ApplyConfiguration(new OrderSubtotalsConfigurations());

            modelBuilder.ApplyConfiguration(new OrdersConfigurations());

            modelBuilder.ApplyConfiguration(new OrdersQryConfigurations());

            modelBuilder.ApplyConfiguration(new ProductSalesFor1997Configurations());

            modelBuilder.ApplyConfiguration(new ProductsConfigurations());

            modelBuilder.ApplyConfiguration(new ProductsAboveAveragePriceConfigurations());

            modelBuilder.ApplyConfiguration(new ProductsByCategoryConfigurations());

            modelBuilder.ApplyConfiguration(new QuarterlyOrdersConfigurations());

            modelBuilder.ApplyConfiguration(new RegionConfigurations());

            modelBuilder.ApplyConfiguration(new SalesByCategoryConfigurations());

            modelBuilder.ApplyConfiguration(new SalesTotalsByAmountConfigurations());

            modelBuilder.ApplyConfiguration(new ShippersConfigurations());

            modelBuilder.ApplyConfiguration(new SummaryOfSalesByQuarterConfigurations());

            modelBuilder.ApplyConfiguration(new SummaryOfSalesByYearConfigurations());

            modelBuilder.ApplyConfiguration(new SuppliersConfigurations());

            modelBuilder.ApplyConfiguration(new TerritoriesConfigurations());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

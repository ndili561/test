using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
using Incommunities.Logistics.Audit;
using Incommunities.Logistics.Common.Conventions;
using Incommunities.Logistics.Common.Domain;
using log4net;
using log4net.Config;
using Configuration = Incommunities.Logistics.Data.Migrations.Configuration;

namespace Incommunities.Logistics.Data
{
    public class LogisticsDbContext : TrackerContext
    {
        // TODO: Auditing entities
        private static ILog logger;

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroups { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<PickCart> PickCarts { get; set; }
        public DbSet<PickNote> PickNotes { get; set; }
        public DbSet<PickNoteItem> PickNoteItems { get; set; }
        public DbSet<PickNoteItemQuantityDetail> PickNoteItemQuantityDetails { get; set; }
        public DbSet<DispatchNote> DispatchNotes { get; set; }
        public DbSet<DispatchNoteItem> DispatchNoteItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductAlternativeProduct> ProductAlternativeProducts { get; set; }
        public DbSet<ProductAssociatedProduct> ProductAssociatedProducts { get; set; }
        public DbSet<ProductKeyword> ProductKeywords { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierContract> SupplierContracts { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<UnitOfIssue> UnitsOfIssue { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<Stock> ProductStock { get; set; }
        public DbSet<WarehouseStock> WarehouseStock { get; set; }
        public DbSet<WarehouseLocation> StockLocations { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<StocktakeTask> StocktakeTasks { get; set; }
        public DbSet<StocktakeTaskItem> StocktakeTaskItems { get; set; }
        public DbSet<StockCart> StockCarts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<CreditNote> CreditNotes { get; set; }
        public DbSet<CreditNoteItem> CreditNoteItems { get; set; }
        public DbSet<PaymentRun> PaymentRuns { get; set; }

        public DbSet<RequisitionRequest> RequisitionRequests { get; set; }
        public DbSet<RequisitionRequestItem> RequisitionRequestItems { get; set; }
        public DbSet<RequisitionRequestItemReturn> RequisitionRequestItemsReturn { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<PurchaseOrderItemDetail> PurchaseOrderItemDetails { get; set; }

        public DbSet<VatRate> VatRate { get; set; }
        public DbSet<DeliveryTime> DeliveryTime { get; set; }
        public DbSet<OASupplierDetails> OASupplierDetails { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<PdfFile> PdfFile { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<StandardJob> StandardJob { get; set; }
        public DbSet<VanLocation> VanLocation { get; set; }
        public DbSet<DeliveryVan> DeliveryVanTrack { get; set; }
        public DbSet<VanStockUsedInRepair> VanStockUsedInRepair { get; set; }
        public DbSet<VanStockReplenishment> VanStockReplenishment { get; set; }
        public DbSet<DeliveryVanOperator> DeliveryVanOperator { get; set; }

        public DbSet<PermanentJobData> PermanentJobData { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<StockTransaction> StockTransaction { get; set; }

        public DbSet<LogisticsSetting> LogisticsSetting { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            XmlConfigurator.Configure();
            logger = LogManager.GetLogger("Application");
            logger.Info("OnModelCreating start");

            var env = ConfigurationManager.AppSettings.Get("Environment");

            logger.InfoFormat(" > Environment:{0}", env);

            switch (env)
            {
                case "Debug":
                    break;
                case "Dev":
                    System.Data.Entity.Database.SetInitializer(
                        new MigrateDatabaseToLatestVersion<LogisticsDbContext, Configuration>());
                    break;
                case "Test":
                    System.Data.Entity.Database.SetInitializer(
                        new MigrateDatabaseToLatestVersion<LogisticsDbContext, Configuration>());
                    //new TestDbInitializer());
                    break;
                case "Live":
                    break;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Apply convention to format decimal,date etc datatypes. Decimal data type has default value of precision 18 and scale 2
            //which is not configurable whilst defining domain objects.
            modelBuilder.ApplyConfigurationAttributes(typeof (ProductGroup).Assembly);

            modelBuilder.Entity<RequisitionRequestItem>()
                .HasRequired(t => t.RequisitionRequest)
                .WithMany(t => t.RequisitionRequestItems)
                .HasForeignKey(d => d.RequisitionRequestId)
                .WillCascadeOnDelete(true);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = new StringBuilder();
                exceptionMessage.Append(string.Concat(ex.Message, " The validation errors are: ", Environment.NewLine));

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        exceptionMessage.Append(string.Format("Class: {0}, Property: {1}, Error: {2}{3}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage,
                            Environment.NewLine));
                    }
                }
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage.ToString(), ex.EntityValidationErrors);
            }
        }

        #region Audit

        //public DbSet<CategoryAudit> CategoryAudits { get; set; }
        //public DbSet<CategoryTypeAudit> CategoryTypeAudits { get; set; }
        //public DbSet<ProductAudit> ProductAudits { get; set; }
        //public DbSet<ProductAlternativeProductAudit> ProductAlternativeProductAudits { get; set; }
        //public DbSet<ProductAssociatedProductAudit> ProductAssociatedProductAudits { get; set; }

        #endregion Audit

        #region context overloads

        static LogisticsDbContext()
        {
            System.Data.Entity.Database.SetInitializer<LogisticsDbContext>(null);
        }

        public LogisticsDbContext()
            : base("Name=LogisticsDBContext")
        {
        }


        public LogisticsDbContext(string connectionString)
            : base(connectionString)
        {
        }

        #endregion
    }

    //public class CreateDatabaseInitializer : CreateDatabaseIfNotExists<LogisticsDbContext>
    //{
    //    private static ILog logger;

    //    protected override void Seed(LogisticsDbContext context)
    //    {
    //        log4net.Config.XmlConfigurator.Configure();
    //        logger = log4net.LogManager.GetLogger("Application");
    //        logger.Info("Creating new DB");
    //        new DbSeed().Seed(context);
    //        base.Seed(context);
    //    }
    //}
}
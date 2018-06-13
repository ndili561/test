using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Incommunities.Core.Data.Repository;
using Incommunities.Logistics.Audit.Models;
using Incommunities.Logistics.Common.Domain;
using Incommunities.Logistics.Common.DTO;
using OASupplierDetails = Incommunities.Logistics.Common.Domain.OASupplierDetails;
using Repair = Incommunities.Logistics.Common.Domain.Repair;

namespace Incommunities.Logistics.Data
{
    /// <summary>
    ///     Groups the individual repositories into a single object that represents a database with a single save method.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LogisticsDbContext _context;

        private bool _disposed;

        public void Refresh(object entityObject, RefreshMode refreshMode = RefreshMode.ClientWins)
        {
            var objectContext = (_context as IObjectContextAdapter).ObjectContext;
            objectContext.Refresh(refreshMode, entityObject);
        }

        public IRepository<Invoice> Invoice()
        {
            return _invoiceRepository ?? (_invoiceRepository = new Repository<Invoice>(_context));
        }

        public IRepository<InvoiceItem> InvoiceItem()
        {
            return _invoiceItemRepository ?? (_invoiceItemRepository = new Repository<InvoiceItem>(_context));
        }

        public IRepository<CreditNote> CreditNote()
        {
            return _creditNoteRepository ?? (_creditNoteRepository = new Repository<CreditNote>(_context));
        }

        public IRepository<CreditNoteItem> CreditNoteItem()
        {
            return _creditNoteItemRepository ?? (_creditNoteItemRepository = new Repository<CreditNoteItem>(_context));
        }

        public IRepository<PaymentRun> PaymentRun()
        {
            return _paymentRunRepository ?? (_paymentRunRepository = new Repository<PaymentRun>(_context));
        }

        public IRepository<PickCart> PickCart()
        {
            return _pickCartRepository ?? (_pickCartRepository = new Repository<PickCart>(_context));
        }

        public IRepository<PickNote> PickNote()
        {
            return _pickNoteRepository ?? (_pickNoteRepository = new Repository<PickNote>(_context));
        }

        public IRepository<PickNoteItem> PickNoteItem()
        {
            return _pickNoteItemRepository ?? (_pickNoteItemRepository = new Repository<PickNoteItem>(_context));
        }

        public IRepository<DispatchNote> DispatchNote()
        {
            return _dispatchNoteRepository ?? (_dispatchNoteRepository = new Repository<DispatchNote>(_context));
        }

        public IRepository<DispatchNoteItem> DispatchNoteItem()
        {
            return _dispatchNoteItemRepository ??
                   (_dispatchNoteItemRepository = new Repository<DispatchNoteItem>(_context));
        }


        public IRepository<SearchRepair> SearchRepairs()
        {
            return _searchrepair ?? (_searchrepair = new Repository<SearchRepair>(_context));
        }

        public IRepository<Repair> Repairs()
        {
            return _repairs ?? (_repairs = new Repository<Repair>(_context));
        }

        public IRepository<Asbestos> SearchAsbestos()
        {
            return _asbestos ?? (_asbestos = new Repository<Asbestos>(_context));
        }

        public IRepository<RedFlag> SearchRedFlag()
        {
            return _redflag ?? (_redflag = new Repository<RedFlag>(_context));
        }

        public IRepository<DeliveryTime> DeliveryTime()
        {
            return _deliveryTime ?? (_deliveryTime = new Repository<DeliveryTime>(_context));
        }

        public IRepository<Operative> Operative()
        {
            return _operative ?? (_operative = new Repository<Operative>(_context));
        }

        public IRepository<RequisitionRequest> RequisitionRequest()
        {
            return _requisitionRequest ?? (_requisitionRequest = new Repository<RequisitionRequest>(_context));
        }

        public IRepository<RequisitionRequestItem> RequisitionRequestItems()
        {
            return _requisitionRequestItem ??
                   (_requisitionRequestItem = new Repository<RequisitionRequestItem>(_context));
        }

        public IRepository<RequisitionRequestItemReturn> RequisitionRequestItemReturns()
        {
            return _requisitionRequestItemReturn ??
                   (_requisitionRequestItemReturn = new Repository<RequisitionRequestItemReturn>(_context));
        }

        public IRepository<RequisitionRequest_Repair> RequisitionRequest_Repairs()
        {
            return _requisitionRequest_Repair ??
                   (_requisitionRequest_Repair = new Repository<RequisitionRequest_Repair>(_context));
        }

        public IRepository<Address> Address()
        {
            return _addressRepository ?? (_addressRepository = new Repository<Address>(_context));
        }

        public IRepository<ProductType> ProductType()
        {
            return _productTypeRepository ?? (_productTypeRepository = new Repository<ProductType>(_context));
        }

        public IRepository<ProductSubGroup> ProductSubGroup()
        {
            return _productSubGroupRepository ??
                   (_productSubGroupRepository = new Repository<ProductSubGroup>(_context));
        }

        public IRepository<ProductGroup> ProductGroup()
        {
            return _productGroupRepository ?? (_productGroupRepository = new Repository<ProductGroup>(_context));
        }

        public IRepository<Contact> Contact()
        {
            return _contactRepository ?? (_contactRepository = new Repository<Contact>(_context));
        }

        public IRepository<Manufacturer> Manufacturer()
        {
            return _manufacturerRepository ?? (_manufacturerRepository = new Repository<Manufacturer>(_context));
        }


        public IRepository<Product> Product()
        {
            return _productRepository ?? (_productRepository = new Repository<Product>(_context));
        }

        public IRepository<ProductAlternativeProduct> ProductAlternativeProduct()
        {
            return _productAlternativeProductRepository ??
                   (_productAlternativeProductRepository = new Repository<ProductAlternativeProduct>(_context));
        }

        public IRepository<ProductAssociatedProduct> ProductAssociatedProduct()
        {
            return _productAssociatedProductRepository ??
                   (_productAssociatedProductRepository = new Repository<ProductAssociatedProduct>(_context));
        }

        public IRepository<ProductImage> ProductImage()
        {
            return _productImageRepository ?? (_productImageRepository = new Repository<ProductImage>(_context));
        }

        public IRepository<ProductKeyword> ProductKeyword()
        {
            return _productKeywordRepository ??
                   (_productKeywordRepository = new Repository<ProductKeyword>(_context));
        }

        public IRepository<Supplier> Supplier()
        {
            return _supplierRepository ??
                   (_supplierRepository = new Repository<Supplier>(_context));
        }

        public IRepository<SupplierContract> SupplierContract()
        {
            return _supplierContractRepository ??
                   (_supplierContractRepository = new Repository<SupplierContract>(_context));
        }

        public IRepository<SupplierProduct> SupplierProduct()
        {
            return _supplierProductRepository ??
                   (_supplierProductRepository = new Repository<SupplierProduct>(_context));
        }

        public IRepository<SupplierType> SupplierType()
        {
            return _supplierTypeRepository ??
                   (_supplierTypeRepository = new Repository<SupplierType>(_context));
        }

        public IRepository<UnitOfIssue> UnitOfIssue()
        {
            return _unitOfIssueRepository ??
                   (_unitOfIssueRepository = new Repository<UnitOfIssue>(_context));
        }

        public IRepository<VatRate> VatRate()
        {
            return _vatRateRepository ??
                   (_vatRateRepository = new Repository<VatRate>(_context));
        }

        public IRepository<WarehouseType> WarehouseType()
        {
            return _warehouseTypeRepository ??
                   (_warehouseTypeRepository = new Repository<WarehouseType>(_context));
        }

        public IRepository<Warehouse> Warehouse()
        {
            return _warehouseRepository ??
                   (_warehouseRepository = new Repository<Warehouse>(_context));
        }

        public IRepository<WarehouseStock> WarehouseStock()
        {
            return _warehouseStockRepository ??
                   (_warehouseStockRepository = new Repository<WarehouseStock>(_context));
        }


        public IRepository<Van> Van()
        {
            return _vanRepository ??
                   (_vanRepository = new Repository<Van>(_context));
        }

        public IRepository<Stock> Stock()
        {
            return _stockRepository ??
                   (_stockRepository = new Repository<Stock>(_context));
        }

        public IRepository<WarehouseLocation> WarehouseLocation()
        {
            return _warehouseLocationRepository ??
                   (_warehouseLocationRepository = new Repository<WarehouseLocation>(_context));
        }

        public IRepository<WarehouseStockLocation> WarehouseStockLocation()
        {
            return _warehouseStockLocationRepository ??
                   (_warehouseStockLocationRepository = new Repository<WarehouseStockLocation>(_context));
        }

        public IRepository<WarehouseProduct> WarehouseProduct()
        {
            return _warehouseProductRepository ??
                   (_warehouseProductRepository = new Repository<WarehouseProduct>(_context));
        }

        public IRepository<Task> Task()
        {
            return _taskRepository ??
                   (_taskRepository = new Repository<Task>(_context));
        }

        public IRepository<StocktakeTask> StocktakeTask()
        {
            return _stocktakeTaskRepository ??
                   (_stocktakeTaskRepository = new Repository<StocktakeTask>(_context));
        }

        //public IRepository<StocktakeTask> WarehouseStocktakeTask()
        //{
        //    return _warehouseStocktakeTaskRepository ??
        //           (_warehouseStocktakeTaskRepository = new Repository<StocktakeTask>(_context));
        //}

        public IRepository<StocktakeTaskItem> StocktakeTaskItem()
        {
            return _stocktakeTaskItemRepository ??
                   (_stocktakeTaskItemRepository = new Repository<StocktakeTaskItem>(_context));
        }

        //public IRepository<VanStocktakeTask> VanStocktakeTask()
        //{
        //    return _vanStocktakeTaskRepository ??
        //           (_vanStocktakeTaskRepository = new Repository<VanStocktakeTask>(_context));
        //}

        //public IRepository<VanStocktakeTaskItem> VanStocktakeTaskItem()
        //{
        //    return _vanStocktakeTaskItemRepository ??
        //           (_vanStocktakeTaskItemRepository = new Repository<VanStocktakeTaskItem>(_context));
        //}

        public IRepository<StockCart> StockCart()
        {
            return _cartRepository ??
                   (_cartRepository = new Repository<StockCart>(_context));
        }

        public IRepository<PurchaseOrder> PurchaseOrder()
        {
            return _purchaseOrder ??
                   (_purchaseOrder = new Repository<PurchaseOrder>(_context));
        }

        public IRepository<PurchaseOrderItem> PurchaseOrderItem()
        {
            return _purchaseOrderItem ??
                   (_purchaseOrderItem = new Repository<PurchaseOrderItem>(_context));
        }

        public IRepository<PurchaseOrderItemDetail> PurchaseOrderItemDetail()
        {
            return _purchaseOrderItemDetail ??
                   (_purchaseOrderItemDetail = new Repository<PurchaseOrderItemDetail>(_context));
        }

        public IRepository<AuditLog> AuditLog()
        {
            return _auditLogReposiory ??
                   (_auditLogReposiory = new Repository<AuditLog>(_context));
        }

        public IRepository<RequisitionRequestTemplate> RequisitionRequestTemplate()
        {
            return _requisitionRequestTemplate ??
                   (_requisitionRequestTemplate = new Repository<RequisitionRequestTemplate>(_context));
        }

        public IRepository<StandardJob> StandardJob()
        {
            return _standardJob ??
                   (_standardJob = new Repository<StandardJob>(_context));
        }

        public IRepository<VanLocation> VanLocation()
        {
            return _vanLocation ??
                   (_vanLocation = new Repository<VanLocation>(_context));
        }

        public IRepository<Comment> Comments()
        {
            return _comment ??
                   (_comment = new Repository<Comment>(_context));
        }

        public IRepository<VanStockUsedInRepair> VanStockUsedInRepair()
        {
            return _vanStockUsedInRepair ??
                   (_vanStockUsedInRepair = new Repository<VanStockUsedInRepair>(_context));
        }

        public IRepository<VanStockReplenishment> VanStockReplenishment()
        {
            return _vanStockReplenishment ??
                   (_vanStockReplenishment = new Repository<VanStockReplenishment>(_context));
        }

        public IRepository<DeliveryVanOperator> DeliveryVanOperator()
        {
            return _deliveryVanOperator ??
                   (_deliveryVanOperator = new Repository<DeliveryVanOperator>(_context));
        }

        public IRepository<DeliveryVan> DeliveryVan()
        {
            return _deliveryVan ??
                   (_deliveryVan = new Repository<DeliveryVan>(_context));
        }

        public IRepository<StockTransaction> StockTransaction()
        {
            return _stockTransaction ??
                   (_stockTransaction = new Repository<StockTransaction>(_context));
        }

        public IRepository<PermanentJobData> PermanentJobData()
        {
            return _permanentJobData ??
                   (_permanentJobData = new Repository<PermanentJobData>(_context));
        }

        public IRepository<User> User()
        {
            return _user ??
                   (_user = new Repository<User>(_context));
        }

        public IRepository<LogisticsSetting> LogisticsSetting()
        {
            return _logisticsSetting ??
                   (_logisticsSetting = new Repository<LogisticsSetting>(_context));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CommitWithAudit(string userId, string userIPAddress)
        {
            _context.SaveChanges(userId, userIPAddress);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<OASupplierDetails> SearchOASupplier()
        {
            return _searchOASupplier ?? (_searchOASupplier = new Repository<OASupplierDetails>(_context));
        }

        public IRepository<StocktakeTaskItem> WarehouseStocktakeTaskItem()
        {
            return _stocktakeTaskItemRepository ??
                   (_stocktakeTaskItemRepository = new Repository<StocktakeTaskItem>(_context));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        #region private fields

        private IRepository<Address> _addressRepository;
        private IRepository<ProductSubGroup> _productSubGroupRepository;
        private IRepository<ProductGroup> _productGroupRepository;
        private IRepository<Contact> _contactRepository;
        private IRepository<Manufacturer> _manufacturerRepository;
        private IRepository<PickCart> _pickCartRepository;
        private IRepository<PickNote> _pickNoteRepository;
        private IRepository<PickNoteItem> _pickNoteItemRepository;
        private IRepository<DispatchNote> _dispatchNoteRepository;
        private IRepository<DispatchNoteItem> _dispatchNoteItemRepository;
        private IRepository<Product> _productRepository;
        private IRepository<ProductAlternativeProduct> _productAlternativeProductRepository;
        private IRepository<ProductAssociatedProduct> _productAssociatedProductRepository;
        private IRepository<ProductImage> _productImageRepository;
        private IRepository<ProductKeyword> _productKeywordRepository;
        private IRepository<ProductType> _productTypeRepository;
        private IRepository<Supplier> _supplierRepository;
        private IRepository<SupplierContract> _supplierContractRepository;
        private IRepository<SupplierProduct> _supplierProductRepository;
        private IRepository<SupplierType> _supplierTypeRepository;
        private IRepository<UnitOfIssue> _unitOfIssueRepository;
        private IRepository<VatRate> _vatRateRepository;
        private IRepository<WarehouseType> _warehouseTypeRepository;
        private IRepository<Warehouse> _warehouseRepository;
        private IRepository<Van> _vanRepository;
        private IRepository<WarehouseStock> _warehouseStockRepository;
        private IRepository<Stock> _stockRepository;
        private IRepository<WarehouseLocation> _warehouseLocationRepository;
        private IRepository<WarehouseStockLocation> _warehouseStockLocationRepository;
        private IRepository<WarehouseProduct> _warehouseProductRepository;
        private IRepository<Task> _taskRepository;
        private IRepository<StocktakeTask> _stocktakeTaskRepository;
        private IRepository<StocktakeTaskItem> _stocktakeTaskItemRepository;
        //private IRepository<StocktakeTask> _warehouseStocktakeTaskRepository;
        //private IRepository<StocktakeTaskItem> _warehouseStocktakeTaskItemRepository;
        //private IRepository<VanStocktakeTask> _vanStocktakeTaskRepository;
        //private IRepository<VanStocktakeTaskItem> _vanStocktakeTaskItemRepository;
        private IRepository<StockCart> _cartRepository;
        private IRepository<Invoice> _invoiceRepository;
        private IRepository<InvoiceItem> _invoiceItemRepository;
        private IRepository<CreditNote> _creditNoteRepository;
        private IRepository<CreditNoteItem> _creditNoteItemRepository;
        private IRepository<PaymentRun> _paymentRunRepository;

        private IRepository<SearchRepair> _searchrepair;
        private IRepository<Operative> _operative;
        private IRepository<RequisitionRequest> _requisitionRequest;
        private IRepository<RequisitionRequestItem> _requisitionRequestItem;
        private IRepository<RequisitionRequestItemReturn> _requisitionRequestItemReturn;
        private IRepository<RequisitionRequest_Repair> _requisitionRequest_Repair;

        private IRepository<PurchaseOrder> _purchaseOrder;
        private IRepository<PurchaseOrderItem> _purchaseOrderItem;
        private IRepository<PurchaseOrderItemDetail> _purchaseOrderItemDetail;
        private IRepository<Asbestos> _asbestos;
        private IRepository<RedFlag> _redflag;
        private IRepository<OASupplierDetails> _searchOASupplier;
        private IRepository<DeliveryTime> _deliveryTime;
        private IRepository<Repair> _repairs;
        private IRepository<AuditLog> _auditLogReposiory;
        private IRepository<RequisitionRequestTemplate> _requisitionRequestTemplate;
        private IRepository<StandardJob> _standardJob;
        private IRepository<VanLocation> _vanLocation;
        private IRepository<Comment> _comment;
        private IRepository<VanStockUsedInRepair> _vanStockUsedInRepair;
        private IRepository<VanStockReplenishment> _vanStockReplenishment;
        private IRepository<DeliveryVanOperator> _deliveryVanOperator;
        private IRepository<DeliveryVan> _deliveryVan;
        private IRepository<StockTransaction> _stockTransaction;
        private IRepository<PermanentJobData> _permanentJobData;
        private IRepository<User> _user;
        private IRepository<LogisticsSetting> _logisticsSetting;

        #endregion private fields

        #region ctor

        public UnitOfWork()
            : this(new LogisticsDbContext())
        {
        }

        public UnitOfWork(LogisticsDbContext dbContext)
        {
            _context = dbContext;
        }

        #endregion
    }
}
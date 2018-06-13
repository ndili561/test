using System;
using System.Data.Entity.Core.Objects;
using Incommunities.Core.Data.Repository;
using Incommunities.Logistics.Audit.Models;
using Incommunities.Logistics.Common.Domain;
using Incommunities.Logistics.Common.DTO;
using OASupplierDetails = Incommunities.Logistics.Common.Domain.OASupplierDetails;
using Repair = Incommunities.Logistics.Common.Domain.Repair;

namespace Incommunities.Logistics.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Refresh(object entityObject, RefreshMode refreshMode = RefreshMode.ClientWins);

        IRepository<Address> Address();
        IRepository<ProductSubGroup> ProductSubGroup();
        IRepository<ProductGroup> ProductGroup();
        IRepository<ProductType> ProductType();
        IRepository<Contact> Contact();
        IRepository<Manufacturer> Manufacturer();
        IRepository<PickCart> PickCart();
        IRepository<PickNote> PickNote();
        IRepository<PickNoteItem> PickNoteItem();
        IRepository<DispatchNote> DispatchNote();
        IRepository<DispatchNoteItem> DispatchNoteItem();
        IRepository<Product> Product();
        IRepository<ProductAlternativeProduct> ProductAlternativeProduct();
        IRepository<ProductAssociatedProduct> ProductAssociatedProduct();
        IRepository<ProductImage> ProductImage();
        IRepository<ProductKeyword> ProductKeyword();
        IRepository<Supplier> Supplier();
        IRepository<SupplierProduct> SupplierProduct();
        IRepository<SupplierContract> SupplierContract();
        IRepository<SupplierType> SupplierType();
        IRepository<UnitOfIssue> UnitOfIssue();
        IRepository<VatRate> VatRate();
        IRepository<WarehouseType> WarehouseType();
        IRepository<Warehouse> Warehouse();
        IRepository<Van> Van();
        IRepository<WarehouseStock> WarehouseStock();
        IRepository<Stock> Stock();
        IRepository<WarehouseLocation> WarehouseLocation();
        IRepository<WarehouseStockLocation> WarehouseStockLocation();
        IRepository<WarehouseProduct> WarehouseProduct();
        IRepository<Task> Task();
        IRepository<StocktakeTask> StocktakeTask();
        IRepository<StocktakeTaskItem> StocktakeTaskItem();
        //IRepository<VanStocktakeTask> VanStocktakeTask();
        //IRepository<VanStocktakeTaskItem> VanStocktakeTaskItem();
        IRepository<StockCart> StockCart();

        IRepository<Invoice> Invoice();
        IRepository<InvoiceItem> InvoiceItem();

        IRepository<CreditNote> CreditNote();
        IRepository<CreditNoteItem> CreditNoteItem();

        IRepository<PaymentRun> PaymentRun();

        IRepository<SearchRepair> SearchRepairs();
        IRepository<Repair> Repairs();
        IRepository<Operative> Operative();
        IRepository<RequisitionRequest> RequisitionRequest();
        IRepository<RequisitionRequestItem> RequisitionRequestItems();
        IRepository<RequisitionRequestItemReturn> RequisitionRequestItemReturns();
        IRepository<RequisitionRequest_Repair> RequisitionRequest_Repairs();

        IRepository<PurchaseOrder> PurchaseOrder();
        IRepository<PurchaseOrderItem> PurchaseOrderItem();
        IRepository<PurchaseOrderItemDetail> PurchaseOrderItemDetail();
        IRepository<Asbestos> SearchAsbestos();
        IRepository<RedFlag> SearchRedFlag();
        IRepository<OASupplierDetails> SearchOASupplier();
        IRepository<DeliveryTime> DeliveryTime();
        void Commit();
        void CommitWithAudit(string userId, string userIPAddress);
        IRepository<AuditLog> AuditLog();
        IRepository<RequisitionRequestTemplate> RequisitionRequestTemplate();
        IRepository<StandardJob> StandardJob();
        IRepository<VanLocation> VanLocation();
        IRepository<Comment> Comments();
        IRepository<VanStockUsedInRepair> VanStockUsedInRepair();
        IRepository<VanStockReplenishment> VanStockReplenishment();
        IRepository<DeliveryVanOperator> DeliveryVanOperator();
        IRepository<DeliveryVan> DeliveryVan();
        IRepository<StockTransaction> StockTransaction();
        IRepository<PermanentJobData> PermanentJobData();

        IRepository<User> User();

        IRepository<LogisticsSetting> LogisticsSetting();
    }
}
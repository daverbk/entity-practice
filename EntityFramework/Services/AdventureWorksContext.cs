using EF.Models.HumanResources;
using EF.Models.Person;
using EF.Models.Production;
using EF.Models.Purchasing;
using EF.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace EF.services;

public class AdventureWorksContext : DbContext
{
    public DbSet<Department> Department { get; set; } = null!;

    public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; } = null!;

    public DbSet<EmployeePayHistory> EmployeePayHistory { get; set; } = null!;

    public DbSet<JobCandidate> JobCandidate { get; set; } = null!;

    public DbSet<Shift> Shift { get; set; } = null!;

    public DbSet<Address> Address { get; set; } = null!;

    public DbSet<AddressType> AddressType { get; set; } = null!;
    
    public DbSet<BusinessEntity> BusinessEntity { get; set; } = null!;

    public DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; } = null!;
    
    public DbSet<BusinessEntityContact> BusinessEntityContact { get; set; } = null!;
    
    // public DbSet<ContactType> ContactType { get; set; } = null!;
    //
    // public DbSet<CountryRegion> CountryRegion { get; set; } = null!;
    //
    // public DbSet<EmailAddress> EmailAddress { get; set; } = null!;
    //
    // public DbSet<Password> Password { get; set; } = null!;
    //
    // public DbSet<Person> Person { get; set; } = null!;
    //
    // public DbSet<PersonPhone> PersonPhone { get; set; } = null!;
    //
    // public DbSet<PhoneNumberType> PhoneNumberType { get; set; } = null!; 
    //
    // public DbSet<StateProvince> StateProvince { get; set; } = null!;
    //
    // public DbSet<BillOfMaterials> BillOfMaterials { get; set; } = null!;
    //
    // public DbSet<Culture> Culture { get; set; } = null!;
    //
    // public DbSet<Document> Document { get; set; } = null!;
    //
    // public DbSet<Illustration> Illustration { get; set; } = null!;
    //
    // public DbSet<Location> Location { get; set; } = null!;
    //
    // public DbSet<Product> Product { get; set; } = null!;
    //
    // public DbSet<ProductCategory> ProductCategory { get; set; } = null!;
    //
    // public DbSet<ProductDescription> ProductDescription { get; set; } = null!;
    //
    // public DbSet<ProductDocument> ProductDocument { get; set; } = null!;
    //
    // public DbSet<ProductInventory> ProductInventory { get; set; } = null!;
    //
    // public DbSet<ProductListPriceHistory> ProductListPriceHistory { get; set; } = null!;
    //
    // public DbSet<ProductModel> ProductModel { get; set; } = null!;
    //
    // public DbSet<ProductModelIllustration> ProductModelIllustration { get; set; } = null!;
    //
    // public DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; } = null!;
    //
    // public DbSet<ProductPhoto> ProductPhoto { get; set; } = null!;
    //
    // public DbSet<ProductProductPhoto> ProductProductPhoto { get; set; } = null!;
    //
    // public DbSet<ProductReview> ProductReview { get; set; } = null!;
    //
    // public DbSet<ProductSubcategory> ProductSubcategory { get; set; } = null!;
    //
    // public DbSet<ScrapReason> ScrapReason { get; set; } = null!;
    //
    // public DbSet<TransactionHistory> TransactionHistory { get; set; } = null!;
    //
    // public DbSet<UnitMeasure> UnitMeasure { get; set; } = null!;
    //
    // public DbSet<WorkOrder> WorkOrder { get; set; } = null!;
    //
    // public DbSet<WorkOrderRouting> WorkOrderRouting { get; set; } = null!;
    //
    // public DbSet<ProductVendor> ProductVendor { get; set; } = null!;
    //
    // public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; } = null!;
    //
    // public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; } = null!;
    //
    // public DbSet<ShipMethod> ShipMethod { get; set; } = null!;
    //
    // public DbSet<Vendor> Vendor { get; set; } = null!;
    //
    // public DbSet<CountryRegionCurrency> CountryRegionCurrency { get; set; } = null!;
    //
    // public DbSet<Currency> Currency { get; set; } = null!;
    //
    // public DbSet<CurrencyRate> CurrencyRate { get; set; } = null!;
    //
    // public DbSet<Customer> Customer { get; set; } = null!;
    //
    // public DbSet<PersonCreditCard> PersonCreditCard { get; set; } = null!;
    //
    // public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; } = null!;
    //
    // public DbSet<SalesOrderHeader> SalesOrderHeader { get; set; } = null!;
    //
    // public DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; } = null!;
    //
    // public DbSet<SalesPerson> SalesPerson { get; set; } = null!;
    //
    // public DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; } = null!;
    //
    // public DbSet<SalesReason> SalesReason { get; set; } = null!;
    //
    // public DbSet<SalesTaxRate> SalesTaxRate { get; set; } = null!;
    //
    // public DbSet<SalesTerritory> SalesTerritory { get; set; } = null!;
    //
    // public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; } = null!;
    //
    // public DbSet<SpecialOffer> SpecialOffer { get; set; } = null!;
    //
    // public DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; } = null!;
    //
    // public DbSet<Store> Store { get; set; } = null!;
    
    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options)
    { }
}

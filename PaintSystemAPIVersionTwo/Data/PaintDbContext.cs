using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data;

public class PaintDbContext : DbContext
{
    //Define table 
    public DbSet<User> UserTable { get; set; }
    public DbSet<Order> OrderTable { get; set; }
    public DbSet<PaintBrand> PaintBrandTable { get; set; }
    
    public DbSet<PaintProduct> PaintProductTable { get; set; }
    public DbSet<PaintSeries> PaintSeriesTable { get; set; }
    public DbSet<PaintCategories> PaintCategoryTable { get; set; }
    public DbSet<OrderPaintProductDetail> OrderPaintProductTable { get; set; }
    public DbSet<PaintProductsStock> PaintProductsStockTable { get; set; }
    public DbSet<Payment> PaymentTable { get; set; }
    public DbSet<StockTransaction> StockTransactionTable { get; set; }
    
    
    public PaintDbContext(DbContextOptions<PaintDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    //Using FluentAPI to build Entity class 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Has..
        // With..
        // FK 
        
        //user ---> order  (1 to many) 
        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //Order ---> StockTransaction (1 to 1 )
        modelBuilder.Entity<Order>()
            .HasOne(o => o.StockTransaction) //  // 主表 Order 有一个 StockTransaction
            .WithOne(st => st.Order) // 依赖表 StockTransaction 有一个 Order
            .HasForeignKey<StockTransaction>(st => st.ReferenceOrderId) // 外键定义
            .OnDelete(DeleteBehavior.Cascade); // 删除级联

        //PaintBrand ------> PaintSeries  (1-----> Many)
        modelBuilder.Entity<PaintBrand>()
            .HasMany(p => p.PaintSeriesList) //PaintBrand has many PaintSeries
            .WithOne(s => s.PaintBrand) //PaintSeries has a PaintBrand
            .HasForeignKey(s => s.PaintBrandId) //PaintSeries has fk (PaintBrandId） from PaintBrand
            .OnDelete(DeleteBehavior.Cascade);
        //PaintBrand ------> PaintProduct      (1-----> Many)
        modelBuilder.Entity<PaintBrand>()
            .HasMany(p => p.PaintProductList) // PaintBrand 有多条 PaintProduct
            .WithOne(x => x.PaintBrand) //one PaintProduct has one PaintBrand 
            .HasForeignKey(x => x.PaintBrandId) //FK PaintBrandId from  PaintBrand
            .OnDelete(DeleteBehavior.Cascade);

        //PaintSeries------> PaintProduct      (1-----> Many)
        modelBuilder.Entity<PaintSeries>()
            .HasMany(s => s.PaintProducts) //PaintSeries has many PaintProducts
            .WithOne(p => p.PaintSeries) // PaintProducts has one PaintSeries
            .HasForeignKey(p => p.PaintSeriesId) //PaintProduct has Fk PaintSeriesId from PaintSeries
            .OnDelete(DeleteBehavior.Restrict);

        //PaintCategories--> Product      (1----->Many)
        modelBuilder.Entity<PaintCategories>()
            .HasMany(c => c.PaintProducts)
            .WithOne(p => p.PaintCategories)
            .HasForeignKey(p => p.PaintCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        //PaintProduct------> Order   (Many-----> Many)
        //显示定义 1 中间表定义 2 添加中间表导航属性在PaintProduct和Order中 3 定义关系APIFluent

        modelBuilder.Entity<OrderPaintProductDetail>()
            .HasKey(op => new { op.OrderId, op.PaintProductId }); //中间表OrderId和PaintProductId的复合Key

        //建立OrderPaintProduct和Order之间的关系
        modelBuilder.Entity<OrderPaintProductDetail>()
            .HasOne(op => op.Order) //中间表 OrderPaintProduct 关联一个 Order
            .WithMany(o => o.OrderPaintProducts) //一个 Order 拥有多个 OrderPaintProduct
            .HasForeignKey(op => op.OrderId) //外键 OrderId 来源于 Order 表
            .OnDelete(DeleteBehavior.Cascade); // 删除 Order 时，对应的中间表记录也被删除

        //建立OrderPaintProduct和PaintProduct之间的关系 
        modelBuilder.Entity<OrderPaintProductDetail>()
            .HasOne(op => op.PaintProduct) //中间表OrderPaintProduct关联PaintProduct
            .WithMany(p => p.OrderPaintProducts) //一个PaintProduct 拥有多个OrderPaintProduct
            .HasForeignKey(op => op.PaintProductId) //OrderPaintProduct有一个外建PaintProductId
            .OnDelete(DeleteBehavior.Cascade); //删除PaintProduct时，对应的中间表记录也被删除

        //PaintProduct 和 PaintProductsStock 的 1 对 1 关系
        modelBuilder.Entity<PaintProduct>()
            .HasOne(p => p.PaintProductsStock)
            .WithOne(s => s.PaintProduct)
            .HasForeignKey<PaintProductsStock>(s => s.PaintProductId)
            .IsRequired() // 确保外键 NOT NULL
            .OnDelete(DeleteBehavior.Cascade);
        
        //Order 和 Payment的 1 对 1 关系
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Payment)
            .WithOne(p => p.Order)
            .HasForeignKey<Payment>(p => p.OrderId)
            .IsRequired() // 确保外键 NOT NULL
            .OnDelete(DeleteBehavior.Cascade);
        
        //  PaintProduct  ---->  StockTransactions (1 ----> Many)   
        modelBuilder.Entity<PaintProduct>()
            .HasMany(p=>p.StockTransactions)
            .WithOne(s=>s.PaintProduct)
            .HasForeignKey(s=>s.PaintProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //PaintProductsStock -----> StockTransaction (Many-----> Many)
        
        
        
        modelBuilder.Entity<StockTransactionDetail>()
            .HasKey(st => new { st.PaintProductsStockId, st.StockTransactionId }); // 复合主键
        
        //StockTransactionDetail ---> PaintProductsStock (关联表 多对多关系)
        modelBuilder.Entity<StockTransactionDetail>()
            .HasOne(st=>st.PaintProductsStock) //StockTransactionDetail 关联一个PaintProductsStock
            .WithMany(ps=>ps.StockTransactionDetails)//PaintProductsStock可关联多个StockTransactionDetail
            .HasForeignKey(st=>st.PaintProductsStockId)//中间表有PaintProductsStock的外建
            .OnDelete(DeleteBehavior.NoAction);
        
        
        
        //StockTransactionDetail---> StockTransaction
        modelBuilder.Entity<StockTransactionDetail>()
            .HasOne(st=>st.StockTransaction) 
            .WithMany(t=>t.StockTransactionDetails)
            .HasForeignKey(st=>st.StockTransactionId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}
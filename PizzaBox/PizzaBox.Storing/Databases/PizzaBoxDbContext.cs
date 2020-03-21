using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<PizzaType> PizzaType { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }  
    public DbSet<Store> Store { get; set; }  
    public DbSet<Size> Size { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<PizzaType>().HasKey(pt => pt.TypeId);
      builder.Entity<Order>().HasKey(o => o.OrderId);
      builder.Entity<User>().HasKey(u => u.UserId);
      builder.Entity<Store>().HasKey(s => s.Location);
      builder.Entity<Size>().HasKey(s => s.SizeId);

      builder.Entity<PizzaType>().HasMany(pt => pt.Pizzas).WithOne(p => p.PizzaType);
      builder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.Order);
      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
      builder.Entity<Store>().HasMany(s => s.Orders).WithOne(o => o.Location);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);

      builder.Entity<PizzaType>().HasData(new PizzaType[]
      {
        new PizzaType() { TypeId = 1, Name = "Pepperoni Pizza", Crust = "Cheese Filled Crust", Cost = 8.50M },
        new PizzaType() { TypeId = 2, Name = "Cheese Pizza", Crust = "Thin Crust", Cost = 7.00M },
        new PizzaType() { TypeId = 3, Name = "Pineapple Bacon Pizza", Crust = "Thick Crust", Cost = 10.25M },
      });

      builder.Entity<User>().HasData(new User[]
      {
        new User() { UserId = "alex", Password = "123", UserType = "Customer"},
        new User() { UserId = "isaiah", Password = "234", UserType = "Customer"},
        new User() { UserId = "nick", Password = "345", UserType = "Customer"},
        new User() { UserId = "roby", Password = "456", UserType = "Admin"},
        new User() { UserId = "fred", Password = "567", UserType = "Admin"}
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { Location = "S Cooper St"},
        new Store() { Location = "S West St"},
        new Store() { Location = "W Mitchell St"}
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { SizeId = 1, Name = "Small", Cost = 8.00M },
        new Size() { SizeId = 2, Name = "Medium", Cost = 10.00M },
        new Size() { SizeId = 3, Name = "Large", Cost = 12.00M }
        
        
      });
    }
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    public PizzaBoxDbContext Instance { get { return _db; } }
  }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPNETCOREDATABASE.Models
{

    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employee { get; set; }
        public List<Detail> Detail { get; set; }
    }

    public class Detail
    {
        public int DetailId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UPC { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class Employee
    {
        public int EmployeeId {get; set;}
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Inventory.db");
        }
    }
}
//connect c# & React: figure out what react is trying to do(because it'll already be built, 
//make the api (to insert records), then edit & delete (if there's time)
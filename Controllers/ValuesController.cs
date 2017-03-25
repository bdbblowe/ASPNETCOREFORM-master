using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREDATABASE.Models;
using Newtonsoft.Json;

namespace ASPNETCOREDATABASE.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            using (var db = new InventoryContext())
            {
                //Query 
                var inventoryInfo = db.Inventories.Where(x => x.InventoryId == 1);

                if (inventoryInfo.Count() > 0)
                {
                    var record = inventoryInfo.FirstOrDefault();
                    Console.WriteLine("ID: {0} URL {1} ", record.InventoryId, record.Name);


                    //Update the record
                    record.Name = "Changed Inventory Item";
                    db.Inventories.Update(record);
                    db.SaveChanges();

                    var response = "ID: " + record.InventoryId + " URL: " + record.Name;
                    return response;
                }
                else
                {
                    //Create a new list of Type Detail
                    List<Detail> detail2 = new List<Detail>();
                    List<Employee> employee2 = new List<Employee>();

                    detail2.Add(new Detail { Description = "description", Quantity = 3, UPC = 1234 });
                    employee2.Add(new Employee { FirstName = "FirstName", LastName = "LastName", EmployeeNumber = 001 });

                    //Add a new record
                    db.Inventories.Add(new Inventory
                    {
                        Name = "First Inventory Item",
                        Detail = detail2,
                        Employee = employee2
                    });

                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);

                    Console.WriteLine();
                    Console.WriteLine("All inventories in database: ");
                    foreach (var inventoryItem in db.Inventories)
                    {
                        Console.WriteLine(" - {0}", inventoryItem.Name);
                    }
                    db.SaveChanges();
                }
                return "Done";
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult POST([FromBody] Inventory inventory)
        {
            using (var db = new InventoryContext())
            {
                //Query 
                var inventoryInfo = db.Inventories.Where(x => x.InventoryId == 1);

                if (inventoryInfo.Count() > 0)

                    try
                    {
                        //Add a new record
                        db.Inventories.Add(inventory);
                        db.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error);
                        Json(error.ToString());
                    }
            }

            return Json("DONE");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

// HW: Extend migrations (add more tables, etc)
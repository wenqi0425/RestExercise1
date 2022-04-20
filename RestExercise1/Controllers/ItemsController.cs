using Microsoft.AspNetCore.Mvc;
using RestExercise1.Managers;
using RestExercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercise1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        //A object of the ItemsManager class
        //Might be created several times, but the internal List is static
        private ItemsManager _manager = new ItemsManager();

        // GET: api/Items
        //Gets all the items in the managers list
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _manager.GetAll();
        }

        // GET api/Items/5
        //Gets a specific Item in the managers list, return null if the object wasn't found
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/Items
        //Sends the new object to list, which gives it a new ID and return the newly created object
        //Notice the FromBody part of the parameter, this expects a Json body from the request
        [HttpPost]
        public Item Post([FromBody] Item newItem)
        {
            return _manager.Add(newItem);
        }

        // PUT api/Items/5
        //Sends the id and the Item object to the manager to update the values
        //The id in the object is ignored
        //Returns null if no items has the id
        //As seen here, we can mix different ways of expected data from the client
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        //Notice the FromBody part of the parameter, this expects a Json body from the request
        [HttpPut("{id}")]
        public Item Put(int id, [FromBody] Item updatedItem)
        {
            return _manager.Update(id, updatedItem);
        }

        // DELETE api/Items/5
        //Asks the Manager to delete the item with the specific id
        //Returns null if the item was not found
        //Notice the "{id}" part of the annotation, this makes the URI to the object expect a /int
        [HttpDelete("{id}")]
        public Item Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}

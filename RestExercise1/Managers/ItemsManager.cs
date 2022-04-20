using RestExercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExercise1.Managers
{
    public class ItemsManager
    {
        //Keeps track of ids, in order for all items to have a unique ID
        private static int _nextId = 1;
        //Creates the list of Items and fills it with 3 items to begin with
        //The 3 items is only for testing purposes
        private static readonly List<Item> Data = new List<Item>
        {
            new Item {Id = _nextId++, Name = "Book about C#", ItemQuality = 300, Quantity = 10},
            new Item {Id = _nextId++, Name = "Not a Book about C#", ItemQuality = 1, Quantity =1},
            new Item {Id = _nextId++, Name = "Fruit basket", ItemQuality = 50, Quantity =5}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        //Returns all items in the List, in a new List
        public List<Item> GetAll()
        {
            return new List<Item>(Data);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        //Returns a specific Item from the list
        //return null if the id is not found
        public Item GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }

        //Adds a new Item to the list, and assigns it the next id
        //returns the newly added Item
        public Item Add(Item newItem)
        {
            newItem.Id = _nextId++;
            Data.Add(newItem);
            return newItem;
        }

        //Deletes the Item from the list with the specific Id
        //Returns null of no Item has the Id
        public Item Delete(int id)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }

        //Updates the values of the Item with the specific Id
        //Returns null of no Item has the Id
        //Notice Id is not changed in the Item from the List
        public Item Update(int id, Item updates)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            item.Name = updates.Name;
            item.ItemQuality = updates.ItemQuality;
            item.Quantity = updates.Quantity;
            return item;
        }
    }
}

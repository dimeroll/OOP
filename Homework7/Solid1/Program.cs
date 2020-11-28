using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//порушено принцип єдиності відповідальності

namespace Solid1
{
    class Item
    {

    }
    class Order
    {
        private List<Item> itemList;

        internal List<Item> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }

        public void AddItem(Item item) {/*...*/}
        public void DeleteItem(Item item) {/*...*/}
    }

    class OrderCalculationAndChoice
    {
        private Order order;
        internal Order Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public void CalculateTotalSum() {/*...*/}
        public void GetItems() {/*...*/}
        public void GetItemCount() {/*...*/}
    }

    class PrintShowManager
    {
        private Order order;
        internal Order Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public void PrintOrder() {/*...*/}
        public void ShowOrder() {/*...*/}
    }
        
    class LoadSaveManager
    {
        private Order order;
        internal Order Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public void Load() {/*...*/}
        public void Save() {/*...*/}
    }

    class UpdateDeleteManager
    {
        private Order order;
        internal Order Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }
        public void Update() {/*...*/}
        public void Delete() {/*...*/}
    }
   
    class Program
    {
        static void Main()
        {
        }
    }
}

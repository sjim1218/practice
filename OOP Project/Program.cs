using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Git Test ffdsfasfdsafdfdsaf
            Customer customer = new Customer();
            List<MenuItem> menuItems = Initialize();

            Menu menu = new Menu(menuItems);
            Barista barista = new Barista();
            string inputInfo = "1";
            Coffee coffee = customer.Order(inputInfo, menu, barista);            
        }

        private static List<MenuItem> Initialize()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            for (int idx = 0; idx < 4; idx++)
            {
                MenuItem menuItem = new MenuItem(idx.ToString(), 2000);
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
    }

    class Customer
    {
        public Coffee Order(string menuName, Menu menu, Barista barista)
        {
            MenuItem menuItem = menu.GetCoffeeInfo(menuName);
            Coffee coffee = barista.Make(menuItem);
            return coffee;
        }
    }

    class Barista
    {
        public Coffee Make(MenuItem menuItem)
        {
            string coffeeName = menuItem.GetName();
            double coffeePrice = menuItem.GetPrice();
            Coffee coffee = new Coffee(coffeeName, coffeePrice);
            return coffee;
        }
    }

    class Menu
    {
        private List<MenuItem> MenuItems;

        public Menu(List<MenuItem> menuItems)
        {
            this.MenuItems = menuItems;
        }

        public MenuItem GetCoffeeInfo(string menuName)
        {
            MenuItem menuItem = Find(menuName);
            return menuItem;
        }

        private MenuItem Find(string menuName)
        {
            foreach(MenuItem menuItem in this.MenuItems)
            {
                if (menuItem.GetName() == menuName)
                    return menuItem;
            }
            return null;
        }

    }

    class MenuItem
    {
        private string Name;
        private double Cost;

        public MenuItem(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string GetName()
        {
            return this.Name;
        }
        public double GetPrice()
        {
            return this.Cost;
        }
    }

    class Coffee
    {
        private string Name;
        private double Price;

        public Coffee(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string GetInfo()
        {
            string info = this.Name + " : " + this.Price.ToString();
            return info;
        }
    }
}

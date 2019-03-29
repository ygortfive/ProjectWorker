using Order_Restaurant_Ex_Proposto.Entities;
using Order_Restaurant_Ex_Proposto.Entities.Enums;
using System;
using System.Globalization;

namespace Order_Restaurant_Ex_Proposto
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, email, product;
            DateTime birthDate;
            int items, quantity;
            double price;
            OrderStatus status;
            Client c1;
            Product p1;
            OrderItem oi1;
            Order or1;



            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Email: ");
            email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            birthDate = DateTime.Parse(Console.ReadLine());

            c1 = new Client(name, email, birthDate);

            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            items = int.Parse(Console.ReadLine());

            or1 = new Order(DateTime.Now, status, c1);
            
            for(int i = 1; i <= items; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                product = Console.ReadLine();
                Console.Write("Product price: ");
                price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine());

                p1 = new Product(product, price);
                oi1 = new OrderItem(quantity, price, p1);
                or1.addItem(oi1);
            }
            Console.WriteLine();
            Console.WriteLine(or1);



        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Order_Restaurant_Ex_Proposto.Entities.Enums;

namespace Order_Restaurant_Ex_Proposto.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public  OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double total()
        {
            double sum = 0;
            foreach(OrderItem item in Items)
            {
                sum += item.subTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMARY:");
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order Status: {Status}");
            sb.AppendLine($"Client: {Client.Name} ({Client.birthDate.ToShortDateString()}) - {Client.Email}");
            sb.AppendLine("Order items: ");
            foreach(OrderItem item in Items)
            {
                sb.Append($"{item.Product.Name}, ${item.Price.ToString("N2",CultureInfo.InvariantCulture)}, ");
                sb.AppendLine($"Quantity: {item.Quantity}, SubTotal: {item.subTotal().ToString("N2", CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine($"Total: {total().ToString("N2", CultureInfo.InvariantCulture)}");

            return sb.ToString();

        }
    }
}

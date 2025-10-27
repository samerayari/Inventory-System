using Avalonia.Controls;
using Afl6.Models;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Afl6
{
    public partial class MainWindow : Window
    {
        private readonly OrderBook orderBook = new();
        private readonly ItemSorterRobot robot = new(); 

        public MainWindow()
        {
            InitializeComponent();

            QueuedList.ItemsSource = orderBook.QueuedOrders;
            ProcessedList.ItemsSource = orderBook.ProcessedOrders;

            
            ProcessButton.Click += (_, __) =>
            {
                orderBook.ProcessNextOrder();
                UpdateUI();
            };

            
            ProcessOrderRobotButton.Click += async (_, __) =>
            {
                await ProcessOrderWithRobot();
            };

            SeedData();
            UpdateUI();
        }

        private void SeedData()
        {
            var hammer = new Item("Hammer", 30);
            var cement = new BulkItem("Cement", 10, "kg");
            var screwdriver = new Item("Screwdriver", 50);
            var sand = new BulkItem("Sand", 5, "kg");

            orderBook.Inventory.AddStock(hammer, 10);
            orderBook.Inventory.AddStock(cement, 50);
            orderBook.Inventory.AddStock(screwdriver, 5);
            orderBook.Inventory.AddStock(sand, 40);

            var o1 = new Order();
            o1.OrderLines.Add(new OrderLine(hammer, 2));
            o1.OrderLines.Add(new OrderLine(cement, 3));

            var o2 = new Order();
            o2.OrderLines.Add(new OrderLine(screwdriver, 1));
            o2.OrderLines.Add(new OrderLine(sand, 4));

            var o3 = new Order();
            o3.OrderLines.Add(new OrderLine(hammer, 1));

            var customer = new Customer("Ali");
            customer.CreateOrder(orderBook, o1);
            customer.CreateOrder(orderBook, o2);
            customer.CreateOrder(orderBook, o3);
        }

        private void UpdateUI()
        {
            RevenueText.Text = $"Total Revenue: {orderBook.TotalRevenue():C}";
            UpdateInventoryText();
        }

        private void UpdateInventoryText()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Inventory:");
            foreach (var kvp in orderBook.Inventory.Stock)
            {
                sb.AppendLine($"- {kvp.Key.Name}: {kvp.Value}");
            }

            var lowItems = orderBook.Inventory.LowStockItems();
            if (lowItems.Count > 0)
            {
                sb.AppendLine("\n⚠️ Low stock items:");
                foreach (var item in lowItems)
                    sb.AppendLine($"  {item.Name}");
            }

            InventoryText.Text = sb.ToString();
        }
        
        private async Task ProcessOrderWithRobot()
        {
            StatusMessages.Text += "🤖 Processing order with robot...\n";

            foreach (var orderLine in orderBook.ProcessNextOrder())
            {
                for (int i = 0; i < orderLine.Quantity; i++)
                {
                    StatusMessages.Text += $"Picking up {orderLine.Item.Name}\n";
                    robot.PickUp((uint)(i + 1)); 
                    await Task.Delay(9500); 
                }
            }

            UpdateUI();
            StatusMessages.Text += "✅ Order completed!\n";
        }
    }
}

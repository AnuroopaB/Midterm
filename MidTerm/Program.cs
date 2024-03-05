public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public int limitedQuantity = 0;

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        this.ItemName = itemName;
        this.ItemId = itemId;
        this.Price = price;
        this.QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        this.Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        this.QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        if (this.QuantityInStock >= quantitySold)
        {
            this.QuantityInStock -= quantitySold;
        }
        else
        {
            limitedQuantity = 1;
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        if (this.QuantityInStock > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"\nPlease find the product details:\nName:\t\t{ItemName}\nId:\t\t{ItemId}\nPrice:\t\t{Price}\nStock Quantity:\t{QuantityInStock}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);
        InventoryItem item = new InventoryItem("", 0, 0.0, 0);

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 2. Sell some items and then print the updated details.
        // 3. Restock an item and print the updated details.
        // 4. Check if an item is in stock and print a message accordingly.

        Console.WriteLine("Welcome to Virtual Store\n************************");
        Loop:
        Console.Write("\nOptions:\n1. Details of all the Items\n2. Sell an item\n3. Restock an item\n4. Check the status of stock\n5. Update Price of an item\n6. Exit\n\nEnter your selection: ");
        int input = int.Parse(Console.ReadLine());
        int inputItem;
        int quantity;
        double newPrice = 0.0;
        switch (input)
        {
            case 1:
                item1.PrintDetails();
                item2.PrintDetails();
                goto Loop;
            case 2:
                ItemSelection();
                QuantitySelection();
                item.SellItem(quantity);
                if (item.limitedQuantity == 1)
                {
                    Console.WriteLine($"\nCannot sell {quantity} {item.ItemName}/s as quantity is less!");
                }
                else
                {
                    Console.WriteLine($"\n{quantity} {item.ItemName}/s sold, updated quantity is {item.QuantityInStock}");
                }
                goto Loop;
            case 3:
                ItemSelection();
                QuantitySelection();
                item.RestockItem(quantity);
                item.PrintDetails();
                Console.WriteLine($"\n{quantity} {item.ItemName}/s restocked, updated quantity is {item.QuantityInStock}");
                goto Loop;
            case 4:
                ItemSelection();
                if (item.IsInStock())
                {
                    Console.WriteLine($"{item.ItemName} is in stock");
                }
                else
                {
                    Console.WriteLine($"{item.ItemName} is out of stock");
                }
                goto Loop;
            case 5:
                ItemSelection();
                Console.Write("\nEnter the new Price: ");
                newPrice = double.Parse(Console.ReadLine());
                item.UpdatePrice(newPrice);
                Console.WriteLine($"\nNew price of {item.ItemName} is {item.Price}");
                goto Loop;
            case 6:
                Console.WriteLine("Quiting...");
                break;
            default:
                Console.WriteLine("\nPlease select a valid option!");
                goto Loop;
        }
        void ItemSelection()
        {
            Console.Write("\nSelect item: \nEnter 1 for Laptop\nEnter 2 for Smartphone\n\nSelection :");

            inputItem = int.Parse(Console.ReadLine());
            item = inputItem == 1 ? item1 : item2;
        }
        void QuantitySelection()
        {
            Console.Write("\nEnter the quantity: ");
            quantity = int.Parse(Console.ReadLine());
        }
    }
}

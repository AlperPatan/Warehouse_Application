using StockApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using System.Text.Json.Nodes;

public class ProductManager
{
    private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "products.json");



    public static void SaveProducts(List<Product> products)
    {
        string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
        Console.WriteLine("Product list updated successfully.");
    }



    public static List<Product> LoadProducts()
    {
        if (!File.Exists(FilePath))
            return new List<Product>();

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
    }

   
    public static void ListProducts()
    {
        List<Product> products = LoadProducts();



        if (products.Count == 0)                           //Liste boş ise "Stock empty yazdır ve ana menüye döndür"
        {
            Console.WriteLine("Stock is Empty.");
            return;
        }
        var sortedProducts = products.OrderBy(p => p.Id).ToList();     //id ye göre sırala küçükten büyüğe

        Console.WriteLine("Id       Name        Quantity          Brand");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"{product.Id}\t{product.Name}\t{"  "}\t{product.Quantity}\t{""}\t{product.Brand}");
        }
    }
    public static void AddProduct()
    {
        List<Product> products = LoadProducts();
        int id;

        while (true)
        {

            //Id
            Console.Write("Item ID: ");
            if (!int.TryParse(Console.ReadLine(), out id)) 
            {
                Console.WriteLine("Please enter a valid numeric ID!");
                continue;
            }

            if (products.Any(p => p.Id == id))
            {
                Console.WriteLine("This ID is already existing, please try another one.");
            }
            else
            {
                break; 
            }

        }
              //Name
            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();
        
            //Quantity
            int quantity;
            while (true)
            {

                Console.Write("Item Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Please enter a number!");

            }
            else { break; }
                
            }
            //Brand
            Console.WriteLine("Item Brand: ");
            string brand = Console.ReadLine();


            Product newProducts = new Product(id, name, quantity, brand);

        products.Add(new Product(id, name, quantity, brand));
        SaveProducts(products); 


    }

    public static void EditProduct()
    {
        List<Product> products = LoadProducts();

        int id;
        
        
        
        while (true) {
            
            if (!int.TryParse(Console.ReadLine(), out id)) // Geçersiz giriş kontrolü
        {
            Console.WriteLine("Please enter a valid numeric ID !");
            continue;
        }

            Product product = products.Find(p => p.Id == id);

            if (product==null)
        {
            Console.WriteLine("This Id is not existing !");
            }
            else { break; }
        }

        Product productToEdit = products.Find(p => p.Id == id);

        Console.Write($"New Name ({productToEdit.Name}): ");
        string newName = Console.ReadLine();
        productToEdit.Name = !string.IsNullOrEmpty(newName) ? newName : productToEdit.Name;

        //Edit Quantity
        while (true) { 
        Console.Write($"New Quantity ({productToEdit.Quantity}): ");
        if (!int.TryParse(Console.ReadLine(), out int newQuantity))
        {
            Console.WriteLine("Please enter a number !");
            
        }
        else
        {
            productToEdit.Quantity = newQuantity;
                break;
        }

        }

        Console.Write($"New Brand ({productToEdit.Brand}): ");
        string newBrand = Console.ReadLine();
        productToEdit.Brand = !string.IsNullOrEmpty(newBrand) ? newBrand : productToEdit.Brand;

        SaveProducts(products); 


    }
    public static void DeleteProduct()
    {
        List<Product> products = LoadProducts();
        Console.WriteLine("Enter Id of the Product: ");

        int id;
        while (true)
        {

        
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a valid Id !");
                continue;
        }

        if (id==null)
        {
            Console.WriteLine("This Id is not existing !");
        }
            else { break; }
        }

        Product productToDelete = products.Find(p => p.Id == id);

        if (productToDelete != null)
        {
            products.Remove(productToDelete);
        }

        SaveProducts(products);

    }
    public static void SearchItem()
    {
        
        List<Product> products = LoadProducts();
        Console.WriteLine("Please enter Id or Name: ");
        string input = Console.ReadLine();

        if(int.TryParse(input,out int id))
        {
            Product product = products.Find(p => p.Id == id);
            if (product != null)
            {
                Console.WriteLine($"Found: {product.Id} - {product.Name} - {product.Quantity} - {product.Brand}");
            }
            else
            {
                Console.WriteLine("No product found with this ID.");
            }
        }
        else
        {
            
            var matchedProducts = products
    .Where(p => p.Name.ToLower().Contains(input.ToLower()))
    .ToList();


            if (matchedProducts.Any())
            {
                Console.WriteLine("Matching products:");
                foreach (var p in matchedProducts)
                {
                    Console.WriteLine($"{p.Id} - {p.Name} - {p.Quantity} - {p.Brand}");
                }
            }
            else
            {
                Console.WriteLine("No product found with this name.");
            }
        }
    }
}



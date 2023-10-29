using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class Program
    {
        private static double totalMoney = 0.0; // Total money inserted by the user
        private static double previousTotal = 0.0; // Variable to store the previous total before product selection
        private static string[] products = { "", "Snickers", "Twix", "Mars", "Malteasers", "Bounty", "Wispa", "Dairy Milk", "Fudge", "Kinder Bueno", "Aero" };// Array of product names
        private static string[] prices = { "", "1.20", "1.50", "1.00", "1.80", "2.00", "0.80", "1.75", "1.90", "1.10 ", "1.25" }; // Array of prices of products
        static void Main()
        {
            DisplayWelcomeScreen(); // Display welcome message and available products

            while (true)
            {
                Console.WriteLine("Enter your choice: ");
                string userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "i")
                {
                    InsertCoins(); // If user chooses 'i', insert coins
                }
                else if (userChoice.ToLower() == "ii")
                {
                    previousTotal = totalMoney; // Store the total money before product selection
                    ProductSelection(); // If user chooses 'ii', select products
                }
            }
        }
        static void DisplayWelcomeScreen() // Method to display the welcome message and available products
        {
            Console.WriteLine("Welcome to the Vending Machine!\nAvailable Products:");
            for (int i = 1; i < products.Length; i++)
            {
                Console.WriteLine(i + " - " + products[i] + " - £" + prices[i] + "");
            }
            Console.WriteLine("\nOptions:");
            Console.WriteLine("i) Insert Coins");
            Console.WriteLine("ii) Select Product");
            Console.WriteLine("iii) Exit to homescreen\n");
        }
        static void InsertCoins() // Method to handle the insertion of coins
        {
            Console.WriteLine("Enter coins: (5p, 10p, 20p, 50p, £1, £2, £5, £10)");

            while (true)
            {
                string coinsInserted = Console.ReadLine().ToLower();

                if (coinsInserted == "iii")
                    break;
                double coinValue = 0;
                switch (coinsInserted) // Cases to identify the selected product
                {
                    case "5p":
                        coinValue = 0.05;
                        break;
                    case "10p":
                        coinValue = 0.10;
                        break;
                    case "20p":
                        coinValue = 0.20;
                        break;
                    case "50p":
                        coinValue = 0.50;
                        break;
                    case "£1":
                        coinValue = 1.00;
                        break;
                    case "£2":
                        coinValue = 2.00;
                        break;
                    case "£5":
                        coinValue = 5.00;
                        break;
                    case "£10":
                        coinValue = 10.00;
                        break;
                    default:
                        Console.WriteLine("Invalid! Please enter a valid coin value.");
                        continue;
                }
                totalMoney += coinValue;
                Console.WriteLine($"Inserted: " + coinsInserted + " Total money: £" + totalMoney + "");
            }

            Console.WriteLine("Total money: £" + totalMoney + "");
        }
        static void ProductSelection()  // Method to handle product selection and purchase
        {
            Console.WriteLine("Enter the product code to purchase (enter iii to finish buying)");

            while (true)
            {
                string productCode = Console.ReadLine();
                string product = "";

                if (productCode == "iii")
                    break;
                switch (productCode) // Cases to identify the selected product
                {
                    case "1":
                        product = "Snickers";
                        break;
                    case "2":
                        product = "Twix";
                        break;
                    case "3":
                        product = "Mars";
                        break;
                    case "4":
                        product = "Malteasers";
                        break;
                    case "5":
                        product = "Bounty";
                        break;
                    case "6":
                        product = "Wispa";
                        break;
                    case "7":
                        product = "Dairy Milk";
                        break;
                    case "8":
                        product = "Fudge";
                        break;
                    case "9":
                        product = "Kinder Bueno";
                        break;
                    case "10":
                        product = "Aero";
                        break;
                    default:
                        Console.WriteLine("Invalid product code!");
                        continue;
                }
                if (Convert.ToDouble(totalMoney) < Convert.ToDouble(prices[Convert.ToInt32(productCode)]))
                {
                    Console.WriteLine("Not enough money inserted. Please insert more coins or choose a different product.");
                }
                else if (totalMoney >= Convert.ToDouble(prices[Convert.ToInt32(productCode)]))
                {
                    totalMoney -= Convert.ToDouble(prices[Convert.ToInt32(productCode)]);
                    Console.WriteLine("You chose: " + product + " Remaining credit: £" + totalMoney);
                }
                else
                {
                    Console.WriteLine("Invalid price for the selected product. Please try again.");
                }
            }
            Console.WriteLine("Would you like to refund your products? (y/n)");
            string refundOption = Console.ReadLine().ToLower();

            if (refundOption == "y")
            {
                Console.WriteLine("Refunded: £" + totalMoney);
                totalMoney = previousTotal; // Set total money back to the previous total
            }
            else if (refundOption == "n")
            {
                
            }
            Console.WriteLine("Thank you for using the Vending Machine!");
            totalMoney = 0; // Reset the total money
            Main(); // Restart the main function for another session
        }
    }
}

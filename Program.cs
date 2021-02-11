using System;

namespace NicoleProvanFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runApp = true;

            do
            {
                string username;
                string password;
                Console.WriteLine("Welcome to Nicole Provan\'s Application! Please enter your creditials to log in.");

            Retry:
                Console.WriteLine("Enter Username:");
                username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                password = Console.ReadLine();

                if (username.Length > 0 && password.Length > 0)
                {
                    Console.WriteLine("Thank you for entering your username and password.");
                }
                else
                {
                    Console.WriteLine("Sorry, you must enter a username and password.");
                    goto Retry;
                }

                bool credCheck = Customer_Detail.IsCheckCredentials(username, password);

                if (credCheck == true)
                {
                OptionsMenu:
                    Console.WriteLine($"Welcome {username}! Please choose an option: " +
                        $"\nOption 1: Edit Cutsomer Profile \nOption 2: Buy Products \nOption 3: Exit Application");
                    try
                    {
                        int menuChoice = Int32.Parse(Console.ReadLine());

                        switch (menuChoice)
                        {
                            case 1:
                            EditProfileRetry:

                                //edit customer profile
                                Console.WriteLine("1. Edit City\n2. Edit Credit Limit");
                                int editProfileChoice = Int32.Parse(Console.ReadLine());
                                switch (editProfileChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter City:");
                                        string updateCity = Console.ReadLine();
                                        Customer.EditCity(username, updateCity);
                                        break;
                                    case 2:
                                    CreditRetry:
                                        //throws error if number entered is too large for Int32
                                        Console.WriteLine("Enter Credit Limit:");
                                        decimal updateCredit = Int32.Parse(Console.ReadLine());
                                        if (updateCredit < 1000 || updateCredit > 5000)
                                        {
                                            Console.WriteLine("Credit Limit must be between 1000 and 5000. Please try again.");
                                            goto CreditRetry;
                                        }
                                        Customer.EditCredit(username, updateCredit);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid entry. Please try again.");
                                        goto EditProfileRetry;
                                }

                                goto OptionsMenu;

                            case 2:
                                int displayPrice;
                                int quant;
                                int custId = Customer_Detail.GetId(username);
                                Console.WriteLine("Choose Product Type:");
                                Product.GetProductTypes();
                                int typeChoice = Int32.Parse(Console.ReadLine());
                                switch (typeChoice)
                                {
                                    case 1:

                                        Product.ProductsAvailable("Appliance");
                                        Console.WriteLine("Select product to display price:");
                                        displayPrice = Int32.Parse(Console.ReadLine());
                                        switch (displayPrice)
                                        {
                                            case 1:
                                                Product.DisplayPrice("Stove");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Stove", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            case 2:
                                                Product.DisplayPrice("Toaster");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Toaster", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            default: break;
                                        }

                                        break;
                                    case 2:
                                        Product.ProductsAvailable("Hardware");
                                        Console.WriteLine("Select product to display price:");
                                        displayPrice = Int32.Parse(Console.ReadLine());
                                        switch (displayPrice)
                                        {
                                            case 1:
                                                Product.DisplayPrice("Electric heater");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Electric heater", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            case 2:
                                                Product.DisplayPrice("Jumper cables");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Jumper cables", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            case 3:
                                                Product.DisplayPrice("Snow shovel");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Snow shovel", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            default: break;
                                        }
                                        break;
                                    case 3:
                                        Product.ProductsAvailable("Sports");
                                        Console.WriteLine("Select product to display price:");
                                        displayPrice = Int32.Parse(Console.ReadLine());
                                        switch (displayPrice)
                                        {
                                            case 1:
                                                Product.DisplayPrice("Hockey stick");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Hockey stick", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            case 2:
                                                Product.DisplayPrice("Snowboard");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Snowboard", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            case 3:
                                                Product.DisplayPrice("Swiss army knife");
                                                do
                                                {
                                                    Console.WriteLine("How many would you like to buy?");
                                                    quant = Int32.Parse(Console.ReadLine());
                                                    Product.ValidateQuantity(quant, "Swiss army knife", custId);
                                                    if (quant > 0) { break; }
                                                } while (true);
                                                goto OptionsMenu;
                                            default: break;
                                        }
                                        break;
                                    default: break;
                                }
                                break;
                            case 3:
                                //exit application
                                Console.WriteLine("Exiting application...");
                                runApp = false;
                                break;
                            default: break;
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Invalid input. Please only enter integers above 0. ");
                        goto OptionsMenu;
                    }

                }
                else
                {
                SignupRetry:
                    Console.WriteLine("Username and Password combination doesn\'t exist. Choose an option below: ");
                    Console.WriteLine("1. Retry\n2. Sign Up");
                    try
                    {
                        int userinput = Int32.Parse(Console.ReadLine());

                        if (userinput == 2)
                        {
                            Console.WriteLine("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            bool custCheck = Customer.CheckCustomer(firstName, lastName);

                            if (custCheck != true)
                            {
                                Console.WriteLine("User not in system");
                                Console.WriteLine("Enter City:");
                                string city = Console.ReadLine();
                                Console.WriteLine("Enter Credit Limit:");
                                int credLim = Int32.Parse(Console.ReadLine());
                                Customer.NewCustomer(firstName, lastName, city, credLim);
                            }

                            Customer_Detail.AddDetail(firstName, lastName);

                            Console.WriteLine("Account Created. Please try logging in again.");
                            goto Retry;
                        }
                        else
                        {
                            goto Retry;
                        }

                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Invalid input. First name, Last name, and City must be strings. Credit limit must be numbers. ");
                        goto SignupRetry;
                    }

                }

            } while (runApp);

        }
    }
}

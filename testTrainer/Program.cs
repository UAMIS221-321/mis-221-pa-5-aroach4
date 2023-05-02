using testTrainer;
//main start
MenuSystem();
//main end


static void MenuSystem(){
    
    int menuChoice = 0;
    while (menuChoice != 5)
        {
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Manage trainer data");
        Console.WriteLine("2. Manage listing data");
        Console.WriteLine("3. Manage customer booking data");
        Console.WriteLine("4. Run reports");
        Console.WriteLine("5. Exit the application");

        try
        {
            menuChoice = int.Parse(System.Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    
                   TrainerMenuSystem();
                   break;
                case 2:
                    ListingMenuSystem();
                    break;
                case 3:
                    BookingMenuSystem();
                    break;
                case 4:
                    ReportMenuSystem();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Exiting the application...");
                    break;
                default:
                    throw new Exception("Please enter a valid menu choice.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}


static void TrainerMenuSystem()
{
    
    TrainerUtility utility = new TrainerUtility();
    
    int menuChoice = 0;
    while (menuChoice != 5)
    {
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add a new trainer");
        Console.WriteLine("2. Edit an existing trainer");
        Console.WriteLine("3. Delete an existing trainer");
        Console.WriteLine("4. View list of trainers");
        Console.WriteLine("5. Return to main menu");

        try
        {
            menuChoice = int.Parse(System.Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    utility.GetAllTrainersFromFile();
                    utility.AddTrainer();
                    break;

                case 2:
                    Console.Clear();
                    utility.GetAllTrainersFromFile();
                    utility.EditTrainer();
                    // code for editing an existing trainer
                    break;

                case 3:
                    Console.Clear();
                    utility.GetAllTrainersFromFile();
                    utility.DeleteTrainer();
                    break;

                case 4:
                    Console.Clear();
                    utility.GetAllTrainersFromFile();
                    utility.PrintAllTrainers();
                    break;
                case 5:
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    throw new Exception("Please enter a valid menu choice.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

static void ListingMenuSystem()
{
    
    ListingUtility utility = new ListingUtility();
    
    int menuChoice = 0;
    while (menuChoice != 5)
    {
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add a new listing");
        Console.WriteLine("2. Edit an existing listing");
        Console.WriteLine("3. Delete an existing listing");
        Console.WriteLine("4. View all listings");
        Console.WriteLine("5. Return to main menu");

        try
        {
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    utility.GetAllListingsFromFile();
                    utility.AddListing();
                    break;

                case 2:
                    Console.Clear();
                    utility.GetAllListingsFromFile();
                    utility.EditListing();
                    break;

                case 3:
                    Console.Clear();
                    utility.GetAllListingsFromFile();
                    utility.DeleteListing();
                    break;

                case 4:
                    Console.Clear();
                    utility.GetAllListingsFromFile();
                    utility.PrintAllListings();
                    break;
                case 5:
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    throw new Exception("Please enter a valid menu choice.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        
    }
}

static void BookingMenuSystem(){
    int menuChoice = 0;
    BookingUtility utility = new BookingUtility();
    

    while (menuChoice != 5)
        {
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. View available training sessions");
        Console.WriteLine("2. Book a session");
        Console.WriteLine("3. Update session status");
        Console.WriteLine("4. View all bookings");
        Console.WriteLine("5. Return to main menu");

        try
        {
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    utility.GetAllBookingsFromFile();
                   utility.ViewAvailableBooking();
                   break;
                case 2:
                    utility.GetAllBookingsFromFile();
                    utility.BookASession();
                    break;
                case 3:
                    utility.GetAllBookingsFromFile();
                    utility.UpdateStatus();
                    break;
                
                case 4:
                    Console.Clear();
                    utility.GetAllBookingsFromFile();
                    utility.PrintAllBookings();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Returning to menu...");
                    break;
                default:
                    throw new Exception("Please enter a valid menu choice.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

static void ReportMenuSystem(){
    SessionReport report = new SessionReport();
    int menuChoice = 0;
    while (menuChoice != 9)
        {
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. View sessions by email");
        System.Console.WriteLine("2. View sessions by trainer");
        Console.WriteLine("3. View sessions by customer and date");
        Console.WriteLine("4. View revenue by month and year");
        System.Console.WriteLine("5. View average session cost per trainer");
        System.Console.WriteLine("6. View cheapest vs most expensive listing");
        System.Console.WriteLine("7. View range of listing prices");
        System.Console.WriteLine("8. View pairs of listings under $100");
        Console.WriteLine("9. Return to main menu");

        try
        {
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.SessionsByEmail();
                   break;
                case 2:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.SessionsByTrainer();
                    break;
                case 3:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.HistoricalCustomerSessions();
                    break;
                case 4:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.HistoricalRevenueReport();
                    break;
                
                case 5:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.AvgCostByTrainer();
                    break;
                case 6:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.MinMax();
                    break;
                case 7:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.ListingsByCost();
                    break;
                case 8:
                    report.bookingUtility.GetAllBookingsFromFile();
                    report.PairsUnder100();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Returning to menu...");
                    break;
                default:
                    throw new Exception("Please enter a valid menu choice.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}



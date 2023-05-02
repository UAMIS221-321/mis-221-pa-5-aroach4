namespace testTrainer
{
    public class BookingUtility
    {
        
        public Booking[] bookings = new Booking[100];
        ListingUtility listingUtility = new ListingUtility();

        string[] ids = new string[100];

        public BookingUtility()
        {
                   
        }

        public void GetAllBookingsFromFile()
        {
            StreamReader inFile = new StreamReader("transactions.txt");
            Booking newBooking = new Booking();
            listingUtility.GetAllListingsFromFile();
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(
                    temp[0], temp[1], temp[2], temp[3], temp[4],temp[5],temp[6]);
                ids[Booking.GetCount()] = temp[0];
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void ViewAvailableBooking(){
            Console.Clear();
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listingUtility.listings[i].GetSessionTaken() == false){
                    System.Console.WriteLine(listingUtility.listings[i].ToString());
                    System.Console.WriteLine("\n");
                }
            }
        }

        public void BookASession(){
            Console.Clear();
            System.Console.WriteLine("Available listing ID's: ");
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listingUtility.listings[i].GetSessionTaken() == false){
                    System.Console.Write(listingUtility.ids[i]+", ");
                }
            }
            System.Console.WriteLine("\n\nPlease enter the listing ID of session you would like to book.");
            string id = Console.ReadLine();
            
            int index = listingUtility.FindListing(id);
            while(id != "STOP"){
                if(index >=0){
                    if(listingUtility.listings[index].GetSessionTaken() == false){
                        Console.Clear();
                        System.Console.WriteLine(listingUtility.listings[index].ToString());
                        System.Console.WriteLine("\nWould you like to book this session? (Y/N)");
                        string input = Console.ReadLine();
                        if(input.ToUpper() == "Y"){
                            
                            AddBooking(index, id);
                            id = "STOP";
                        }
                        else
                        id = "STOP";
                    } 
                    else{
                        System.Console.WriteLine("Session is already taken, please enter another listing ID.");
                        id = Console.ReadLine();
                        index = listingUtility.FindListing(id);
                    }
                }
                else{
                    System.Console.WriteLine("Listing ID does not exist. Please enter valid listing ID.");
                    index = listingUtility.FindListing(Console.ReadLine());
                }
            }
            
        }

        public void AddBooking(int index, string id){
            Console.Clear();
            Booking newBooking = new Booking();
            newBooking.SetSessionID(id);
            System.Console.WriteLine("What is the name of the customer?");
            newBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("What is the email of the customer?");
            newBooking.SetCustomerEmail(Console.ReadLine());
            Console.Clear();
            System.Console.WriteLine("Session ID is "+newBooking.GetSessionID());
            System.Console.WriteLine("Customer Name is "+newBooking.GetCustomerName());
            System.Console.WriteLine("Customer Email is "+newBooking.GetCustomerEmail());
            string trainingDate = listingUtility.listings[index].GetSessionDate();
            newBooking.SetTrainingDate(trainingDate);
            System.Console.WriteLine("Training date is "+trainingDate);
            string trainerID = listingUtility.listings[index].GetTrainerID();
            newBooking.SetTrainerID(trainerID);
            System.Console.WriteLine("Trainer ID is "+trainerID);
            string trainerName = listingUtility.listings[index].GetTrainerName();
            newBooking.SetTrainerName(trainerName);
            System.Console.WriteLine("Trainer name is "+trainerName);
            bookings[Booking.GetCount()] = newBooking;
            listingUtility.listings[index].SetSessionTaken(true);
            listingUtility.Save();
            Booking.IncCount();
            Save();
        }

        public void UpdateStatus(){
            Console.Clear();
            int index = 0;
            System.Console.WriteLine("Booked session ID's: ");
            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetStatus()== "booked"){
                    System.Console.Write(bookings[i].GetSessionID()+", ");
                }
            }
            System.Console.WriteLine("\n\nWhat is the session ID of the session you would like to update?");
            string searchVal1 = Console.ReadLine();
            
            while(searchVal1 != "STOP"){
                index = FindBooking(searchVal1);    
                if(index == -1){
                    System.Console.WriteLine("Session ID does not exists. Please enter another ID.");
                    searchVal1 = Console.ReadLine();
                }
                else{
                    
                    if(bookings[index].GetStatus() != "booked"){
                        System.Console.WriteLine("Session has already been completed or cancelled. Please enter Session ID of booked session.");
                        searchVal1 = Console.ReadLine();
                    }
                    else if(bookings[index].GetStatus() == "booked"){
                       searchVal1 = "STOP"; 
                    }
                    
                }
            }
            Console.Clear();
            System.Console.WriteLine(bookings[index]);
            System.Console.WriteLine("\nHas the session been completed? (Y/N)");
                        string input = Console.ReadLine();
                        if(input.ToUpper() == "Y"){
                            bookings[index].SetStatus("completed");
                            System.Console.WriteLine("Status updated.");
                        }
                        else{
                            System.Console.WriteLine("Did customer cancel or no-show session? (Y/N)");
                            input = Console.ReadLine();
                            if(input.ToUpper() == "Y"){
                                bookings[index].SetStatus("cancelled");
                                System.Console.WriteLine("Status updated.");
                            }
                            else{
                                System.Console.WriteLine("Session has not been completed or cancelled. Status will remain booked.");
                            }
                        }
            Save();
                        
            
        }

        public void Save(){
            
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for (int i = 0; i < Booking.GetCount(); i++){
                 outFile.WriteLine(bookings[i].ToFile());
            }

            outFile.Close();
        }

        public int FindBooking(string sessionID)
        {
            for (int i = 0; i < Booking.GetCount(); i++)
            {
                if (sessionID == bookings[i].GetSessionID())
                {
                    return i;
                }
            }
            return -1;
        }

        public void PrintAllBookings()
        {
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                System.Console.WriteLine(bookings[i].ToString());
                System.Console.WriteLine();
            }
        }

        
    }
}
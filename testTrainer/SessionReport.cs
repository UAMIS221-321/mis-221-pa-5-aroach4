namespace testTrainer{
    public class SessionReport{
        
        public BookingUtility bookingUtility = new BookingUtility();
        public ListingUtility listingUtility = new ListingUtility();


        public SessionReport(){

        }

        public void SessionsByEmail(){
            Console.Clear();
            Booking[] ByEmail = new Booking[100];
            System.Console.WriteLine("Please enter customer email: ");
            int emailCount = 0;
            string email = Console.ReadLine();
            int c = 0;
            while(c == 0){
                for(int i = 0; i < Booking.GetCount(); i++){
                    if((email).ToUpper() == (bookingUtility.bookings[i].GetCustomerEmail()).ToUpper()){
                        ByEmail[emailCount] = bookingUtility.bookings[i];
                        emailCount++;
                        c++;
                    }
                    
                }
                
                if(c == 0){
                    System.Console.WriteLine("No sessions under entered customer email. Please enter valid email: ");
                    email = Console.ReadLine();
                }   
            }
            printSessionsByEmail(emailCount, email, ByEmail);
            System.Console.WriteLine("_______________________________\n");
            System.Console.WriteLine("\nWould you like to save this report to a file? (Y/N):");
            string takenInput = Console.ReadLine();
            if (takenInput.ToUpper() == "Y")
            {
                SaveReport(ByEmail, emailCount);
            }
            
            
        }

        public void printSessionsByEmail(int emailCount, string email, Booking[] ByEmail){
            Console.Clear();
            System.Console.WriteLine("_______________________________\n");
            System.Console.WriteLine("Sessions under "+email+": \n");
            
            for (int i = 0; i < emailCount; i++){
                if(ByEmail[i].GetCustomerEmail()==email){
                    System.Console.WriteLine(ByEmail[i].ToString());
                    System.Console.WriteLine();
                }
            }
        }

        public void SessionsByTrainer(){
            Console.Clear();
            Booking[] ByTrainer = new Booking[100];
            System.Console.WriteLine("Please enter trainer name: ");
            int trainerCount = 0;
            string trainerName = Console.ReadLine();
            int c = 0;
            while(c == 0){
                for(int i = 0; i < Booking.GetCount(); i++){
                    if((trainerName).ToUpper() == (bookingUtility.bookings[i].GetTrainerName()).ToUpper()){
                        ByTrainer[trainerCount] = bookingUtility.bookings[i];
                        trainerCount++;
                        c++;
                    }
                }
                        
                if(c == 0){
                    System.Console.WriteLine("No sessions under entered trainer name. Please enter valid name: ");
                    trainerName = Console.ReadLine();
                }   
            }
            printSessionsByTrainer(trainerCount, trainerName, ByTrainer);
            System.Console.WriteLine("_______________________________\n");
            System.Console.WriteLine("\nWould you like to save this report to a file? (Y/N):");
            string takenInput = Console.ReadLine();
            if (takenInput.ToUpper() == "Y")
            {
                SaveReport(ByTrainer, trainerCount);
            }
        }
        public void printSessionsByTrainer(int trainerCount, string trainerName, Booking[] ByTrainer){
            Console.Clear();
            System.Console.WriteLine("_______________________________\n");
            System.Console.WriteLine("Sessions under "+trainerName+": \n");
                    
            for (int i = 0; i < trainerCount; i++){
                if(ByTrainer[i].GetTrainerName()==trainerName){
                    System.Console.WriteLine(ByTrainer[i].ToString());
                    System.Console.WriteLine();
                }
            }
        }

        public void SaveReport(Booking[] report, int count){
            Console.Clear();
            System.Console.WriteLine("Please enter the name of the file that you would like this report to be saved to: ");
            string fileName = Console.ReadLine();
            StreamWriter outFile = new StreamWriter(fileName+".txt");

            for (int i = 0; i < count; i++){
                 outFile.WriteLine(report[i].ToFile());
            }

            outFile.Close();
            System.Console.WriteLine("Report saved to file "+fileName+".txt");
        }
        public void HistoricalCustomerSessions(){
            Console.Clear();
            bookingUtility.GetAllBookingsFromFile();
            Booking[] bookings = bookingUtility.bookings;
            
            int count = Booking.GetCount();
            
            
            // Selection sort by customer email and date
            for (int i = 0; i < Booking.GetCount(); i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (bookings[j].GetCustomerEmail().CompareTo(bookings[minIndex].GetCustomerEmail()) < 0 ||
                        (bookings[j].GetCustomerEmail() == bookings[minIndex].GetCustomerEmail() &&
                        bookings[minIndex].GetTrainingDate().CompareTo(bookings[j].GetTrainingDate()) > 0))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Booking temp = bookings[i];
                    bookings[i] = bookings[minIndex];
                    bookings[minIndex] = temp;
                }
            }
            
            string currentCustomerEmail = "";
            
            int totalSessions = 0;
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                
                string customerEmail = bookings[i].GetCustomerEmail();
                
                
                
                if (customerEmail != currentCustomerEmail)
                {
                    if (totalSessions > 0)
                    {
                        System.Console.WriteLine("Total sessions for " + currentCustomerEmail + ": " + totalSessions + "\n");
                        System.Console.WriteLine("_______________________________\n");
                    }
                    System.Console.WriteLine("\nCustomer email: " + customerEmail + "\n");
                    currentCustomerEmail = customerEmail;
                    totalSessions = 0;
                }
                System.Console.WriteLine(bookings[i].ToString() + "\n");
                totalSessions++;
            }
            
            System.Console.WriteLine("Total sessions for " + currentCustomerEmail + ": " + totalSessions + "\n");
            System.Console.WriteLine("_______________________________\n");

            System.Console.WriteLine("\nWould you like to save this report to a file? (Y/N):");
            string takenInput = Console.ReadLine();
            if (takenInput.ToUpper() == "Y")
            {
                SaveReport(bookings, Booking.GetCount());
            }
                
            }

            public void HistoricalRevenueReport()
            {
                Console.Clear();                
                Booking[] bookings = bookingUtility.bookings;
                listingUtility.GetAllListingsFromFile();
                int count = Booking.GetCount();

                //bubble sort
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = 0; j < count - i - 1; j++)
                    {
                        if (bookings[j].GetTrainingDate().CompareTo(bookings[j + 1].GetTrainingDate()) > 0)
                        {
                            Booking temp = bookings[j];
                            bookings[j] = bookings[j + 1];
                            bookings[j + 1] = temp;
                        }
                    }
                }
                bookingUtility.bookings = bookings;

                DateTime book1ng = DateTime.Parse(bookings[0].GetTrainingDate());
            
                string listingID = bookings[0].GetSessionID();
                int index = listingUtility.FindListing(listingID);
                double totalRevenue = listingUtility.listings[index].GetSessionCost();
                    int currentMonth = book1ng.Month;
                    int currentYear = book1ng.Year;
                for (int i = 1; i < Booking.GetCount(); i++){
                    DateTime trainingDate = DateTime.Parse(bookings[i].GetTrainingDate());
                    
                    listingID = bookings[i].GetSessionID();
                    index = listingUtility.FindListing(listingID);
                    double cost = listingUtility.listings[index].GetSessionCost();
                    if (trainingDate.Month == currentMonth && trainingDate.Year == currentYear)
                    {
                        
                        if(bookings[i].GetStatus() == "completed"){
                            totalRevenue += cost;
                        }
        
                    }
                    else{
                        Console.WriteLine("Total revenue for " + (currentMonth) + "/" + currentYear + ": " + totalRevenue.ToString("C") + "\n");
                        totalRevenue = cost;
                        currentMonth = trainingDate.Month;
                        currentYear = trainingDate.Year;
                    }
                    
                    
                }
                Console.WriteLine("Total revenue for " + (currentMonth) + "/" + currentYear + ": " + totalRevenue.ToString("C") + "\n");

}

        public void AvgCostByTrainer(){
            Console.Clear();
            bookingUtility.GetAllBookingsFromFile();
            Booking[] bookings = bookingUtility.bookings;
            listingUtility.GetAllListingsFromFile();
            double avg = 0;
            int count = Booking.GetCount();
            
            // Selection sort by trainer
            for (int i = 0; i < Booking.GetCount(); i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (bookings[i].GetTrainerName().CompareTo(bookings[minIndex].GetTrainerName()) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Booking temp = bookings[i];
                    bookings[i] = bookings[minIndex];
                    bookings[minIndex] = temp;
                }
            }
            string currTrainer = bookings[0].GetTrainerName();
            int c = 1;
            string ID = bookings[0].GetSessionID();
            int index = listingUtility.FindListing(ID);
            double sum  = listingUtility.listings[index].GetSessionCost();
            for (int i = 1; i < Booking.GetCount(); i++){
                if(bookings[i].GetTrainerName() == currTrainer){
                    ID = bookings[i].GetSessionID();
                    index = listingUtility.FindListing(ID);
                    sum += listingUtility.listings[index].GetSessionCost();
                    c++;
                }
                else{
                    avg = sum/c;
                    ProcessBreak(ref sum, avg, bookings, i, ref currTrainer, ref c);
                }
            }
            avg = sum / c;
            ProcessBreak(currTrainer, avg);
             
        }

        public void ProcessBreak(ref double sum, double avg, Booking[] bookings, int i, ref string currTrainer, ref int c){
                System.Console.WriteLine("Trainer "+currTrainer+"average cost: $"+avg);
                currTrainer = bookings[i].GetTrainerName();
                string ID = bookings[i].GetSessionID();
                int index = listingUtility.FindListing(ID);
                sum = listingUtility.listings[index].GetSessionCost();
                c = 1;
                }  

        public void ProcessBreak(string currTrainer, double avg){
                            System.Console.WriteLine("Trainer "+currTrainer+"average cost: $"+avg);

        }

        public void MinMax(){
            Console.Clear();
            listingUtility.GetAllListingsFromFile();
            double min = listingUtility.listings[0].GetSessionCost();
            string minID = listingUtility.listings[0].GetListingID();
            double max = listingUtility.listings[0].GetSessionCost();
            string maxID = listingUtility.listings[0].GetListingID();
            for(int i = 1; i < Listing.GetCount(); i++){
                if(listingUtility.listings[i].GetSessionCost() < min){
                    min = listingUtility.listings[i].GetSessionCost();
                    minID = listingUtility.listings[i].GetListingID();
                }
                else if(listingUtility.listings[i].GetSessionCost() > max){
                    max = listingUtility.listings[i].GetSessionCost();
                    maxID = listingUtility.listings[i].GetListingID();
                }
            }
            System.Console.WriteLine("Most expensive listing: Listing "+maxID+" $"+max);
            System.Console.WriteLine("Cheapest listing: Listing "+minID+" $"+min);

        }

        public void ListingsByCost(){
            Console.Clear();
            listingUtility.GetAllListingsFromFile();
            string id;
            System.Console.WriteLine("Please enter maximum price for session: ");
            double max = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Please enter minimum price for session: ");
            double min = double.Parse(Console.ReadLine());
            Console.Clear();
            System.Console.WriteLine("Listings between $"+min+"-$"+max);
            System.Console.WriteLine();
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listingUtility.listings[i].GetSessionCost() >= min && listingUtility.listings[i].GetSessionCost()<= max){
                    id = listingUtility.listings[i].GetListingID();
                    System.Console.WriteLine("Listing "+id+" $"+listingUtility.listings[i].GetSessionCost());
                }
            }

        }

        public void PairsUnder100(){
            Console.Clear();
            double cost;
            listingUtility.GetAllListingsFromFile();
            System.Console.WriteLine("\nPairs of listings under $100: \n");
            for(int I = 0; I < Listing.GetCount( ); I++){
                for(int j = I+1; j <Listing.GetCount( ); j++){
                
                    if(listingUtility.listings[I].GetSessionCost( ) + listingUtility.listings[j].GetSessionCost( ) <= 100){
                        cost = listingUtility.listings[I].GetSessionCost( ) + listingUtility.listings[j].GetSessionCost( );
                        System.Console.WriteLine("Listing "+listingUtility.listings[I].GetListingID( )+" and Listing "+listingUtility.listings[j].GetListingID( )+" cost $"+cost+" combined");
                    }
                }

        }

}}}
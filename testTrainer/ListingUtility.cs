namespace testTrainer{
     public class ListingUtility
    {
        public Listing[] listings = new Listing[100];

        public string[] ids = new string[100];
        private string[] names = new string[100];
        
        public TrainerUtility trainerUtility = new TrainerUtility();
        public ListingUtility()
        {
           
        }

        

          
        public void GetAllListingsFromFile()
        {
            StreamReader inFile = new StreamReader("listings.txt");
            Listing newListing = new Listing();
            trainerUtility.GetAllTrainersFromFile();
            //populates array of trainer names to be displayed later
            for(int i = 0; i < Trainer.GetCount(); i++){
                names[i] = trainerUtility.trainers[i].GetTrainerName();
            }
            
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(
                    temp[0], temp[1], temp[2], temp[3], Convert.ToDouble(temp[4]), Convert.ToBoolean(temp[5]));
                listings[Listing.GetCount()].SetTrainerID(trainerUtility.FindID(temp[1]));
                
                ids[Listing.GetCount()] = temp[0];
                
                Listing.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void AddListing()
        {
            Listing newListing = new Listing();
            System.Console.WriteLine("Taken listing ID's: ");
                    for(int i = 0; i < Listing.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nWhat is the listing ID you would like to add?");
            string searchVal1 = Console.ReadLine();
            while(searchVal1 != "STOP"){
                if(FindListing(searchVal1) == -1){
                    newListing.SetListingID(searchVal1);
                    searchVal1 = "STOP";
                }
                else{
                    System.Console.WriteLine("Listing ID already exists. Please enter another ID.");
                    searchVal1 = Console.ReadLine();
                }
            }
            Console.Clear();
            System.Console.WriteLine("Available trainers: ");
            for(int i = 0; i < Trainer.GetCount(); i++){
                System.Console.Write(names[i]+", ");
            }
            System.Console.WriteLine("\n\nWhat is the name of the trainer you would like to add?");
            string searchVal2 = Console.ReadLine();
            while(searchVal2 != "STOP"){
                if(trainerUtility.FindName(searchVal2) == 1){
                    newListing.SetTrainerName(searchVal2);
                    string id = trainerUtility.FindID(searchVal2);
                    newListing.SetTrainerID(id);
                    searchVal2 = "STOP";
                }
                else {
                    System.Console.WriteLine("Trainer name is not in system. Please enter existing trainer name.");
                    searchVal2 = Console.ReadLine();
                }
            }
            System.Console.WriteLine("\nWhat is the date of the session you would like to add? (MM/DD/YYYY)");
            newListing.SetSessionDate(Console.ReadLine());
            System.Console.WriteLine("\nWhat is the time of the session you would like to add? (HH:MM AM/PM)");
            newListing.SetSessionTime(Console.ReadLine());
            System.Console.WriteLine("\nWhat is the cost of the session you would like to add?");
            newListing.SetSessionCost(Convert.ToDouble(Console.ReadLine()));
            System.Console.WriteLine("\nHas the session been taken? (Y/N):");
            string takenInput = Console.ReadLine();
            if (takenInput.ToUpper() == "Y")
            {
                newListing.SetSessionTaken(true);
            }
            else
            {
                newListing.SetSessionTaken(false);
            }

            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();
            Save();
        }

       public void EditListing()
        {
            System.Console.WriteLine("Listing ID's: ");
                    for(int i = 0; i < Listing.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nPlease enter the listing ID of the listing you want to edit:");
            string id = Console.ReadLine();

            int index = FindListing(id);
            while (id != "STOP"){
                if (index >= 0)
                {
                    System.Console.WriteLine("Enter new details for the listing:");
                    System.Console.WriteLine("Taken listing ID's: ");
                        for(int i = 0; i < Listing.GetCount(); i++){
                            System.Console.Write(ids[i]+", ");
                        }
                    System.Console.WriteLine("\n\nWhat is the new listing ID? (or leave blank to keep current value)");
                    string newListingID = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newListingID))
                    {
                        string searchVal1 = newListingID;
                        while(searchVal1 != "STOP"){
                            if(FindListing(searchVal1) == -1){
                                listings[index].SetListingID(searchVal1);
                                searchVal1 = "STOP";
                            }
                            else{
                                System.Console.WriteLine("Listing ID already exists. Please enter another ID.");
                                searchVal1 = Console.ReadLine();
                            }
                        }
                    }
                    System.Console.WriteLine("Available trainers: ");
                    for(int i = 0; i < Trainer.GetCount(); i++){
                        System.Console.Write(names[i]+", ");
                    }
                    System.Console.WriteLine("\n\nWhat is the new trainer name? (or leave blank to keep current value)");
                    string newTrainerName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newTrainerName))
                    {
                        string searchVal = newTrainerName;
                        while(searchVal != "STOP"){
                            if(trainerUtility.FindName(searchVal) == 1){
                                listings[index].SetTrainerName(searchVal);
                                searchVal = "STOP";
                            }
                            else {
                                System.Console.WriteLine("Trainer name is not in system. Please enter existing trainer name.");
                                searchVal = Console.ReadLine();
                            }
                }
                    }

                    System.Console.WriteLine("What is the new date of the session? (MM/DD/YYYY or leave blank to keep current value)");
                    string newSessionDate = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newSessionDate))
                    {
                        listings[index].SetSessionDate(newSessionDate);
                    }

                    System.Console.WriteLine("What is the new time of the session? (HH:MM AM/PM or leave blank to keep current value)");
                    string newSessionTime = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newSessionTime))
                    {
                        listings[index].SetSessionTime(newSessionTime);
                    }

                    System.Console.WriteLine("What is the new cost of the session? (or leave blank to keep current value)");
                    string newSessionCost = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newSessionCost))
                    {
                        double cost;
                        if (double.TryParse(newSessionCost, out cost))
                        {
                            listings[index].SetSessionCost(cost);
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid cost input, keeping current value.");
                        }
                    }

                    System.Console.WriteLine("Has the session been taken? (Y/N or leave blank to keep current value):");
                    string takenInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(takenInput))
                    {
                        if (takenInput.ToUpper() == "Y")
                        {
                            listings[index].SetSessionTaken(true);
                        }
                        else
                        {
                            listings[index].SetSessionTaken(false);
                        }
                    }

                    Save();
                    id = "STOP";
                }
                else
                {
                    System.Console.WriteLine("Listing with ID " + id + " not found. Please enter valid listing ID.");
                    index = FindListing(Console.ReadLine());
                }
            }
        }
        

        public void DeleteListing()
        {
            System.Console.WriteLine("Listing ID's: ");
                    for(int i = 0; i < Listing.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nPlease enter the listing ID of the listing you want to delete:");
            string id = Console.ReadLine();

            
            while (id != "STOP"){
                int indexToDelete = FindListing(id);
                if (indexToDelete == -1)
                {
                    System.Console.WriteLine("Listing with ID " + id + " not found. Please enter valid listing ID.");
                    id = Console.ReadLine();
                }
                else
                {
                    for (int i = indexToDelete; i < Listing.GetCount() - 1; i++)
                    {
                        listings[i] = listings[i + 1];
                    }

                    Listing.DecCount();
                    System.Console.WriteLine("Listing with ID "+id+" has been deleted.");
                    id = "STOP";
                    Save();
                }
            
            }
        }

        public int FindListing(string listingID)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if (listingID == listings[i].GetListingID())
                {
                    return i;
                }
            }
            return -1;
        }
        public void Save(){
            
            StreamWriter outFile = new StreamWriter("listings.txt");

            for (int i = 0; i < Listing.GetCount(); i++){
                 outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }

        public void PrintAllListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToString());
                System.Console.WriteLine();
            }
        }

    }}
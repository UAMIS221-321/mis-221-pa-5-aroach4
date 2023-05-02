namespace testTrainer{
    public class TrainerUtility{
        public Trainer[] trainers = new Trainer[100];
        public string[] ids = new string[100];
        public TrainerUtility(){
            
        }

        

        public void GetAllTrainersFromFile()
        {
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer newTrainer = new Trainer();
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(temp[0], temp[1], temp[2], temp[3]);
                ids[Trainer.GetCount()] = temp[0];
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void AddTrainer(){
            Trainer newTrainer = new Trainer();
            System.Console.WriteLine("Taken trainer ID's: ");
                    for(int i = 0; i < Trainer.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nWhat is the trainer ID you would like to add?");
            string searchVal1 = Console.ReadLine();
            while(searchVal1 != "STOP"){
                if(FindTrainer(searchVal1) == -1){
                    newTrainer.SetTrainerID(searchVal1);
                    searchVal1 = "STOP";
                }
                else{
                    System.Console.WriteLine("Trainer ID already exists. Please enter another ID.");
                    searchVal1 = Console.ReadLine();
                }
            }
            System.Console.WriteLine("\nWhat is the name of the trainer you would like to add?");
            newTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("\nWhat is the mailing address you would like to add?");
            newTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("\nWhat is the email address you would like to add?");
            newTrainer.SetEmailAddress(Console.ReadLine());
            trainers[Trainer.GetCount()] = newTrainer;
            Trainer.IncCount();
            Save();
        }

        public void EditTrainer()
        {
            System.Console.WriteLine("Trainer ID's: ");
                    for(int i = 0; i < Trainer.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nPlease enter Trainer ID of Trainer you would like to edit.");
            string trainerID = Console.ReadLine();
            int index = FindTrainer(trainerID);
            while (trainerID != "STOP"){
                if (index >= 0)
                {
                    System.Console.WriteLine("\nEnter new Trainer ID (or leave blank to keep current value):");
                    string newID = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newID))
                    {
                        trainers[index].SetTrainerID(newID);
                    }
                    System.Console.WriteLine("\nEnter new Trainer Name (or leave blank to keep current value):");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        trainers[index].SetTrainerName(newName);
                    }
                    System.Console.WriteLine("\nEnter new Mailing Address (or leave blank to keep current value):");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newAddress))
                    {
                        trainers[index].SetMailingAddress(newAddress);
                    }
                    System.Console.WriteLine("\nEnter new Email Address (or leave blank to keep current value):");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        trainers[index].SetEmailAddress(newEmail);
                    }
                    Save();
                    trainerID = "STOP";
                }
                else
                {
                    System.Console.WriteLine("Trainer with ID " + trainerID + " not found. Please enter valid trainer ID.");
                    index = FindTrainer(Console.ReadLine());
                }
            }
        }

        
        public void Save(){
            
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for (int i = 0; i < Trainer.GetCount(); i++){
                 outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        public int FindTrainer(string trainerID){
            for (int i = 0; i < Trainer.GetCount(); i++){
                if (trainerID == trainers[i].GetTrainerID()){
                    return i;            
                }
            }
            return -1;
        }

        public int FindName(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return 1;
                }
            }
            return -1;
        }

        public string FindID(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return trainers[i].GetTrainerID();
                }
            }
            return " ";
        }


        public void DeleteTrainer()
        {
            System.Console.WriteLine("Trainer ID's: ");
                    for(int i = 0; i < Trainer.GetCount(); i++){
                        System.Console.Write(ids[i]+", ");
                    }
            System.Console.WriteLine("\n\nPlease enter Trainer ID of Trainer you would like to delete.");
            string idToDelete = Console.ReadLine();
            while(idToDelete != "STOP"){
                int indexToDelete = FindTrainer(idToDelete);
                if (indexToDelete == -1)
                {
                    System.Console.WriteLine($"Trainer with ID {idToDelete} not found. Please enter valid trainer ID.");
                    indexToDelete = FindTrainer(Console.ReadLine());
                    
                }
                else{
                    // Shift the elements of the array left to remove the deleted trainer.
                    for (int i = indexToDelete; i < Trainer.GetCount() - 1; i++)
                    {
                        trainers[i] = trainers[i + 1];
                    
                    }
                    Trainer.DecCount();
                    Save();
                    System.Console.WriteLine($"Trainer with ID {idToDelete} deleted.");
                    idToDelete = "STOP";
                }
        }
        }

        public void PrintAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

    }}

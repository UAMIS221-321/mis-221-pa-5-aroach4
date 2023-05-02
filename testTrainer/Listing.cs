namespace testTrainer{
    public class Listing
    {
        private static int count = 0;

        private string listingID;
        private string trainerName;
        private string trainerID;
        private string sessionDate;
        private string sessionTime;
        private double cost;
        private bool isTaken;

        public Listing()
        {
        }

        public Listing(string listingID, string trainerName, string sessionDate, string sessionTime, double cost, bool isTaken)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.cost = cost;
            this.isTaken = isTaken;
        }

        public string GetListingID()
        {
            return this.listingID;
        }

        public void SetListingID(string listingID)
        {
            this.listingID = listingID;
        }
        

        public string GetTrainerName()
        {
            return this.trainerName;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerID(){
            return this.trainerID;
        }
        public void SetTrainerID(string trainerID){
            this.trainerID = trainerID;
        }

        public string GetSessionDate()
        {
            return this.sessionDate;
        }

        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }

        public string GetSessionTime()
        {
            return this.sessionTime;
        }

        public void SetSessionTime(string sessionTime)
        {
            this.sessionTime = sessionTime;
        }

        public double GetSessionCost()
        {
            return this.cost;
        }

        public void SetSessionCost(double cost)
        {
            this.cost = cost;
        }

        public bool GetSessionTaken()
        {
            return this.isTaken;
        }

        public void SetSessionTaken(bool isTaken)
        {
            this.isTaken = isTaken;
        }

        static public void SetCount(int count)
        {
            Listing.count = count;
        }
        static public void IncCount()
        {
            Listing.count++;
        }
        static public int GetCount()
        {
            return count;
        }
        static public void DecCount(){
            Listing.count--;
        }

        public string ToFile()
        {
            string output = this.listingID + "#" + this.trainerName + "#" + this.sessionDate + "#" + this.sessionTime + "#" + this.cost.ToString() + "#" + this.isTaken.ToString();
            return output;
        }

        public override string ToString()
        {
            string output = "Listing ID: " + this.listingID + "\n" + "Trainer Name: " + this.trainerName + "\n" + "Session Date: " + this.sessionDate + "\n" + "Session Time: " + this.sessionTime + "\n" + "Cost: $" + this.cost.ToString() + "\n" + "Is Taken: " + this.isTaken.ToString();
            return output;
        }
    }
}
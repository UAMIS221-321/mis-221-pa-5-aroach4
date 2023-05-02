namespace testTrainer
{
    public class Booking
    {
        public string sessionID;
        public string customerName;
        public string customerEmail;
        public string trainingDate;
        public string trainerID;
        public string trainerName;

      
        public string status = "booked";
        private static int count = 0;

        

    

        public Booking(){
        
        }

        public Booking(string sessionID, string customerName, string customerEmail, string trainingDate, string trainerID, string trainerName, string status) 
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }
        

        public void SetSessionID(string sessionID)
        {
            this.sessionID = sessionID;
        }

        public string GetSessionID()
        {
            return sessionID;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        }

        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
        }

        public string GetTrainingDate()
        {
            
            return trainingDate;
        }

        

        

        public void SetTrainerID(string trainerID)
        {
            this.trainerID = trainerID;
        }

        public string GetTrainerID()
        {
            return trainerID;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public string GetStatus()
        {
            return status;
        }
        public override string ToString()
        {
            return $"Session ID: {this.sessionID} \nCustomer Name: {this.customerName} \nCustomer Email: {this.customerEmail}  \nTraining Date: {this.trainingDate} \nTrainer ID: {this.trainerID} \nTrainer Name: {this.trainerName} \nStatus: {this.status}";
        }
        static public void SetCount(int count)
        {
            Booking.count = count;
        }
        static public void IncCount()
        {
            Booking.count++;
        }
        static public int GetCount()
        {
            return count;
        }
        static public void DecCount(){
            Booking.count--;
        }
        
        public string ToFile(){
            return $"{this.sessionID}#{this.customerName}#{this.customerEmail}#{this.trainingDate}#{this.trainerID}#{this.trainerName}#{this.status}";
        }
}
}
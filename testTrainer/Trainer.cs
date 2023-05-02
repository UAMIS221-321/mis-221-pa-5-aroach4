namespace testTrainer{
public class Trainer {
//instance variables
    private string trainerID;

    private string trainerName;

    private string mailingAddress;

    private string emailAddress;
   

    static private int count;

//blank constructor
    public Trainer(){

    }
//constructor
    public Trainer(string trainerID, string trainerName, string mailingAddress, string emailAddress){
        this.trainerID = trainerID;
        this.trainerName = trainerName;
        this.mailingAddress = mailingAddress;
        this.emailAddress = emailAddress;
        
    }

    public void SetTrainerID(string trainerID){
        this.trainerID = trainerID;
    }

    public string GetTrainerID(){
        return trainerID;
    }
    public void SetTrainerName(string trainerName){
        this.trainerName = trainerName;
    }
    public string GetTrainerName(){
        return trainerName;
    }
    public void SetMailingAddress(string mailingAddress){
        this.mailingAddress = mailingAddress;
    }

    public string GetMailingAddress(){
        return mailingAddress;
    }
    public void SetEmailAddress(string emailAddress){
        this.emailAddress = emailAddress;
    }

    public string GetEmailAddress(){
        return emailAddress;
    }
    
    static public void SetCount(int count)
        {
            Trainer.count = count;
        }
        static public void IncCount()
        {
            Trainer.count++;
        }
        static public int GetCount()
        {
            return count;
        }
        static public void DecCount(){
            Trainer.count--;
        }

   public override string ToString()
        {
            return $"ID: {this.trainerID} Name: {this.trainerName} Address: {this.mailingAddress}  Email: {this.emailAddress}";
        }
    public string ToFile(){
        return $"{this.trainerID}#{this.trainerName}#{this.mailingAddress}#{this.emailAddress}";
    }
   

}}
namespace API.Helpers;

public class SMSSettings
{
    public string Twilio_Account_SID { 
        get {
            return "Account SID";
        } 
    }
    public string Twilio_Auth_TOKEN {
        get
        {
            return "Auth Token";
        }
    }
    public string Twilio_Phone_Number
    {
        get
        {
            return "My Twilio phone number";
        }
    }
} 
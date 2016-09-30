public class OTPResponse
{
    public TwilioResponse TwilioResponse;    
}

public class TwilioResponse
{
    public SMSMessage SMSMessage;
}

public class SMSMessage
{
    public string Status;
}
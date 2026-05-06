using System;

interface INotification
{
    void Send(string message);
}

class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine("Email: " + message);
}

class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine("SMS: " + message);
}

class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine("Push: " + message);
}

class NotificationFactory
{
    public INotification CreateNotification(string type)
    {
        switch (type.ToLower())
        {
            case "email": return new EmailNotification();
            case "sms": return new SMSNotification();
            case "push": return new PushNotification();
            default: throw new Exception("Invalid type");
        }
    }
}

class Program
{
    static void Main()
    {
        var factory = new NotificationFactory();
        var notification = factory.CreateNotification("email");

        notification.Send("Welcome!");
    }
}
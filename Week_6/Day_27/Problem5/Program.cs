using System;

class ConfigurationManager
{
    private static ConfigurationManager instance;

    private ConfigurationManager() { }

    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
            instance = new ConfigurationManager();

        return instance;
    }

    public string AppName = "MyApp";
}

class Program
{
    static void Main()
    {
        var obj1 = ConfigurationManager.GetInstance();
        var obj2 = ConfigurationManager.GetInstance();

        Console.WriteLine(obj1.AppName);
        Console.WriteLine("Same Instance: " + (obj1 == obj2));
    }
}
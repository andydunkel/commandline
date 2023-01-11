// See https://aka.ms/new-console-template for more information

namespace CheckServer;

static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            PrintHelp();
            return;
        }
        
        MainAsync(args[0]).Wait();    
    }
    
    static async Task MainAsync(string url)
    {
        var uri = new Uri(url, UriKind.Absolute);
        
        using var client = new HttpClient();
        client.Timeout = new TimeSpan(0, 0, 5);

        try
        {
            var result = await client.GetAsync(uri);
            Console.WriteLine((int)result.StatusCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
    }

    private static void PrintHelp()
    {
        Console.WriteLine("Usage: CheckServer.exe https://mydomain.de");
    }
}


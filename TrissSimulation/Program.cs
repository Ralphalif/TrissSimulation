using System;

internal class Program
{
    private static bool _endApp;
    private static int Total { get; set; }
    private static int Count { get; set; }
    private static int LargestWin { get; set; }
    private static int NoOfWinningTickets { get; set; }

    private static void Main()
    {
        StartSimulation();
        while (!_endApp)
        {
            ProcessTicketPurchase();
            HandleUserInput();
        }
    }

    private static void StartSimulation()
    {
        Total = 0;
        Count = 0;
        LargestWin = 0;
        NoOfWinningTickets = 0;

        Console.WriteLine("Sindis Triss-Simulator");
        Console.WriteLine("------------------------");
        Console.Write("Tryck på en enter för att köpa en trisslott för 30 kr!\n");
        Console.Write("Tryck på s + enter för statistik!\n");
        Console.Write("Tryck på r + enter för omstart!\n");
        Console.Write("Tryck på h + enter för hjälp!\n");
        Console.Write("Tryck på n + enter för att avsluta!\n");
        Console.ReadLine();
    }

    private static void ProcessTicketPurchase()
    {
        Total -= 30;
        Count++;
        try
        {
            var result = NewTicket();
            Total += result;
            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Grattis! Du vann {result} kronor på lott #{Count}!");
                if (result > LargestWin)
                {
                    if (LargestWin > 0)
                    {
                        Console.WriteLine($"Det är din största vinst hittills! Din tidigare största vinst låg på {LargestWin} kr!");
                    }
                    LargestWin = result;
                }
                NoOfWinningTickets++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Attans! Lott #{Count} var en nitlott! ");
            }

            WriteTotalWinnings();
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
        }

        Console.WriteLine("------------------------");
        Console.Write("Tryck på enter för att köpa en till lott för 30 kr!\n");
    }

    private static void HandleUserInput()
    {
        switch (Console.ReadLine())
        {
            case "n":
                GetStats();
                _endApp = true;
                break;
            case "s":
                GetStats();
                Console.ReadLine();
                Console.Clear();
                break;
            case "r":
                Console.Clear();
                StartSimulation();
                break;
            case "h":
                Console.Clear();
                StartSimulation();
                break;
        }
    }

    public static int NewTicket()
    {
        var rand = new Random();
        var randomNumber = rand.Next(1, 2000000);

        if (randomNumber == 1)
        {
            return 27565000;
        }
        else if (randomNumber < 2)
        {
            return 1000000;
        }
        else if (randomNumber < 7)
        {
            return 265000;
        }
        else if (randomNumber < 8)
        {
            return 200000;
        }
        else if (randomNumber < 10)
        {
            return 100000;
        }
        else if (randomNumber < 13)
        {
            return 50000;
        }
        else if (randomNumber < 21)
        {
            return 20000;
        }
        else if (randomNumber < 76)
        {
            return 10000;
        }
        else if (randomNumber < 97)
        {
            return 5000;
        }
        else if (randomNumber < 112)
        {
            return 2500;
        }
        else if (randomNumber < 192)
        {
            return 1500;
        }
        else if (randomNumber < 352)
        {
            return 1000;
        }
        else if (randomNumber < 412)
        {
            return 900;
        }
        else if (randomNumber < 463)
        {
            return 750;
        }
        else if (randomNumber < 662)
        {
            return 600;
        }
        else if (randomNumber < 862)
        {
            return 500;
        }
        else if (randomNumber < 987)
        {
            return 450;
        }
        else if (randomNumber < 1917)
        {
            return 300;
        }
        else if (randomNumber < 3117)
        {
            return 180;
        }
        else if (randomNumber < 6857)
        {
            return 150;
        }
        else if (randomNumber < 14057)
        {
            return 120;
        }
        else if (randomNumber < 40057)
        {
            return 90;
        }
        else if (randomNumber < 240410)
        {
            return 60;
        }
        else if (randomNumber < 428929)
        {
            return 30;
        }

        return 0;
    }

    private static void GetStats()
    {
        Console.Clear();
        Console.WriteLine($"\nDu har köpt {Count} lotter.");
        Console.WriteLine($"Av dem vann du på {NoOfWinningTickets} st.");
        Console.WriteLine($"Din största vinst låg på {LargestWin} kr.\n");
        WriteTotalWinnings();
    }

    private static void WriteTotalWinnings()
    {
        if (Total > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Din totala vinst är {Total} kronor!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Din totala förlust är {Total} kronor!");
        }
    }
}

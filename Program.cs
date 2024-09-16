using System.Security.Cryptography.X509Certificates;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            do
            {   
                MenuHelper.ShowMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        isActive = false;
                        break;
                    case "1":
                        PrintThePrice(GetUIntInput("ålder"));
                        break;
                    case "2":
                        uint nrOfGuests = GetUIntInput("Antal gäster "); //Build logic for if input is zero
                        uint totalCost = 0;
                        for (int i = 1; i <= nrOfGuests; i++)
                        {
                            uint ageInput = GetUIntInput($"Ange åldern för person {i}: ");
                            uint price = GetPriceBasedOnAge(ageInput);
                                totalCost += price;
                        }
                        PrintMessage($"\nAntal personer: {nrOfGuests} \nTotalkostnad för hela sällskapet: {totalCost} kr");
                        break;
                    case "3":
                        PrintMessage(GetStringInput("meddelande"), 10);
                        break;
                    case "4":
                        int wordCount = 3;
                        string messageToSplit = GetStringInput($"meddelande med minst {wordCount} ord: ");
                        //Spliting the user input and adding option in split method that removes empty entries in case of more whitespaces
                        string[] words = messageToSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        while (words.Length < wordCount)
                        {
                            messageToSplit = GetStringInput($"meddelande med minst {wordCount} ord: ");
                            words = messageToSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        }
                        PrintMessage(words.ElementAt(wordCount - 1));
                        break;
                    default:
                        PrintMessage("Vänligen ange ett giltigt alternativ");
                        break;
                }
            }
            while (isActive);
        }

      private static class MenuHelper
        {
            public const string Exit = "0";
            public const string PriceMenu = "1";
            public const string CostCalculator = "2";
            public const string Message = "3";
            public const string WordCountMessage = "4";

public static void ShowMenu()
{
    Console.WriteLine($@"
Välkommen till huvudmenyn. Vänligen välj ditt alternativ:   
{Exit}: Avsluta 
{PriceMenu}: Biljettpris 
{CostCalculator}: Totalkostnad för hela sällskap  
{Message}: Lägg till ett meddelande 
{WordCountMessage}: Skriv minst tre ord");
 }
}


    

    private static uint GetUIntInput(string prompt)
    {
        do
        {
            string input = GetStringInput(prompt);
            if (uint.TryParse(input, out uint result))
            {
                return result;
            }
            else
            {
                PrintMessage($"Vänligen ange ett giltigt {prompt}");
            }
        }
        while (true);
    }


    private static string GetStringInput(string prompt)
    {
        bool isCorrect = false;
        string input;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"Vänligen ange ett giltigt {prompt}");
                input = Console.ReadLine();
            }
            else
            {
                isCorrect = true;
            }
        } while (!isCorrect);

        return input;
    }


    private static void PrintThePrice(uint age)
    {
        if (age > 100 || age < 5) PrintMessage("Gratis tillträde");
        else if (age < 20) PrintMessage("Ungdomspris: 80kr");
        else if (age > 64) PrintMessage("Pensionärspris: 90kr");
        else PrintMessage("Standardpris: 120kr");
    }


    private static uint GetPriceBasedOnAge(uint age)
    {
        if (age > 100 || age < 5) return 0;
        else if (age < 20) return 80;
        else if (age > 64) return 90;
        else return 120;
    }


    private static void PrintMessage(string message, int printCount = 1)
    {
        if (printCount > 1)
        {
            for (int i = 0; i < printCount; i++)
            {
                Console.Write(message);
            }
        }
        else
        {
            Console.WriteLine(message);
        }
    }

    }
}

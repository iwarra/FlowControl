namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            do
            {   //Turn the menu options to variables and refactor the print menu line to be more readable
                Console.WriteLine("\nVälkommen till huvudmenyn. Vänligen välj ditt alternativ: \n0: Avsluta \n1: Biljettpris \n3: Lägg till ett meddelande \n4: Skriv minst tre ord");
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
                        //Add calculation for the whole company
                        break;
                    case "3":
                        PrintMessage(GetStringInput("meddelande"), 10);
                        break;
                    case "4":
                        int wordCount = 3;
                        string messageToSplit = GetStringInput($"meddelande med minst {wordCount} ord: ");
                        //Spliting the user input and adding option in split method that removes empty entries in case of more whitespaces
                        string[] words = messageToSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length < wordCount)
                            GetStringInput($"meddelande med minst {wordCount} ord: ");
                        else PrintMessage(words.ElementAt(wordCount - 1));
                        break;
                    default:
                        PrintMessage("Vänligen ange ett giltigt alternativ");
                        break;
                }
            }
            while (isActive);
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
                Console.WriteLine($"Vänligen ange ett giltigt {prompt}");
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
        if (age > 100 || age < 5) Console.WriteLine("Gratis tillträde");
        else if (age < 20) Console.WriteLine("Ungdomspris: 80kr");
        else if (age > 64) Console.WriteLine("Pensionärspris: 90kr");
        else Console.WriteLine("Standardpris: 120kr");
    }

    private static void PrintMessage(string message, int printCount = 1)
        { 
            if (printCount > 1 )
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

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            do
            {   //Turn the menu options to variables and refactor the print menu line to be more readable
                Console.WriteLine("\nVälkommen till huvudmenyn. Vänligen välj ditt alternativ: \n0: Avsluta \n1: Biljettpris \n2: Totalkostnad för hela sällskap  \n3: Lägg till ett meddelande \n4: Skriv minst tre ord");
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
                        PrintMessage($"\nAntal personer: {nrOfGuests}");
                        PrintMessage($"Totalkostnad för hela sällskapet: {totalCost}kr");
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

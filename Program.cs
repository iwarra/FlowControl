namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {   //Turn the menu options to variables and refactor the print menu line to be more readable
                Console.WriteLine("\nVälkommen till huvudmenyn. Vänligen välj ditt alternativ: \n0: Avsluta \n1: Biljettpris \n3: Lägg till ett meddelande \n4: Skriv minst tre ord");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0": Environment.Exit(0);
                        break;
                    case "1":
                        Console.Write("Vänligen ange din ålder: ");

                        uint age;
                        string ageInput = Console.ReadLine();

                        //Create a method to validate integers ?
                        while (!uint.TryParse(ageInput, out age))
                        {
                            Console.WriteLine("Vänligen ange korrekt ålder");
                            ageInput = Console.ReadLine();
                        }

                        if (age > 100 || age < 5) Console.WriteLine("Gratis tillträde");
                        else if (age < 20) Console.WriteLine("Ungdomspris: 80kr");
                        else if (age > 64) Console.WriteLine("Pensionärspris: 90kr");
                        else Console.WriteLine("Standardpris: 120kr");

                        break;
                    case "2":
                        //Add calculation for the whole company
                        break;
                    case "3":
                        int printCount = 10;
                        Console.WriteLine("Vänligen skriv ditt meddelande: ");
                        string message = Console.ReadLine();

                        while (!IsValidStringInput(message))
                        {
                            Console.WriteLine("Vänligen ange ett giltigt meddelande");
                            message = Console.ReadLine();
                        }

                        for (int i = 0; i < printCount; i++)
                        {
                            Console.Write(message);
                        }
                        break;

                    case "4":
                        int wordCount = 3;
                        Console.WriteLine($"Vänligen skriv ditt meddelande med minst {wordCount} ord: ");
                        string messageToSplit = Console.ReadLine();
                        //Spliting the user input and adding option in split method that removes empty entries in case of more whitespaces
                        string[] words = messageToSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        while (!IsValidStringInput(messageToSplit) || words.Length < 3)
                        {
                            Console.WriteLine("Vänligen ange minst tre ord");
                            messageToSplit = Console.ReadLine();
                        }
                        Console.WriteLine(words.ElementAt(2));
                        break;
                    default:
                        Console.WriteLine("Vänligen ange ett giltigt alternativ");
                        break;
                }
            }
            while (true);
        }

     static bool IsValidStringInput (string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            else 
                return true;
        }


    }
}

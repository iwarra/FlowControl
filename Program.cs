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
                        // Add logic to check if the input is correct
                        int age = int.Parse(Console.ReadLine());
                        if (age > 100 || age < 5) Console.WriteLine("Gratis tillträde");
                        else if (age < 20) Console.WriteLine("Ungdomspris: 80kr");
                        else if (age > 64) Console.WriteLine("Pensionärspris: 90kr");
                        else Console.WriteLine("Standardpris: 120kr");
                        break;
                    case "2":
                        //Add calculation for the whole company
                        break;
                    case "3":
                        int printTimes = 10;
                        Console.WriteLine("Vänligen skriv ditt meddelande: ");
                        //Check user input
                        string message = Console.ReadLine();
                        for (int i = 0; i < printTimes; i++)
                        {
                            Console.Write(message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Vänligen skriv ditt meddelande med minst 3 ord: ");
                        string messageToSplit = Console.ReadLine();
                        //Check the input !
                        //Spliting the user input and adding option in split method that removes empty entries in case of more whitespaces
                        string[] words = messageToSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        //Printing out the third word
                        Console.WriteLine(words.ElementAt(2));
                        break;
                    default:
                        Console.WriteLine("Vänligen ange ett giltigt alternativ");
                        break;
                }
            }
            while (true);
        }
    }
}

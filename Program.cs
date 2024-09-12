namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Välkommen till huvudmenyn. Vänligen välj ditt alternativ: \n0: Avsluta \n1: Biljettpris");
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
                    default:
                        Console.WriteLine("Vänligen ange ett giltigt alternativ");
                        break;
                }
            }
            while (true);
        }
    }
}

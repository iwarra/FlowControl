namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to the main menu. Please select your option: \n0: Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0": Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please provide a valid input");
                        break;
                }
            }
            while (true);
        }
    }
}

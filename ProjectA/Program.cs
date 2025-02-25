internal class Program
{
    private static void Main(string[] args)
    {
        // print list
        Console.WriteLine("C# Threading Project - Select Phase:"
                        + "\n1. Basic Thread Operations"
                        + "\n2. Resource Thread Operations"
                        + "\n3. Deadlock Creation"
                        + "\n4. Dealock Resolution"
                        + "\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        // switch statement for different list options
        switch (choice) 
        {
            case 1:
                // phase 1 option - Basic Threading
                //-Phases.Phase1
                break;
            case 2:
                // phase 2 option - Resource Protection
                //-Phases.Phase3
                break;
            case 3:
                // phase 3 option - Deadlock Creation
                //-Phases.Phase3
                break;
            case 4:
                // phase 4 option - Deadlock Resolution
                //-Phases.Phase4
                break;
            default:
                // default option - invalid choice
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
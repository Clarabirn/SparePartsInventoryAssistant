
class Program
{
    static void Main()
    {
        string[] INVENTORY = { "hydraulic pump", "PLC module", "servo motor" };

        Console.WriteLine("Hej. Welcome to the spare parts inventory!");

        while (true)
        {
            Console.Write("Which part do you need? ");
            string part = (Console.ReadLine() ?? "").Trim();

            // Special queries (små stavefejl er tilladt)
            string low = part.ToLowerInvariant();
            if (low.Contains("have any part") || low.Contains("any parts") || low.Contains("anything in stock") ||
                low.Contains("in stock at all"))
            {
                Console.WriteLine($"We have {INVENTORY.Length} part(s)!");
                foreach (var p in INVENTORY)
                    Console.WriteLine(p);
                // fortsætter loopet efter liste
                continue;
            }

            // Præcis match i forhold til lagerlisten
            if (Array.IndexOf(INVENTORY, part) >= 0)
            {
                Console.WriteLine($"I've got {part} here for you 😊");
                break; // programmet afsluttes først når der er den del man skriver på lager
            }

            // Hvis det ikke findes på lager kommer den besked frem indtil man skriver noget der er på lager
            Console.WriteLine($"I am afraid we don't have any {part} in the inventory 😔");
        }
    }
}
namespace Parking_Lot_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] slots = new string[10];

            while (true)
            {
                Console.WriteLine("\nMenu:\n1 - Park a Car\n2 - Remove a Car\n3 - View All Slots\n4 - Search for a Car\n5 - Exit");
                Console.Write("Please choose from 1 to 5: ");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.Write("Enter car license number: ");
                        string carLicen = Console.ReadLine();

                        // Check for duplicates
                        bool exists = false;
                        foreach (string s in slots)
                        {
                            if (s == carLicen)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (exists)
                        {
                            Console.WriteLine("This car is already parked.");
                            break;
                        }

                        // Find empty slot
                        bool parked = false;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == null)
                            {
                                slots[i] = carLicen;
                                Console.WriteLine($"Car parked in slot {i + 1}.");
                                parked = true;
                                break;
                            }
                        }

                        if (!parked)
                        {
                            Console.WriteLine("Parking lot is full.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter car license number to remove: ");
                        string removeCar = Console.ReadLine();
                        bool removed = false;

                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == removeCar)
                            {
                                slots[i] = null;
                                Console.WriteLine("Car removed from the slot.");
                                removed = true;
                                break;
                            }
                        }

                        if (!removed)
                        {
                            Console.WriteLine("Car not found.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- All Slots ---");
                        for (int i = 0; i < slots.Length; i++)
                        {
                            Console.WriteLine($"Slot {i + 1}: {(slots[i] ?? "NULL")}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter car license number to search: ");
                        string searchCar = Console.ReadLine();
                        bool found = false;

                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == searchCar)
                            {
                                Console.WriteLine($"Car found in slot {i + 1}.");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Car not found in any slot.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Thank you!");
                        return;
                }
            }
        }
    }
}

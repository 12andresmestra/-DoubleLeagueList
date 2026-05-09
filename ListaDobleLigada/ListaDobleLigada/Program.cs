using System;

class Program
{
    static void Main()
    {
        var list = new DoublyLinkedList<string>();
        int option;

        do
        {
            Console.WriteLine("\n1. Add");
            Console.WriteLine("2. Show forward");
            Console.WriteLine("3. Show backward");
            Console.WriteLine("4. Sort descending");
            Console.WriteLine("5. Show mode");
            Console.WriteLine("6. Show graph");
            Console.WriteLine("7. Exists");
            Console.WriteLine("8. Remove one");
            Console.WriteLine("9. Remove all");
            Console.WriteLine("0. Exit");

            Console.Write("Option: ");
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Data: ");
                    list.Add(Console.ReadLine()!);
                    break;

                case 2:
                    list.ShowForward();
                    break;

                case 3:
                    list.ShowBackward();
                    break;

                case 4:
                    list.SortDescending();
                    break;

                case 5:
                    list.ShowMode();
                    break;

                case 6:
                    list.ShowGraph();
                    break;

                case 7:
                    Console.Write("Search: ");
                    Console.WriteLine(list.Exists(Console.ReadLine()!)
                        ? "It exists"
                        : "It does not exist");
                    break;

                case 8:
                    Console.Write("Remove one: ");
                    list.RemoveOne(Console.ReadLine()!);
                    break;

                case 9:
                    Console.Write("Remove all: ");
                    list.RemoveAll(Console.ReadLine()!);
                    break;
            }

        } while (option != 0);
    }
}
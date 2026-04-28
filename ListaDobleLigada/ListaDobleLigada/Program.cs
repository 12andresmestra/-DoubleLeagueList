using System;

class Program
{
    static void Main()
    {
        var lista = new ListaDoble<string>();
        int opcion;

        do
        {
            Console.WriteLine("\n1. Adicionar");
            Console.WriteLine("2. Mostrar adelante");
            Console.WriteLine("3. Mostrar atrás");
            Console.WriteLine("4. Ordenar descendente");
            Console.WriteLine("5. Mostrar moda");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una");
            Console.WriteLine("9. Eliminar todas");
            Console.WriteLine("0. Salir");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Dato: ");
                    lista.Adicionar(Console.ReadLine()!);
                    break;

                case 2:
                    lista.MostrarAdelante();
                    break;

                case 3:
                    lista.MostrarAtras();
                    break;

                case 4:
                    lista.OrdenarDescendente();
                    break;

                case 5:
                    lista.MostrarModa();
                    break;

                case 6:
                    lista.MostrarGrafico();
                    break;

                case 7:
                    Console.Write("Buscar: ");
                    Console.WriteLine(lista.Existe(Console.ReadLine()!) ? "Sí existe" : "No existe");
                    break;

                case 8:
                    Console.Write("Eliminar uno: ");
                    lista.EliminarUna(Console.ReadLine()!);
                    break;

                case 9:
                    Console.Write("Eliminar todos: ");
                    lista.EliminarTodas(Console.ReadLine()!);
                    break;
            }

        } while (opcion != 0);
    }
}
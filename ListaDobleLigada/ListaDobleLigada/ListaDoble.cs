using System;
using System.Collections.Generic;

public class ListaDoble<T> where T : IComparable<T>
{
    private Nodo<T>? cabeza;
    private Nodo<T>? cola;

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
    }

    // 1) ADICIONAR (EN ORDEN ASCENDENTE AUTOMÁTICO)
    public void Adicionar(T dato)
    {
        var nuevo = new Nodo<T>(dato);

        if (cabeza == null)
        {
            cabeza = cola = nuevo;
            return;
        }

        var actual = cabeza;

        // avanzar mientras dato sea mayor (orden ascendente)
        while (actual != null && dato.CompareTo(actual.Dato) > 0)
        {
            actual = actual.Siguiente;
        }

        if (actual == cabeza)
        {
            // insertar al inicio
            nuevo.Siguiente = cabeza;
            cabeza.Anterior = nuevo;
            cabeza = nuevo;
        }
        else if (actual == null)
        {
            // insertar al final
            cola!.Siguiente = nuevo;
            nuevo.Anterior = cola;
            cola = nuevo;
        }
        else
        {
            // insertar en medio
            var anterior = actual.Anterior!;
            anterior.Siguiente = nuevo;
            nuevo.Anterior = anterior;

            nuevo.Siguiente = actual;
            actual.Anterior = nuevo;
        }
    }

    // 2) MOSTRAR ADELANTE
    public void MostrarAdelante()
    {
        var aux = cabeza;
        while (aux != null)
        {
            Console.Write(aux.Dato + " ");
            aux = aux.Siguiente;
        }
        Console.WriteLine();
    }

    // 3) MOSTRAR ATRÁS
    public void MostrarAtras()
    {
        var aux = cola;
        while (aux != null)
        {
            Console.Write(aux.Dato + " ");
            aux = aux.Anterior;
        }
        Console.WriteLine();
    }

    // 4) ORDENAR DESCENDENTE (INVIRTIENDO ENLACES)
    public void OrdenarDescendente()
    {
        var actual = cabeza;
        Nodo<T>? temp = null;

        while (actual != null)
        {
            temp = actual.Anterior;
            actual.Anterior = actual.Siguiente;
            actual.Siguiente = temp;
            actual = actual.Anterior;
        }

        if (temp != null)
        {
            // intercambiar cabeza y cola
            cola = cabeza;
            cabeza = temp.Anterior;
        }
    }

    // 5) MOSTRAR MODA(S)
    public void MostrarModa()
    {
        var conteo = new Dictionary<T, int>();
        var aux = cabeza;

        while (aux != null)
        {
            if (conteo.ContainsKey(aux.Dato))
                conteo[aux.Dato]++;
            else
                conteo[aux.Dato] = 1;

            aux = aux.Siguiente;
        }

        int max = 0;
        foreach (var v in conteo.Values)
            if (v > max) max = v;

        Console.Write("Moda(s): ");
        foreach (var par in conteo)
            if (par.Value == max)
                Console.Write(par.Key + " ");

        Console.WriteLine();
    }

    // 6) MOSTRAR GRÁFICO
    public void MostrarGrafico()
    {
        var conteo = new Dictionary<T, int>();
        var aux = cabeza;

        while (aux != null)
        {
            if (conteo.ContainsKey(aux.Dato))
                conteo[aux.Dato]++;
            else
                conteo[aux.Dato] = 1;

            aux = aux.Siguiente;
        }

        foreach (var par in conteo)
        {
            Console.Write(par.Key + " ");
            for (int i = 0; i < par.Value; i++)
                Console.Write("*");
            Console.WriteLine();
        }
    }

    // 7) EXISTE
    public bool Existe(T dato)
    {
        var aux = cabeza;
        while (aux != null)
        {
            if (aux.Dato!.Equals(dato))
                return true;
            aux = aux.Siguiente;
        }
        return false;
    }

    // 8) ELIMINAR UNA OCURRENCIA
    public void EliminarUna(T dato)
    {
        var aux = cabeza;

        while (aux != null)
        {
            if (aux.Dato!.Equals(dato))
            {
                if (aux == cabeza)
                {
                    cabeza = cabeza.Siguiente;
                    if (cabeza != null) cabeza.Anterior = null;
                    else cola = null;
                }
                else if (aux == cola)
                {
                    cola = cola.Anterior;
                    if (cola != null) cola.Siguiente = null;
                    else cabeza = null;
                }
                else
                {
                    aux.Anterior!.Siguiente = aux.Siguiente;
                    aux.Siguiente!.Anterior = aux.Anterior;
                }
                return;
            }
            aux = aux.Siguiente;
        }
    }

    // 9) ELIMINAR TODAS LAS OCURRENCIAS
    public void EliminarTodas(T dato)
    {
        while (Existe(dato))
        {
            EliminarUna(dato);
        }
    }
}
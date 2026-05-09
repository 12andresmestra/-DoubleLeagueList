using System;
using System.Collections.Generic;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    // 1) ADD (AUTOMATIC ASCENDING ORDER)
    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        var current = head;

        while (current != null && data.CompareTo(current.Data) > 0)
        {
            current = current.Next;
        }

        if (current == head)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        else if (current == null)
        {
            tail!.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        else
        {
            var previous = current.Previous!;
            previous.Next = newNode;
            newNode.Previous = previous;

            newNode.Next = current;
            current.Previous = newNode;
        }
    }

    // 2) SHOW FORWARD
    public void ShowForward()
    {
        var current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // 3) SHOW BACKWARD
    public void ShowBackward()
    {
        var current = tail;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    // 4) SORT DESCENDING
    public void SortDescending()
    {
        var current = head;
        Node<T>? temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        if (temp != null)
        {
            tail = head;
            head = temp.Previous;
        }
    }

    // 5) SHOW MODE(S)
    public void ShowMode()
    {
        var counter = new Dictionary<T, int>();
        var current = head;

        while (current != null)
        {
            if (counter.ContainsKey(current.Data))
                counter[current.Data]++;
            else
                counter[current.Data] = 1;

            current = current.Next;
        }

        int max = 0;
        foreach (var value in counter.Values)
        {
            if (value > max)
                max = value;
        }

        Console.Write("Mode(s): ");
        foreach (var item in counter)
        {
            if (item.Value == max)
                Console.Write(item.Key + " ");
        }

        Console.WriteLine();
    }

    // 6) SHOW GRAPH
    public void ShowGraph()
    {
        var counter = new Dictionary<T, int>();
        var current = head;

        while (current != null)
        {
            if (counter.ContainsKey(current.Data))
                counter[current.Data]++;
            else
                counter[current.Data] = 1;

            current = current.Next;
        }

        foreach (var item in counter)
        {
            Console.Write(item.Key + " ");
            for (int i = 0; i < item.Value; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    // 7) EXISTS
    public bool Exists(T data)
    {
        var current = head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
                return true;

            current = current.Next;
        }

        return false;
    }

    // 8) REMOVE ONE OCCURRENCE
    public void RemoveOne(T data)
    {
        var current = head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == head)
                {
                    head = head.Next;
                    if (head != null)
                        head.Previous = null;
                    else
                        tail = null;
                }
                else if (current == tail)
                {
                    tail = tail.Previous;
                    if (tail != null)
                        tail.Next = null;
                    else
                        head = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return;
            }

            current = current.Next;
        }
    }

    // 9) REMOVE ALL OCCURRENCES
    public void RemoveAll(T data)
    {
        while (Exists(data))
        {
            RemoveOne(data);
        }
    }
}
using System;

class Node
{
    public int id;
    public string name;
    public Node next;

    public Node(int i, string n)
    {
        id = i;
        name = n;
        next = null;
    }
}

class Program
{
    static Node head = null;

    static void InsertEnd(int id, string name)
    {
        Node n = new Node(id, name);

        if (head == null)
        {
            head = n;
            return;
        }

        Node t = head;
        while (t.next != null)
            t = t.next;

        t.next = n;
    }

    static void Delete(int id)
    {
        if (head == null) return;

        if (head.id == id)
        {
            head = head.next;
            return;
        }

        Node t = head;
        while (t.next != null && t.next.id != id)
            t = t.next;

        if (t.next != null)
            t.next = t.next.next;
    }

    static void Display()
    {
        Node t = head;
        while (t != null)
        {
            Console.WriteLine(t.id + " - " + t.name);
            t = t.next;
        }
    }

    static void Main()
    {
        InsertEnd(101, "John");
        InsertEnd(102, "Sara");
        InsertEnd(103, "Mike");

        Delete(102);

        Display();

        Console.ReadLine();
    }
}
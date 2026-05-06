using System;

class Program
{
    static void Main()
    {
        string[] stack = new string[10];
        int top = -1;

        void Push(string x)
        {
            if (top < 9)
            {
                top++;
                stack[top] = x;
                Display();
            }
        }

        void Pop()
        {
            if (top >= 0)
            {
                Console.WriteLine("Undo: " + stack[top]);
                top--;
                Display();
            }
            else
            {
                Console.WriteLine("Nothing to undo");
            }
        }

        void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Empty");
                return;
            }

            for (int i = 0; i <= top; i++)
                Console.Write(stack[i] + " ");
            Console.WriteLine();
        }

        Push("Type A");
        Push("Type B");
        Push("Type C");
        Pop();
        Pop();

        Console.ReadLine();
    }
}
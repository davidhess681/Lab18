using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    class Program
    {
        static void Main(string[] args)
        {
            // Comment/Uncomment these methods to run them
            
            
            //LinkedListUsingArray();
            //LinkedListUsingHashtable();
            TestingNodes();
            Console.ReadKey();


        }

        // Demonstrate the algorithm that uses an Array (part 2a)
        static void LinkedListUsingArray()
        {
            // initialize LinkedListArray
            LinkedListArray myList = new LinkedListArray();

            // print status to the console
            myList.Status();

            // insert new elements until full
            while (myList.Insert()) ;

            // print results of the algorithm
            myList.Print();

        }
        // Demonstrate the algorithm that uses Hashtables (part 2b)
        static void LinkedListUsingHashtable()
        {
            // initialize LinkedListHash
            LinkedListHash myList = new LinkedListHash();

            // print status to console
            myList.Status();

            // insert new elements until full
            while (myList.Insert()) ;

            // print results of the algorithm
            myList.Print();
        }

        // Test Methods from part 1
        static void TestingNodes()
        {
            // Initialize list
            LinkedListNode myList = new LinkedListNode();
            myList.Add("Steve");
            myList.Add("David");
            myList.Add("Clayton");
            myList.Add("Rudy");
            myList.Add("DANIEL EDWARDS");
            myList.Add("Mauricio");
            myList.Add("Evan");
            myList.Add("Ty");

            // print amount of elements in list
            Console.WriteLine("my list's count is " + myList.Count);

            // print initial list
            myList.PrintList();
            Console.WriteLine();

            // remove at index 2 (removes clayton)
            myList.RemoveAt(2);

            Console.WriteLine("I removed Clayton");
            Console.WriteLine();

            // print edited list
            myList.PrintList();
            Console.WriteLine("Now my list's count is "+ myList.Count);
            Console.WriteLine();

            // add Andrea to the list at index 4 (before Mauricio)
            Node newNode = new Node();
            newNode.Data = "Andrea";
            myList.InsertAt(4, newNode);

            // print edited list
            Console.WriteLine("I added Andrea");
            Console.WriteLine("my list's count is " + myList.Count);
            myList.PrintList();

            // print in reverse
            Console.WriteLine();
            Console.WriteLine("Now I print in reverse:");
            myList.PrintListReverse();
        }

    }
}

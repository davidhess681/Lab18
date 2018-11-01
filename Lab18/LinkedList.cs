using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    class LinkedListArray
    {
        // initialize the array (size 15)
        int[] items = new int[15];

        int count = 0;
        static int ValidInt()
        {
            while (true)
            {
                // Validate user input (must be an int)
                try
                {
                    int userInt = int.Parse(Console.ReadLine());
                    return userInt;
                }
                catch
                {
                    Console.Write("Invalid. Please enter a number: ");
                }
            }
        }

        // property of LinkedListArray (amount of items present)
        public int Length()
        {
            return count;
        }

        // print various properties of the Array
        public void Status()
        {
            Console.WriteLine("my list's length is " + Length());
            Console.WriteLine("is empty = " + IsEmpty());
            Console.WriteLine("is full = " + IsFull());
        }

        public bool Insert()
        {
            // if array is full, return false
            if (IsFull())
            {
                return false;
            }

            // prompt user for a number
            Console.Write("Please enter a number ({0} of 15): ", count + 1);

            // set first empty element to user input, then increment count
            items[count] = ValidInt();
            count++;
            
            return true;
        }

        public bool IsFull()
        {
            // check if count is equal to the size of the array
            if (count == items.Length)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            // check if count is 0
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        public int CountItem(int item)
        {
            int freq = 0;

            // cycle through the array to check each element
            for (int i = 0; i<count; i++)
            {
                // if current element matches the element passed in, increment frequency
                if (items[i] == item)
                {
                    freq++;
                }
            }
            // return the amount of times elements matched
            return freq;
        }

        public void Print()
        {

            // keep track of which elements have been counted
            List<int> uniqueItems = new List<int>();

            // check each element in the array
            for (int i = 0; i<count; i++)
            {
                // if element was already counted, skip to the next element
                int thisItem = items[i];
                if (uniqueItems.Contains(thisItem))
                {
                    continue;
                }
                
                // count frequency of the element and print to the console
                Console.WriteLine("[{0}]: {1}", thisItem, CountItem(thisItem));

                // add element to our list of elements counted
                uniqueItems.Add(thisItem);

            }
        }
        public void PrintReverse()
        {
            // same as Print() but reverse order


            List<int> uniqueItems = new List<int>();
            for (int i = count; i >= 0; i--)
            {
                int thisItem = items[i];
                if (uniqueItems.Contains(thisItem))
                {
                    continue;
                }
                Console.WriteLine("[{0}]: {1}", thisItem, CountItem(thisItem));
                uniqueItems.Add(thisItem);

            }
        }
        

    }

    class LinkedListHash
    {
        Hashtable itemsHash = new Hashtable();

        int count = 0;
        static int ValidInt()
        {
            while (true)
            {
                try
                {
                    int userInt = int.Parse(Console.ReadLine());
                    return userInt;
                }
                catch
                {
                    Console.Write("Invalid. Please enter a number: ");
                }
            }
        }


        public int Length()
        {
            return count;
        }

        public void Status()
        {
            Console.WriteLine("my list's length is " + Length());
            Console.WriteLine("is empty = " + IsEmpty());
            Console.WriteLine("is full = " + IsFull());
        }

        public bool Insert()
        {
            if (IsFull())
            {
                return false;
            }
            Console.Write("Please enter a number ({0} of 15): ", count + 1);

            // add user input to the hashtable with count as the key
            itemsHash.Add(count, ValidInt());
            count++;
            return true;
        }

        public bool IsFull()
        {
            if (count == 15)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            if (count == 0)
            {
                return true;
            }
            return false;
        }

        public int CountItem(int item)
        {
            int freq = 0;

            // check the values of each element in the hashtable
            foreach (int i in itemsHash.Values)
            {
                // if element matches the int passed in, increment frequency
                if (i == item)
                {
                    freq++;
                }
            }
            return freq;
        }

        public void Print()
        {


            List<int> uniqueItems = new List<int>();
            
            foreach (int i in itemsHash.Values)
            {
                
                if (uniqueItems.Contains(i))
                {
                    continue;
                }
                // count frequency of element and print to the console
                Console.WriteLine("[{0}]: {1}", i, CountItem(i));
                uniqueItems.Add(i);

            }
        }
    }

    class Node
    {
        public string Data { get; set; }
        public Node Next { get; set; }

        public Node Previous { get; set; }
        

    }

    class LinkedListNode
    {
        // properties of the LinkedList (Head is the first node, Tail is the last node)
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        // add node to the end of the list
        public void Add(string userInput)
        {
            // initialize
            Node node0 = new Node { Next = null, Data = userInput };

            // if list is empty, new node is the head and the tail
            if (Count == 0)
            {
                Head = node0;
                Tail = node0;
                Count++;
            }
            else
            {
                // set new node's previous to the current Tail
                node0.Previous = Tail;

                // set current Tail's next to the new node
                Tail.Next = node0;

                // make node0 the new Tail
                Tail = node0;

                // always be counting
                Count++;
            }
        }

        public Node GetNode(int index)
        {
            int start = 0;

            // start searching at the head
            Node temp = Head;

            // if start index doesn't match passed index
            while (start != index)
            {
                start += 1;

                // move to the next node
                temp = temp.Next;
            }
            // return node at the specified index
            return temp;
        }

        public void PrintList()
        {
            // print the data of each node to the console
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(GetNode(i).Data);
            }
        }
        public void PrintListReverse()
        {
            // same as PrintList() but in reverse
            for (int i = Count-1; i >=0; i--)
            {
                Console.WriteLine(GetNode(i).Data);
            }
        }



        public bool RemoveAt(int index)
        {
            // if index is out of range, return false
            if (index >= Count || index < 0)
            {
                return false;
            }
            
            // find the node we need to remove
            Node nToRemove = GetNode(index);

            // if removing the Head
            if (index == 0)
            {
                // set the next node as the new Head
                Head = nToRemove.Next;

                // nullify the new Head's previous
                nToRemove.Next.Previous = null;

                // delete the node
                nToRemove = null;
            }
            // if removing the Tail
            else if (index == Count -1)
            {
                // set the previous node as the new Tail
                Tail = nToRemove.Previous;

                // nullify the new Tail's next
                nToRemove.Previous.Next = null;

                // delete the node
                nToRemove = null;
            }
            else
            {
                // link the next and previous of the deleted node to each other
                
                // set the next node's previous to the current node's previous
                nToRemove.Next.Previous = nToRemove.Previous;

                // set the previous node's next to the current node's next
                nToRemove.Previous.Next = nToRemove.Next;

                // delete the node
                nToRemove = null;
            }
            // always be counting
            Count--;
            return true;
        }
        public bool InsertAt(int index, Node nToInsert)
        {
            // if index is out of range, stop
            if (index >= Count || index < 0)
            {
                return false;
            }

            // if inserting before the head
            if (index == 0)
            {
                // set new node's next as the current Head
                nToInsert.Next = Head;

                // set the current Head's previous to the new node
                Head.Previous = nToInsert;

                // set new node as the new Head
                Head = nToInsert;
            }
            // if inserting at the end
            else if (index == Count -1)
            {
                // same logic as Add()
                nToInsert.Previous = Tail;
                Tail.Next = nToInsert;
                Tail = nToInsert;
            }
            else
            {
                // insert new node at the index and re-establish connections 

                // call the node at the index specified
                Node nAtIndex = GetNode(index);

                // set new node's next to said node
                nToInsert.Next = nAtIndex;

                // set new node's previous to said node's previous
                nToInsert.Previous = nAtIndex.Previous;

                // set the previous node's next to the new node
                nToInsert.Previous.Next = nToInsert;

                // set said node's previous to the new node
                nAtIndex.Previous = nToInsert;


            }
            // always be counting
            Count++;
            return true;

        }
    }
}

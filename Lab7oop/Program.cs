namespace Lab7oop
{
    class ListNode
    {
        public int Data { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int data)
        {
            Data = data;
            Next = null;
        }
    }
    
    class List
    {
        internal ListNode Head;
        
        public List()
        {
            Head = null;
        }

        public void AddToList(int data)
        {
            ListNode newNode = new ListNode(data);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head.Next;
                Head.Next = newNode;
            }
        }
        
        //----------------------------------------------------------------------------------------------------------

        public int FindMinimumValue()
        {
            if (Head == null)
            {
                return 0;
            }
            int min = this[0];
            int listLength = 1;
            ListNode current = Head.Next;
            
            while (current != null)
            {
                if (this[listLength] < min)
                {
                    min = this[listLength];
                }
                current = current.Next;
                listLength++;
            }

            return min;
        }

        public int this[int index]
        {
            get
            {
                ListNode current = Head;
                int currentIndex = 0;
                
                while (current != null && currentIndex < index)
                {
                    current = current.Next;
                    currentIndex++;
                }

                if (current == null)
                    return 0;
                
                return current.Data;
            }
        }
        
        //----------------------------------------------------------------------------------------------------------

        public int FindFirstOccurrence(int data)
        {
            ListNode current = Head;

            while (current != null)
            {
                if (current.Data > data)
                {
                    return current.Data;
                }
                current = current.Next;
            }

            return -1;
        }

        public int FindSumOfLessElements(int headOfList)
        {
            int sum = 0;
            ListNode current = Head;

            while (current != null)
            {
                if (current.Data < headOfList)
                {
                    sum += current.Data;
                }

                current = current.Next;
            }

            return sum;
        }

        public List GetNewList(int selectedValue)
        {
            List newList = new List();
            ListNode current = Head;

            while (current != null)
            {
                if (current.Data > selectedValue)
                {
                    newList.AddToList(current.Data);
                }
                current = current.Next;
            }
            
            return newList;
        }

        public void RemoveAfterMaxElement()
        {
            ListNode current = Head;
            ListNode maxValue = Head;

            while (current != null)
            {
                if (current.Data > maxValue.Data)
                {
                    maxValue = current;
                }

                current = current.Next;
            }
            ListNode afterMax = maxValue;
            
            while (afterMax != null)
            {
                if (maxValue.Next != null)
                {
                    maxValue.Next = null;
                }

                current = maxValue.Next;
                afterMax = current;
            }
        }
    }
    
    class Program
    {
        public static void Main()
        {
            List myList = new List();
            
            myList.AddToList(5);
            myList.AddToList(7);
            myList.AddToList(4);
            myList.AddToList(10);
            myList.AddToList(30);
            myList.AddToList(9);
            myList.AddToList(1);
            
            //----------------------------------------------------------------------------------------------------------
            
            Console.WriteLine("My list contents: ");
            ListNode current = myList.Head;
            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write("  ");
                current = current.Next;
            }
            Console.WriteLine();
            
            //----------------------------------------------------------------------------------------------------------

            int minimum = myList.FindMinimumValue();
            Console.WriteLine("Minimul value in the list: " + minimum);
            
            //----------------------------------------------------------------------------------------------------------
            
            int selectedNumber = 9;
            
            int FoundOccurrence = myList.FindFirstOccurrence(selectedNumber);
            if (FoundOccurrence != -1)
            {
                Console.WriteLine("First bigger number than " + selectedNumber + " is - " + FoundOccurrence);
            }
            else
            {
                Console.WriteLine("No higher values in the list!");
            }
            Console.WriteLine();

            //----------------------------------------------------------------------------------------------------------
            
            int SumOfLessElements = myList.FindSumOfLessElements(selectedNumber);
                
            Console.WriteLine("Sum of elements less than " + selectedNumber + " is - " + SumOfLessElements);
            Console.WriteLine();
            
            //----------------------------------------------------------------------------------------------------------
            
            selectedNumber = 7;
            
            List newList = myList.GetNewList(selectedNumber);
            Console.WriteLine("New list contents(all elements bigger than - " + selectedNumber + "): ");
            
            current = newList.Head;
            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write("  ");
                current = current.Next;
            }
            Console.WriteLine();
            
            //----------------------------------------------------------------------------------------------------------
            
            Console.WriteLine("My list after removing will contain: ");
            myList.RemoveAfterMaxElement();
            current = myList.Head;
            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write("  ");
                current = current.Next;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strange__Massive
{
    public class InOutput
    {
        static public LinkedList<int> Input(out bool isTrueArray)
        {
            LinkedList<int> linkedList;

            isTrueArray = false;

            int count = int.Parse(Console.ReadLine());

            linkedList = new LinkedList<int>(0);

            if (count != 0)
            {
                string s = Console.ReadLine();

                int [] arr = s.Split(' ').
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => int.Parse(x)).ToArray();

                linkedList = new LinkedList<int>(arr[0]);

                for(int i = 1; i < count;i++)
                {
                    linkedList.Insert(i, arr[i]);
                }

                isTrueArray = true;
            }

            

            return linkedList;
        }

        static public void OutputList(LinkedList<int> result,int counter)
        {
            Console.Write("New Array: ");
            foreach(int elem in result)
            {
                Console.Write(elem+" ");
            }
            Console.WriteLine("\nCount of new elements: " + counter);
        }

    }
}

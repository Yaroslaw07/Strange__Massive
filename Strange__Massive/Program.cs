using System;

namespace Strange__Massive
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrueArray;
            int counter;

            LinkedList<int> list = InOutput.Input(out isTrueArray);

            if (isTrueArray == true)
            {
                LinkedList<int> res = MakeItStrange(list,out counter);

                InOutput.OutputList(res,counter);
            }
            else
                Console.WriteLine("Array is empty");
        }

        static LinkedList<int> MakeItStrange(LinkedList<int> resource, out int counter)
        {
            counter = 0;
            for(int i = 1;i < resource.Count;i++)
            {
                if (MathF.Max(resource[i], resource[i - 1]) > 2 * (MathF.Min(resource[i], resource[i - 1])))
                {
                    counter++;
                    if (resource[i] > resource[i - 1])
                        resource.Insert(i, resource[i - 1] * 2);
                    else
                        resource.Insert(i, NormalDivision(resource[i - 1]));
                }

            }

            return resource;
        }

        static int NormalDivision(int a)
        {
            if (a % 2 == 0)
                return a / 2;
            else
                return a / 2 + 1;
        }
    }
}

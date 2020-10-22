using System;
using System.Collections.Generic;
using System.Linq;

namespace cspractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0, leave = 0, n, m;

            while (leave != 1)
            {
                Console.WriteLine("Enter Choice " +
                      "\n 1 for DifferenceOfSum"
                    + "\n 2 for LargeSmallSum"
                    + "\n 3 for ProductSMallestPair"
                    + "\n 4 for OperationsBinaryString"
                    + "\n 5 for FindSmallestSubArrayLength"
                    + "\n 6 for DectoNBase"
                    + "\n 7 for NivenNumbers");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    DifferenceOfSum();
                else if (choice == 2)
                {
                    Console.WriteLine("Enter Size");
                    int size = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Array");
                    int[] arr = new int[] { };

                    // string[] x = Console.ReadLine().Split(" ");
                    arr = Array.ConvertAll(Console.ReadLine().Split(" "), p => int.Parse(p));

                    //for (int i = 0; i < size; i++)
                    //{
                    //    arr[i] = int.Parse(x[i]);
                    //}

                    if (arr.Length == 0) Console.WriteLine($"array kength is {arr.Length}");
                    else if (arr.Length <= 3) Console.WriteLine($"{0}");
                    else Console.Write($" answer is {LargeSmallSum(size, arr.ToList())}");
                }
                else if (choice == 3)
                {
                    int sum, size;
                    int[] arr = new int[] { };
                    Console.WriteLine("Enter sum");
                    sum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter array size");
                    size = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Array");
                    arr = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
                    if (size == 0 || size < 2) Console.WriteLine("-1");
                    else
                        Console.WriteLine($"{ProductSmallestPair(sum, arr)}");
                }
                else if (choice == 4)
                {
                    //Input read from StDIN
                    Console.WriteLine("Enter");
                    var str = Console.ReadLine();
                    int result = OperationsBinaryString(str);
                    Console.WriteLine($"the result for {str} is {result}");

                    //result printed
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter Array");
                    int[] arr = new int[] { };
                    var x = Console.ReadLine().Split(" ");
                    arr = Array.ConvertAll(x, p => int.Parse(p));
                    Console.WriteLine("Enter Sum");

                    int sum = 0;
                    sum = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{ FindSmallestSubArrayLength(arr, sum)}");
                }
                else if (choice == 6)
                {
                    Console.WriteLine($"{DectoNBase(5, 5)}");
                }
                else if (choice == 7) NivenNum();
                Console.WriteLine("Leave?");
                leave = int.Parse(Console.ReadLine());
            }


            void DifferenceOfSum()


            {
                //Find the sum of all numbers in range from 1 to m(both inclusive) that are not divisible by n.
                //Return difference between sum of integers not divisible by n with sum of numbers divisible by n.
                int Esum = 0, OSum = 0, diff;
                Console.WriteLine("Enter N and M");
                var item = Console.ReadLine().Split(" ");
                n = int.Parse(item[0]);
                m = int.Parse(item[1]);
                for (int i = 0; i <= m; i++)
                {
                    if (i % n == 0)
                    {
                        Esum += i;
                    }
                    else
                    {
                        OSum += i;
                    }
                }
                if ((Esum - OSum) <= 0)
                    diff = OSum - Esum;
                else
                    diff = Esum - OSum;

                Console.WriteLine($"Difference = {diff} ");



            }
            int LargeSmallSum(int size, List<int> arr)
            {
                List<int> even = new List<int>();
                List<int> odd = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    if (i % 2 == 0) even.Add(arr[i]);
                    else odd.Add(arr[i]);
                }
                even.Sort();
                odd.Sort();
                //arr of size ’length’ as its arguments 
                //you are required to return the sum of second largest largest element from the even positions
                //and second smallest from the odd position of given ‘arr’
                return (even[even.Count - 2] + odd[1]);

            }
            int ProductSmallestPair(int sum, int[] arr)
            {   //The function accepts an integers sum and an integer array arr of size n. 
                //Implement the function to find the pair, (arr[j], arr[k]) 
                //where j!=k, Such that arr[j] and arr[k] are the least two elements of array (arr[j] + arr[k] <= sum) 
                //and return the product of element of this pair

                List<int> holder = new List<int>();
                int pos = 0;
                bool found = false;
                holder = arr.ToList();
                holder.Sort();
                for (int i = 0; i < holder.Count - 1; i++)
                {
                    if (holder[i] + holder[i + 1] <= sum)
                    {
                        pos = i;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    return 0;
                }
                else
                    return (holder[pos] * holder[pos + 1]);
            }
            static int OperationsBinaryString(string str)
            {//1C0C1C1A0B1
                int result = 0, previoussum = 7;
                System.Collections.Generic.List<string> holder = new List<string>();
                if (str == null)
                {
                    return -1;
                }
                else
                {
                    foreach (var item in str)
                    {
                        holder.Add(item.ToString());
                    }
                    previoussum = int.Parse(holder[0]);
                    for (int i = 1; i < holder.Count; i += 2)
                    {
                        if (holder[i] == 'A'.ToString())
                        {

                            previoussum = previoussum & int.Parse(holder[i + 1]);
                        }
                        else if (holder[i] == 'B'.ToString())
                        {
                            previoussum = previoussum | int.Parse(holder[i + 1]);

                        }
                        else if (holder[i] == 'C'.ToString())
                        {
                            previoussum = previoussum ^ int.Parse(holder[i + 1]);

                        }

                    }
                }
                return previoussum;

            }
            static int FindSmallestSubArrayLength(int[] arr, int sum)
            {//https://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
                int minlen = arr.Length;
                bool done = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    int tempsum = arr[i];
                    if (tempsum > sum)
                    {
                        done = true;
                        return 1;
                    }

                    else
                    {
                        for (int last = i + 1; last < arr.Length; last++)
                        {
                            tempsum += arr[last];
                            if (tempsum > sum && last - i < minlen)
                            {
                                minlen = last - i + 1;
                                done = true;
                            }
                        }
                    }

                }
                if (!done) return -1;
                else return minlen;

            }
            string DectoNBase(int n, int num)
            { 
                return "ajhnjhnh";
            }
            void NivenNum()
            {
                int n = 36, sum = 0;
                string x = n.ToString();
                List<int> mylist = new List<int>();
                foreach (var item in x)
                {
                    mylist.Add(int.Parse(item.ToString()));
                }
                for (int i = 0; i < mylist.Count; i++)
                {
                    sum += mylist[i];
                }
                if (n % sum == 0) Console.WriteLine($"{n / sum}");

                else Console.WriteLine("0");
            }








            //List<int> holder = new List<int>(); int mysum = 0, pos = 0, k = 0; bool done = false;
            //holder = arr.ToList();
            //for (int i = 0; i < holder.Count; i++)
            //{
            //    if (holder[i] > sum)
            //    {
            //        done = true;
            //        pos = i;
            //        break;
            //    }
            //}
            //if (done == false && pos == 0)
            //{
            //    for (int i = 0; i < holder.Count; i++)
            //    {

            //        for (int j = 0; j < holder.Count; j++)
            //        {
            //            if (holder[j] > sum)
            //            {
            //                done = true;
            //                pos = i;
            //                break;
            //            }
            //            if (!done)
            //            {
            //                k++;
            //            }
            //        }


            //    }
            //}


            //if (mysum == 0 && pos == 0) return -1;
            //else return pos + 1;

        }

    }
}


//if ((Esum - Osum) <=)
//    return Esum - Osum;
//else return Osum - Esum;

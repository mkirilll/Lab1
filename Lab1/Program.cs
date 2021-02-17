using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
        jump2:
            Console.Write("Input quantity of elements in set A: ");
            int elementsQuantitySetA = int.Parse(Console.ReadLine());
            double[] setA = new double[elementsQuantitySetA];
            for (int i = 0; i < elementsQuantitySetA; i++)
            {
                Console.Write($"\nInput {i + 1} element of set A: ");
                setA[i] = double.Parse(Console.ReadLine());
            }

            if (IfExcistDuplicateElements(setA) == true)
            {
                Console.WriteLine("\nDuplicate elements cannot be present in a set (setA)");
                Console.ReadKey();
                Console.Clear();
                goto jump2;              
            }

            Console.Write("\nInput quantity of elements in set B: ");
            int elementsQuantitySetB = int.Parse(Console.ReadLine());
            double[] setB = new double[elementsQuantitySetB];

            for (int i = 0; i < elementsQuantitySetB; i++)
            {
                Console.Write($"\nInput {i + 1} element of set B: ");
                setB[i] = double.Parse(Console.ReadLine());
            }

            if (IfExcistDuplicateElements(setB) == true)
            {
                Console.WriteLine("\nDuplicate elements cannot be present in a set (setB)");
                Console.ReadKey();
                Console.Clear();
                goto jump2;
            }

            Console.Write("\nInput quantity of elements in set C: ");
            int elementsQuantitySetC = int.Parse(Console.ReadLine());
            double[] setC = new double[elementsQuantitySetC];

            for (int i = 0; i < elementsQuantitySetC; i++)
            {
                Console.Write($"\nInput {i + 1} element of set C: ");
                setC[i] = double.Parse(Console.ReadLine());
            }

            if (IfExcistDuplicateElements(setC) == true)
            {
                Console.WriteLine("\nDuplicate elements cannot be present in a set (setC)");
                Console.ReadKey();
                Console.Clear();
                goto jump2;
            }

            Console.WriteLine("\n\nSet A: " + string.Join(", ", BubbleSort(setA)));
            Console.WriteLine("\nSet B: " + string.Join(", ", BubbleSort(setB)));
            Console.WriteLine("\nSet C: " + string.Join(", ", BubbleSort(setC)));

            Console.WriteLine("\nUniversal U: " + string.Join(", ", Universal(setA, setB, setC)));

            Console.WriteLine("\nIntersection AB: " + string.Join(", ", Intersection(setA, setB)));
            Console.WriteLine("\nIntersection AC: " + string.Join(", ", Intersection(setA, setC)));
            Console.WriteLine("\nIntersection BC: " + string.Join(", ", Intersection(setB, setC)));

            Console.WriteLine("\nDifference AB: " + string.Join(", ", Difference(setA, setB)));
            Console.WriteLine("\nDifference AC: " + string.Join(", ", Difference(setA, setC)));
            Console.WriteLine("\nDifference BA: " + string.Join(", ", Difference(setB, setA)));
            Console.WriteLine("\nDifference BC: " + string.Join(", ", Difference(setB, setC)));
            Console.WriteLine("\nDifference CA: " + string.Join(", ", Difference(setC, setA)));
            Console.WriteLine("\nDifference CB: " + string.Join(", ", Difference(setC, setB)));

            Console.WriteLine("\nSymmetric difference AB: " + string.Join(", ", SymmetricDifference(setA, setB)));
            Console.WriteLine("\nSymmetric difference AC: " + string.Join(", ", SymmetricDifference(setA, setC)));
            Console.WriteLine("\nSymmetric difference BC: " + string.Join(", ", SymmetricDifference(setB, setC)));

            Console.WriteLine("\nUnion AB: " + string.Join(", ", Union(setA, setB)));
            Console.WriteLine("\nUnion AC: " + string.Join(", ", Union(setA, setC)));
            Console.WriteLine("\nUnion BC: " +  string.Join(", ", Union(setB, setC)));

            Console.WriteLine("\nComplement of A: " + string.Join(", ", Complement(setB, setC, setA)));
            Console.WriteLine("\nComplement of B: " + string.Join(", ", Complement(setA, setC, setB)));
            Console.WriteLine("\nComplement of C: " + string.Join(", ", Complement(setA, setB, setC)));
        }

        static bool IfExcistDuplicateElements<T>(T[] arr)
        {
            bool flag = false;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].Equals(arr[j]))
                    {
                        flag = true;
                        goto jump1;
                    }                   
                }
            }

        jump1:
            return flag;
        }

        static double[] Intersection(double[] arr1, double[] arr2)
        {
            int counter = 0;
            double[] result = new double[arr1.Length + arr2.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i].Equals(arr2[j]))
                    {
                        result[counter] = arr1[i];
                        counter++;
                    }
                }
            }

            result = RemoveZero(result, counter);
            result = RemoveDuplicateElements(result);
            BubbleSort(result);

            return result;
        }

        static double[] Difference(double[] arr1, double[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (i < arr1.Length)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            arr1 = DeleteElement(arr1, i);
                        }
                    }
                }
            }

            arr1 = RemoveDuplicateElements(arr1);
            return arr1;
        }

        static double[] Union(double[] arr1, double[] arr2)
        {
            double[] result = new double[arr1.Length + arr2.Length];

            for (int i = 0; i < result.Length; i++)
            {
                if (i >= arr1.Length)
                {
                    result[i] = arr2[i - arr1.Length];
                }
                else
                {
                    result[i] = arr1[i];
                }
            }

            result = RemoveDuplicateElements(result);
            BubbleSort(result);
            return result;
        }

        static double[] Universal(double[] arr1, double[] arr2, double[] arr3)
        {
            return Union(Union(arr1, arr2), arr3);
        }

        static double[] Complement(double[] arr1, double[] arr2, double[] arr3)
        {
            double[] result = new double[arr1.Length + arr2.Length];

            result = Union(arr1, arr2);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < arr3.Length; j++)
                {
                    if (result[i].Equals(arr3[j]))
                    {
                        result = DeleteElement(result, i);
                    }
                }
            }

            return result;
        }

        static double[] SymmetricDifference(double[] arr1, double[] arr2)
        {
            double[] union = new double[arr1.Length + arr2.Length];
            union = Union(arr1, arr2);

            double[] intersection = new double[arr1.Length + arr2.Length];
            intersection = Intersection(arr1, arr2);

            for (int i = 0; i < union.Length; i++)
            {
                for (int j = 0; j < intersection.Length; j++)
                {
                    if (union[i] == intersection[j])
                    {
                        union = DeleteElement(union, i);
                    }
                }
            }

            return union;
        }

        static double[] RemoveZero(double[] arr, int n)
        {
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = arr[i];
            }

            return result;
        }

        static double[] RemoveDuplicateElements(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        arr = DeleteElement(arr, j);
                    }
                }
            }
            

            return arr;
        }

        static double[] DeleteElement(double[] arr, int place)
        {
            double[] result = new double[arr.Length - 1];

            for (int i = 0; i < place; i++)
            {
                result[i] = arr[i];
            }

            for (int i = place + 1; i < arr.Length; i++)
            {
                result[i - 1] = arr[i];
            }

            return result;
        } 
        
        static double[] BubbleSort(double[] arr)
        {
            double temp;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }
    }
}






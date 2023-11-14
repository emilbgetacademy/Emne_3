namespace _1_intro_arrays
{
    internal class LearnArray
    {
        public static int[] GetArrayWithZeros(int length)
        {
            int[] arr = new int[length];
            return arr;
        }

        public static int[] InsertNumberRangeIncreaseingIntoArray(int[] some_array)
        {
            for (int i = 0; i < some_array.Length; i++)
            {
                some_array[i] = i + 1;
            }
            return some_array;
        }

        public static int[] InsertNumberRangeDecreaseingIntoArray(int[] some_array)
        {
            for (int i = 0; i < some_array.Length; i++)
            {
                some_array[i] = some_array.Length - i;
            }
            return some_array;
        }
        public static void PrintElementsWithIndexInArray(int[] some_array)
        {
            Console.WriteLine("Printing out elements and their index position");
            for (int i = 0; i < some_array.Length; i++)
            {
                var number = some_array[i];
                Console.WriteLine($"Element in position {i} = {number}");
            }
        }

        public static void PrintElementsInArray(int[] some_array)
        {
            Console.WriteLine("Printing out elements in one line");
            int last_number = some_array[some_array.Length - 1];
            foreach (var number in some_array)
            {
                if (number == last_number)
                {
                    Console.WriteLine($"{number} ");
                }
                else
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}

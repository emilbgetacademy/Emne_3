namespace _1_intro_arrays
{
    internal class LearnList
    {
        public static List<char> GetListWithAlphabet(char from_c = 'a', char to_c = 'z')
        {
            // example of both implicit and explicit declaration (we use explicit and comment out implicit)
            // var my_list = new List<char>(); // implicit
            List<char> my_list = new(); // explicit

            for (char letter = from_c; letter <= to_c; letter++)
            {
                my_list.Add(letter);
            }

            return my_list;
        }

        public static List<char> AddToAlphabetList(List<char> my_list, char value)
        {
            my_list.Add(value);
            return my_list;
        }

        public static void PrintLettersInAlphabetList(List<char> my_list)
        {
            Console.WriteLine("Printing out the letters in alphabet list");

            for (var index = 0; index < my_list.Count; index++)
            {
                var letter = my_list[index];
                Console.Write($"{letter} ");
            }
        }
    }
}

namespace _1_intro_arrays;
class Program
{
    static void Main(string[] args)
    {
        int[] my_array = LearnArray.GetArrayWithZeros(5);
        my_array = LearnArray.InsertNumberRangeIncreaseingIntoArray(my_array);

        LearnArray.PrintElementsInArray(my_array);
        LearnArray.PrintElementsWithIndexInArray(my_array);

        my_array = LearnArray.InsertNumberRangeDecreaseingIntoArray(my_array);

        LearnArray.PrintElementsInArray(my_array);
        LearnArray.PrintElementsWithIndexInArray(my_array);

        List<char> my_alphabet_list = LearnList.GetListWithAlphabet('a', 'e');
        my_alphabet_list = LearnList.AddToAlphabetList(my_alphabet_list, 'f');

        LearnList.PrintLettersInAlphabetList(my_alphabet_list);

        char[] my_new_alphabet_array = CharListToCharArray(my_alphabet_list);
        List<char> my_new_alphabet_list = CharArrayToCharList(my_new_alphabet_array);
    }

    private static char[] CharListToCharArray(List<char> some_list)
    {
        char[] some_array = some_list.ToArray();
        return some_array;
    }

    private static List<char> CharArrayToCharList(char[] array)
    {
        List<char> charList = new(array);
        return charList;
    }
}

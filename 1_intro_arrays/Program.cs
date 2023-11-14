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
    }
}

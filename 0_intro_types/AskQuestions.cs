namespace _0_intro_types
{
    internal class AskQuestions
    {
        public static string StringInStringOut(string question)
        // Send in a string, maybe a question and return input from user as string.
        {
            Console.Write(question + " ");
            string stringInput = Console.ReadLine() ?? "";
            return stringInput;
        }

        public static int StringIn32IntOut(string question)
        // Send in a string, maybe a question and return input from user as int32.
        {
            Console.Write(question + " ");
            var stringInput = Console.ReadLine();
            if (stringInput == "")
            {
                stringInput = "0";
            }
            return Convert.ToInt32(stringInput);
        }

        public static bool StringInBoolOut(string question)
        // Send in a string, maybe a question and return input from user as bool.
        {
            Console.Write(question + " [y/N] ");
            string stringInput = Console.ReadLine() ?? "";
            return stringInput.ToLower().StartsWith('y');
        }
    }
}

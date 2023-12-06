namespace AoC.Day4;

class Part2
{
    private static Dictionary<int, int[][]>? _game_cards;
    private static int _last_card_number = 0;
    public static string Run(string[] puzzle_input)
    {
        _game_cards = PrepareGameCard(puzzle_input);

        int result = CalculateGameCards();

        return result.ToString();
    }

    private static IEnumerable<int> IterStringNumbers(string str, char first_delimiter, char last_delimiter)
    {
        // iterating over all numbers from a string 
        // ..which are delimited by whitespace
        // ..and wrapped inside a first and last delimiter

        if (first_delimiter != ' ') str = str.Split(first_delimiter)[1];
        if (last_delimiter != ' ') str = str.Split(last_delimiter)[0];

        int i = 0;
        while (i < str.Length)
        {
            string number = "";
            while (char.IsNumber(str[i]))
            {
                number += str[i].ToString();
                i++;
                if (i == str.Length) break;
            }
            if (number.Length > 0) yield return int.Parse(number);

            i++;
        }
    }

    private static Dictionary<int, int[][]> PrepareGameCard(string[] puzzle_input)
    {
        var game_cards = new Dictionary<int, int[][]>();

        int current_card_number = 0;

        int len_card_numbers = 0;
        foreach (int _ in IterStringNumbers(puzzle_input[0], ':', '|' )) len_card_numbers++;

        int len_winning_numbers = 0;
        foreach (int n in IterStringNumbers(puzzle_input[0], '|', ' ' )) len_winning_numbers++;

        foreach (string line in puzzle_input)
        {

            int[][] numbers = new int[2][];
            numbers[0] = new int[len_card_numbers];
            numbers[1] = new int[len_winning_numbers];
            
            foreach (int n in IterStringNumbers(line, ' ', ':' )) current_card_number = n;

            int i = 0;
            foreach (int number in IterStringNumbers(line, ':', '|' ))
            {
                numbers[0][i] = number;
                i++;
            }

            i = 0;
            foreach (int number in IterStringNumbers(line, '|', ' ' ))
            {
                numbers[1][i] = number;
                i++;
            }
            game_cards.Add(current_card_number, numbers);
        }

        _last_card_number = current_card_number;

        return game_cards;
    }

    private static int CalculateGameCards()
    {
        int[] arr_copies = Enumerable.Repeat(1, _last_card_number).ToArray();

        int total_gamecards = 0;
        int copy_index = 0;
        while (copy_index < arr_copies.Length)
        {
            int card_number = copy_index + 1; // card number is offset by +1

            int copies = arr_copies[copy_index];

            while (copies > 0)
            {
                int res = TotalMatches(card_number);
                while (res > 0)
                {
                    int new_copy_index = copy_index + res;
                    res--;
                    arr_copies[new_copy_index]++;
                }
                total_gamecards++;
                copies--;
            }
            copy_index++;
        }

        return total_gamecards;
    }

    private static int TotalMatches(int card_number)
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.

        int[] card_numbers = _game_cards[card_number][0];
        int[] winning_numbers = _game_cards[card_number][1];

        int total = 0;
        foreach (int c_number in card_numbers)
        {
            foreach (int w_number in winning_numbers)
            {
                if (c_number == w_number)
                {
                    total++;
                }
            }
        }

        return total;
    }
}

class ConvertingTypes
{

    private static readonly string MyNumberString = "10";
    private static readonly string MyBoolString = "FaLsE";
    private static readonly char MyChar = 'a';
    private static readonly int MyNumberInt = 5;
    private static readonly double MyNumberDouble = 10.5 ;
    private static readonly bool MyBoolean = true;

    public enum MyEnumWeekdays
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }

    public static void Run()
    {
        // CAST TO INT
        int string_to_int = Int32.Parse(MyNumberString); // "10" => 10

        // CONVERT TO ASCII VALUE FOR CHAR
        int char_to_int = (int)MyChar; // 'a' => 97

        // CAST TO STRING
        string int_to_string = MyNumberInt.ToString();       // 5 => "5"
        string bool_to_string = MyBoolean.ToString();            // true => "true"
        string double_to_string = MyNumberDouble.ToString(); // 10.5 => "10,5"

        // CONVERT TO BOOL
        bool int_to_bool = MyNumberInt > 0;             // 0 => true
        bool string_to_bool = bool.Parse(MyBoolString); // FaLsE => false

        // AVOIDING CRASH WITH TryParse
        var parse_bool_ok = bool.TryParse(MyBoolString, out bool try_string_to_bool);
        if (parse_bool_ok)
        {
            // do something with try_string_to_bool
        }

        var parse_int_ok = Int32.TryParse(MyNumberString, out int try_string_to_int);
        if (parse_int_ok)
        {
            // do something with try_string_to_int
        }


        // CAST ENUMS
        MyEnumWeekdays enum_tuesday = MyEnumWeekdays.Tuesday; // MyEnumWeekdays.Tuesday

        // CAST TO INT
        int int_as_tuesday = (int)enum_tuesday; // MyEnumWeekdays.Tuesday => 1

        // CAST ENUM WEEKDAY
        MyEnumWeekdays saturday_as_MyEnumWeekdays = (MyEnumWeekdays)MyNumberInt; // 5 => MyEnumWeekdays.Saturday
    }
}

public class UserInputHandler
{
    public static List<string> GetMultipleStringInput(List<string> messages)
    {
        List<string> UserInputs = new List<string>();

        foreach (string input in messages)
        {
            UserInputs.Add(GetStringInput(input));
        }

        return UserInputs;
    }
    public static string GetStringInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    public static int GetIntInput(string message = "")
    {
        System.Console.Write(message);
        string IntVal = Console.ReadLine();
        int ConvertedInt;

        try
        {
            ConvertedInt = int.Parse(IntVal);

            return ConvertedInt;
        }
        catch (FormatException f)
        {
            System.Console.WriteLine("Provided value is NOT a number");
        }

        return 0;
    }

    internal static Categories AcceptCategories()
    {
        Categories[] enumValues = (Categories[])Enum.GetValues(typeof(Categories));

        System.Console.WriteLine("Choose categories");
        foreach (Categories day in enumValues)
        {
            string key = day.ToString();
            int value = (int)day;

            // Console.WriteLine($"Key: {key}, Value: {value}");
            System.Console.WriteLine($"{value}. {key}");
        }

        // foreach (string type in enumDictionary)
        // {
        //     System.Console.WriteLine($"{enumDictionary[type]}. {type}");
        // }

        return (Categories)GetIntInput("Choice: ");
    }
}
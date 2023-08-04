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
    public static string GetStringInput(string message, int length = 0){
        string input = "";
        do{
            Console.Write($"\n{message}");
            input = Console.ReadLine();
        } while (
            input.Length < length
            );
        return input;
    }
    
    public static int GetIntInput(string message = "", int mini = 0, int maxi = 1)
    {
        int ConvertedInt;
        do{
            Console.Write($"\n{message}");
        } while (
            !int.TryParse(Console.ReadLine(), out ConvertedInt) ||
            ConvertedInt < mini ||
            ConvertedInt > maxi
            );

        return ConvertedInt;
    }

    internal static Categories AcceptCategories()
    {
        Categories[] enumValues = (Categories[])Enum.GetValues(typeof(Categories));

        System.Console.WriteLine("\nChoose categories");
        foreach (Categories day in enumValues)
        {
            string key = day.ToString();
            int value = (int)day;
            System.Console.WriteLine($"{value}. {key}");
        }
        return (Categories)GetIntInput("Choice: ", 0, 6);
    }
}
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class FileManager {
    
    private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "task.csv");
    public static async Task<bool> LineAppender(string newData){
        string message;
        try{
            File.AppendAllText(filePath, newData + Environment.NewLine);
            return true;
        }
        catch(FileNotFoundException ex){
            message = "The File task.csv is Not Found";
        }
        catch(IOException ex){
           message = $"Something Went Wrong while writing. Check your disk!";
        }
        catch(Exception ex){
            message =  "Something Went wrong";
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }
    
    public static async Task<string[]> LineReader() {
        try{
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }catch(Exception ex){
            string[] s = {};
            return s;
        }
    }
    
    
    public static async Task<bool> LineChanger(int lineNumber, string[] newData) {
        string message;
        try{
            await File.WriteAllLinesAsync(filePath, newData);
            return true;
        }
        catch(FileNotFoundException ex){
            message = "The File task.csv is Not Found";
        }
        catch(IOException ex){
            message = $"Something Went Wrong while writing. Check your disk!";
        }
        catch(Exception ex){
            message =  "Something Went wrong";
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
        
    }
}
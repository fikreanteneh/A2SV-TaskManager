using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class FileManager {
    
    private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "task.csv");
    public static async Task<bool> LineAppender(string newData) {
        try{
            File.AppendAllText(filePath, newData + Environment.NewLine);
            return true;
        }
        catch(FileNotFoundException ex){
            Console.WriteLine("The File task.csv is Not Found");
        }
        catch(IOException ex){
            Console.WriteLine($"Something Went Wrong while writing. Check your disk!");
        }
        catch(Exception ex){
            Console.WriteLine("Something Went wrong");
        }
        return false;
    }
    
    public static async Task<string[]> LineReader() {
        try{
            // List<string> lines = new List<string>(await File.ReadAllLinesAsync(filePath));
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }catch(Exception ex){
            string[] s = {};
            return s;
        }
    }
    
    
    public static async Task<bool> LineChanger(int lineNumber, string newData) {
        try{
            string[] lines = await File.ReadAllLinesAsync(filePath);
            if (lineNumber >= 0 && lineNumber < lines.Length){
                lines[lineNumber] = newData;
            }
            else{
                Console.WriteLine("Invalid line number.");
                return false;
            }

            await File.WriteAllLinesAsync(filePath, lines);
            return true;
        }
        catch(FileNotFoundException ex){
            Console.WriteLine("The File task.csv is Not Found");
        }
        catch(IOException ex){
            Console.WriteLine($"Something Wetr Wrong while writing. Check your disk space");
        }
        catch(Exception ex){
            Console.WriteLine("Something Went wrong. Check If your are editing the correct Line");
        }
        return false;
        
    }
}
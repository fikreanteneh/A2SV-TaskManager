using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class FileManager {
    
    private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "task.csv");
    public static async Task<bool> LineAppender(string newData) {
        try{
            // string[] oldLines = await File.ReadAllLinesAsync(filePath);
            // List<string> lines = new List<string>(oldLines); 
            // lines.Add(newData);
            // await File.WriteAllLinesAsync(filePath, lines);
            // Console.WriteLine("Data appended to CSV line successfully.");
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
    
    public static async Task<List<string>> LineReader() {
        try{
            List<string> lines = new List<string>(await File.ReadAllLinesAsync(filePath));
            return lines;
        }catch(Exception ex){
            return new List<string>() ;
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
            Console.WriteLine("Data appended to CSV line successfully.");
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
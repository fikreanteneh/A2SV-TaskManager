


using System.Runtime.InteropServices.JavaScript;

class TaskManager {
    
    protected List<Task> Tasks = new List<Task>();
    
    //Intializer when task manager started the check if task.csv file
    //If it does it loads the data
    //It creates a new file
    public TaskManager() {
        string[] task = FileManager.LineReader().Result;
        for (int i = 1; i < task.Length; i++){
            Tasks.Add(FileLineToTaskConverter(task[i]));
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        if (Tasks.Count > 0){
            Console.WriteLine("Your previous task was loaded.");
        }
        else{
            FileManager.LineAppender("Name,Category,IsCompleted,Description");
            Console.WriteLine("You had No Previous Task. New Task Sheet Started");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    // Getters 
    public int GetTaskLength() => Tasks.Count;
    public Task GetTaskById(int id) => Tasks[id];
    
    //this convert the task in the file to the task object.
    protected Task FileLineToTaskConverter(string taskString){
        List<string> task = new List<string>(taskString.Split(","));
        string name = task[0];
        Categories categories;
        Enum.TryParse<Categories>(task[1], out categories);
        bool completed = task[2].ToLower() == "false" ? false: true;
        String description = task[3];

        return new Task{
            Name = name,
            Category = categories,
            Completed = completed,
            Description = description,
        };
    }
    
    //Addidng task by inserting description
    public void AddTask(string aName, string aDescription, Categories aCategory){
        Task newTask = new Task{
            Name = aName,
            Description = aDescription,
            Category = aCategory,
            Completed = false
        };
        if(!FileManager.LineAppender(newTask.ToWrite()).Result) return;
        Tasks.Add(newTask);
    }
    
    //Adding a task by providing task object
    public void AddTask(Task aTask) {
        if(!FileManager.LineAppender(aTask.ToWrite()).Result) return;
        Tasks.Add(aTask);
    }
    
    // Updating task requires the temporary index/id the the descriptions 
    public void UpdateTask(int aIndex, string aName, string aDescription, Categories aCategory, bool aCompleted) {
        Task task = Tasks[aIndex];
        task.UpdateTask(aName, aDescription, aCategory, aCompleted);
        FileManager.LineChanger(aIndex + 1, task.ToWrite());
    }
    
    //This prints the each task in ordered manner
    public void DisplayTasks(){
        for (int i = 0; i < Tasks.Count; i++){
            Tasks[i].DisplayTasks(i);
        }
    }
    
    //This filters the task by completion and prints and return the data
    public List<Task> FilterTaskByCategory(Categories aCategory) {
        List<Task> filteredTask = Tasks.FindAll(task => aCategory == task.Category);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You have {filteredTask.Count} tasks in this category.");
        for (int i = 0; i < filteredTask.Count; i++) {
            filteredTask[i].DisplayTasks(i);
        }
        return filteredTask; 
    }
    
    //This filters by category
    public List<Task> FilterTaskByCompleted(bool aCompleted) {
        
        List<Task> filteredTask = Tasks.FindAll(task => task.Completed == aCompleted);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You have {filteredTask.Count} tasks in this category.");
        for (int i = 0; i < filteredTask.Count; i++) {
            filteredTask[i].DisplayTasks(i);
        }
        return filteredTask;
    }
}
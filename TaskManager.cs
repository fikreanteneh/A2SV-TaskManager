


using System.Runtime.InteropServices.JavaScript;

class TaskManager {
    
    protected List<Task> Tasks = new List<Task>();

    public TaskManager() {
        List<string> task = FileManager.LineReader().Result;
        for (int i = 1; i < task.Count; i++){
            this.AddTask(FileLineToTaskConverter(task[i]));
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

    public int GetTaskLength() => Tasks.Count;
    public Task GetTaskById(int id) => Tasks[id];
    protected Task FileLineToTaskConverter(string taskString){
        List<string> task = new List<string>(taskString.Split(","));
        string name = task[0];
        Categories categories;
        Enum.TryParse<Categories>(task[1], out categories);
        bool completed = task[2] == "FALSE" ? false: true;
        String description = task[3];

        return new Task{
            Name = name,
            Category = categories,
            Completed = completed,
            Description = description,
        };
    }

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

    public void AddTask(Task aTask) {
        if(!FileManager.LineAppender(aTask.ToWrite()).Result) return;
        Tasks.Add(aTask);
    }
    
    
    public void UpdateTask(int aIndex, string aName, string aDescription, Categories aCategory, bool aCompleted) {
        Task task = Tasks[aIndex];
        task.UpdateTask(aName, aDescription, aCategory, aCompleted);
        FileManager.LineChanger(aIndex + 1, task.ToWrite());
    }
    
    public void DisplayTasks(){
        for (int i = 0; i < Tasks.Count; i++){
            Tasks[i].DisplayTasks(i);
        }
    }
    
    public List<Task> FilterTaskByCategory(List<Categories> aCategory) {
        List<Task> filteredTask = Tasks.FindAll(task => aCategory.Contains(task.Category));
        for (int i = 0; i < filteredTask.Count; i++) {
            filteredTask[i].DisplayTasks(i);
        }
        return filteredTask; 
    }
    public List<Task> FilterTaskByCompleted(bool aCompleted) {
        List<Task> filteredTask = Tasks.FindAll(task => task.Completed == aCompleted);
        for (int i = 0; i < filteredTask.Count; i++) {
            filteredTask[i].DisplayTasks(i);
        }
        return filteredTask;
    }

}
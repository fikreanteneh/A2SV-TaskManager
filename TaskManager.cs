


class TaskManager {
    
    protected List<Task> Tasks = new List<Task>();
    
    public void AddTask(string aName, string aDescription, Categories aCategory){
        Task newTask = new Task {
            Name = aName,
            Description = aDescription,
            Category = aCategory,
            Completed = false
        };
        Tasks.Add(newTask);
    }
    
    public void AddTask(Task aTask) {
        Tasks.Add(aTask);
    }
    
    public void AddTask(List<Task> Tasks) {
        foreach (Task task in Tasks) {
            Tasks.Add(task);
        }
    }
    
    public void UpdateTask(int aIndex, string aName, string aDescription, Categories aCategory, bool aCompleted) {
        Task task = Tasks[aIndex];
        task.UpdateTask(aName, aDescription, aCategory, aCompleted);
    }

    public void RemoveTask(int index) {
        Tasks.RemoveAt(index);
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
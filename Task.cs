class Task {
    internal string Name { get; set; }
    internal bool Completed{ get; set; } = false;
    internal string Description { get; set; }
    internal Categories Category { get; set; }

    public override string ToString() {
        return $"{Name},{Category},{Completed},{Description}";
    }
    
    public string ToWrite(){
        return $"{Name},{Category},{Completed},{Description}";
    }
    
    public void UpdateTask(string name, string description, Categories category, bool completed) {
        Name = name;
        Description = description;
        Category = Category;
        Completed = Completed;
    }
    public void DisplayTasks(int index){
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Task {index}: {Name}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\t{Category}");
        if (Completed){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tCompleted");
        }
        else{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tInCompleted");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\t{Description}");
    }
    
}
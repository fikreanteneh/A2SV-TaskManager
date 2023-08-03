class Menu {
    public static void Main() {
        int choice = 1;
        TaskManager taskManager = new TaskManager();
        while (choice != 0) {
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine("Task Manager");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.WriteLine("1. Add Task");
            System.Console.WriteLine("2. Update Task");
            System.Console.WriteLine("3. View Tasks");
            System.Console.WriteLine("0. Exit");
            System.Console.WriteLine();

            choice = UserInputHandler.GetIntInput("Enter choice: ");

            if (choice == 0)
                break;

            else if (choice == 1) {
                // add task
                Task NewTask = new Task {
                    Name = UserInputHandler.GetStringInput("Enter task name: "),
                    Description = UserInputHandler.GetStringInput("Enter desc: "),
                    Category = UserInputHandler.AcceptCategories(),
                    // Completed = UserInputHandler.GetIntInput("1 if task complete 0 if not completed: ") == 0 ? false : true,
                };
                
                taskManager.AddTask(NewTask);
            }
            else if (choice == 2) {
                taskManager.DisplayTasks();
                int selected = UserInputHandler.GetIntInput("Which Task do you wanna edit insert a the correct Task num: ");
                int length = taskManager.GetTaskLength();
                while (0 > selected || selected >= length){
                    selected = UserInputHandler.GetIntInput("Please insert the correct Task num:");
                }
                Task selectedTask = taskManager.GetTaskById(selected);
                string name = UserInputHandler.GetCustomStringInput(": ", selectedTask.Name);
                string description = UserInputHandler.GetCustomStringInput("Edit desc: ",selectedTask.Description);
                    // Category = UserInputHandler.AcceptCategories(),
                    // Completed = UserInputHandler.GetIntInput("1 if task complete 0 if not completed: ") == 0 ? false : true,
                }

                //TODO: update the task using index in Task Manager
            else if (choice == 3) {
                taskManager.DisplayTasks();
            }
            else {
                // incorrect
                System.Console.WriteLine("Incorrect choice!!");
            }
        }
    }
}
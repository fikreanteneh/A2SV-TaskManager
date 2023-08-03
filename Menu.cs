class Menu {
    public static void Main() {
        int choice = 1;

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
                    Completed = UserInputHandler.GetIntInput("1 if task complete 0 if not completed: ") == 0 ? false : true,
                };

                // System.Console.WriteLine($"here: {NewTask}");
                // TODO: add the new task to the Task Manager
            }
            else if (choice == 2) {
                // update task
                Task NewTask = new Task {
                    Name = UserInputHandler.GetStringInput("Enter task name: "),
                    Description = UserInputHandler.GetStringInput("Enter desc: "),
                    Category = UserInputHandler.AcceptCategories(),
                    Completed = UserInputHandler.GetIntInput("0 if task complete 1 if not completed: ") == 0 ? false : true,
                };

                //TODO: update the task using index in Task Manager
            }
            else if (choice == 3) {
                // delete task
                //TODO: view all tasks using index from Task Manager
            }
            else {
                // incorrect
                System.Console.WriteLine("Incorrect choice!!");
            }
        }
    }
}
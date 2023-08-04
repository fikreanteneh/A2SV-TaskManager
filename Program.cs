// See https://aka.ms/new-console-template for more information
class Program
{
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
            System.Console.WriteLine("4. Filter Tasks");
            System.Console.WriteLine("0. Exit");
            System.Console.WriteLine();

            choice = UserInputHandler.GetIntInput("Enter correct choice: ", 0, 4);

            if (choice == 0)
                break;

            else if (choice == 1) {
                Task NewTask = new Task {
                    Name = UserInputHandler.GetStringInput("Enter task name: ", 3),
                    Description = UserInputHandler.GetStringInput("Enter desc: ", 5),
                    Category = UserInputHandler.AcceptCategories(),
                };
                taskManager.AddTask(NewTask);
            }
            else if (choice == 2) {
                taskManager.DisplayTasks();
                int length = taskManager.GetTaskLength();
                int selected = UserInputHandler.GetIntInput("Insert the corrct id for updation: ", 0, length - 1);
                Task selectedTask = taskManager.GetTaskById(selected);

                string name = UserInputHandler.GetStringInput($"Enter new name or leave empty: old >> {selectedTask.Name}\n", 0);

                string description = UserInputHandler.GetStringInput($"Enter new desccriptiom or leavet empty: old >> {selectedTask.Description}\n", 0);
                
                bool completed = UserInputHandler.GetIntInput("1 if task complete 0 if not completed: ") == 0
                    ? false
                    : true;

                description = description.Length > 0 ? description: selectedTask.Description;
                name = name.Length > 0 ? name: selectedTask.Name;
                taskManager.UpdateTask(selected, name, description, selectedTask.Category,completed);
            }
            else if (choice == 3) {
                taskManager.DisplayTasks();
            }
            else if (choice == 4){
                int selected = UserInputHandler.GetIntInput("Insert 0 to filter by task completion or 1 by category: ");
                if (selected == 0){
                    selected = UserInputHandler.GetIntInput("Insert 0 for incomplete 1 for complete: ");
                    taskManager.FilterTaskByCompleted(selected == 0 ? false : true );
                }
                else{
                    Categories cat = UserInputHandler.AcceptCategories();
                    taskManager.FilterTaskByCategory(cat);
                }
            }
            else {
                System.Console.WriteLine("Incorrect choice!!");
            }
        }
    }
}
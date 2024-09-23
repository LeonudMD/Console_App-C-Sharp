namespace ToDo_App
{
    // Класс, представляющий задачу
    class Task
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }

        // Конструктор для создания задачи
        public Task(string description)
        {
            Description = description;
            CreatedDate = DateTime.Now;
            IsCompleted = false;
        }

        // Метод для вывода задачи в консоль
        public override string ToString()
        {
            return $"Описание: {Description}, Дата создания: {CreatedDate}, Статус: {(IsCompleted ? "Выполнено" : "Не выполнено")}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            string? command;
            
            do
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Изменить статус задачи");
                Console.WriteLine("4. Показать все задачи");
                Console.WriteLine("5. Показать выполненные задачи");
                Console.WriteLine("6. Показать невыполненные задачи");
                Console.WriteLine("0. Выйти");

                Console.Write("\nВведите команду: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        DeleteTask(tasks);
                        break;
                    case "3":
                        ChangeTaskStatus(tasks);
                        break;
                    case "4":
                        ShowAllTasks(tasks);
                        break;
                    case "5":
                        ShowFilteredTasks(tasks, true);
                        break;
                    case "6":
                        ShowFilteredTasks(tasks, false);
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }

            } while (command != "0");
        }

        // Добавить новую задачу
        static void AddTask(List<Task> tasks)
        {
            Console.Write("Введите описание задачи: ");
            string description = Console.ReadLine();
            tasks.Add(new Task(description));
            Console.WriteLine("Задача добавлена.");
        }

        // Удалить задачу по индексу
        static void DeleteTask(List<Task> tasks)
        {
            ShowAllTasks(tasks);
            Console.Write("Введите индекс задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Задача удалена.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        // Изменить статус задачи
        static void ChangeTaskStatus(List<Task> tasks)
        {
            ShowAllTasks(tasks);
            Console.Write("Введите индекс задачи для изменения статуса: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = !tasks[index].IsCompleted;
                Console.WriteLine("Статус задачи изменен.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        // Показать все задачи
        static void ShowAllTasks(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.WriteLine("\n--- Все задачи ---");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}. {tasks[i]}");
            }
        }

        // Показать задачи с фильтрацией по статусу
        static void ShowFilteredTasks(List<Task> tasks, bool showCompleted)
        {
            var filteredTasks = tasks.Where(t => t.IsCompleted == showCompleted).ToList();

            if (filteredTasks.Count == 0)
            {
                Console.WriteLine(showCompleted ? "Нет выполненных задач." : "Нет невыполненных задач.");
                return;
            }

            Console.WriteLine(showCompleted ? "\n--- Выполненные задачи ---" : "\n--- Невыполненные задачи ---");
            for (int i = 0; i < filteredTasks.Count; i++)
            {
                Console.WriteLine($"{i}. {filteredTasks[i]}");
            }
        }
    }
}

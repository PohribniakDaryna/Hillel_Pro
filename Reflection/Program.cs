namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = new TaskItem
            {
                Title = "Test",
                Description = "TestDesc",
                Deadline = new DateTime(2023, 03, 03),
            };
            Helper.PrintTask(task);

            //2 
            Console.WriteLine("\nTask 2. Get property by name:");
            var propertyName = Helper.ReadFromConsole("Enter property name:");
            var property = Actions.GetPropertyByName(task, propertyName);
            Console.WriteLine(property);

            //3 
            Console.WriteLine("\nTask 2. Set property by name:");
            var propertyNameForSetting = Helper.ReadFromConsole("Enter property name:");
            var newValue = Helper.ReadFromConsole("Enter new property value:");
            Actions.SetPropertyByName(task, propertyNameForSetting, newValue);
            Helper.PrintTask(task);

            //4
            Console.WriteLine("\nTask 4. Result of serialization:");
            var print = Actions.SerializeTaskToString(task);
            Console.WriteLine($"Print serialized string:\n{print}");

            //5 
            Console.WriteLine("\nTask 5.Result of deserialization:");
            var deserializedTask = Actions.DeserializeTask(task.GetType(), print);
            Helper.PrintTaskObject(deserializedTask, deserializedTask.GetType());

            //6 
            Console.WriteLine("\nTask 6. Result of deserialization (Generic):");
            var deserializedTaskAsGeneric = Actions.DeserializeTask2<TaskItem>(print);
            Helper.PrintTaskObject(deserializedTaskAsGeneric, deserializedTaskAsGeneric.GetType());
        }
    }
}
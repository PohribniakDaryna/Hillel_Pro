using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public static class Helper
    {
        public static void PrintTask(TaskItem task)
        {
            Console.WriteLine($"Title: {task.Title}, description: {task.Description}, deadline: {task.Deadline}");
        }
        public static void PrintTaskObject(object instance, Type type)
        {
            var propertyies = type.GetProperties();
            foreach (PropertyInfo property in propertyies)
            {
                var propertyValue = property.GetValue(instance);
                Console.WriteLine($"{property.Name} : {propertyValue}");
            }
        }
        public static string ReadFromConsole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Reflection
{
    public static class Actions
    {
        //2
        public static object? GetPropertyByName(TaskItem taskItem, string property)
        {
            var prop = taskItem.GetType().GetProperty(property);
            return prop?.GetValue(taskItem);
        }

        //3
        public static object SetPropertyByName(TaskItem taskItem, string property, string newValueProperty)
        {
            var prop = taskItem.GetType().GetProperty(property);
            var realValue = Convert.ChangeType(newValueProperty, prop.PropertyType);
            prop?.SetValue(taskItem, realValue);
            return taskItem;
        }

        //4
        public static string SerializeTaskToString(TaskItem taskItem)
        {
            StringBuilder serializedString = new();
            var properties = taskItem.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                var attribute = Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                if (attribute != null) name = attribute.Name;
                serializedString.Append($"{name}:{property.GetValue(taskItem)};");
            }
            return serializedString.ToString();
        }

        //5
        public static object DeserializeTask(Type type, string serializedString)
        {
            var instance = Activator.CreateInstance(type);
            var properties = instance.GetType().GetProperties();
            var propertiesList = ConvertSerializedStringToList(serializedString);
            foreach (var item in properties)
            {
                for (int i = 0; i < propertiesList.Count; i++)
                {
                    var attribute = Attribute.GetCustomAttribute(item, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    if (propertiesList[i] == item.Name || (attribute != null && propertiesList[i] == attribute.Name))
                    {
                        var realValue = Convert.ChangeType(propertiesList[i + 1], item.PropertyType);
                        item.SetValue(instance, realValue);
                    }
                }
            }
            return instance;
        }

        //6
        public static T DeserializeTask2<T>(string serializedString)
        {
            return (T)DeserializeTask(typeof(T), serializedString);
        }

        private static List<string> ConvertSerializedStringToList(string serializedString)
        {
            List<string> propertiesFromString = new List<string>();
            string[] properties = serializedString.Split(";");

            foreach (string item in properties)
            {
                int charSplitIndex = item.IndexOf(':');
                if (charSplitIndex > 0)
                {
                    string fieldValue = item.Substring(++charSplitIndex);
                    string fieldName = item.Remove(--charSplitIndex);
                    propertiesFromString.Add(fieldName);
                    propertiesFromString.Add(fieldValue);
                }
            }
            return propertiesFromString;
        }
    }
}
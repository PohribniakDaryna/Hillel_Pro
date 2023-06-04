namespace Reflection
{
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string name = null)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
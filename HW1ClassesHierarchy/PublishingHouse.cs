namespace HW1ClassesHierarchy
{
    public class PublishingHouse<T> where T : class, new()
    {
        public T Create()
        {
            return new T();
        }
    }
}
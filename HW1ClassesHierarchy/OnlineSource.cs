namespace HW1ClassesHierarchy
{
    public class OnlineSource : Source
    {
        public string ResourceUrl { get; }
        public OnlineSource(string name, string description, bool isFreeSourse, string resourceUrl) : base(name, description, isFreeSourse)
        {
            ResourceUrl = resourceUrl;
        }

        public override void PrintSource()
        {
            base.PrintSource();
            Console.Write($"resource url: {ResourceUrl}\n");
        }

        public override string GetName()
        {
            return base.GetName();
        }

        public override void TranslateIntoUkrainian()
        {
            string name =  GetName();
            Console.WriteLine($"Source \"{name}\" is in English only.");
        }
    }
}
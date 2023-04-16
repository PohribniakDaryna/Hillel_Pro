namespace HW1ClassesHierarchy
{
    public class DigitalSource : Source
    {
        public DigitalSource(string name, string description, bool isFreeSourse, string author, string publicationFormat)
            : base(name, description, isFreeSourse)
        {
            Author = author;
            PublicationFormat = publicationFormat;
        }

        public string Author { get; }
        public string PublicationFormat { get; }

        public override void PrintSource()
        {
            base.PrintSource();
            Console.Write($"author: {Author}, publicationFormat: {PublicationFormat}\n");
        }

        public override string GetName()
        {
            return base.GetName();
        }

        public override void TranslateIntoUkrainian()
        {
            string name = GetName();
            Console.WriteLine($"Source \"{name}\" you can't translate into ukrainian.");
        }
    }
}

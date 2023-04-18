namespace HW1ClassesHierarchy
{
    public class VideoSource : Source
    {
        private int Duration { get; }

        public VideoSource(string name, string description, bool isFreeSourse, int duration) : base(name, description, isFreeSourse)
        {
            Duration = duration;
        }

        public override void PrintSource()
        {
            base.PrintSource();
            Console.Write($"duration: {Duration}\n");
        }

        public override string GetName()
        {
            return base.GetName();
        }

        public override void TranslateIntoUkrainian()
        {
            string name = GetName();
            Console.WriteLine($"Source \"{name}\". You can read only ukrainian subtitles.");
        }
    }
}
namespace HW1ClassesHierarchy
{
    public abstract class Source : IReviewSources, IAction
    {
        private readonly string name;
        private readonly string description;
        private readonly bool isFreeSourse;

        public Source(string name, string description, bool isFreeSourse)
        {
            this.name = name;
            this.description = description;
            this.isFreeSourse = isFreeSourse;
        }

        public string Review { get; set; }
        public int Rating { get; set; }

        public virtual string GetName()
        {
            return name;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual void PrintSource()
        {
            Console.WriteLine($"Name: \"{this.name}\", description: \"{this.description}\",");
        }
        public abstract void TranslateIntoUkrainian();

        public void CheckSourceIsFree()
        {
            if (isFreeSourse)
            {
                Console.WriteLine($"Source \"{this.name}\" is free.");
            }
            else
            {
                Console.WriteLine($"Source \"{this.name}\" is not free.");
            }
        }

        public void AddSourceReview(string review)
        {

            Review = review.ToUpper();
            Console.WriteLine($"Review about \"{this.name}\" is written.");
        }

        public void AddSourseRating(int rating)
        {
            Rating = rating;
            Console.WriteLine($"Rating of source \"{this.name}\" is {Rating}.");
        }

        public void OpenSource()
        {
            Console.WriteLine($"Source \"{this.name}\" is opened.");
        }

        public void CloseSource()
        {
            Console.WriteLine($"Source \"{this.name}\" is closed.");
        }
    }
}
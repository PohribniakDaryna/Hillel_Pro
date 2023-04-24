namespace HW1ClassesHierarchy
{
    public class Rating: IReviewSources
    {
        public int RatingNumber { get; set; }
        public string ReviewMessage { get; set; }

        public void AddSourseRating(int rating, Source source)
        {
            RatingNumber = rating;
            Console.WriteLine($"Rating of source \"{source.GetName}\" is {RatingNumber}.");
        }
        public void AddSourceReview(string message, Source source)
        {
            ReviewMessage = message;
            Console.WriteLine($"Review about \"{source.GetName}\" is written.");
        }
    }
}
namespace HW1ClassesHierarchy
{
    public static class Helper
    {
        public static void IncreaseSourceRating(Source source, int rating)
        {
            int result = source.Rating.RatingNumber + rating;
            Console.WriteLine($"New Rating of \"{source.GetName()}\" is {result}.");
        }
        public static void PrintSourceReview(Source source)
        {
            Console.WriteLine($"Review of \"{source.GetName()}\" : {source.Review.ReviewMessage}");
        }

        public static void Separate(string message, int lenght=40)
        {
            Console.WriteLine("\n" + new string((char)SeparatorEnum.point, lenght) + "\n" + message + "\n" + new string((char)SeparatorEnum.asterisk, lenght));
        }

        public static void Run()
        {
            VideoSource videoSource = new("C# Full Course - Learn C# 10 and .NET 6 in 7 hours", "educational video", true, 40);
            DigitalSource digitalSource = new("Pro C# 10 with .NET 6", "educational book", false, "Andrew Troelsen", PublicationFormatEnum.pdf);
            OnlineSource onlineSource = new("Explore object oriented programming with classes and objects", "educational article", true, "learn.microsoft.com");

            Separate("Sources:",100);
            videoSource.PrintSource();
            digitalSource.PrintSource();
            onlineSource.PrintSource();

            Separate("Review info:");
            videoSource.AddSourceReview("This source is usefull for education.");
            PrintSourceReview(videoSource);
            digitalSource.AddSourceReview("You can use this book for education!");
            PrintSourceReview(digitalSource);
            onlineSource.AddSourceReview("I recommend this source.");
            PrintSourceReview(onlineSource);

            Separate("Rating info:");
            videoSource.AddSourseRating(8);
            IncreaseSourceRating(videoSource, 2);
            digitalSource.AddSourseRating(8);
            IncreaseSourceRating(digitalSource, 2);
            onlineSource.AddSourseRating(8);
            IncreaseSourceRating(onlineSource, 2);

            Separate("Possibility of translation info:");
            videoSource.TranslateIntoUkrainian();
            digitalSource.TranslateIntoUkrainian();
            onlineSource.TranslateIntoUkrainian();

            Separate("Info about free sources:");
            videoSource.CheckSourceIsFree();
            digitalSource.CheckSourceIsFree();
            onlineSource.CheckSourceIsFree();
        }
    }
}
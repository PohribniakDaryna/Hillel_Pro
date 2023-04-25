namespace HW1ClassesHierarchy
{
    public static class Extension
    {
        public static void DoubleWork<T>(this T value, Source source, string review, int rating) where T : IAction, IReviewSources
        {
            value.OpenSource();
            value.CloseSource();
            value.AddSourceReview(review, source);
            value.AddSourseRating(rating, source);
        }
    }
}
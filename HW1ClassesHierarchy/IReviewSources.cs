namespace HW1ClassesHierarchy
{
    public interface IReviewSources
    {
        void AddSourceReview(string review, Source source);
        void AddSourseRating(int rating, Source source);
    }
}
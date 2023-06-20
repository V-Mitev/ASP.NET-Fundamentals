namespace ForumApp.Common
{
    public static class EntityValidations
    {
        public static class Post
        {
            public const int PostTitleMinLength = 10;
            public const int PostTitleMaxLength = 50;

            public const int PostContentMinLength = 30;
            public const int PostContentMaxLength = 1500;
        }
    }
}

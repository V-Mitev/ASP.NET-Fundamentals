namespace Homies.Common
{
    public static class EntityValidations
    {
        public static class Event
        {
            public const int EventNameMinLength = 5;
            public const int EventNameMaxLength = 20;

            public const int EventDescriptionMinLength = 15;
            public const int EventDescriptionMaxLength = 150;
        }

        public static class Type
        {
            public const int TypeNameMinLength = 5;
            public const int TypeNameMaxLength = 15;
        }
    }
}

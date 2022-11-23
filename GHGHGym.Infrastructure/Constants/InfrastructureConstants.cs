namespace GHGHGym.Infrastructure.Constants
{
    public class InfrastructureConstants
    {
        public static class TrainerConstant
        {
            public const int FirstNameMaxLength = 25;
            public const int LastNameMaxLength = 25;
            public const int DescriptionMaxLength = 500;
        }

        public static class CommentConstant
        {
            public const int TextMaxLength = 500;
            public const int TextMinLength = 1;
        }

        public static class ApplicationUserConstant
        {
            public const int FirstNameMaxLength = 25;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 25;
            public const int LastNameMinLength = 2;

            public const int PasswordMinLength = 6;
        }
        public static class ProductConstant
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 5;

            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 10;

            public const int QuantityMaxLength = 10;
            public const int QuantityMinLength = 1;
        }

        public static class SubscriptionType
        {
            public const int NameMaxLength = 100;
        }

        public static class Category
        {
            public const int NameMaxLength = 40;
            public const int NameMinLength = 4;

            public const string SubCategory = "SubCategory";
        }
    }
}

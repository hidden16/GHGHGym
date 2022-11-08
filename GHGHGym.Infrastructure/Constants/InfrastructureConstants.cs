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
        }

        public static class ApplicationUserConstant
        {
            public const int FirstNameMaxLength = 25;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 25;
            public const int LastNameMinLength = 2;
        }
        public static class ProductConstant
        {
            public const int NameMaxLength = 30;
            public const int DescriptionMaxLength = 250;
        }

        public static class SubscriptionType
        {
            public const int NameMaxLength = 15;
        }

        public static class Category
        {
            public const int NameMaxLength = 20;

            public const string ProteinsCategoryName = "Proteins";
            public const string WeightLossCategoryName = "Weight loss supplements";
        }
    }
}

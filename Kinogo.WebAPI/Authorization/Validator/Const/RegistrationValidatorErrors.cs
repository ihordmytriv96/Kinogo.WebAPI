namespace Kinogo.WebAPI.Host.Authorization.Validator.Const
{
    public static class RegistrationValidatorErrors
    {
        public const string UserNameIsNullOrEmpty = "User name is null or empty";
        public const string UserNameIsAlreadyInDatabase = "User name is already in database";
        public const string IncorrectPassword = "The password must consist of at least 6 and no more than 16 characters";
        public const string IncorrectUserName = "The user name must consist of at least 6 and no more than 16 characters";
        public const string IncorrectEmail = "Email must consist of at least 6 and no more than 30 characters";
        public const string IncorrectAge = "age must be at least 5 and not more than 99";
        public const string IncorrectFirstName = "The name must contain no more than 2 characters and no less than 14 characters";
        public const string IncorrectLastName = "The last name must contain no more than 2 characters and no less than 20 characters";
    }
}

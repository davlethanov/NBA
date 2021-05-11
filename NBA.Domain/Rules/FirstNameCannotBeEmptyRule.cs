
namespace NBA.Domain.Rules
{
    public class FirstNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string firstName;

        public FirstNameCannotBeEmptyRule(string firstName)
        {
            this.firstName = firstName;
        }
        public string Message => "First name cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(firstName);
    }
}

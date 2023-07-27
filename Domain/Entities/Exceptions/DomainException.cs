namespace Domain.Entities.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        {

        }

        public static void VerifyValidation(bool condition, string msg)
        {
            if(!condition) throw new DomainException(msg);
        }

    }
}

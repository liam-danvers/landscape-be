namespace landscape_be.models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Employee()
        { 
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }

         public Employee( string firstName, string lastName, string email)
        {
            if (firstName is null) throw new ArgumentNullException(nameof(firstName));
            if (lastName is null) throw new ArgumentNullException(nameof(lastName));
            if (email is null) throw new ArgumentNullException(nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} <{Email}>";
        }
    }
}

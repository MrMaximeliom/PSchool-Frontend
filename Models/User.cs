namespace TestBlazor.Models
{
    public class User
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime RegistrationDateTime { get; set; } = DateTime.UtcNow;

        public DateTime LastLoginDateTime { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Relation properties

        // Navigation properties

        public List<Parent>? Parents { get; set; }

        public List<Student>? Students { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}

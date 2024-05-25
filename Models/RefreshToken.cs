

namespace TestBlazor.Models
{

    public class RefreshToken
    {
        public string? Token { get; set; }

        public DateTime ExpiresOn { get; set; } 

        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

        public DateTime CreateAt { get; set; }

        public DateTime? RevokedOn { get; set; }

        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}

namespace Men_Fashion.Request
{
    public class RegisterRequest
    {
        public string? CodeEmail { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role = "US";
    }
}

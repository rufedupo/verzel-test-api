namespace verzel_test_api.domain.Responses
{
    public class RegisterResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

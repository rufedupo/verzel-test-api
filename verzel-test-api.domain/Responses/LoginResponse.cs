namespace verzel_test_api.domain.Responses
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpireToken { get; set; }
    }
}

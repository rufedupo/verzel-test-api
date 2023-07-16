namespace verzel_test_api.domain.Responses
{
    public class CarListResponse
    {
        public List<CarResponse> CarList { get; set; }

        public int TotalPages { get; set; }
    }
}

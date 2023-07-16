using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.domain.Interfaces.Services
{
    public interface ICarService
    {
        Task<CarListResponse> GetAllByUserId(int page, Guid userId);

        Task<CarListResponse> SearchCars(SearchCarViewModel searchCarViewModel);

        Task<CarResponse> CreateCar(AddCarViewModel addCarViewModel, Guid userId);

        Task<bool> DeleteCar(Guid id, Guid userId);
    }
}

using verzel_test_api.domain.Exceptions;
using verzel_test_api.domain.Interfaces.Repositories;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Models;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;
using System.Net;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace verzel_test_api.business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;

        public CarService (ICarRepository carRepository, IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public async Task<CarResponse> GetById(Guid id, Guid userId)
        {
            var car = await _carRepository.GetById(id);
            if (car == null)
                throw new HttpException("Veículo não encontrado", HttpStatusCode.NotFound);

            if (car.UserId != userId)
                throw new HttpException("Não está autorizado a excluir este veículo", HttpStatusCode.Unauthorized);

            return new CarResponse
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Age = car.Age,
                Km = car.Km,
                Price = car.Price.ToString("C").Replace("R$ ", ""),
                Photo = car.Photo,
                UserId = userId,
                CreatedAt = car.CreatedAt
            };
        }

        public async Task<CarListResponse> GetAllByUserId(int page, Guid userId)
        {
            var cars = await _carRepository.GetAll();
            var carList = cars.Where(c => c.UserId == userId).ToList();
            var totalPages = (carList.Count() / 24) + 1;
            carList = carList.OrderBy(c => c.Price)
                                .Skip(page * 24)
                                    .Take(24)
                                        .ToList();

            var carListResponse = new List<CarResponse>();
            carList.ForEach(car =>
            {
                carListResponse.Add(new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Brand = car.Brand,
                    Model = car.Model,
                    Color = car.Color,
                    Age = car.Age,
                    Km = car.Km,
                    Price = car.Price.ToString("C").Replace("R$ ", ""),
                    Photo = car.Photo,
                    UserId = car.UserId,
                    CreatedAt = car.CreatedAt
                });
            });

            return new CarListResponse()
            {
                CarList = carListResponse,
                TotalPages = totalPages
            };
        }

        public async Task<CarListResponse> SearchCars(SearchCarViewModel searchCarViewModel)
        {
            var cars = await _carRepository.GetAll();
            var carList = cars.Where(c => c.Name.ToUpper().Contains(searchCarViewModel.SearchText.ToUpper())).ToList();
            var totalPages = (carList.Count() / 24) + 1;
            carList = carList.OrderBy(c => c.Price)
                                .Skip(searchCarViewModel.Page * 24)
                                    .Take(24)
                                        .ToList();
            var carListResponse = new List<CarResponse>();
            carList.ForEach(car =>
            {
                carListResponse.Add(new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Brand = car.Brand,
                    Model = car.Model,
                    Color = car.Color,
                    Age = car.Age,
                    Km = car.Km,
                    Price = car.Price.ToString("C").Replace("R$ ", ""),
                    Photo = car.Photo,
                    UserId = car.UserId,
                    CreatedAt = car.CreatedAt
                });
            });

            return new CarListResponse()
            {
                CarList = carListResponse,
                TotalPages = totalPages
            };
        }

        public async Task<CarResponse> CreateCar(AddCarViewModel addCarViewModel, Guid userId)
        {
            var newCar = new Car
            {
                Id = Guid.NewGuid(),
                Name = addCarViewModel.Name,
                Brand = addCarViewModel.Brand,
                Model = addCarViewModel.Model,
                Color = addCarViewModel.Color,
                Age = addCarViewModel.Age,
                Km = addCarViewModel.Km,
                Price = addCarViewModel.Price,
                Photo = addCarViewModel.Photo,
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            var car = await _carRepository.Insert(newCar);
            return new CarResponse
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Age = car.Age,
                Km = car.Km,
                Price = car.Price.ToString("C").Replace("R$ ", ""),
                Photo = car.Photo,
                UserId = car.UserId,
                CreatedAt = car.CreatedAt
            };
        }

        public async Task<CarResponse> UpdateCar(EditCarViewModel editCarViewModel, Guid userId)
        {
            var car = await _carRepository.GetById(editCarViewModel.Id);
            if (car == null)
                throw new HttpException("Veículo não encontrado", HttpStatusCode.NotFound);

            if (car.UserId != userId)
                throw new HttpException("Não está autorizado a excluir este veículo", HttpStatusCode.Unauthorized);

            car.Name = editCarViewModel.Name;
            car.Brand = editCarViewModel.Brand;
            car.Model = editCarViewModel.Model;
            car.Color = editCarViewModel.Color;
            car.Age = editCarViewModel.Age;
            car.Km = editCarViewModel.Km;
            car.Price = editCarViewModel.Price;
            car.Photo = editCarViewModel.Photo;
            car.UpdatedAt = DateTime.UtcNow;

            var carUpdated = await _carRepository.Update(car);
            return new CarResponse
            {
                Id = carUpdated.Id,
                Name = carUpdated.Name,
                Brand = carUpdated.Brand,
                Model = carUpdated.Model,
                Color = carUpdated.Color,
                Age = carUpdated.Age,
                Km = carUpdated.Km,
                Price = carUpdated.Price.ToString("C").Replace("R$ ", ""),
                Photo = carUpdated.Photo,
                UserId = carUpdated.UserId,
                CreatedAt = carUpdated.CreatedAt,
                UpdatedAt = carUpdated.UpdatedAt
            };
        }

        public async Task<bool> DeleteCar(Guid id, Guid userId)
        {
            var car = await _carRepository.GetById(id);
            if (car == null)
                throw new HttpException("Veículo não encontrado", HttpStatusCode.NotFound);

            if (car.UserId != userId)
                throw new HttpException("Não está autorizado a excluir este veículo", HttpStatusCode.Unauthorized);
            
            await _carRepository.Delete(id);
            return true;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using verzel_test_api.domain.Exceptions;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Responses;
using verzel_test_api.domain.ViewModels;

namespace verzel_test_api.Controllers
{
    [ApiController]
    [Route("car")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<CarListResponse>> GetAllByUser(int page)
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
                var carListResponse = await _carService.GetAllByUserId(page, userId);
                return Ok(carListResponse);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        [AllowAnonymous]
        public async Task<ActionResult<CarListResponse>> Search([FromBody] SearchCarViewModel searchCarViewModel)
        {
            try
            {
                var carListResponse = await _carService.SearchCars(searchCarViewModel);
                return Ok(carListResponse);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CarResponse>> Create([FromBody] AddCarViewModel addCarViewModel)
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
                if (addCarViewModel == null)
                {
                    return BadRequest();
                }
                var carResponse = await _carService.CreateCar(addCarViewModel, userId);
                return Ok(carResponse);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<CarListResponse>> Delete(Guid id)
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
                var deleted = await _carService.DeleteCar(id, userId);
                return Ok(deleted ? "Veículo excluído com sucesso" : "");
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpStatusCode() == HttpStatusCode.NotFound)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}

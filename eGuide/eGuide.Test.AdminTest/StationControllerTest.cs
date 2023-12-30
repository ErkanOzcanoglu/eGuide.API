using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Cache.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using Xunit;

namespace eGuide.Test.AdminTest {
    public class StationControllerTest {

        /// <summary>
        /// The mock business
        /// </summary>
        private readonly Mock<IStationBusiness> _mockBusiness;

        /// <summary>
        /// The mock mapper
        /// </summary>
        private readonly Mock<IMapper> _mockMapper;

        /// <summary>
        /// The mock cache
        /// </summary>
        private readonly Mock<ICache> _mockCache;

        /// <summary>
        /// The controller
        /// </summary>
        private readonly StationController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationControllerTest"/> class.
        /// </summary>
        public StationControllerTest() {
            _mockBusiness = new Mock<IStationBusiness>();
            _mockMapper = new Mock<IMapper>();
            _mockCache = new Mock<ICache>();
            _controller = new StationController(_mockBusiness.Object, _mockMapper.Object, _mockCache.Object);
        }

        [Fact]
        public async void Get_ReturnListOfStations() {
            // Arrange
            var stations = new StationProfile[] {
                new StationProfile(),
                new StationProfile()
            };

            _mockBusiness.Setup(x => x.GetAllAsync()).ReturnsAsync(stations);

            // Act
            var result = await _controller.Get();

            // Assert
            

        }

        /// <summary>
        /// Posts the return ok result.
        /// </summary>
        [Fact]
        public async void Post_ReturnOkResult() {
            var id = Guid.NewGuid();
            var station = new CreationDtoForStationProfile {
                Id = id,
                Name = "Test",
                Address = "Address Test",
                Latitude = "12.3213213",
                Longitude = "12.3213213",
                StationStatus = 1
            };

            var stationEntity = new StationProfile {
                Id = id,
                Name = station.Name,
                Address = station.Address,
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                StationStatus = station.StationStatus
            };

            // Set up mock mapper to return the entity when the DTO is mapped to it
            _mockMapper.Setup(x => x.Map<StationProfile>(station)).Returns(stationEntity);
            // Set up mock business to return the entity when it is added
            _mockBusiness.Setup(x => x.AddAsync(stationEntity)).ReturnsAsync(stationEntity);

            // Act
            var result = await _controller.Post(station);

            // Assert
            var actionResult = Assert.IsType<ActionResult<StationProfile>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsType<StationProfile>(okObjectResult.Value);

            Assert.Equal(id, model.Id);
            Assert.Equal("Test", model.Name);
        }

        /// <summary>
        /// Puts the return ok result.
        /// </summary>
        [Fact]
        public async void Put_ReturnOkResult() {
            var id = Guid.NewGuid();
            var station = new UpdateDtoForStationProfile {
                Name = "Test",
                Address = "Address Test",
                Latitude = "12.3213213",
                Longtitude = "12.3213213",
                StationStatus = 1
            };

            var stationEntity = new StationProfile {
                Id = id,
                Name = "Test2",
                Address = "Address Test2",
                Latitude = "32.12312321",
                Longitude = "23.3213213",
                StationStatus = 1
            };

            // Set up mock mapper to return the entity when the DTO is mapped to it
            _mockBusiness.Setup(b => b.GetbyIdAsync(id)).ReturnsAsync(stationEntity);

            // Act
            var result = await _controller.Put(id, station);

            // Assert
            var actionResult = Assert.IsType<ActionResult<StationProfile>>(result);
            var okObjectResult = Assert.IsType<OkResult>(actionResult.Result);

            Assert.Equal(200, okObjectResult.StatusCode);
        }
    }
}
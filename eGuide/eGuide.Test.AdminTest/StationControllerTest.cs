using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.Identity.Client;
using Moq;
using Xunit;

namespace eGuide.Test.AdminTest {
    public class StationControllerTest {
        [Fact]
        public async void Get_ReturnsListOfStations() {

            // Arrange
            var mockBusiness = new Mock<IStationBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StationController(mockBusiness.Object, mockMapper.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Post_AddNewStaiton() {

            // Arrange 
            var mockBusiness = new Mock<IStationBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StationController(mockBusiness.Object, mockMapper.Object);

            var createDto = new CreationDtoForStationProfile {
                Address = "New Address",
                Latitude = "38.123982938",
                Longitude = "27.123982938",
                Name = "New Name",
                StationModelId = Guid.NewGuid()
            };

            // Act
            var result = await controller.Post(createDto);
            var model = result.Value as StationProfile;

            // Assert
            Assert.NotNull(result);
            // OkObjectResult
            if (model != null) {
                Assert.Equal("New Address", model.Address);
                Assert.Equal(1, model.Status);
                Assert.Equal("38.123982938", model.Latitude);
            }
        }

        [Fact]
        public async void Put_UpdateStationController() {

            // Arrange
            var mockBusiness = new Mock<IStationBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StationController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();
            var updateDto = new UpdateDtoForStationProfile {
                Address = "Update Address",
                Latitude = "38.123982938",
                Longtitude = "27.123982938",
                Name = "Update Name",
            };

            // Act
            var result = await controller.Put(id, updateDto);
            var model = result.Value as StationProfile;

            // Assert
            Assert.NotNull(result);
            if (model != null) {
                Assert.Equal("Update Address", model.Address);
                Assert.Equal("38.123982938", model.Latitude);
            }
        }

        [Fact]
        public async void Delete_RemoveStation() {

            // Arrange
            var mockBusiness = new Mock<IStationBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StationController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();

            // Act
            var result = await controller.Delete(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
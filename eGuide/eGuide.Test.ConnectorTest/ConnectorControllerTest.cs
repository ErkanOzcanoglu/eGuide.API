using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Moq;
using Xunit;

namespace eGuide.Test.ConnectorTest {
    public class ConnectorControllerTest {

        /// <summary>
        /// Gets the returns list of connectors.
        /// </summary>
        [Fact]
        public async void Get_ReturnsListOfConnectors() {

            // Arrange
            var mockBusiness = new Mock<IConnectorBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ConnectorController(mockBusiness.Object, mockMapper.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Posts the add new connector.
        /// </summary>
        [Fact]
        public async void Post_AddNewConnector() {

            // Arrange
            var mockBusiness = new Mock<IConnectorBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ConnectorController(mockBusiness.Object, mockMapper.Object);

            var createDto = new CreationDtoForConnector {
                Type = "New Type",
                Icon = "New Icon"
            };

            // Act
            var result = await controller.Post(createDto);
            var model = result.Value as Connector;

            // Assert
            Assert.NotNull(result);
            // OkObjectResult 
            if (model != null) {
                Assert.Equal("New Type", model.Type);
                Assert.Equal(1, model.Status);
            }

        }

        /// <summary>
        /// Puts the updates connector.
        /// </summary>
        [Fact]
        public async void Put_UpdatesConnector() {

            // Arrange
            var mockBusiness = new Mock<IConnectorBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ConnectorController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();
            var updateDto = new UpdateDtoForConnector {
                Type = "Updated Type",
                Icon = "Updated Icon"
            };

            // Act
            var result = await controller.Put(id, updateDto);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Deletes the remove connector.
        /// </summary>
        [Fact]
        public async void Delete_RemoveConnector() {

            // Arrange 
            var mockBusiness = new Mock<IConnectorBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ConnectorController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();

            // Act
            var result = await controller.Delete(id);
            var model = result.Value as Connector;

            // Assert
            Assert.NotNull(result);
            // OkObjectResult
            if (model != null)
                Assert.Equal(0, model.Status);

        }
    }
}
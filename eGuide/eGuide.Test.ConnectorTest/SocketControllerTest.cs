using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Moq;
using Xunit;

namespace eGuide.Test.ConnectorTest {
    public class SocketControllerTest {
        /// <summary>
        /// Gets the returns list of sockets.
        /// </summary>
        [Fact]
        public async void Get_ReturnsListOfSockets() {
            // Arrange
            var mockBusiness = new Mock<ISocketBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new SocketController(mockBusiness.Object, mockMapper.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Posts the add new socket.
        /// </summary>
        [Fact]
        public async void Post_AddNewSocket() {
            // Arrange
            var mockBusiness = new Mock<ISocketBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new SocketController(mockBusiness.Object, mockMapper.Object);

            var createDto = new CreationDtoForSocket {
                ConnectorId = Guid.NewGuid(),
                Name = "New Name",
                Current = "200",
                Voltage = "220",
                Power = "100",
                Type = "New Type"
            };

            // Act
            var result = await controller.AddSocket(createDto);
            var model = result.Value as Socket;

            // Assert
            Assert.NotNull(result);

            if(model != null) {
                Assert.Equal("220", model.Voltage);
                Assert.Equal(1, model.Status);
            }
        }

        /// <summary>
        /// Puts the updates socket.
        /// </summary>
        [Fact]
        public async void Put_UpdatesSocket() {
            // Arrange
            var mockBusiness = new Mock<ISocketBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new SocketController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();
            var updateDto = new UpdateDtoForSocket {
                Current = "300",
                Voltage = "220",
                Power = "100",
                Type = "Updated Type"
            };

            // Act
            var result = await controller.Put(id, updateDto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Delete_RemoveSocket() {
            // Arrange
            var mockBusiness = new Mock<ISocketBusiness>();
            var mockMapper = new Mock<IMapper>();
            var controller = new SocketController(mockBusiness.Object, mockMapper.Object);

            var id = Guid.NewGuid();

            // Act
            var result = await controller.Delete(id);
            var model = result.Value as Socket;

            // Assert
            Assert.NotNull(result);
            if(model != null) {
                Assert.Equal(1, model.Status);
            }
        }
    }
}
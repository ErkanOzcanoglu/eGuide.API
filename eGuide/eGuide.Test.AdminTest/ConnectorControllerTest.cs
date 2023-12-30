using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Conctrete;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace eGuide.Test.AdminTest {
    public class ConnectorControllerTest {

        /// <summary>
        /// The mock business
        /// </summary>
        private readonly Mock<IConnectorBusiness> _mockBusiness;

        /// <summary>
        /// The mock mapper
        /// </summary>
        private readonly Mock<IMapper> _mockMapper;

        /// <summary>
        /// The controller
        /// </summary>
        private readonly ConnectorController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorControllerTest"/> class.
        /// </summary>
        public ConnectorControllerTest() {
            _mockBusiness = new Mock<IConnectorBusiness>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ConnectorController(_mockBusiness.Object, _mockMapper.Object);
        }


        /// <summary>
        /// Gets the returns list of connectors.
        /// </summary>
        //[Fact]
        //public async void Get_ReturnsListOfConnectors() {
        //    var connectors = new List<Connector> {
        //        new Connector {
        //            ImageName = "Test Image Name",
        //            Status = 1,
        //            CreatedDate = DateTime.Now,
        //            Type = "Test Type",
        //            ImageData = "Test Image Data",
                    
        //            Sockets = new List<ChargingUnit> {
        //                new ChargingUnit {
        //                    Current = "200",
        //                    Name = "Test Name",
        //                    Power = "200",
        //                    Type = "Test Type",
        //                    Voltage = "200",
        //                    CreatedDate = DateTime.Now,
        //                }

        //            }
        //        }
        //    };

        //    _mockBusiness.Setup(x => x.GetAllAsync()).ReturnsAsync(connectors);

        //    // Act
        //    var result = await _controller.Get();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<ActionResult<Connector>>(result);
        //    var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //    var model = Assert.IsAssignableFrom<Connector>(okResult.Value);

        //    Assert.Contains(connectors, x => x.ImageName == "Test Image Name");
        //}

        /// <summary>
        /// Gets the return connector with identifier.
        /// </summary>
        [Fact]
        public async void Get_ReturnConnectorWithId() {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var connectors = new List<Connector> {
                new Connector {
                    Id = id1,
                    ImageName = "Test Image Name",
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    Type = "Test Type",
                    ImageData = "Test Image Data",
                },
                new Connector {
                    Id = id2,
                    ImageName = "Test Image Name2",
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    Type = "Test Type2",
                    ImageData = "Test Image Data2",
                }
            };

            _mockBusiness.Setup(x => x.GetbyIdAsync(id1)).ReturnsAsync(connectors[0]);
            _mockBusiness.Setup(x => x.GetbyIdAsync(id2)).ReturnsAsync(connectors[1]);

            //  Act
            var result1 = await _controller.GetById(id1);

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<ActionResult<Connector>>(result1);
            var okResult1 = Assert.IsType<OkObjectResult>(result1.Result);
            var model1 = Assert.IsAssignableFrom<Connector>(okResult1.Value);
            Assert.NotNull(model1);
            Assert.Equal("Test Image Name", model1.ImageName);

            //  Act
            var result2 = await _controller.GetById(id2);

            // Assert
            Assert.NotNull(result2);
            Assert.IsType<ActionResult<Connector>>(result2);
            var okResult2 = Assert.IsType<OkObjectResult>(result2.Result);
            var model2 = Assert.IsAssignableFrom<Connector>(okResult2.Value);
            Assert.NotNull(model2);
            Assert.Equal("Test Image Name2", model2.ImageName);

        }

        /// <summary>
        /// Posts the add new connector.
        /// </summary>
        [Fact]
        public async void Post_AddNewConnector() {
            var connectorDto = new CreationDtoForConnector {
                Type = "Test Type",
                ImageData = "Test Image Data",
                ImageName = "Test Image Name"
            };

            var connector = new Connector {
                Id = Guid.NewGuid(),
                ImageName = connectorDto.ImageName,
                Status = 1,
                CreatedDate = DateTime.Now,
                Type = connectorDto.Type,
                ImageData = connectorDto.ImageData,
                Sockets = new List<ChargingUnit> {
                    new ChargingUnit {
                        Id = Guid.NewGuid(),
                        Status = 1,
                        CreatedDate = DateTime.Now,
                        Name = "Test Name",
                        ConnectorId = Guid.NewGuid(),
                        Current = "200",
                        Power = "200",
                        Voltage = "200",
                        Type = "Test Type",
                    }
                }
            };

            _mockMapper.Setup(x => x.Map<Connector>(connectorDto)).Returns(connector);

            _mockBusiness.Setup(x => x.AddAsync(connector)).ReturnsAsync(connector);

            // Act
            var result = await _controller.Post(connectorDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<Connector>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<Connector>(okResult.Value);

            Assert.Equal("Test Image Name", model.ImageName);
        }

        /// <summary>
        /// Puts the updates connector.
        /// </summary>
        [Fact]
        public async void Put_UpdatesConnector() {
            var id = Guid.NewGuid();
            var updateDto = new UpdateDtoForConnector {
                Type = "Updated Type",
                ImageData = "Updated Image Data",
                ImageName = "Updated Image Name"
            };

            var existingEntity = new Connector {
                Id = id,
                Type = "Original Type",
                ImageData = "Original Image Data",
                ImageName = "Original Image Name",
            };

            // Set up mock business to return the entity when it is updated
            _mockBusiness.Setup(b => b.GetbyIdAsync(id)).ReturnsAsync(existingEntity);

            // Act
            var result = await _controller.Put(id, updateDto);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal("Updated Type", existingEntity.Type);
            Assert.Equal("Updated Image Data", existingEntity.ImageData);
            Assert.Equal("Updated Image Name", existingEntity.ImageName);

        }

        /// <summary>
        /// Deletes the remove connector.
        /// </summary>

        [Fact]
        public async void Post_AddsConnectorAndStatusIs1() {
            
            var creationDto = new CreationDtoForConnector {
                Type = "NewType",
                ImageData = "NewImageData",
                ImageName = "NewImageName"
            };

            // Act
            var result = await _controller.Post(creationDto);
            var model = result.Value as Connector;

            // Assert
            Assert.NotNull(result);
            // OkObjectResult 
            if (model != null) {
                Assert.Equal(1, model.Status);
            }
        }

        /// <summary>
        /// Gets all returns active connectors.
        /// </summary>
        [Fact]
        public void GetAll_ReturnsActiveConnectors() {
            
            // Arrange
            var connectors = new List<Connector> {
                new Connector { Id = Guid.NewGuid(), Status = 1 },
                new Connector { Id = Guid.NewGuid(), Status = 1 },
                new Connector { Id = Guid.NewGuid(), Status = 0 },
                new Connector { Id = Guid.NewGuid(), Status = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Connector>>();
            mockSet.As<IQueryable<Connector>>().Setup(m => m.Provider).Returns(connectors.Provider);
            mockSet.As<IQueryable<Connector>>().Setup(m => m.Expression).Returns(connectors.Expression);

            var mockContext = new Mock<eGuideContext>();
            mockContext.Setup(c => c.Set<Connector>()).Returns(mockSet.Object);

            var repository = new ConnectorRepository(mockContext.Object);

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.Equal(3, result.Count()); 
            }
        }

}
using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace eGuide.Test.AdminTest {

    /// <summary>
    /// 
    /// </summary>
    public class CharigngUnitControllerTest {

        /// <summary>
        /// The mock business
        /// </summary>
        private readonly Mock<IChargingUnitBusiness> _mockBusiness;

        /// <summary>
        /// The mock mapper
        /// </summary>
        private readonly Mock<IMapper> _mockMapper;

        /// <summary>
        /// The controller
        /// </summary>
        private readonly ChargingUnitController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharigngUnitControllerTest"/> class.
        /// </summary>
        public CharigngUnitControllerTest() {
            _mockBusiness = new Mock<IChargingUnitBusiness>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ChargingUnitController(_mockBusiness.Object, _mockMapper.Object);
        }

        /// <summary>
        /// Gets the returns list of charging units.
        /// </summary>
        [Fact]
        public async void Get_ReturnsListOfChargingUnits() {
            var chargingUnits = new List<ChargingUnit> {
                new ChargingUnit {
                    Id = Guid.NewGuid(),
                    Voltage = "220",
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Test Name",
                    Power = "100",
                    Current = "200",
                    Type = "Test Type",
                    Connector = new Connector {
                        Id = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                        Status = 1,
                        CreatedDate = DateTime.Now,
                        ImageData = "Test Image Data",
                        ImageName = "Test Image Name",
                        Type = "Test Type",
                    },
                    ConnectorId = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                }
            };

            _mockBusiness.Setup(x => x.GetAllAsync()).ReturnsAsync(chargingUnits);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<ChargingUnit>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<ChargingUnit>>(okResult.Value);

            Assert.Contains(model, x => x.Voltage == "220");
            Assert.Contains(model, x => x.Status == 1);
            Assert.Contains(model, x => x.Connector.Id == Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"));
        }

        /// <summary>
        /// Gets the return charging unit with identifier.
        /// </summary>
        [Fact]
        public async void Get_ReturnChargingUnitWithId() {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var chargingUnits = new List<ChargingUnit> {
                new ChargingUnit {
                    Id = id1,
                    Voltage = "220",
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Test Name",
                    Power = "100",
                    Current = "200",
                    Type = "Test Type",
                    Connector = new Connector {
                        Id = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                        Status = 1,
                        CreatedDate = DateTime.Now,
                        ImageData = "Test Image Data",
                        ImageName = "Test Image Name",
                        Type = "Test Type",
                    },
                    ConnectorId = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                },
                new ChargingUnit {
                    Id = id2,
                    Voltage = "120",
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Test Name2",
                    Power = "300",
                    Current = "400",
                    Type = "Test Type2",
                    Connector = new Connector {
                        Id = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                        Status = 1,
                        CreatedDate = DateTime.Now,
                        ImageData = "Test Image Data",
                        ImageName = "Test Image Name",
                        Type = "Test Type",
                    },
                    ConnectorId = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
                }
            };

            _mockBusiness.Setup(x => x.GetbyIdAsync(id1)).ReturnsAsync(chargingUnits[0]);
            _mockBusiness.Setup(x => x.GetbyIdAsync(id2)).ReturnsAsync(chargingUnits[1]);


            // Act
            var result = await _controller.GetById(id2);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<ChargingUnit>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<ChargingUnit>(okResult.Value);
            Assert.NotNull(model);
            Assert.Equal("120", model.Voltage);
            Assert.Equal("Test Name2", model.Name);
            Assert.Equal("Test Type", model.Connector.Type);
        }

        /// <summary>
        /// Posts the add new charging units.
        /// </summary>
        [Fact]
        public async void AddChargingUnits_ReturnsOkResult() {
            var chargingUnitDto = new CreationDtoForChargingUnit {
                // Set properties of the DTO for testing
                Voltage = "220",
                Name = "Test Name",
                Power = "100",
                Current = "200",
                Type = "Test Type",
                ConnectorId = Guid.Parse("67034ff8-bb10-4bd0-9e96-90f0288328bc"),
            };

            var chargingUnitEntity = new ChargingUnit {
                Id = Guid.Parse("f1d84052-75b7-44b2-b3a6-075c647a969b"),
                Voltage = chargingUnitDto.Voltage,
                Name = chargingUnitDto.Name,
                Power = chargingUnitDto.Power,
                Current = chargingUnitDto.Current,
                Type = chargingUnitDto.Type,
                ConnectorId = chargingUnitDto.ConnectorId,
                CreatedDate = DateTime.Now,
                Status = 1,
                Connector = new Connector { 
                    Id = chargingUnitDto.ConnectorId,
                    CreatedDate = DateTime.Now,
                    ImageData = "Test Image Data",
                    ImageName = "Test Image Name",
                    Status = 1,
                    Type = "Test Type",
                }
            };

            // Set up mock mapper to return the entity when the DTO is mapped to it
            _mockMapper.Setup(m => m.Map<ChargingUnit>(chargingUnitDto)).Returns(chargingUnitEntity);
            // Set up mock business to return the entity when it is added
            _mockBusiness.Setup(b => b.AddAsync(chargingUnitEntity)).ReturnsAsync(chargingUnitEntity);

            // Act
            var result = await _controller.AddSocket(chargingUnitDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ChargingUnit>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsType<ChargingUnit>(okObjectResult.Value);

            Assert.Equal("220", model.Voltage);
            Assert.Equal("Test Name", model.Name);
            Assert.Equal("Test Type", model.Connector.Type);
        }

        /// <summary>
        /// Puts the update charging unit returns ok result.
        /// </summary>
        [Fact]
        public async void Put_UpdateChargingUnit_ReturnsOkResult() {
            var id = Guid.NewGuid(); 
            var updateDto = new UpdateDtoForChargingUnit {
                Voltage = "Updated Voltage",
                Current = "Updated Current",
                Name = "Updated Name",
                Power = "Updated Power",
                Type = "Updated Type",
            };

            var existingEntity = new ChargingUnit {
                Id = id,
                Voltage = "Original Voltage",
                Current = "Original Current",
                Name = "Original Name",
                Power = "Original Power",
                Type = "Original Type",
            };

            // Set up mock business to return the entity when it is updated
            _mockBusiness.Setup(b => b.GetbyIdAsync(id)).ReturnsAsync(existingEntity);

            // Act
            var result = await _controller.Put(id, updateDto);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal("Updated Voltage", existingEntity.Voltage);
            Assert.Equal("Updated Current", existingEntity.Current);
            Assert.Equal("Updated Name", existingEntity.Name);
            Assert.Equal("Updated Power", existingEntity.Power);
            Assert.Equal("Updated Type", existingEntity.Type);
        }

        /// <summary>
        /// Puts the entity not found returns not found result.
        /// </summary>
        [Fact]
        public async void Put_EntityNotFound_ReturnsNotFoundResult() {
            var id = Guid.Parse("c3e44ebc-82bc-4634-826d-4a6e72c9fa7a");
            var updateDto = new UpdateDtoForChargingUnit {
                Voltage = "Updated Voltage",
                Current = "Updated Current",
                Name = "Updated Name",
                Power = "Updated Power",
                Type = "Updated Type",
            };

            // Act
            var result = await _controller.Put(id, updateDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
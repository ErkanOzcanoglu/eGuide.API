using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Station;
using eGuide.Service.AdminAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eGuide.Test.AdminTest {
    public class ColorControllerTest {

        /// <summary>
        /// The mock business
        /// </summary>
        private readonly Mock<IColorBusiness> _mockBusiness;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly Mock<IMapper> _mapper;

        /// <summary>
        /// The controller
        /// </summary>
        private readonly ColorController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorControllerTest"/> class.
        /// </summary>
        public ColorControllerTest() {
            _mockBusiness = new Mock<IColorBusiness>();
            _mapper = new Mock<IMapper>();
            _controller = new ColorController(_mockBusiness.Object, _mapper.Object);
        }

        /// <summary>
        /// Gets the color of the return list of.
        /// </summary>
        [Fact]
        public async void Get_ReturnListOfColor() {
            var color = new List<Color> {
                new Color {
                    DarkColor1 = "#000000",
                    DarkColor2 = "#000000",
                    DarkColor3 = "#000000",
                    DarkColor4 = "#000000",
                    DarkColor5 = "#000000",
                    LightColor1 = "#000000",
                    LightColor2 = "#000000",
                    LightColor3 = "#000000",
                    LightColor4 = "#000000",
                    LightColor5 = "#000000",
                    CreatedDate = DateTime.Now,
                }
            };

            _mockBusiness.Setup(x => x.GetAllAsync()).ReturnsAsync(color);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<Color>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<Color>>(okResult.Value);

            Assert.Contains(model, x => x.LightColor1 == "#000000");
        }

        /// <summary>
        /// Posts the return ok.
        /// </summary>
        [Fact]
        public async void Post_ReturnOk() {
            var dto = new CreationDtoForColor {
                DarkColor1 = "#000001",
                DarkColor2 = "#000001",
                DarkColor3 = "#000001",
                DarkColor4 = "#000001",
                DarkColor5 = "#000001",
                LightColor1 = "#000001",
                LightColor2 = "#000001",
                LightColor3 = "#000001",
                LightColor4 = "#000001",
                LightColor5 = "#000001",
            };

            var color = new Color {
                DarkColor1 = dto.DarkColor1,
                DarkColor3 = dto.DarkColor2,
                DarkColor2 = dto.DarkColor3,
                DarkColor4 = dto.DarkColor4,
                DarkColor5 = dto.DarkColor5,
                LightColor1 = dto.LightColor1,
                LightColor2 = dto.LightColor2,
                LightColor3 = dto.LightColor3,
                LightColor4 = dto.LightColor4,
                LightColor5 = dto.LightColor5,
                CreatedDate = DateTime.Now,
            };

            _mapper.Setup(x => x.Map<Color>(dto)).Returns(color);
            _mockBusiness.Setup(x => x.AddAsync(color)).ReturnsAsync(color);

            // Act
            var result = await _controller.Post(dto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Color>(okResult.Value);

            Assert.Equal("#000001", model.DarkColor1);
        }

        /// <summary>
        /// Puts the upadate color return ok result.
        /// </summary>
        [Fact]
        public async void Put_UpadateColor_ReturnOkResult() {
            var id = Guid.NewGuid();
            var dto = new UpdateDtoForColor {
                DarkColor1 = "#000001",
                DarkColor2 = "#000001",
                DarkColor3 = "#000001",
                DarkColor4 = "#000001",
                DarkColor5 = "#000001",
                LightColor1 = "#000001",
                LightColor2 = "#000001",
                LightColor3 = "#000001",
                LightColor4 = "#000001",
                LightColor5 = "#000001",
            };

            var color = new Color {
                Id = id,
                DarkColor1 = "#111111",
                DarkColor3 = "#111111",
                DarkColor2 = "#111111",
                DarkColor4 = "#111111",
                DarkColor5 = "#111111",
                LightColor1 = "#222222",
                LightColor2 = "#222222",
                LightColor3 = "#222222",
                LightColor4 = "#222222",
                LightColor5 = "#222222",
                CreatedDate = DateTime.Now,
            };

            // Set up mock business to return the entity when it is updated
            _mockBusiness.Setup(b => b.GetbyIdAsync(id)).ReturnsAsync(color);

            // Act
            var result = await _controller.Put(dto, id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
            Assert.Equal("#222222", color.LightColor5);
            Assert.Equal("#111111", color.DarkColor5);
        }
    }
}

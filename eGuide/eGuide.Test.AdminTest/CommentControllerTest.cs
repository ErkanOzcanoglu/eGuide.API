using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Station;
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
    public class CommentControllerTest {

        /// <summary>
        /// The mock business
        /// </summary>
        private readonly Mock<ICommentBusiness> _mockBusiness;

        /// <summary>
        /// The mock mapper
        /// </summary>
        private readonly Mock<IMapper> _mockMapper;

        /// <summary>
        /// The controller
        /// </summary>
        private readonly CommentController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentControllerTest"/> class.
        /// </summary>
        public CommentControllerTest() {
            _mockBusiness = new Mock<ICommentBusiness>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CommentController(_mockBusiness.Object, _mockMapper.Object);
        }

        /// <summary>
        /// Gets the return list of comments.
        /// </summary>
        [Fact]
        public async void Get_ReturnListOfComments() {
            var id = Guid.NewGuid();
            var stationId = Guid.NewGuid();
            var ownerId = Guid.NewGuid();
            var comment = new List<Comment> {
                new Comment {
                Id = id,
                StationId = stationId,
                OwnerId = ownerId,
                Text = "Test",
                Rating = 5,
                Status = 1,
                }
            };

            _mockBusiness.Setup(b => b.GetAllComments()).ReturnsAsync(comment);

            // Act
            var result = await _controller.GetAllComments();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<Comment>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<Comment>>(okResult.Value);

            Assert.Contains(model, x => x.Rating == 5);
            Assert.Contains(model, x => x.Status == 1);
        }
    }
}

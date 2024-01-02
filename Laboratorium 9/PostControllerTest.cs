using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_9
{
    using Laboratorium3___App.Controllers;
    using Laboratorium3___App.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Moq;

    namespace Laboratorium_9
    {
        public class PostControllerTest
        {
            private PostController _controller;
            private IPostService _service;
            private IDateTimeProvider _dateTimeProvider;

            public PostControllerTest()
            {
                _dateTimeProvider = new CurrentDateTimeProvider();
                _service = new MemoryPostService(_dateTimeProvider);
                _service.Add(new Post() { Id = 1 });
                _service.Add(new Post() { Id = 2 });
                _controller = new PostController(_service);
            }

          

            [Theory]
            [InlineData(45)]
            [InlineData(99)]
            public void DetailsTestForNotExistingPost(int id)
            {
                var result = _controller.Details(id);
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}

namespace LuxuryEstateProject.Services.Data.Tests.BlogServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Models;
    using LuxuryEstateProject.Data.Repositories;
    using Xunit;

    public class CommentServiceTests : TestBase
    {
        public CommentServiceTests()
        {
        }

        [Fact]
        public async Task AddCommentShouldWorkCorrectly()
        {
            var db = GetDatabase();

            var commentRepository = new EfDeletableEntityRepository<Comment>(db);

            var service = new CommentService(commentRepository);

            await service.AddCommentAsync("someContent", 1, "1", "123@abv.bg");

            Assert.Equal(1, await service.GetCountAsync());
        }
    }
}

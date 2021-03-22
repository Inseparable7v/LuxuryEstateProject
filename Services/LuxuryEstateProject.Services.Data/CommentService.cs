namespace LuxuryEstateProject.Services.Data
{
    using System.Threading.Tasks;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task AddCommentAsync(string content, int blogId, string userId, string email)
        {
            //var user = commentsRepository.AllAsNoTracking.AgentId

            var comment = new Comment
            {
                Content = content,
                BlogId = blogId,
                AddedByUserId = userId,
                Name = email,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}

namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task AddCommentAsync(string content, int blogId, string userId, string email);
    }
}

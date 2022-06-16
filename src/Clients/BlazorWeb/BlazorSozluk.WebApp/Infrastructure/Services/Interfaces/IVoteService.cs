namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IVoteService
    {
        Task DeleteEntryCommentVote(Guid entryCommentId);
        Task DeleteEntryVote(Guid entryId);
    }
}
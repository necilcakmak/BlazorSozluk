namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IVoteService
    {
        Task DeleteEntryCommentVote(Guid entryCommentId);
        Task DeleteEntryVote(Guid entryId);
        Task CreateEntryUpVote(Guid entryId);
        Task CreateEntryDownVote(Guid entryId);
    }
}
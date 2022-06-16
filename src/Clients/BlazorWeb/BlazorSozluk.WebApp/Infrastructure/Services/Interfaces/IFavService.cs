namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IFavService
    {
        Task CreateEntryFav(Guid entryId);
        Task CreateEntryCommentFav(Guid entryCommentId);
        Task DeleteEntryFav(Guid entryId);
        Task DeleteEntryCommentFav(Guid entryCommentId);
    }
}

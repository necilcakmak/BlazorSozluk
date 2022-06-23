using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient client;

        public VoteService(HttpClient client)
        {
            this.client = client;
        }
        public async Task CreateEntryUpVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote Error");
        }

        public async Task DeleteEntryVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote Error");
        }

        public async Task DeleteEntryCommentVote(Guid entryCommentId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryCommentVote Error");
        }

        public async Task CreateEntryDownVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("CreateEntryDownVote Error");
        }
    }
}

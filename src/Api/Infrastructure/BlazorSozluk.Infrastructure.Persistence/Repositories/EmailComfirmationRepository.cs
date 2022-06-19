using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;

namespace BlazorSozluk.Infrastructure.Persistence.Repositories
{
    public class EmailComfirmationRepository : GenericRepository<EmailConfirmation>, IEmailComfirmationRepository
    {
        public EmailComfirmationRepository(BlazorSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}

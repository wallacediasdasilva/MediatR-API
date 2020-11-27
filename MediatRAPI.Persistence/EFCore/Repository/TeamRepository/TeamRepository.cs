using DDDAPI.Domain.Interfaces.TeamRepository;
using DDDAPI.Domain.Team;
using DDDAPI.Persistence.EFCore.Context;
using DDDAPI.Persistence.EFCore.Repository.Core;

namespace DDDAPI.Persistence.EFCore.Repository.TeamRepository
{
    public class TeamRepository : Repository<TeamEntity>, ITeamRepository
    {
        public TeamRepository(MediatRContext mediatRContext) : base(mediatRContext)
        {

        }
    }
}

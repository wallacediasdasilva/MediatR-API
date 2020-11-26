using AutoMapper;
using DDDAPI.Application.App.Interface;
using DDDAPI.Application.DTO;
using DDDAPI.Domain.Interfaces.TeamRepository;
using DDDAPI.Domain.Team;

namespace DDDAPI.Application.App
{
    public class TeamApplication : ITeamApplication
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TeamApplication(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public void Create(TeamCreateDTO teamsDTO)
        {
            var teams = _mapper.Map<TeamEntity>(teamsDTO);

            _teamRepository.Create(teams);
        }

        public void Delete(int id)
        {
            _teamRepository.Delete(_teamRepository.GetById(id));
        }

        public TeamListDTO GetById(int id)
        {
            return _mapper.Map<TeamListDTO>(_teamRepository.GetById(id));
        }

        public void Update(int id, TeamUpdateDTO teamDTO)
        {

            var teams = _mapper.Map<TeamEntity>(teamDTO);
            teams.Id = id;
            _teamRepository.Update(teams);
        }
    }
}

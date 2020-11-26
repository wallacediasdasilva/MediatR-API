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
            var teams = new TeamEntity(teamsDTO.Name, teamsDTO.Modality, teamsDTO.QtdPlayers);

            _teamRepository.Create(teams);
        }

        public void Delete(int id)
        {
            var teams = _teamRepository.GetById(id);

            _teamRepository.Delete(teams);
        }

        public TeamListDTO GetById(int id)
        {
            var teams = _teamRepository.GetById(id);

            var team = new TeamListDTO()
            {
                Name = teams.Name,
                Modality = teams.Modality,
                QtdPlayers = teams.QtdPlayers
            };

            return team;
        }

        public void Update(int id, TeamUpdateDTO teamDTO)
        {
            var teams = _teamRepository.GetById(id);

            if (teams != null)
            {
                teams.ChangeName(teamDTO.Name);
                teams.ChangeModality(teamDTO.Modality);
                teams.ChangeQtdPlayers(teamDTO.QtdPlayers);
                _teamRepository.Update(teams);
            }
        }
    }
}

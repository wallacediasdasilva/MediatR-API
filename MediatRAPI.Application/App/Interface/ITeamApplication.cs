using DDDAPI.Application.DTO;

namespace DDDAPI.Application.App.Interface
{
    public interface ITeamApplication
    {
        void Create(TeamCreateDTO command);
        void Update(int id, TeamUpdateDTO teamDTO);
        void Delete(int id);
        TeamListDTO GetById(int id);
    }
}

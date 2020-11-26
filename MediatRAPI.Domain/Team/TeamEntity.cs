using DDDAPI.CrossCutting.Support.Util;
using MediatR.Test.Util;

namespace DDDAPI.Domain.Team
{
    public class TeamEntity
    {
        public TeamEntity(string name, string modality, int qtdPlayers)
        {
            RuleValidator.New()
                .When(string.IsNullOrEmpty(name), Resource.InvalidName)
                .When(string.IsNullOrEmpty(modality), Resource.InvalidModality)
                .When(qtdPlayers <= 0, Resource.InvalidQtdPlayers)
                .ExceptionIfExist();

            Name = name;
            Modality = modality;
            QtdPlayers = qtdPlayers;
        }

        public TeamEntity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Modality { get; private set; }
        public int QtdPlayers { get; private set; }

        public void ChangeName(string nome)
        {
            Name = nome;
        }
        public void ChangeModality(string modality)
        {
            Modality = modality;
        }
        public void ChangeQtdPlayers(int qtdPlayers)
        {
            QtdPlayers = qtdPlayers;
        }
    }
}

using MediatR.Test.Util;
using MediatRAPI.CrossCutting.Support.Util;
using System.Text.RegularExpressions;

namespace MediatRAPI.Domain.User
{
    public class UserEntity
    {
        public UserEntity(string name, string cpf, string email, string phone)
        {
            RuleValidator.New()
                .When(string.IsNullOrEmpty(name), Resource.InvalidName)
                .CpfIsValid(cpf, Resource.InvalidCpf)
                .When(string.IsNullOrEmpty(email), Resource.InvalidEmail)
                .When(string.IsNullOrEmpty(phone), Resource.InvalidPhone)
                .ExceptionIfExist();

            Name = name;
            CPF = cpf;
            Email = email;
            Phone = phone;
        }

        public UserEntity(int id)
        {
            Id = id;
        }

        private readonly Regex _cpfRegex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }


        public void ChangeName(string nome)
        {
            Name = nome;
        }
    }
}

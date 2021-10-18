using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Entities
{
    public class UtilizadorEntity : BaseEntity, IAggregateRoot
    {
        public string Username { get; }
        public string Email { get; }
        public IEnumerable<EntidadeEntity> Entidades { get; }

        public UtilizadorEntity(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

    }
}

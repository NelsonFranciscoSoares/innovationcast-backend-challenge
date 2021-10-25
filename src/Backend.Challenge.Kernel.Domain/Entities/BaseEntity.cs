using System;

namespace Backend.Challenge.Kernel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DataInsercao { get; set; }

        public DateTime? DataEdicao { get; set; }

        protected BaseEntity() {
            this.Id = Guid.NewGuid();
        }
    }
}

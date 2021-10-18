using System;

namespace Backend.Challenge.Kernel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset DataInsercao { get; set; }

        public DateTimeOffset DataEdicao { get; set; }

        protected BaseEntity() {
            this.Id = Guid.NewGuid();
        }
    }
}

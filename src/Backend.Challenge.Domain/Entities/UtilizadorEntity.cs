﻿using Backend.Challenge.Kernel.Domain.AggregateRoot;
using Backend.Challenge.Kernel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Entities
{
    public class UtilizadorEntity : BaseEntity, IAggregateRoot
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<ComentarioEntity> ComentariosVisualizados { get; }

        public UtilizadorEntity(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        public UtilizadorEntity(Guid id)
        {
            this.Id = id;
        }

        public UtilizadorEntity() { }

    }
}

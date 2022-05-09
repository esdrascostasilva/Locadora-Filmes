using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.API.Model
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Communicator.Domain.Entities.Base
{
    public abstract class Entity : IEntitiesBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }

        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }
    }
}
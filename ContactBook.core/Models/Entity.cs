using ContactBook.core.Interfaces;

namespace ContactBook.core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
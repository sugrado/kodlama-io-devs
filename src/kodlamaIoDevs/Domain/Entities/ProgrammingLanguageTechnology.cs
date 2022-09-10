using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguageTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology()
        {

        }

        public ProgrammingLanguageTechnology(int id, int programmingLanguageId, string name, string description) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Description = description;
        }
    }
}

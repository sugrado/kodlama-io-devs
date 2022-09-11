namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class ProgrammingLanguageTechnologyGetByIdDto
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

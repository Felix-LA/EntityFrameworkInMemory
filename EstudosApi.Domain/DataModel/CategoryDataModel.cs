using EstudosApi.Domain.Enums;

namespace EstudosApi.Domain.DataModel
{
    public class CategoryDataModel
    {
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public int Id { get; set; }
    }
}

using EstudosApi.Domain.Enums;

namespace EstudosApi.Domain.DataModel
{
    public class CategoryDataModel
    {
        public string Name { get; set; }
        public CategoryStatusEnum Status { get; set; }
        public int Id { get; set; }
    }
}

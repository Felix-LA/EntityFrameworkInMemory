using EntityFrameworkInMemory.Enums;

namespace EntityFrameworkInMemory.DataModel
{
    public class CategoryDataModel
    {
        public string Name { get; set; }
        public CategoryStatusEnum Status { get; set; }
        public int Codigo { get; set; }
    }
}

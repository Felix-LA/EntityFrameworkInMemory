using EntityFrameworkInMemory.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkInMemory.DataModel
{
    public class ProductDataModel
    {
        public string? Name { get; set; }
        public CategoryModel Category { get; set; }
        public float Price { get; set; }
        public int Codigo { get; set; }
    }
}

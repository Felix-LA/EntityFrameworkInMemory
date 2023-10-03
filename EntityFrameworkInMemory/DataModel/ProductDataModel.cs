using EntityFrameworkInMemory.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkInMemory.DataModel
{
    public class ProductDataModel
    {
        public string? Name { get; set; }
        public int IdCategory { get; set; }
        //public CategoryDataModel Category { get; set; }
        public float Price { get; set; }
        public int Codigo { get; set; }
    }
}

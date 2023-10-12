using EstudosApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EstudosApi.Domain.DataModel
{
    public class ProductDataModel
    {
        public string? Name { get; set; }
        public int IdCategory { get; set; }
        //public CategoryDataModel Category { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }
    }
}

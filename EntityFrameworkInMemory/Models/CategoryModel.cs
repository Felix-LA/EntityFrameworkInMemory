﻿using EntityFrameworkInMemory.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkInMemory.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryStatusEnum CategoryStatus { get; set; }
        public int CategoryCodigo { get; set; }
    }
}

using EstudosApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.Models
{
    public class MarcaModel
    {
        [Key]
        public int MarcaId { get; set; }
        public string MarcaName { get; set; }    
        public StatusEnum MarcaStatus { get; set; }
    }
}

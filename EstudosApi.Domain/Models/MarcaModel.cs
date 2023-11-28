using EstudosApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.Models
{
    public class MarcaModel
    {
        public int MarcaId { get; set; }
        public string MarcaName { get; set; }    
        public StatusEnum MarcaStatus { get; set; }
    }
}

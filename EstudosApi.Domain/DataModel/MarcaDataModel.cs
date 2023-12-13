using EstudosApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.DataModel
{
    public class MarcaDataModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public string Description { get; set; }

    }
}

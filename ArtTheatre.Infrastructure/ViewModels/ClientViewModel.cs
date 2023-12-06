using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTheatre.Infrastructure.ViewModels
{
    public class ClientViewModel
    {
        
        public long id { get; set; }

        public string fio { get; set; }

        public string dataRozd { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasabah.ViewModel
{
    public class NasabahViewModel
    {
        public int ID { get; set; }
        public string NoKTP { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NoHP { get; set; }
    }
}

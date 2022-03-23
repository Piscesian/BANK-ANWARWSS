using System;
using System.Collections.Generic;

namespace Nasabah.DataAccess.Models
{
    public partial class MstDatum
    {
        public int Id { get; set; }
        public string? NoKtp { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? NoHp { get; set; }
    }
}

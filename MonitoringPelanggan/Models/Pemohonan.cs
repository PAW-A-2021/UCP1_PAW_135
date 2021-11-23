using System;
using System.Collections.Generic;

#nullable disable

namespace MonitoringPelanggan.Models
{
    public partial class Pemohonan
    {
        public int Id { get; set; }
        public int? NoKk { get; set; }
        public string NamaPenuh { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public string Kelayakan { get; set; }
        public int? IdPetugas { get; set; }
        public string Proses { get; set; }

        public virtual Petuga IdPetugasNavigation { get; set; }
    }
}

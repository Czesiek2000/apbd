using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia8.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }

        public virtual Prescription Prescriptions { get; set; }
        public virtual Medicament Medicaments { get; set; }

        public virtual Medicament IMedicamentNavigation { get; set; }
        public virtual Prescription IPrescriptionNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Symptom
    {
        public Symptom()
        {
            Obserbations = new HashSet<Obserbation>();
        }

        public int Id { get; set; }
        public string CommonName { get; set; }
        public int ReactionTime { get; set; }

        public virtual ICollection<Obserbation> Obserbations { get; set; }
    }
}

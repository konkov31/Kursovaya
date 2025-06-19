namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NOMINATIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOMINATIONS()
        {
            AWARDINGS = new HashSet<AWARDINGS>();
        }

        [Key]
        public int nomination_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string category { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public int participant_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AWARDINGS> AWARDINGS { get; set; }

        public virtual PERSONS PERSONS { get; set; }
    }
}

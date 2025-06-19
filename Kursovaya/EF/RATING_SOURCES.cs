namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RATING_SOURCES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RATING_SOURCES()
        {
            RATINGS = new HashSet<RATINGS>();
        }

        [Key]
        public int source_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(255)]
        public string website { get; set; }

        [StringLength(255)]
        public string logo_url { get; set; }

        public double? trust_score { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATINGS> RATINGS { get; set; }
    }
}

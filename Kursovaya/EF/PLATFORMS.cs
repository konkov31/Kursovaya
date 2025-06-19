namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PLATFORMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLATFORMS()
        {
            MOVIE_AVAILABILITY = new HashSet<MOVIE_AVAILABILITY>();
        }

        [Key]
        public int platform_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public decimal subscription_cost { get; set; }

        [StringLength(255)]
        public string logo_url { get; set; }

        [Column(TypeName = "date")]
        public DateTime? added_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIE_AVAILABILITY> MOVIE_AVAILABILITY { get; set; }
    }
}

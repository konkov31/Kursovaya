namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONS()
        {
            FILM_POSITIONS = new HashSet<FILM_POSITIONS>();
            NOMINATIONS = new HashSet<NOMINATIONS>();
        }

        [Key]
        public int person_id { get; set; }

        [Required]
        [StringLength(100)]
        public string full_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_date { get; set; }

        [StringLength(255)]
        public string photo_url { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public int? height { get; set; }

        [StringLength(255)]
        public string imdb_link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILM_POSITIONS> FILM_POSITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOMINATIONS> NOMINATIONS { get; set; }
    }
}

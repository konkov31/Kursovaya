namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FILMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FILMS()
        {
            AWARDINGS = new HashSet<AWARDINGS>();
            FILM_POSITIONS = new HashSet<FILM_POSITIONS>();
            MOVIE_AVAILABILITY = new HashSet<MOVIE_AVAILABILITY>();
            MOVIE_GENRES = new HashSet<MOVIE_GENRES>();
            RATINGS = new HashSet<RATINGS>();
            REVIEWS = new HashSet<REVIEWS>();
        }

        [Key]
        public int movie_id { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string original_title { get; set; }

        public int release_year { get; set; }

        public int duration { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [StringLength(20)]
        public string age_rating { get; set; }

        public decimal? imdb_rating { get; set; }

        [StringLength(255)]
        public string poster_url { get; set; }

        [StringLength(255)]
        public string trailer_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AWARDINGS> AWARDINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILM_POSITIONS> FILM_POSITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIE_AVAILABILITY> MOVIE_AVAILABILITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIE_GENRES> MOVIE_GENRES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATINGS> RATINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWS> REVIEWS { get; set; }
    }
}

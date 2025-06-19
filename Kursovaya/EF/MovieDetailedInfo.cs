namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieDetailedInfo")]
    public partial class MovieDetailedInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int movie_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string original_title { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int release_year { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(27)]
        public string duration_formatted { get; set; }

        [StringLength(20)]
        public string age_rating { get; set; }

        public decimal? imdb_rating { get; set; }

        [StringLength(8000)]
        public string genres { get; set; }

        [StringLength(100)]
        public string free_on_platform { get; set; }

        public int? avg_user_rating { get; set; }

        public int? reviews_count { get; set; }
    }
}

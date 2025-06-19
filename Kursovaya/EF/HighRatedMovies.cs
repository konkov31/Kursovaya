namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HighRatedMovies
    {
        [Key]
        [Column(Order = 0)]
        public int movie_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string title { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int release_year { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int duration { get; set; }

        public decimal? imdb_rating { get; set; }
    }
}

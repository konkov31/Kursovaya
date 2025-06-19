namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOVIE_AVAILABILITY
    {
        [Key]
        public int availability_id { get; set; }

        public int movie_id { get; set; }

        public int platform_id { get; set; }

        public bool? is_free { get; set; }

        public decimal? rental_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? available_from { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual PLATFORMS PLATFORMS { get; set; }
    }
}

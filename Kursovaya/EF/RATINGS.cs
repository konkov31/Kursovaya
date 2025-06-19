namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RATINGS
    {
        [Key]
        public int rating_id { get; set; }

        public int movie_id { get; set; }

        public int source_id { get; set; }

        public int? value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rating_date { get; set; }

        public int? votes_count { get; set; }

        [Column(TypeName = "text")]
        public string rating_comment { get; set; }

        [StringLength(255)]
        public string original_url { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual RATING_SOURCES RATING_SOURCES { get; set; }
    }
}

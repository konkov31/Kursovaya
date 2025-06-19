namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOVIE_GENRES
    {
        [Key]
        public int movie_genre_id { get; set; }

        public int movie_id { get; set; }

        public int genre_id { get; set; }

        public bool? is_primary { get; set; }

        public int? genre_order { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual GENRES GENRES { get; set; }
    }
}

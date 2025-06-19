namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FAVORITE_GENRES
    {
        [Key]
        public int user_genre_id { get; set; }

        public int user_id { get; set; }

        public int genre_id { get; set; }

        public virtual GENRES GENRES { get; set; }

        public virtual USERS USERS { get; set; }
    }
}

namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REVIEWS
    {
        [Key]
        public int review_id { get; set; }

        public int movie_id { get; set; }

        public int user_id { get; set; }

        public int? rating { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        public bool? is_favourite { get; set; }

        public int? likes_count { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}

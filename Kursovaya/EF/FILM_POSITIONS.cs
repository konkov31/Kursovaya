namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FILM_POSITIONS
    {
        [Key]
        public int position_id { get; set; }

        public int movie_id { get; set; }

        public int person_id { get; set; }

        [Required]
        [StringLength(50)]
        public string position_type { get; set; }

        [StringLength(100)]
        public string character_name { get; set; }

        public bool? is_lead_role { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual PERSONS PERSONS { get; set; }
    }
}

namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AWARDINGS
    {
        [Key]
        public int awarding_id { get; set; }

        public int movie_id { get; set; }

        public int nomination_id { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual NOMINATIONS NOMINATIONS { get; set; }
    }
}

namespace Kursovaya.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserReviewsSummary")]
    public partial class UserReviewsSummary
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string username { get; set; }

        public int? total_reviews { get; set; }

        public int? avg_user_rating { get; set; }
    }
}

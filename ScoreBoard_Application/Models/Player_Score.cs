using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard_Application.Models
{
    public class Player_Score
    {
        [Key]
        public int PlayerScoreId { get; set; }
        [Display(Name ="Player Name")]
        public string PlayerName { get; set; }
        public long Score { get; set; }
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Modified Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
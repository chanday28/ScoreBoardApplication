using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScoreBoard_Application.Models
{
    public class ScoreBoardContext : DbContext
    {
        public ScoreBoardContext() : base("ScoreBoardContextDemo")
        {

        }
        public DbSet<Player_Score> Player_Scores { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int VoteCastingId { get; set; }

        public int PositionId { get; set; }

        public int CandidateId { get; set; }

        public int VoterId { get; set; }
    }
}
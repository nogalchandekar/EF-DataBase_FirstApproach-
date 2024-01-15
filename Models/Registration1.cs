using System;
using System.Collections.Generic;

namespace DataBaseFirstEFCore.Models
{
    public partial class Registration1
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Dept { get; set; }
        public string? Role { get; set; }
        public decimal? Fee { get; set; }
        public string? Status { get; set; }
        public string? Qualification { get; set; }
    }
}

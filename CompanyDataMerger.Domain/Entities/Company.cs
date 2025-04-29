using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Domain.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
         public string Domain { get; set; } = string.Empty; 
        public string? Name { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? LinkedInId { get; set; }
        public string? Industry { get; set; }
        public string? CompanySize { get; set; }
        public string? Country { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public string? HeadquartersAddress { get; set; }
        public string? HeadquartersCity { get; set; }
        public string? HeadquartersZip { get; set; }
        public int SourcePriority { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

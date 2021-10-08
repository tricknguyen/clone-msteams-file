using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Modified { get; set; }
        public string Modify_By { get; set; }
    }
}

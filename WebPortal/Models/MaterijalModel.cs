using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace WebPortal.Models
{
    public class MaterijalModel
    {

        [Key]
       public int materijalId { get; set; }
        [Required]
        public byte[] materijalFile { get; set; }
        public string materijalUrl { get; set; }
       
        public string materijalTip { get; set; }
        
        public string materijalNaziv { get; set; }

    }
}
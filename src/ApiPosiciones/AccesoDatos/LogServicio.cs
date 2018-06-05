using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccesoDatos
{
    public class LogServicio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Decimal IdLlamado { get; set; }
        [Display(Name = "Path")]
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime Fecha { get; set; }
        public string StatusCode { get; set; }
    }
}

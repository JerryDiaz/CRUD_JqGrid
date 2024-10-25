using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
        public int Status { get; set; }
    }
}
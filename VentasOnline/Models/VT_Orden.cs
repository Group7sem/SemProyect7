//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentasOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VT_Orden
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public string departamento { get; set; }
        public string zona { get; set; }
        public string direccion { get; set; }
    
        public virtual VT_Articulo VT_Articulo { get; set; }
        public virtual VT_Usuario VT_Usuario { get; set; }
    }
}

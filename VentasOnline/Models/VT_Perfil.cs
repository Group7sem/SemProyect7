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
    
    public partial class VT_Perfil
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int idUsuario { get; set; }
        public int idTipoPerfil { get; set; }
    
        public virtual VT_TipoPerfil VT_TipoPerfil { get; set; }
        public virtual VT_Usuario VT_Usuario { get; set; }
    }
}
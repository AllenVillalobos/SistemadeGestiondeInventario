using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión_de_Inventario.Modelos
{
    public class Proveedor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; }

        public Proveedor()
        {
        }

        public Proveedor(int id, string nombre, string contacto)
        {
            this.id = id;
            this.nombre = nombre;
            this.contacto = contacto;
        }

        public static List<Proveedor> ObtenerProveedores()
        {
            if (System.Web.HttpContext.Current.Application["proveedor"] == null)
            {
                List<Proveedor> proveedores = new List<Proveedor>();
                proveedores.Add(new Proveedor(1, "Proveedor A", "22222222"));
                proveedores.Add(new Proveedor(2, "Proveedor B", "33333333"));
                proveedores.Add(new Proveedor(3, "Proveedor C", "44444444"));
                proveedores.Add(new Proveedor(4, "Proveedor D", "55555555"));
                System.Web.HttpContext.Current.Application["proveedor"] = proveedores;
                return (List<Proveedor>)System.Web.HttpContext.Current.Application["proveedor"];
            }
            return (List<Proveedor>)System.Web.HttpContext.Current.Application["proveedor"];
        }
        public static Proveedor BuscarProveedor(int id)
        {
            List<Proveedor> proveedores = ObtenerProveedores();
            Proveedor proveedor = new Proveedor();
            proveedor = proveedores.FirstOrDefault(p => p.id == id);
            return proveedor;
        }
    }
}
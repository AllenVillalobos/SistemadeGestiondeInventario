using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión_de_Inventario.Modelos
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Categoria()
        {
        }
        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public static List<Categoria> ObtenerCategorias()
        {
            if (System.Web.HttpContext.Current.Application["categoria"] == null)
            {
                List<Categoria> categorias = new List<Categoria>();
                categorias.Add(new Categoria(1, "Electrónica"));
                categorias.Add(new Categoria(2, "Ropa"));
                categorias.Add(new Categoria(3, "Alimentos"));
                categorias.Add(new Categoria(4, "Hogar"));
                System.Web.HttpContext.Current.Application["categoria"] = categorias;
                return (List<Categoria>)System.Web.HttpContext.Current.Application["categoria"];
            }
            return (List<Categoria>)System.Web.HttpContext.Current.Application["categoria"];
        }
        public static Categoria BuscarCategoria(int id)
        {
            List<Categoria> categorias = ObtenerCategorias();
            Categoria categoria = new Categoria();
            categoria = categorias.FirstOrDefault(c => c.id == id);
            return categoria;
        }
    }
}
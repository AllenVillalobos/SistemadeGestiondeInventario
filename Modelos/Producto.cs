using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión_de_Inventario.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public Categoria categoria { get; set; }
        public Proveedor proveedor { get; set; }

        public Producto()
        {

        }
        public Producto(int id, string nombre, string descripcion, double precio, int cantidad, Categoria categoria, Proveedor proveedor)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.proveedor = proveedor;
        }
        public static List<Producto> ObtenerProductos()
        {
            if (System.Web.HttpContext.Current.Application["productos"] == null)
            {
                System.Web.HttpContext.Current.Application["productos"] = new List<Producto>();
                return (List<Producto>)System.Web.HttpContext.Current.Application["productos"];
            }
            return (List<Producto>)System.Web.HttpContext.Current.Application["productos"];
        }

        public static bool AgregarProducto(string nombre, string descripcion, double precio, int cantidad, int categoria, int proveedor)
        {
            try
            {
                List<Producto> productos = Producto.ObtenerProductos();
                Producto producto = new Producto();
                producto.id = productos.Count > 0 ? productos.Max(p => p.id) + 1 : 1;
                producto.nombre = nombre;
                producto.descripcion = descripcion;
                producto.precio = precio;
                producto.cantidad = cantidad;
                producto.categoria = Categoria.BuscarCategoria(categoria);
                producto.proveedor = Proveedor.BuscarProveedor(proveedor);
                productos.Add(producto);
                System.Web.HttpContext.Current.Application["productos"] = productos;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EliminarProducto(int id)
        {
            try
            {
                List<Producto> productos = Producto.ObtenerProductos();
                Producto producto = productos.FirstOrDefault(p => p.id == id);
                if (producto != null)
                {
                    productos.Remove(producto);
                    System.Web.HttpContext.Current.Application["productos"] = productos;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ModificarProducto(int id, string nombre, string descripcion, double precio, int cantidad, int categoria, int proveedor)
        {
            try
            {
                List<Producto> productos = Producto.ObtenerProductos();
                Producto productoE = productos.FirstOrDefault(p => p.id == id);
                if (productoE != null)
                {
                    productoE.id = id;
                    productoE.nombre = nombre;
                    productoE.descripcion = descripcion;
                    productoE.precio = precio;
                    productoE.cantidad = cantidad;
                    productoE.categoria = Categoria.BuscarCategoria(categoria);
                    productoE.proveedor = Proveedor.BuscarProveedor(proveedor);
                    System.Web.HttpContext.Current.Application["productos"] = productos;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static List<Producto> PorCategoria(int categoria)
        {
            List<Producto> productos = ObtenerProductos();
            List<Producto> productosCategoria = new List<Producto>();
            productosCategoria = productos.Where(p => p.categoria.id == categoria).ToList();
            if (productosCategoria.Count > 0)
            {
                System.Web.HttpContext.Current.Application["productoCategoria"] = productosCategoria;
                return (List<Producto>)System.Web.HttpContext.Current.Application["productoCategoria"];
            }
            else
            {
                System.Web.HttpContext.Current.Application["productoCategoria"] = new List<Producto>();
                return (List<Producto>)System.Web.HttpContext.Current.Application["productoCategoria"];
            }
        }
        public static Producto BuscarProducto(int id)
        {
            List<Producto> productos = ObtenerProductos();
            Producto producto = productos.FirstOrDefault(p => p.id == id);
            return producto;
        }
    }
}
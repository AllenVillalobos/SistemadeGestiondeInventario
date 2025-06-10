using Sistema_de_Gestión_de_Inventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_de_Gestión_de_Inventario.Paginas
{
    public partial class Productos_Gestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = Categoria.ObtenerCategorias();
                ddlCategoria.DataTextField = "nombre";
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataBind();

                ddlProveedor.DataSource = Proveedor.ObtenerProveedores();
                ddlProveedor.DataTextField = "nombre";
                ddlProveedor.DataValueField = "id";
                ddlProveedor.DataBind();

                ddlFiltro.DataSource = Categoria.ObtenerCategorias();
                ddlFiltro.DataTextField = "nombre";
                ddlFiltro.DataValueField = "id";
                ddlFiltro.DataBind();

                lvProductos.DataSource = Producto.ObtenerProductos();
                lvProductos.DataBind();
            }

        }
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            int categoriaId = int.Parse(ddlCategoria.SelectedValue);
            int proveedorId = int.Parse(ddlProveedor.SelectedValue);

            Producto.AgregarProducto(txtNombre.Text,txtDescripcion.Text,
                double.Parse(txtPrecio.Text),int.Parse(txtCantidad.Text),categoriaId,proveedorId);

            lvProductos.DataSource = Producto.ObtenerProductos();
            lvProductos.DataBind();
        }
        public void btnFiltro_Click(object sender, EventArgs e)
        {
            int categoriaSeleccionada =int.Parse(ddlFiltro.SelectedValue);
            lvProductos.DataSource = Producto.PorCategoria(categoriaSeleccionada);
            lvProductos.DataBind();
        }

        public void lvProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                int productoId = Convert.ToInt32(e.CommandArgument);
                Producto.EliminarProducto(productoId);
                lvProductos.DataSource = Producto.ObtenerProductos();
                lvProductos.DataBind();
            }/*else if (e.CommandName == "editar")
            {
                int productoId = Convert.ToInt32(e.CommandArgument);
                Producto producto = Producto.BuscarProducto(productoId);
                txtNombre.Text = producto.nombre;
                txtDescripcion.Text = producto.descripcion;
                txtPrecio.Text = producto.precio.ToString();
                txtCantidad.Text = producto.cantidad.ToString();
                ddlCategoria.SelectedValue = producto.categoria.id.ToString();
                ddlProveedor.SelectedValue = producto.proveedor.id.ToString();
            }*/
        }
    }
}
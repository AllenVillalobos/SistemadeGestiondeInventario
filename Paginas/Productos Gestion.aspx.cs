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

        public void lvProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}
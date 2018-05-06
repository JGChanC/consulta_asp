using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Insertamos las librerias para BD
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Int16 Cla,Can;
        String Np, Fv;
        Decimal Prec;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clave_TextChanged(object sender, EventArgs e)
        {
            Cla = Convert.ToInt16(clave.Text);
        }

        protected void nombre_TextChanged(object sender, EventArgs e)
        {
            Np = Convert.ToString(nombre.Text);
        }

        protected void TxPrecio_TextChanged(object sender, EventArgs e)
        {
            Prec = Convert.ToDecimal(TxPrecio.Text);
        }

        protected void TxVentFech_TextChanged(object sender, EventArgs e)
        {
            Fv = TxVentFech.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection Conn;
            String OrderSql;
            Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VS2015\\U_4\\BDatosUno.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                Conn.Open();
                OrderSql = String.Format("DELETE FROM TablaProductos WHERE Clave={0}", Cla);
                SqlCommand cmd = new SqlCommand(OrderSql, Conn);
                cmd.ExecuteNonQuery();
                LblMensj.Text = "Se elimina registro...";
                Conn.Close();
            }
            catch (Exception ex1)
            {
                LblMensj.Text = "Error de inserción " + ex1.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //INSERTa Modo desconectado
            SqlConnection Conn;
            String OrderSql;
            Conn = new SqlConnection();

            //Nuevo
            SqlDataAdapter adp = null;
            DataSet ds;

            Conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VS2015\\U_4\\BDatosUno.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                Conn.Open();
                OrderSql = String.Format("SELECT * FROM TablaProductos");
                // _Nuevo
                ds = new DataSet();
                //Nuevo
                adp = new SqlDataAdapter(OrderSql, Conn);
                adp.Fill(ds, "CopiaTabla");
                //Nuevo
                DataRow dr;
                dr = ds.Tables["CopiaTabla"].NewRow();
                SqlCommand cmd = new SqlCommand(OrderSql, Conn);
                //AGREGAMOS LA INFORMACION EN LA FILA

                dr["Clave"] = Cla;
                dr["NomProd"] = Np;
                dr["Precio"] = Prec;
                dr["FechaVenta"] = Fv;
                dr["Cantidad"] = Can;
                ds.Tables["CopiaTabla"].Rows.Add(dr);
                LblMensj.Text = "Se inserta registro";
                //---------
                //Ahora se ACTUALIZA UNA VEZ!!
                SqlCommandBuilder cb;
                cb = new SqlCommandBuilder(adp);
                adp.Update(ds.Tables["CopiaTabla"]);
                cmd.ExecuteNonQuery();                
                Conn.Close();
            }
            catch (Exception ex1)
            {
                LblMensj.Text = "Error de inserción " + ex1.Message;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Procedimiento almacenado
            SqlConnection Conn;
            String OrderSql;
            Conn = new SqlConnection();
            SqlParameter sp;
            Conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VS2015\\U_4\\BDatosUno.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                Conn.Open();
                //Nombre del procedimiento almacenado

                OrderSql = String.Format("CambiarPrecio");
                SqlCommand cmd = new SqlCommand(OrderSql, Conn);
                //Definir el procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CambiaPrecio";
                //Agregar los parametros de entrada
                cmd.Parameters.Add(new SqlParameter("@ClaveP", int.Parse(clave.Text)));
                cmd.Parameters.Add(new SqlParameter("@PrecioP", float.Parse(TxPrecio.Text)));

                sp = new SqlParameter();
                sp.ParameterName = "@Result";
                sp.SqlDbType = SqlDbType.Int;
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                cmd.ExecuteNonQuery();

                if (int.Parse(sp.Value.ToString()) > 0)
                {
                    LblMensj.Text = "Precio Actualizado por procedimiento";
                }
                else {
                    LblMensj.Text = "No existe el codigo...";
                }

               
                Conn.Close();
            }
            catch (Exception ex1)
            {
                LblMensj.Text = "Error de registro " + ex1.Message;
            }

        }

        protected void TxCant_TextChanged(object sender, EventArgs e)
        {
            Can = Convert.ToInt16(TxCant.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conn;
            String OrderSql;
            Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\VS2015\\U_4\\BDatosUno.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                Conn.Open();
                OrderSql = String.Format("INSERT INTO TablaProductos(Clave, NomProd, Precio, FechaVenta, Cantidad) VALUES({0},'{1}',{2},'{3}',{4})",Cla,Np,Prec,Fv,Can);
                SqlCommand cmd = new SqlCommand(OrderSql, Conn);
                cmd.ExecuteNonQuery();
                LblMensj.Text = "Se interta registro...";
                Conn.Close();
            }
            catch (Exception ex1) {
                LblMensj.Text = "Error de inserción " + ex1.Message;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Cerrajeria_2
{  
    public partial class Cliente : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DTRPMJU7;Initial Catalog=Cerrajeria_Hns;Integrated Security=True");
        Validaciones V = new Validaciones();
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand InCliente = new SqlCommand("sp_AgregarCliente", con);
                InCliente.CommandType = CommandType.StoredProcedure;

                //AGREGAR PARAMETROS
                InCliente.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = txtNombre.Text;
                InCliente.Parameters.AddWithValue("@RFC", SqlDbType.VarChar).Value = txtRFC.Text;
                InCliente.Parameters.AddWithValue("@Direc", SqlDbType.VarChar).Value = txtDomicilio.Text;
                InCliente.Parameters.AddWithValue("@Co_Po", SqlDbType.VarChar).Value = txtCodigo.Text;
                InCliente.Parameters.AddWithValue("@Ciu", SqlDbType.VarChar).Value = txtCiudad.Text;
                InCliente.Parameters.AddWithValue("@Tel", SqlDbType.VarChar).Value = txtTelefono.Text;
                InCliente.Parameters.AddWithValue("@Col", SqlDbType.VarChar).Value = txtColonia.Text;

                //EJECUTAR SP
                InCliente.ExecuteNonQuery();
                MessageBox.Show("CLIENTE AGREGADO!", "INGRESO EXITOSO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DE CONEXION, INTENTE MAS TARDE\n\n" + ex.ToString());
            }
            finally
            {
                con.Close();
                Limpiar();
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtCiudad.Text = "";
            txtDomicilio.Text = "";
            txtColonia.Text = "";
            txtRFC.Text = "";
            txtTelefono.Text = "";
        }

        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloLetras(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.SoloNumeros(e);
        }
    }
}

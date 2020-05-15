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
    public partial class Empleado : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DTRPMJU7;Initial Catalog=Cerrajeria_Hns;Integrated Security=True");
        public Empleado()
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
                if (txtContra.Text == txtConfContra.Text)
                {
                    con.Open();
                    SqlCommand InEmpleado = new SqlCommand("sp_AgregarEmpleado", con);
                    InEmpleado.CommandType = CommandType.StoredProcedure;

                    //AGREGAR PARAMETROS
                    InEmpleado.Parameters.AddWithValue("@Nom", SqlDbType.VarChar).Value = txtNombre.Text;
                    InEmpleado.Parameters.AddWithValue("@NomUsu", SqlDbType.VarChar).Value = txtUsuario.Text;
                    InEmpleado.Parameters.AddWithValue("@Contra", SqlDbType.VarChar).Value = txtContra.Text;
                    InEmpleado.Parameters.AddWithValue("@Ape_P", SqlDbType.VarChar).Value = txtApe_P.Text;
                    InEmpleado.Parameters.AddWithValue("@Ape_M", SqlDbType.VarChar).Value = txtApe_M.Text;
                    InEmpleado.Parameters.AddWithValue("@F_Nac", SqlDbType.DateTime).Value = dtpF_Nacimiento.Value;
                    InEmpleado.Parameters.AddWithValue("@F_Reg", SqlDbType.DateTime).Value = DateTime.Today;
                    InEmpleado.Parameters.AddWithValue("@Direc", SqlDbType.VarChar).Value = txtDireccion.Text;
                    InEmpleado.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = txtCelular.Text;

                    //EJECUTAR SP
                    InEmpleado.ExecuteNonQuery();
                    MessageBox.Show("EMPLEADO AGREGADO!", "INGRESO EXITOSO");
                }
                else { MessageBox.Show("Las contraseñas no coinciden, verifique de nuevo", "ERROR DE CONFIRMACION"); }
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

        void Limpiar()
        {
            txtApe_M.Clear();
            txtApe_P.Clear();
            txtCelular.Clear();
            txtConfContra.Clear();
            txtContra.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            txtUsuario.Clear();
        }
    }
}

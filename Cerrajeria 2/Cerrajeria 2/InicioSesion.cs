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
    public partial class InicioSesion : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DTRPMJU7;Initial Catalog=Cerrajeria_Hns;Integrated Security=True");
        SqlDataReader read;
        string pwd;
        List<string> pass = new List<string>();
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string ConsultaEmpleados = "SELECT NomUsuario, CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contrasena)) FROM Empleados";
                SqlCommand NomUsuarios = new SqlCommand(ConsultaEmpleados, con);
                read = NomUsuarios.ExecuteReader();

                while (read.Read())
                {
                    cbxUsers.Items.Add(read.GetValue(0).ToString());
                    pass.Add(read.GetValue(1).ToString());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR DE CONEXION A USUARIOS, INTENTE MAS TARDE\n\n", Ex.ToString());
            }
            con.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    //pwd=GetPwd();
                    if (textBox1.Text == pass.ElementAt(cbxUsers.SelectedIndex))
                    {
                        Principal Formulario = new Principal();
                        Formulario.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA INCORRECTA", "ERROR");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR, CONTACTE CON EL ADMINSTRADOR", "ERROR DE ACCESO");
            }
        }

        /*string GetPwd()
        {
            con.Open();
            SqlCommand pwd = new SqlCommand("sp_GetPWD", con);
            pwd.CommandType = CommandType.StoredProcedure;
            pwd.Parameters.AddWithValue("@Trabajador", SqlDbType.VarChar).Value = cbxUsers.SelectedItem.ToString();
            SqlDataReader read1 = pwd.ExecuteReader();
            return read1.GetValue(0).ToString();
        }*/

        private void cbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cerrajeria_2
{
    class Conexion_BDCerrajeria
    {
        SqlConnection conexion;
        SqlCommand command;
        SqlDataReader dataRead;
        SqlDataAdapter dataAdap;
        DataTable dataTab;

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DTRPMJU7;Initial Catalog=Cerrajeria_Hns;Integrated Security=True");
        public Conexion_BDCerrajeria()
        {
            try
            {
                conexion = new SqlConnection("Data Source=LAPTOP-DTRPMJU7;Initial Catalog=Cerrajeria_Hns;Integrated Security=True");
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo establecer la conexión\n" + ex.ToString());
                conexion.Close();
            }
        }

    }
}

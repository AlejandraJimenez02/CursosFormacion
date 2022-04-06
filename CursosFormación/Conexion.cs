using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CursosFormación
{
    internal class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=cursosFormacion;Integrated Security=True");
                cn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("La conexión no se pudo establecer " + ex.ToString());
            }
        }

        public int login(string usr, string pwd)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("SELECT * FROM usr where usr = '" + usr + "' and pwd ='" + pwd + "' ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontraron resultados para la consulta" + ex.ToString());
            }
            return contador;
        }
       

    }
}

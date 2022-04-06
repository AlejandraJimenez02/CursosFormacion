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

namespace CursosFormación
{
    public partial class PersonasPorCurso : Form
    {
        SqlConnection cn = new SqlConnection();
        public PersonasPorCurso()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultas consultas = new consultas();
            consultas.Show();
            Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CursosFormación CursosFormacion = new CursosFormación();
            CursosFormacion.Show();
            Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(textBox1.Text != "")
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=cursosFormacion;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM empleadosCursos where codigoCurso ='"+ textBox1.Text + "'", cn);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Debe ingresar el código del curso",
                   "Personas por curso", MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
            }
        }
    }
}

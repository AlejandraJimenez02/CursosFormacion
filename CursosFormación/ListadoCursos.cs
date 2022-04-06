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
    public partial class ListadoCursos : Form
    {
        SqlConnection cn = new SqlConnection();
        public ListadoCursos()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListadoCursos_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection("Data Source=.;Initial Catalog=cursosFormacion;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM cursos", cn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {


        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gbDatosUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            consultas consultas = new consultas();
            consultas.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CursosFormación CursosFormacion = new CursosFormación();
            CursosFormacion.Show();
            Hide();
        }
    }
}

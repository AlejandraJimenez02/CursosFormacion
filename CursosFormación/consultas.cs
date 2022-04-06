using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursosFormación
{
    public partial class consultas : Form
    {
        public consultas()
        {
            InitializeComponent();
        }

        private void consultas_Load(object sender, EventArgs e)
        {

        }

        private void gbDatosUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoCursos ListadoCursos = new ListadoCursos();
            ListadoCursos.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonasPorCurso PersonasPorCurso = new PersonasPorCurso();
            PersonasPorCurso.Show();
            Hide();
        }
    }
}

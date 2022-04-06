using Entidades;
using Negocio;
using Repositorio;
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
    public partial class CursosFormación : Form
    {

        public CursosFormación()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombres, "No se admiten caracteres especiales ni números");
            this.ttMensaje.SetToolTip(this.txtApellidos, "No se admiten caracteres especiales ni números");
            this.ttMensaje.SetToolTip(this.txtCodEmpleado, "Solo admite números");
            this.ttMensaje.SetToolTip(this.txtEdicionCurso, "Solo admite números");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            consultas consultas = new consultas();
            consultas.Show();
            Hide();
        }

        private bool ValidarCampos()
        {
            var valido = true;
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                valido = false;
                errorMensaje.SetError(txtNombres, "Debe ingresar el nombre completo del empleado");
            }
            else
            {
                errorMensaje.SetError(txtNombres, null);
            }
            return valido;
        }

        private void txtCodEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                return;
            }
            e.Handled = true;
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||
                (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                e.KeyChar == 8 || e.KeyChar == 32
                ))
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||
                (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                e.KeyChar == 8 || e.KeyChar == 32 ||
                (e.KeyChar >= 48 && e.KeyChar <= 57)
                ))
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||
                 (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                 e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 35 ||
                 (e.KeyChar >= 48 && e.KeyChar <= 57)
                 ))
            {
                e.Handled = true;
            }
        }

        private void txtEdicionCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                return;
            }
            e.Handled = true;
        }

        private void txtNumDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void txtNumDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumDocumento.Text.Length <= 10)
            {
                errorMensaje.SetError(txtNumDocumento, "El número de documento debe contener 6 dígitos o 10 dígitos, " +
                    "según corresponda");
            }
            else
            {
                errorMensaje.SetError(txtNumDocumento, null);
            }
           
        }

        private void tbpEmpleados_Click(object sender, EventArgs e)
        {
           
        }

        private void CursosFormación_Load(object sender, EventArgs e)
        {
            _ = new List<TipoDocumento>();
            var negocio = new MaestroNegocio(new RepositorioMaestro());
            List<TipoDocumento> tiposDocumento = negocio.ObtenerTiposDocumento();

            cbxTipoDocumento.DataSource = tiposDocumento;
            cbxTipoDocumento.DisplayMember = "Nombre";
            cbxTipoDocumento.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void tbpCursos_Click(object sender, EventArgs e)
        {

        }

        private void lblDiaSemana_Click(object sender, EventArgs e)
        {

        }

        private void dtpHoraFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Entidades.CursosFormacion cursoFormacion = new Entidades.CursosFormacion();
                cursoFormacion.FechaNacimiento = dtpFechaNacimiento.Value;
                cursoFormacion.Nombres = txtNombres.Text;
                cursoFormacion.Apellidos = txtApellidos.Text;
                cursoFormacion.NumeroDocumento = txtNumDocumento.Text;
                cursoFormacion.CodigoEmpleado = txtCodEmpleado.TextLength;
                cursoFormacion.Rol = rdbDocente.Checked;
                cursoFormacion.Rol = rdbEstudiante.Checked;
                cursoFormacion.Capacitado = rdbCapacitado.Checked;
                cursoFormacion.Rol = rdbNoCapacitado.Checked;
                cursoFormacion.Sexo = rdbFemenino.Checked;
                cursoFormacion.Sexo = rdbMasculino.Checked;
                cursoFormacion.Direccion = txtDireccion.Text;
                cursoFormacion.FechaInicio = dtpFechaInicio.Value;
                cursoFormacion.FechaFinal = dtpFechaFinal.Value;
                cursoFormacion.HoraInicio = dtpFechaInicio.Value;
                cursoFormacion.HoraFinal = dtpFechaInicio.Value;
                decimal salario = 0;
                if (decimal.TryParse(mtxtSalario.Text, out salario))
                    cursoFormacion.Salario = salario;
                cursoFormacion.Telefono = mtxtTelefono.Text;
                cursoFormacion.EdicionCurso = txtEdicionCurso.TextLength;
                cursoFormacion.TipoDocumento = cbxTipoDocumento.SelectedItem as Entidades.TipoDocumento;

            }
            else
            {
                MessageBox.Show("Hay errores en el formulario. Revisar",
                    "Cursos de Formación", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Entidades.CursosFormacion cursoFormacion = new Entidades.CursosFormacion();
                cursoFormacion.FechaNacimiento = dtpFechaNacimiento.Value;
                cursoFormacion.Nombres = txtNombres.Text;
                cursoFormacion.Apellidos = txtApellidos.Text;
                cursoFormacion.NumeroDocumento = txtNumDocumento.Text;
                cursoFormacion.CodigoEmpleado = txtCodEmpleado.TextLength;
                cursoFormacion.Rol = rdbDocente.Checked;
                cursoFormacion.Rol = rdbEstudiante.Checked;
                cursoFormacion.Capacitado = rdbCapacitado.Checked;
                cursoFormacion.Rol = rdbNoCapacitado.Checked;
                cursoFormacion.Sexo = rdbFemenino.Checked;
                cursoFormacion.Sexo = rdbMasculino.Checked;
                cursoFormacion.Direccion = txtDireccion.Text;
                cursoFormacion.FechaInicio = dtpFechaInicio.Value;
                cursoFormacion.FechaFinal = dtpFechaFinal.Value;
                cursoFormacion.HoraInicio = dtpFechaInicio.Value;
                cursoFormacion.HoraFinal = dtpFechaInicio.Value;
                decimal salario = 0;
                if (decimal.TryParse(mtxtSalario.Text, out salario))
                    cursoFormacion.Salario = salario;
                cursoFormacion.Telefono = mtxtTelefono.Text;
                cursoFormacion.EdicionCurso = txtEdicionCurso.TextLength;
                cursoFormacion.TipoDocumento = cbxTipoDocumento.SelectedItem as Entidades.TipoDocumento;

            }
            else
            {
                MessageBox.Show("Hay errores en el formulario. Revisar",
                    "Cursos de Formación", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}

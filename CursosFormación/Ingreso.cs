using Entidades;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CursosFormación
{
    public partial class Ingreso : Form
    {
        Conexion cn = new Conexion();
        public Ingreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtContraseña, "Solo admite letras mayúsculas, minúsculas y números");
            this.ttMensaje.SetToolTip(this.txtUsuario, "No admite números");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {
                Entidades.Ingreso ingreso = new Entidades.Ingreso();
                ingreso.Usuario = txtUsuario.Text;
                ingreso.Contraseña = txtContraseña.Text;

                if (cn.login(ingreso.Usuario, ingreso.Contraseña) != 0)
                {
                    consultas consultas = new consultas();
                    consultas.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("No se encontró un usuario registrado con estos datos",
                       "Ingreso", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Revisar el formulario. Se identifican errores",
                    "Ingreso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private bool ValidarCampos()
        {
            var valido = true;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                valido = false;
                errorProvider.SetError(txtUsuario, "Debe ingresar el usuario");
            }
            else
            {
                errorProvider.SetError(txtUsuario, null);
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)

        {
            Close();
            Application.Exit();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && (e.KeyChar) != 8 ||
                (e.KeyChar) > 57 && (e.KeyChar) < 65 ||
                (e.KeyChar) > 90 && (e.KeyChar) < 97 ||
                (e.KeyChar) > 122)

            {
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 65 && e.KeyChar <= 90) ||
                (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 35 ||
                (e.KeyChar >= 97 && e.KeyChar <= 122)
                ))
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
        
        }

        private void txtContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                errorProvider.SetError(txtContraseña, "La contraseña no debe contener simbolos ni espacios");
            }
            else
            {
                errorProvider.SetError(txtContraseña, null);
            }
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }

        private void gbDatosUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactosMAVI
{
    public partial class Main : Form
    {
        private Transacciones transacciones = new Transacciones();

        // Valor de la celda seleccionada en el DataGridView
        int id;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvContacto.DataSource = transacciones.GetAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ContactoForm contactoForm = new ContactoForm();
            contactoForm.ShowDialog();
            dgvContacto.DataSource = transacciones.GetAll();
            txtBuscarNombre.Clear();
        }

        private void txtBuscarNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvContacto.DataSource = transacciones.GetAll(txtBuscarNombre.Text);
            if (txtBuscarNombre.Text == "")
                dgvContacto.DataSource = transacciones.GetAll();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Se condiciona si hay algun item seleccionado
            if (dgvContacto.SelectedRows.Count >= 0)
            {
                // Se rpegunt al usuario
                if (MessageBox.Show("¿Desea eliminar el contacto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Si el resultado es positivo, exito !
                    if (transacciones.Delete(Convert.ToInt32(dgvContacto.Rows[dgvContacto.SelectedRows[0].Index].Cells["id_contacto"].Value.ToString())))
                    {
                        // Se notifica al usuario
                        MessageBox.Show("Contacto eliminado correctamente", "Contacto", MessageBoxButtons.OK);

                        // Se refresca la pantalla
                        dgvContacto.DataSource = transacciones.GetAll();
                        txtBuscarNombre.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar estado", "Contacto", MessageBoxButtons.OK);
                    }
                    dgvContacto.DataSource = transacciones.GetAll();
                }
            }
        }

        private void dgvContacto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Se llama al contructor con el valor del id
            ContactoForm contactoForm = new ContactoForm(Convert.ToInt32(dgvContacto.Rows[dgvContacto.SelectedRows[0].Index].Cells["id_contacto"].Value.ToString()));
            contactoForm.ShowDialog();

            // Se refresca la pantalla
            dgvContacto.DataSource = transacciones.GetAll();
            txtBuscarNombre.Clear();
        }

        private void btnVerContacto_Click(object sender, EventArgs e)
        {
            // Se selecciona el usuario
            var contacto = transacciones.GetById(Convert.ToInt32(dgvContacto.Rows[dgvContacto.SelectedRows[0].Index].Cells["id_contacto"].Value.ToString()));

            // Se crea el string del mensaje
            string messageText = "Nombre: " + contacto.nombre + "\n" +
                                   "\nTipo de Contacto: " + transacciones.tipoContacto[Convert.ToChar(contacto.tipo_contacto)] + "\n" +
                                   "\nTelefono Fijo: " + contacto.telefono_fijo + "\n" +
                                   "\nTelefono Movil: " + contacto.telefono_movil + "\n" +
                                   "\nSexo: " + transacciones.sexo[Convert.ToChar(contacto.sexo)] + "\n" +
                                   "\nEstado Civil: " + transacciones.estadoCivil[Convert.ToChar(contacto.estado_civil)] + "\n" +
                                   "\nFecha de Nacimiento: " + contacto.fecha_nacimiento.ToShortDateString();

                                   ;
            MessageBox.Show(messageText, "Datos del Contacto", MessageBoxButtons.OK);
        }
    }
}

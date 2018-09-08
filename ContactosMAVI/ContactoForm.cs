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
    public partial class ContactoForm : Form
    {
        Transacciones transacciones = new Transacciones();

        // Id del contacto a actualizar
        int id;

        public ContactoForm()
        {
            InitializeComponent();

            // Inicializar comboBox de Tipo Contacto
            cbTipoContacto.DataSource = new BindingSource(transacciones.tipoContacto, null);
            cbTipoContacto.DisplayMember = "Value";
            cbTipoContacto.ValueMember = "Key";


            // Inicializar comboBox de sexo
            cbSexo.DataSource = new BindingSource(transacciones.sexo, null);
            cbSexo.DisplayMember = "Value";
            cbSexo.ValueMember = "Key";

            // Inicializar comboBox de Estado Civil
            cbEstado.DataSource = new BindingSource(transacciones.estadoCivil, null);
            cbEstado.DisplayMember = "Value";
            cbEstado.ValueMember = "Key";

            // No mostrar el boton actualizar
            btnActualizar.Visible = false;
        }



        // Constructor para editar Contacto
        public ContactoForm(int id)
        {
            InitializeComponent();

            // Inicializar comboBox de Tipo Contacto
            cbTipoContacto.DataSource = new BindingSource(transacciones.tipoContacto, null);
            cbTipoContacto.DisplayMember = "Value";
            cbTipoContacto.ValueMember = "Key";


            // Inicializar comboBox de sexo
            cbSexo.DataSource = new BindingSource(transacciones.sexo, null);
            cbSexo.DisplayMember = "Value";
            cbSexo.ValueMember = "Key";

            // Inicializar comboBox de Estado Civil
            cbEstado.DataSource = new BindingSource(transacciones.estadoCivil, null);
            cbEstado.DisplayMember = "Value";
            cbEstado.ValueMember = "Key";


            Contacto contacto = transacciones.GetById(id);

            // Inicializar valores en el formulario
            txtNombre.Text = contacto.nombre;
            cbEstado.SelectedValue = contacto.estado_civil;
            cbTipoContacto.SelectedValue = contacto.tipo_contacto;
            txtTFijo.Text = contacto.telefono_fijo;
            txtTMovil.Text = contacto.telefono_movil;
            cbSexo.SelectedValue = contacto.sexo;
            cbEstado.SelectedValue = contacto.estado_civil;

            // No mostrar el boton añadir.
            btnAñadir.Visible = false;

            // Inicializar id
            this.id = id;

        }

        private void ContactoForm_Load(object sender, EventArgs e)
        {
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtTFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtTMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AccionAñadir();
        }

        void AccionActualizar()
        {
            // Revisar si los campos estan llenos
            if (txtNombre.Text != "" && txtNombre.Text != null &&
                cbTipoContacto.Text != "" && cbTipoContacto.Text != null &&
                txtTMovil.Text != "" && txtTMovil.Text != null &&
                cbSexo.Text != "" && cbSexo.Text != null &&
                cbEstado.Text != "" && cbEstado.Text != null)
            {
                //Validar el valor de los campos opcionales
                string fijo = (txtTFijo.Text != "" && txtTFijo.Text != null) ? txtTFijo.Text : "";
                string fecha = (dtpFechaNacimiento.Text != "" && dtpFechaNacimiento.Text != null) ? txtTFijo.Text : "";

                // Enviar a base de datos y revisar resultado
                if (
                transacciones.Update(new Contacto()
                {
                    nombre = txtNombre.Text,
                    estado_civil = Convert.ToChar(cbEstado.SelectedValue),
                    fecha_nacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value),
                    sexo = Convert.ToChar(cbSexo.SelectedValue),
                    telefono_fijo = fijo,
                    telefono_movil = txtTMovil.Text,
                    tipo_contacto = Convert.ToChar(cbTipoContacto.SelectedValue),
                    id_contacto = id
                }))
                {
                    // Creado !
                    MessageBox.Show("Actualizado!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
            else
            {
                MessageBox.Show("Campos pendientes");
            }
        }

    void AccionAñadir()
        {
            // Revisar si los campos estan llenos
            if(txtNombre.Text != "" && txtNombre.Text != null &&
                cbTipoContacto.Text != "" && cbTipoContacto.Text != null &&
                txtTMovil.Text != "" && txtTMovil.Text != null &&
                cbSexo.Text != "" && cbSexo.Text != null &&
                cbEstado.Text != "" && cbEstado.Text != null)
            {
                //Validar el valor de los campos opcionales
                string fijo = (txtTFijo.Text != "" && txtTFijo.Text != null) ? txtTFijo.Text : "";
                string fecha = (dtpFechaNacimiento.Text != "" && dtpFechaNacimiento.Text != null) ? txtTFijo.Text : "";
                
                // Enviar a base de datos y revisar resultado
                if(
                transacciones.Add(new Contacto() {
                    nombre=txtNombre.Text,
                    estado_civil=Convert.ToChar(cbEstado.SelectedValue),
                    fecha_nacimiento=Convert.ToDateTime(dtpFechaNacimiento.Value),
                    sexo=Convert.ToChar(cbSexo.SelectedValue),
                    telefono_fijo=fijo,
                    telefono_movil=txtTMovil.Text,
                    tipo_contacto=Convert.ToChar(cbTipoContacto.SelectedValue)
                })){
                    // Creado !
                    MessageBox.Show("Creado!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
            else
            {
                MessageBox.Show("Campos pendientes");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AccionActualizar();
        }
    }
}

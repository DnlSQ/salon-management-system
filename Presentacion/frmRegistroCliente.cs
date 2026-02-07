using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea2;

namespace Presentacion
{
    public partial class frmRegistroCliente : Form
    {
        public List<Cliente> listaConsultarCliente { get; set; }
        public frmRegistroCliente()
        {
            InitializeComponent();
            CargarListado();
        }

        private void Limpiar()
        {
            txt_id.Text = string.Empty;
            txt_Ncliente.Text = string.Empty;
            txt_Apellido1.Text = string.Empty;
            txt_telefono.Text = string.Empty;
            txt_email.Text = string.Empty;
            cb_Tcedula.Text = " ";
            txt_cedula.Text = string.Empty;
        }

        private void CargarListado()
        {
            try
            {
                List<Cliente> lstaresultado = Logica.ConsultarCliente(new Cliente());
                listaConsultarCliente = lstaresultado;

                DataTable dt = new DataTable();

                dt.Columns.Add("ID Cliente");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Apellido");
                dt.Columns.Add("Télefono");
                dt.Columns.Add("Email");
                dt.Columns.Add("Tipo de Cédula");
                dt.Columns.Add("Numero de cédula");
                

                foreach (Cliente item in lstaresultado)
                {
                    dt.Rows.Add(item.IDCliente,
                        item.C_Nombre,
                        item.C_Apellidos,
                        item.C_Telefono,
                        item.Email,
                        item.TipoCedula,
                        item.NumeroCedula);
                }

                Dgv_RegistroClientes.DataSource = dt;
                Dgv_RegistroClientes.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txt_BuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> filtrado = listaConsultarCliente;

                if (filtrado != null && filtrado.Count() > 0 && txt_BuscarCliente.Text.Trim().Length > 0)
                {
                    filtrado = filtrado.FindAll(Item => Item.NumeroCedula.ToString().Contains(txt_BuscarCliente.Text.ToUpper().Trim())).ToList();

                    DataTable dt = new DataTable();

                    dt.Columns.Add("ID Cliente");
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("Apellido");
                    dt.Columns.Add("Télefono");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("Tipo de Cédula");
                    dt.Columns.Add("Numero de cédula");

                    foreach (Cliente item in filtrado)
                    {
                        dt.Rows.Add(item.IDCliente,
                        item.C_Nombre,
                        item.C_Apellidos,
                        item.C_Telefono,
                        item.Email,
                        item.TipoCedula,
                        item.NumeroCedula);
                    }

                    Dgv_RegistroClientes.DataSource = dt;

                }
                else
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ID Cliente");
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("Apellido");
                    dt.Columns.Add("Télefono");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("Tipo de Cédula");
                    dt.Columns.Add("Numero de cédula");

                    foreach (Cliente item in filtrado)
                    {
                        dt.Rows.Add(item.IDCliente,
                        item.C_Nombre,
                        item.C_Apellidos,
                        item.C_Telefono,
                        item.Email,
                        item.TipoCedula,
                        item.NumeroCedula);
                    }

                    Dgv_RegistroClientes.DataSource = dt;
                }
                Dgv_RegistroClientes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dgv_RegistroClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = Dgv_RegistroClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Ncliente.Text = Dgv_RegistroClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Apellido1.Text= Dgv_RegistroClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_telefono.Text= Dgv_RegistroClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_email.Text= Dgv_RegistroClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            cb_Tcedula.Text= Dgv_RegistroClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_cedula.Text= Dgv_RegistroClientes.Rows[e.RowIndex].Cells[6].Value.ToString();

        }


        #region eventos
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btn_AgregarCliente_Click(object sender, EventArgs e)
        {
            // Expresión regular para validar el formato de número de teléfono internacional
            string phoneNumberPattern = @"^\+\d{1,3} \d{7,15}$";
            Regex phoneNumberRegex = new Regex(phoneNumberPattern);

            // Obtener el número de teléfono ingresado por el usuario
            string phoneNumber = txt_telefono.Text.Trim();

            // Validar el número de teléfono
            if (!phoneNumberRegex.IsMatch(phoneNumber))
            {
                // Mostrar un mensaje de error si el formato no es válido
                MessageBox.Show("Por favor, ingrese un número de teléfono válido con el código de país (por ejemplo: +506 22222222).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear el objeto Cliente solo si la validación es exitosa
            Cliente u = new Cliente
            {
                C_Nombre = txt_Ncliente.Text.Trim(),
                C_Apellidos = txt_Apellido1.Text.Trim(),
                C_Telefono = phoneNumber, // Asegúrate de usar el número de teléfono validado
                Email = txt_email.Text.Trim(),
                TipoCedula = cb_Tcedula.Text.Trim(),
                NumeroCedula = txt_cedula.Text.Trim()
            };

            // Llamar al método para agregar el cliente
            Logica.AgregarCliente(u);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Registro Completo");

            // Limpiar los campos y recargar el listado
            Limpiar();
            CargarListado();
        }


        private void btn_ModificarCliente_Click(object sender, EventArgs e)
        {
            // Expresión regular para validar el formato de número de teléfono internacional
            string phoneNumberPattern = @"^\+\d{1,3} \d{7,15}$";
            Regex phoneNumberRegex = new Regex(phoneNumberPattern);

            // Obtener el número de teléfono ingresado por el usuario
            string phoneNumber = txt_telefono.Text.Trim();

            // Validar el número de teléfono
            if (!phoneNumberRegex.IsMatch(phoneNumber))
            {
                // Mostrar un mensaje de error si el formato no es válido
                MessageBox.Show("Por favor, ingrese un número de teléfono válido con el código de país (por ejemplo: +506 22222222).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear el objeto Cliente solo si la validación es exitosa
            Cliente u = new Cliente
            {
                IDCliente = Convert.ToInt32(txt_id.Text.Trim()),
                C_Nombre = txt_Ncliente.Text.Trim(),
                C_Apellidos = txt_Apellido1.Text.Trim(),
                C_Telefono = phoneNumber, // Asegúrate de usar el número de teléfono validado
                Email = txt_email.Text.Trim(),
                TipoCedula = cb_Tcedula.Text.Trim(),
                NumeroCedula = txt_cedula.Text.Trim()
            };

            // Llamar al método para modificar el cliente
            Logica.ModificarCliente(u);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Información Actualizada");

            // Limpiar los campos y recargar el listado
            Limpiar();
            CargarListado();
        }


        //private void btn_EliminarCliente_Click(object sender, EventArgs e)
        //{
        //    Cliente u = new Cliente
        //    {
        //        IDCliente = Convert.ToInt32(txt_id.Text.Trim())

        //    };
        //    Logica.EliminarCliente(u);
        //    MessageBox.Show("Registro Eliminado");
        //    Limpiar();
        //    CargarListado();
        //}

        private void btn_EliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente u = new Cliente
                {
                    IDCliente = Convert.ToInt32(txt_id.Text.Trim())
                };

                Logica.EliminarCliente(u);
                MessageBox.Show("Registro Eliminado");
                Limpiar();
                CargarListado();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Verificar si el error es por restricción de referencia
                if (ex.Message.Contains("DELETE en conflicto con la restricción REFERENCE"))
                {
                    MessageBox.Show("No se puede eliminar este registro porque está siendo utilizado en otra tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Manejar otros tipos de errores SQL
                    MessageBox.Show("Ocurrió un error al intentar eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            Close();
        }
        #endregion


    }
}


using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = _customerRepository.ObtenerTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtBuscarPorId.Text;
            var cliente = _customerRepository.ObtenerPorID(id);
            List<Customers> Cliente = new List<Customers> { cliente };
            dgvClientes.DataSource = Cliente;

            if (cliente != null)
            {
                AsignarDatosATextBox(cliente);
            }
        }

        private void AsignarDatosATextBox(Customers cliente)
        {
            txtCustomerID.Text = cliente.CustomerID;
            txtContactTitle.Text = cliente.ContactTitle;
            txtContactName.Text = cliente.ContactName;
            txtCompanyName.Text = cliente.CompanyName;
            txtAddres.Text = cliente.Address;
        }

        private void InsertarCliente_Click(object sender, EventArgs e)
        {
            var cliente = Cliente();
            int insertados = _customerRepository.IngresarCliente(cliente);
            MessageBox.Show($"Se inserto {insertados} cliente.");
        }

        private Customers Cliente()
        {
            var cliente = new Customers
            {
                CustomerID = txtCustomerID.Text,
                ContactTitle = txtContactTitle.Text,
                CompanyName = txtCompanyName.Text,
                Address = txtAddres.Text,
                ContactName = txtContactName.Text,
            };

            return cliente;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            string cantidad = txtCantidad.Text;
            string nombre = txtNombre.Text;
            string precio = txtPrecio.Text;

            dgvConceptos.Rows.Add(new object[]{
                cantidad, nombre, precio, "Eliminar"
                });

            txtCantidad.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;

            txtCantidad.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Concepto> conceptos = new List<Concepto>();
                foreach (DataGridViewRow fila in dgvConceptos.Rows)
                {
                    Concepto concepto = new Concepto
                    {
                        nombre = fila.Cells[1].Value.ToString(),
                        cantidad = Convert.ToInt32(fila.Cells[0].Value.ToString()),
                        precio = Convert.ToDecimal(fila.Cells[2].Value.ToString())
                    };
                    conceptos.Add(concepto);
                }

                VentaDB venta = new VentaDB();
                venta.Add(txtCliente.Text, conceptos);
                MessageBox.Show("Venta realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvConceptos.Columns["Op"].Index)
            {
                return;
            }

            dgvConceptos.Rows.RemoveAt(e.RowIndex);
        }
    }
}

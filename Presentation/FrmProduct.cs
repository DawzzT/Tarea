using Domain;
using Domain.Enums;
using Infraestructure;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmProduct : Form
    {
        CultureInfo enUs = new CultureInfo("es-ES", false);
        int count = 0;
        public ProductModel modprd;
        public FrmProduct()
        {
            
            modprd = new ProductModel();
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string name, description;
            int quantity;
            decimal price;
            DateTime x;

            name = txtName.Text;
            if (name == "")
            {
                MessageBox.Show("Debe llenar la caja de texto con el nombre del producto.",
                                "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            description = txtDescription.Text;
            if (description == "")
            {
                MessageBox.Show("Debe llenar la caja de texto con la descripcion del producto.",
                                "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show($"Error, la cantidad:{txtQuantity.Text} no tiene el formato correcto.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!decimal.TryParse(textPrice.Text, out price))
            {
                MessageBox.Show($"Error, el precio:{textPrice.Text} no tiene el formato correcto.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            Product prd = new Product()
            {
                Id = ++count,
                Name = name,
                Description = description,
                Quantity = quantity,
                Price = price,
                CaducityDate = DateTime.Now,
                 MeasuUnit = (MeasurementUnit)Enum.GetValues(typeof(MeasurementUnit))
                          .GetValue(cmbMeasurementUnit.SelectedIndex)
            };
            
            modprd.Add(prd);
            MessageBox.Show($@"             ID: {prd.Id}
            Name: {prd.Name}
            Description: {prd.Description}
            Quantity: {prd.Quantity}
            Price: {prd.Price}
            CaducityTime: {prd.CaducityDate}
            Measurement: {prd.MeasuUnit}");
            
            ClearTextBoxes();
        }


        private void ClearTextBoxes()
        {
           
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            textPrice.Text = string.Empty;
           
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            MessageBox.Show(modprd.GetProductAsJson());
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbMeasurementUnit.Text = string.Empty;
            MeasurementUnit x;
            if ((cmbMeasurementUnit == null))
            {
                MessageBox.Show($"Error, llene todos los espacios.",
                              "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                x = (MeasurementUnit)Enum.GetValues(typeof(MeasurementUnit))
                    .GetValue(cmbMeasurementUnit.SelectedIndex);
            }
            string f = modprd.GetProductoByUnidadMedida(x);
            this.richTextBox1.Text = f;


           
        }

        private void btnOrdenarPrice_Click(object sender, EventArgs e)
        {
            cmbMeasurementUnit.Text = string.Empty;
            this.richTextBox1.Text = modprd.OrdenarByPrecio();
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRangoPrecio_Click(object sender, EventArgs e)
        {
            decimal p1 = 0, p2 = 0;
            if (!decimal.TryParse(txtMin.Text, out p1))
            {
                MessageBox.Show($"Error, el precio:{textPrice.Text} no tiene el formato correcto.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtMax.Text, out p2))
            {
                MessageBox.Show($"Error, el precio:{textPrice.Text} no tiene el formato correcto.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (p1 < p2)
            {
                cmbMeasurementUnit.Text = string.Empty;
                this.richTextBox1.Text =
                modprd.GetbyRangoDePrecio(p1, p2);
               
            }
            else
            {
                MessageBox.Show($"Error, el rango del precio minimo no puede superar al maximo.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

        }
    }
}

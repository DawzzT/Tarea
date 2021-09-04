using Domain;
using System;
using Infraestructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Enums;
using Newtonsoft.Json;

namespace Presentation
{
    public partial class FrmEmployee : Form
    {
        public EmployeeModel model;
        public FrmEmployee()
        {
            model = new EmployeeModel();
            InitializeComponent();

        }

        public int Count { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            //string dni, names, lastnames;
            //decimal wage;

            //dni = txtDni.Text;
            //if (dni == "")
            //{
            //    MessageBox.Show("Debe llenar la caja de texto con su Dni.",
            //                    "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //names = txtName.Text;
            //if (names == "")
            //{
            //    MessageBox.Show("Debe llenar la caja de texto con su Nombre.",
            //                    "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //lastnames = txtLastname.Text;
            //if (lastnames == "")
            //{
            //    MessageBox.Show("Debe llenar la caja de texto con su Apellido.",
            //                    "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (!decimal.TryParse(txtWage.Text, out wage))
            //{
            //    MessageBox.Show($"Error, el salario:{txtWage.Text} no tiene el formato correcto.",
            //                    "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //Employee emp = new Employee()
            //{
            //    Id = ++Count,
            //    Dni = dni,
            //    Name = names,
            //    Lastname = lastnames,
            //    Wage = wage,
            //    AcademicLevel = (AcademicLevel)Enum.GetValues(typeof(AcademicLevel))
            //                                        .GetValue(cmbAcademicLvl.SelectedIndex),
            //    Gender = (Genders)Enum.GetValues(typeof(Genders))
            //                           .GetValue(cmbGender.SelectedIndex)
            //};

           // string jsonEmp = JsonConvert.SerializeObject(emp);

            string jsonObject = @"{
                                    ""Id"": 1,
                                    ""Dni"":""001-000000-0000J"",
                                    ""Name"":""Pepito"",
                                    ""Lastname"": ""Perez"",
                                    ""Wage"": ""11231"",
                                    ""AcademicLevel"": 4,
                                    ""Gender"": 2,
                                    }";
            Employee emp = JsonConvert.DeserializeObject<Employee>(jsonObject);
            //PrintInformationMessage(emp);
            model.add(emp);
            MessageBox.Show($@"
                   ID: {emp.Id}
                   DNI: {emp.Dni}
                   Nombres: {emp.Name}
                   Apellidos: {emp.Lastname}
                   Salario: {emp.Wage}
                   Nivel Academico: {emp.AcademicLevel}");

            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txtDni.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtWage.Text = string.Empty;
            txtDni.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (model.empleados == null)
            {
                MessageBox.Show("Debe llenar los parametros primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($@"El salario mas alto es de: {model.SueldoMaximo()}");
            }
           
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            model.GetSalarioMinimo();
        }

        private void PrintInformationMessage(string message)
        {
            MessageBox.Show(message, "Mensaje de informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

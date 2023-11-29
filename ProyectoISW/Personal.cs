using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoISW
{
    public partial class Personal : Form



    {
        public Personal()
        {
            InitializeComponent();
            listarCargos();
            CargarPaises();
            CargarGenero();

            //dateTimePicker inicie en fecha actual
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }

        NpgsqlConnection conexion = new NpgsqlConnection("server=localhost;User Id=postgres; password=1234567;Database=bdplanilla");

        private void listarCargos()
        {
            // Agregar un ítem predeterminado "Escoger"
            comboBox1.Items.Add("Seleccionar");

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select nombre from personal;", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                conexion.Open();
                da.Fill(dt);

                // Agregar cada nombre al ComboBox
                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["nombre"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            // Seleccionar el ítem predeterminado "Escoger"
            comboBox1.SelectedIndex = 0;


        }


        private void CargarPaises()
        {
            string[] nombresPaises = { "Argentina", "Brasil", "Chile", "Colombia", "México" };

            comboBox2.Items.Add("Seleccionar"); // Ítem predeterminado

            foreach (var nombre in nombresPaises)
            {
                comboBox2.Items.Add(nombre);
            }

            comboBox2.SelectedIndex = 0; // Selección inicial
        }

        private void CargarGenero()
        {
            string[] nombresPaises = { "M", "F"};

            comboBox3.Items.Add("Seleccionar"); // Ítem predeterminado

            foreach (var nombre in nombresPaises)
            {
                comboBox3.Items.Add(nombre);
            }

            comboBox3.SelectedIndex = 0; // Selección inicial
        }

        private void validarNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada de caracteres no numéricos
            }
        }

        private void validarLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada de caracteres que no sean letras
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Personal_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

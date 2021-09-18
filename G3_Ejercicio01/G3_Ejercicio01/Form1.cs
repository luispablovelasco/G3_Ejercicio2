using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G3_Ejercicio01
{

    public partial class Form1 : Form
    {
        private List<Alumno> Alumnos = new List<Alumno>();
        private int editIndice = -1;

        private void actualizarGrid()
        {
            dgvalumnos.DataSource = null;
            dgvalumnos.DataSource = Alumnos;
        }
        private void limpiar()
        {
            txtapellido.Clear();
            txtcarnet.Clear();
            txtmateria.Clear();
            txtnombre.Clear();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            
            Alumno alumno = new Alumno();
            alumno.Nombre = txtnombre.Text;
            alumno.Apellido = txtapellido.Text;
            alumno.Carnet = txtcarnet.Text;
            alumno.Materia = txtmateria.Text;
            for (int i = 0; i < 3; i++)
            {
                alumno.Calificaciones[i] = float.Parse(txtcalificaciones.Text);
            }

            if (editIndice >-1)
            {
                Alumnos[editIndice] = alumno;
                editIndice = -1
            }
            else
            {
                Alumnos.Add(alumno);
            }
            actualizarGrid();
            limpiar();

        }

        private void dgvalumnos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvalumnos.SelectedRows[0];
            int pos = dgvalumnos.Rows.IndexOf(seleccion);
            editIndice = pos;

            Alumno listalumno = Alumnos[pos];

            txtnombre.Text = listalumno.Nombre;
            txtcarnet.Text = listalumno.Apellido;
            txtmateria.Text = listalumno.Materia;
        }
    }
}

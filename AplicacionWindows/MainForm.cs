using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Datos;

namespace AplicacionWindows
{
    public partial class MainForm : Form
    {
        private readonly BdSanPedro _contexto;
        private Alumno _registro;

        public MainForm()
        {
            InitializeComponent();

            _contexto = new BdSanPedro();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _registro = new Alumno();
            alumnoBindingSource.DataSource = _registro;
            ListarDatos();
        }

        private void ListarDatos()
        {
            coleccionAlumnos.DataSource = _contexto.Alumnos.AsNoTracking().ToList();
            coleccionAlumnos.ResetBindings(false);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                alumnoBindingSource.EndEdit();
                _contexto.Alumnos.Add(_registro);
                _contexto.SaveChanges();

                ListarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                alumnoBindingSource.EndEdit();
                
                _contexto.Alumnos.Attach(_registro);
                _contexto.Entry(_registro).State = EntityState.Modified;

                _contexto.SaveChanges();

                ListarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var seleccionado = coleccionAlumnos.Current as Alumno;

                if (seleccionado == null) return;

                _registro = seleccionado;

                alumnoBindingSource.DataSource = seleccionado;
                alumnoBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var seleccionado = coleccionAlumnos.Current as Alumno;

                if (seleccionado == null) return;

                _contexto.Alumnos.Attach(seleccionado);
                _contexto.Entry(seleccionado).State = EntityState.Deleted;
                _contexto.Alumnos.Remove(seleccionado);

                _contexto.SaveChanges();

                ListarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

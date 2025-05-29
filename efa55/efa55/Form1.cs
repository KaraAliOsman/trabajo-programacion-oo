using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace efa55
{
    public partial class Form1 : Form
    {
        private DataTable dtPersonas;

        public Form1()
        {
            InitializeComponent();
            this.dataGridViewPersonas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewPersonas_CellValidating);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.InitializeDatabase();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Crítico al iniciar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try
            {
                dtPersonas = DatabaseHelper.CargarPersonas();
                dataGridViewPersonas.DataSource = dtPersonas; // Asignar directamente

                if (dataGridViewPersonas.Columns.Contains("id"))
                {
                    dataGridViewPersonas.Columns["id"].HeaderText = "ID";
                    dataGridViewPersonas.Columns["id"].ReadOnly = true;
                }
                if (dataGridViewPersonas.Columns.Contains("nombre")) dataGridViewPersonas.Columns["nombre"].HeaderText = "Nombre";
                if (dataGridViewPersonas.Columns.Contains("apellido")) dataGridViewPersonas.Columns["apellido"].HeaderText = "Apellido";
                if (dataGridViewPersonas.Columns.Contains("celular")) dataGridViewPersonas.Columns["celular"].HeaderText = "Celular";

                dataGridViewPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCrear.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Nombre vacío no es válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCrear.Focus();
                return;
            }
            if (!nombre.Replace(" ", "").All(Char.IsLetter))
            {
                MessageBox.Show("Nombre solo letras.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCrear.Focus();
                return;
            }

            try
            {
                DatabaseHelper.CrearPersona(nombre);
                txtNombreCrear.Clear();
                CargarDatos();
                MessageBox.Show("Ok, persona creada.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombreAEliminar = txtNombreEliminar.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreAEliminar))
            {
                MessageBox.Show("Ingresa nombre para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEliminar.Focus();
                return;
            }

            try
            {
                bool eliminado = DatabaseHelper.EliminarPersonaPorNombre(nombreAEliminar);
                txtNombreEliminar.Clear();
                CargarDatos();
                if (eliminado)
                {
                    MessageBox.Show("Eliminado con éxito.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró ese nombre.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPersonas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colNombre = dataGridViewPersonas.Columns[e.ColumnIndex].Name;
            string valor = e.FormattedValue?.ToString().Trim();

            if (dataGridViewPersonas.Rows[e.RowIndex].IsNewRow) return;
            if (string.IsNullOrEmpty(valor)) return;

            if (colNombre == "nombre")
            {
                if (!valor.Replace(" ", "").All(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("Nombre solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else if (colNombre == "apellido")
            {
                if (!valor.Replace(" ", "").All(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("Apellido solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else if (colNombre == "celular")
            {
                if (!long.TryParse(valor, out _))
                {
                    MessageBox.Show("Celular solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dataGridViewPersonas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dtPersonas == null || dtPersonas.Rows.Count <= e.RowIndex) return;
            if (dataGridViewPersonas.Rows[e.RowIndex].IsNewRow) return;

            try
            {
                DataRowView drv = dataGridViewPersonas.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;
                DataRow fila = drv.Row;
                if (fila.RowState == DataRowState.Detached || fila.RowState == DataRowState.Deleted) return;

                int id = Convert.ToInt32(fila["id"]);
                string nombre = fila["nombre"]?.ToString();
                string apellido = fila["apellido"]?.ToString();
                string celular = fila["celular"]?.ToString();
                DatabaseHelper.ActualizarPersona(id, nombre, apellido, celular);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error actualizando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarDatos();
            }
        }
    }
}
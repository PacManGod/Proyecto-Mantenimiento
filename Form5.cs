using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form5 : Form
	{
		private IContainer components = null;

		private Label label1;

		private Button buttonExit;

		private DataGridView dataGridView1;

		private Label label2;

		private Label label3;

		private TextBox textBox1;

		private Button buttonBuscar;

		private Label label4;

		private Label labelTextoNombre;

		private Label labelTextoFecha;

		private Label labelTextoDescripcion;

		private Label labelTextoHerramienta;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		public Form5()
		{
			this.InitializeComponent();
			this.cargarTabla();
		}

		private void buttonBuscar_Click(object sender, EventArgs e)
		{
			string query = string.Concat("SELECT * FROM alertas WHERE id = ", this.textBox1.Text);
			MySqlConnection conexion = Conectar.Conecta();
			conexion.Open();
			try
			{
				MySqlDataReader reader = (new MySqlCommand(query, conexion)).ExecuteReader();
				if (reader.Read())
				{
					string tipo_alert = reader["tipo_alerta"].ToString();
					string descripcion_alert = reader["descripcion_alerta"].ToString();
					string nombre = this.GenerarNombreAleatorio();
					string fecha = this.GenerarFechaAleatoria();
					string herramientas = this.HerramientasAleatorias(int.Parse(tipo_alert));
					string descripcion = descripcion_alert;
					this.labelTextoNombre.Text = nombre;
					this.labelTextoFecha.Text = fecha;
					this.labelTextoDescripcion.Text = descripcion;
					this.labelTextoHerramienta.Text = herramientas;
					if (int.Parse(tipo_alert) != 0)
					{
						this.consulta2(this.textBox1.Text, nombre, fecha, herramientas, descripcion);
					}
				}
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				MessageBox.Show(string.Concat("Error: ", ex.Message));
			}
			conexion.Close();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public void cargarTabla()
		{
			string query = "SELECT * FROM alertas";
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			MySqlDataAdapter adaptador = new MySqlDataAdapter(new MySqlCommand(query, conexionDB));
			DataTable tabla = new DataTable();
			adaptador.Fill(tabla);
			this.dataGridView1.DataSource = tabla;
			conexionDB.Close();
		}

		public void consulta2(string id, string nomb, string fech, string herr, string desc)
		{
			string query = string.Concat(new string[] { "INSERT INTO calendario (id, nombre, fecha, herramientas, descripcion) VALUES ('", id, "', '", nomb, "', '", fech, "', '", herr, "', '", desc, "')" });
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			(new MySqlCommand(query, conexionDB)).ExecuteNonQuery();
			conexionDB.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private string GenerarFechaAleatoria()
		{
			int num = (new Random()).Next(0, 10);
			DateTime fecha = DateTime.Now;
			fecha = fecha.AddDays((double)num);
			return fecha.ToString("dd/MM/yyyy");
		}

		private string GenerarNombreAleatorio()
		{
			string[] nombres = new string[] { "Juan", "Pedro", "Luis", "Jose", "Maria", "Ana", "Luisa", "Josefa", "Rosa", "Carmen", "Miguel", "Carlos", "Jorge", "Ricardo", "Francisco", "Antonio", "Manuel", "Javier", "Ramon", "Fernando", "Joaquin", "Mariano", "Rafael", "Gabriel", "Daniel", "Alejandro", "Eduardo", "Jesús", "Pablo", "Sergio", "Diego", "Enrique", "Adrian", "Victor", "Javier", "Oscar", "Alberto", "Miguel", "Santiago", "Ivan", "Jorge", "Roberto", "Alvaro", "Hugo", "Jaime", "Julio", "Luis", "Mario", "Martin", "Nicolás", "Omar", "Raul", "Ruben", "Salvador", "Samuel", "Sergio", "Tomas", "Vicente", "Víctor", "Agustin", "Alfonso", "Andres", "Angel", "Benito", "Bernardo", "Bruno", "Cesar", "Cristian" };
			string[] apellido = new string[] { "Garcia", "Gonzalez", "Rodriguez", "Fernandez", "Lopez", "Martinez", "Sanchez", "Perez", "Gomez", "Martin", "Jimenez", "Ruiz", "Hernandez", "Diaz", "Moreno", "Alvarez", "Muñoz", "Romero", "Alonso", "Gutierrez", "Navarro", "Torres", "Dominguez", "Vazquez", "Ramos", "Gil", "Ramirez", "Serrano", "Blanco", "Molina", "Morales", "Suarez", "Ortega", "Delgado", "Castro", "Ortiz", "Rubio", "Marin", "Sanz", "Iglesias", "Nuñez", "Medina", "Garrido", "Cortes", "Castillo", "Santos", "Lozano", "Guerrero", "Cano", "Prieto", "Mendez", "Calvo", "Gallego", "Cruz", "Herrera", "Marquez", "Santana", "Lorenzo", "Pascual", "Mora", "Rojas", "Herrero", "Duran", "Aguilar", "Reyes" };
			int num = (new Random()).Next(0, 15);
			string str = string.Concat(nombres[num], " ", apellido[num]);
			return str;
		}

		private string HerramientasAleatorias(int x)
		{
			string herramienta;
			if (x == 1)
			{
				herramienta = "Se necesita verificar el estado el equipo debido a las horas de uso, se recomienda tomar medidas al sistema de seguridad en caso de que se encuentre obsoleto o no funcione correctamente";
			}
			else if (x != 2)
			{
				herramienta = (x != 3 ? "No se requiere mantenimiento" : "Es necesario tomar medidas urgentes el equipo se encuentra con el con elevadas horas de uso sin mantenimiento, se recomienda verificar el estado del equipo y tomar medidas al sistema de seguridad en caso de que se encuentre obsoleto o no funcione correctamente");
			}
			else
			{
				herramienta = "Se necesita tomar medidas debido al uso de la maquina, se recomienda verificar el estado del equipo y tomar medidas al sistema de seguridad en caso de que se encuentre obsoleto o no funcione correctamente";
			}
			return herramienta;
		}

		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			this.label1 = new Label();
			this.buttonExit = new Button();
			this.dataGridView1 = new DataGridView();
			this.label2 = new Label();
			this.label3 = new Label();
			this.textBox1 = new TextBox();
			this.buttonBuscar = new Button();
			this.label4 = new Label();
			this.labelTextoNombre = new Label();
			this.labelTextoFecha = new Label();
			this.labelTextoDescripcion = new Label();
			this.labelTextoHerramienta = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Orden de mantenimiento";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(581, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 20;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.dataGridView1.BorderStyle = BorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Cursor = Cursors.Default;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new Point(12, 83);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(643, 150);
			this.dataGridView1.TabIndex = 21;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(15, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 16);
			this.label2.TabIndex = 22;
			this.label2.Text = "Lista de Alertas";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 266);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Id de alerta";
			this.textBox1.Location = new Point(78, 263);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 24;
			this.buttonBuscar.Location = new Point(200, 261);
			this.buttonBuscar.Name = "buttonBuscar";
			this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
			this.buttonBuscar.TabIndex = 25;
			this.buttonBuscar.Text = "buscar";
			this.buttonBuscar.UseVisualStyleBackColor = true;
			this.buttonBuscar.Click += new EventHandler(this.buttonBuscar_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(15, 306);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Detalle de orden:";
			this.labelTextoNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.labelTextoNombre.Location = new Point(150, 334);
			this.labelTextoNombre.Name = "labelTextoNombre";
			this.labelTextoNombre.Size = new System.Drawing.Size(146, 21);
			this.labelTextoNombre.TabIndex = 28;
			this.labelTextoFecha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.labelTextoFecha.Location = new Point(150, 355);
			this.labelTextoFecha.Name = "labelTextoFecha";
			this.labelTextoFecha.Size = new System.Drawing.Size(212, 21);
			this.labelTextoFecha.TabIndex = 29;
			this.labelTextoFecha.Click += new EventHandler(this.labelTextoFecha_Click);
			this.labelTextoDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.labelTextoDescripcion.Location = new Point(150, 376);
			this.labelTextoDescripcion.Name = "labelTextoDescripcion";
			this.labelTextoDescripcion.Size = new System.Drawing.Size(505, 21);
			this.labelTextoDescripcion.TabIndex = 30;
			this.labelTextoHerramienta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.labelTextoHerramienta.Location = new Point(150, 397);
			this.labelTextoHerramienta.Name = "labelTextoHerramienta";
			this.labelTextoHerramienta.Size = new System.Drawing.Size(413, 116);
			this.labelTextoHerramienta.TabIndex = 31;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(43, 334);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 32;
			this.label5.Text = "Nombre encargado:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(104, 355);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 33;
			this.label6.Text = "Fecha:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(78, 376);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 13);
			this.label7.TabIndex = 34;
			this.label7.Text = "Descripción:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(63, 397);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(81, 13);
			this.label8.TabIndex = 35;
			this.label8.Text = "Observaciones:";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(668, 522);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.labelTextoHerramienta);
			base.Controls.Add(this.labelTextoDescripcion);
			base.Controls.Add(this.labelTextoFecha);
			base.Controls.Add(this.labelTextoNombre);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.buttonBuscar);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.buttonExit);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form5";
			this.Text = "Form5";
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void labelTextoFecha_Click(object sender, EventArgs e)
		{
		}
	}
}
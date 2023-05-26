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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTextoNombre = new System.Windows.Forms.Label();
            this.labelTextoFecha = new System.Windows.Forms.Label();
            this.labelTextoDescripcion = new System.Windows.Forms.Label();
            this.labelTextoHerramienta = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de mantenimiento";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(581, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 20;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(643, 150);
            this.dataGridView1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Lista de Alertas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Id de alerta:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(93, 263);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 24;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(215, 265);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 25;
            this.buttonBuscar.Text = "buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Detalle de orden:";
            // 
            // labelTextoNombre
            // 
            this.labelTextoNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextoNombre.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoNombre.Location = new System.Drawing.Point(175, 334);
            this.labelTextoNombre.Name = "labelTextoNombre";
            this.labelTextoNombre.Size = new System.Drawing.Size(146, 21);
            this.labelTextoNombre.TabIndex = 28;
            // 
            // labelTextoFecha
            // 
            this.labelTextoFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextoFecha.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoFecha.Location = new System.Drawing.Point(166, 355);
            this.labelTextoFecha.Name = "labelTextoFecha";
            this.labelTextoFecha.Size = new System.Drawing.Size(212, 21);
            this.labelTextoFecha.TabIndex = 29;
            this.labelTextoFecha.Click += new System.EventHandler(this.labelTextoFecha_Click);
            // 
            // labelTextoDescripcion
            // 
            this.labelTextoDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextoDescripcion.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoDescripcion.Location = new System.Drawing.Point(174, 376);
            this.labelTextoDescripcion.Name = "labelTextoDescripcion";
            this.labelTextoDescripcion.Size = new System.Drawing.Size(415, 21);
            this.labelTextoDescripcion.TabIndex = 30;
            // 
            // labelTextoHerramienta
            // 
            this.labelTextoHerramienta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextoHerramienta.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoHerramienta.Location = new System.Drawing.Point(159, 397);
            this.labelTextoHerramienta.Name = "labelTextoHerramienta";
            this.labelTextoHerramienta.Size = new System.Drawing.Size(496, 116);
            this.labelTextoHerramienta.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nombre encargado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(104, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Descripción:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(63, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Observaciones:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTextoHerramienta);
            this.Controls.Add(this.labelTextoDescripcion);
            this.Controls.Add(this.labelTextoFecha);
            this.Controls.Add(this.labelTextoNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void labelTextoFecha_Click(object sender, EventArgs e)
		{
		}
	}
}
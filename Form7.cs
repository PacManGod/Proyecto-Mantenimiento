using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form7 : Form
	{
		private IContainer components = null;

		private Label label1;

		private Button buttonExit;

		private Label label2;

		private DataGridView dataGridView1;

		private TextBox textBox1;

		private Button button1;

		private Label label3;

		private Label label4;

		private Label label5;

		public Form7()
		{
			this.InitializeComponent();
			this.llenarTabla();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string query = string.Concat("SELECT * FROM hojaprod WHERE id = '", this.textBox1.Text, "'");
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			try
			{
				MySqlDataReader reader = (new MySqlCommand(query, conexionDB)).ExecuteReader();
				if (reader.Read())
				{
					string num_meta = reader["numero_meta"].ToString();
					string num_actual = reader["numero_actual"].ToString();
					string num_completo_satisfractorio = reader["numero_completo_satisfractorio"].ToString();
					string num_completo_no_satisfactorio = reader["numero_completo_no_satisfactorio"].ToString();
					reader["numero_horas_activo_por_dia"].ToString();
					reader["numero_horas_para_mantenimiento"].ToString();
					string fecha_de_inicio_hora = reader["fecha_de_inicio_horas"].ToString();
					string tiempo_duracion_even = reader["tiempo_duracion_evento"].ToString();
					reader["dia_del_evento"].ToString();
					reader["descripcion_del_evento"].ToString();
					tiempo_duracion_even = ((string.IsNullOrEmpty(tiempo_duracion_even) ? false : tiempo_duracion_even != "") ? reader["tiempo_duracion_evento"].ToString() : "0");
					DateTime DateObject = Convert.ToDateTime(fecha_de_inicio_hora, new CultureInfo("es-ES"));
					int tiempo = (DateTime.Now - DateObject).Days;
					this.indicadorCalidad(num_actual, num_completo_satisfractorio, num_completo_no_satisfactorio);
					this.eficienciaPlaneacion(num_meta, num_actual);
				}
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				MessageBox.Show(string.Concat("Error: ", ex.Message));
			}
			conexionDB.Close();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void eficienciaPlaneacion(string unidProgr, string unidPord)
		{
			int num_unidProgr = int.Parse(unidProgr);
			int eficiencia = int.Parse(unidPord) * 100 / num_unidProgr;
			this.label5.Text = string.Concat("Eficiencia de Planeación: ", eficiencia.ToString(), "%");
		}

		private void indicadorCalidad(string unid_Prod, string unid_Confor, string unid_no_confor)
		{
			int num_unid_Prod = int.Parse(unid_Prod);
			int num_unid_Confor = int.Parse(unid_Confor);
			int num_unid_no_Confor = int.Parse(unid_no_confor);
			int indicador = (num_unid_Confor - num_unid_no_Confor) * 100 / num_unid_Prod;
			this.label4.Text = string.Concat("Indicador de Calidad: ", indicador.ToString(), "%");
		}

		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			this.label1 = new Label();
			this.buttonExit = new Button();
			this.label2 = new Label();
			this.dataGridView1 = new DataGridView();
			this.textBox1 = new TextBox();
			this.button1 = new Button();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(8, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Eficiencia de la Planeación";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(581, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 22;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(8, 330);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 20);
			this.label2.TabIndex = 23;
			this.label2.Text = "Indicador de calidad";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.dataGridView1.BorderStyle = BorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.ColumnHeadersHeight = 30;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new Point(12, 41);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(644, 208);
			this.dataGridView1.TabIndex = 24;
			this.textBox1.Location = new Point(40, 280);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(70, 20);
			this.textBox1.TabIndex = 25;
			this.button1.Location = new Point(116, 278);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 26;
			this.button1.Text = "Consultar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(16, 283);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "ID";
			this.label4.Location = new Point(16, 359);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(369, 23);
			this.label4.TabIndex = 28;
			this.label4.Click += new EventHandler(this.label4_Click);
			this.label5.Location = new Point(16, 422);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(369, 72);
			this.label5.TabIndex = 29;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(668, 522);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.buttonExit);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form7";
			this.Text = "Form7";
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		public void llenarTabla()
		{
			string query = "SELECT * FROM hvequipo";
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			MySqlDataAdapter adaptador = new MySqlDataAdapter(new MySqlCommand(query, conexionDB));
			DataTable tabla = new DataTable();
			adaptador.Fill(tabla);
			this.dataGridView1.DataSource = tabla;
			conexionDB.Close();
		}
	}
}
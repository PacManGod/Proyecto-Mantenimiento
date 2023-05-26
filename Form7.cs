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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Eficiencia de la Planeación";
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
            this.buttonExit.TabIndex = 22;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Indicador de calidad";
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
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(644, 208);
            this.dataGridView1.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(40, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 24);
            this.textBox1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(116, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(369, 23);
            this.label4.TabIndex = 28;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(369, 72);
            this.label5.TabIndex = 29;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form7";
            this.Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
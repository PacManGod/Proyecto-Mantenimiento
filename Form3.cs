using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form3 : Form
	{
		private IContainer components = null;

		private Button buttonSave;

		private Label label3;

		private Label label2;

		private Label label1;

		private Label label10;

		private Label label9;

		private Label label8;

		private Button buttonExit;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private TextBox textBox4;

		private TextBox textBox5;

		private TextBox textBox6;

		private TextBox textBox7;

		private TextBox textBox9;

		private Label label11;

		private TextBox textBox10;

		private Button buttonValidar;

		private Label label12;

		private DateTimePicker dateTimePicker1;

		private DateTimePicker dateTimePicker2;

		private Label label13;

		private Panel panel1;

		private Label label14;

		private RadioButton radioButtonSi;

		private RadioButton radioButtonNo;

		public Form3()
		{
			this.InitializeComponent();
			this.bloqueoCampos(false);
			this.radioButtonNo.Checked = true;
		}

		private void bloqueoCampos(bool valido)
		{
			bool bloqueo = valido;
			if (bloqueo)
			{
				this.textBox10.BackColor = Color.Green;
			}
			else
			{
				this.textBox10.BackColor = Color.Red;
			}
			this.textBox10.Focus();
			this.textBox1.Enabled = bloqueo;
			this.textBox2.Enabled = bloqueo;
			this.textBox3.Enabled = bloqueo;
			this.textBox4.Enabled = bloqueo;
			this.textBox5.Enabled = bloqueo;
			this.textBox6.Enabled = bloqueo;
			this.textBox7.Enabled = bloqueo;
			this.textBox9.Enabled = bloqueo;
			this.buttonSave.Enabled = bloqueo;
			this.dateTimePicker1.Enabled = bloqueo;
			this.dateTimePicker2.Enabled = bloqueo;
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			string id = this.textBox10.Text;
			string numero_meta = this.textBox1.Text;
			string numero_actual = this.textBox2.Text;
			string numero_completo_satisfractorio = this.textBox3.Text;
			string numero_completo_no_satisfactorio = this.textBox4.Text;
			string numero_horas_activo_por_dia = this.textBox5.Text;
			string numero_horas_para_mantenimiento = this.textBox6.Text;
			string tiempo_duracion_evento = this.textBox7.Text;
			string descripcion_del_evento = this.textBox9.Text;
			DateTime value = this.dateTimePicker1.Value;
			string fecha_de_inicio_horas = value.ToString("yyyy-MM-dd");
			value = this.dateTimePicker2.Value;
			string dia_del_evento = value.ToString("yyyy-MM-dd");
			if (this.validacionCamposVacios())
			{
				if (numero_actual == numero_completo_satisfractorio)
				{
					MessageBox.Show("El numero actual no puede ser menor o igual al numero de completos satisfactorios");
				}
				else if (int.Parse(numero_actual) > int.Parse(numero_completo_no_satisfactorio))
				{
					string query = string.Concat(new string[] { "INSERT INTO hojaprod (id, numero_meta, numero_actual, numero_completo_satisfractorio, numero_completo_no_satisfactorio, numero_horas_activo_por_dia, numero_horas_para_mantenimiento, tiempo_duracion_evento, descripcion_del_evento, fecha_de_inicio_horas, dia_del_evento) VALUES (", id, ", ", numero_meta, ", ", numero_actual, ", ", numero_completo_satisfractorio, ", ", numero_completo_no_satisfactorio, ", '", numero_horas_activo_por_dia, "', '", numero_horas_para_mantenimiento, "', '", tiempo_duracion_evento, "', '", descripcion_del_evento, "', '", fecha_de_inicio_horas, "', '", dia_del_evento, "')" });
					MySqlConnection conexionDB = Conectar.Conecta();
					conexionDB.Open();
					try
					{
						(new MySqlCommand(query, conexionDB)).ExecuteNonQuery();
						MessageBox.Show("Se guardó correctamente");
					}
					catch (Exception exception)
					{
						Exception ex = exception;
						MessageBox.Show(string.Concat("Error: ", ex.Message));
					}
					conexionDB.Close();
				}
				else
				{
					MessageBox.Show("El numero actual no puede ser menor o igual al numero de completos no satisfactorios");
				}
			}
		}

		private void buttonValidar_Click(object sender, EventArgs e)
		{
			string query = string.Concat("SELECT * FROM hvequipo WHERE id = ", this.textBox10.Text);
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			try
			{
				MySqlDataReader reader = (new MySqlCommand(query, conexionDB)).ExecuteReader();
				if (!reader.Read())
				{
					MessageBox.Show("El equipo no existe");
				}
				else
				{
					this.bloqueoCampos(true);
					this.buttonSave.Enabled = true;
					this.textBox10.Enabled = false;
					this.textBox10.Font = new System.Drawing.Font(this.textBox10.Font, FontStyle.Bold);
					MessageBox.Show("Se encontró el equipo");
					if (reader["area"].ToString() == "1")
					{
						this.label8.Text = "Casos a Atender";
						this.label9.Text = "Casos Atendidos";
						this.label10.Text = "Casos Conformes";
						this.label4.Text = "Casos No Conformes";
					}
					else if (reader["area"].ToString() == "2")
					{
						this.label8.Text = "Unidades a Producir";
						this.label9.Text = "Unidades Completas";
						this.label10.Text = "Unidades Conformes";
						this.label4.Text = "Unidades No Conformes";
					}
					else if (reader["area"].ToString() == "3")
					{
						this.label8.Text = "Ingresos Estimados";
						this.label9.Text = "Ingresos Reales";
						this.label10.Text = "Ingresos Conformes";
						this.label4.Text = "Ingresos No Conformes";
					}
					else if (reader["area"].ToString() == "4")
					{
						this.label8.Text = "Llamadas a Atender";
						this.label9.Text = "Llamadas Atendidas";
						this.label10.Text = "Llamadas Conformes";
						this.label4.Text = "Llamadas No Conformes";
					}
				}
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				MessageBox.Show(string.Concat("Error: ", ex.Message));
			}
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

		private void InitializeComponent()
		{
			this.buttonSave = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.buttonExit = new Button();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.textBox3 = new TextBox();
			this.textBox4 = new TextBox();
			this.textBox5 = new TextBox();
			this.textBox6 = new TextBox();
			this.textBox7 = new TextBox();
			this.textBox9 = new TextBox();
			this.label11 = new Label();
			this.textBox10 = new TextBox();
			this.buttonValidar = new Button();
			this.label12 = new Label();
			this.dateTimePicker1 = new DateTimePicker();
			this.dateTimePicker2 = new DateTimePicker();
			this.label13 = new Label();
			this.panel1 = new Panel();
			this.label14 = new Label();
			this.radioButtonSi = new RadioButton();
			this.radioButtonNo = new RadioButton();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.buttonSave.Location = new Point(533, 516);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 31;
			this.buttonSave.Text = "Guardar";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
			this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 16);
			this.label3.TabIndex = 24;
			this.label3.Text = "EVENTO";
			this.label3.Visible = false;
			this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(294, 292);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(185, 13);
			this.label2.TabIndex = 23;
			this.label2.Text = "Meta de Horas Para el Mantenimiento";
			this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(61, 292);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Horas Por Dia Activo";
			this.label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(61, 248);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(105, 13);
			this.label10.TabIndex = 21;
			this.label10.Text = "Unidades Conformes";
			this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(294, 200);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(108, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Unidades Producidas";
			this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(61, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Unidades a Producir";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(576, 21);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 18;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
			this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(294, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 13);
			this.label4.TabIndex = 32;
			this.label4.Text = "Unidades No Conformes";
			this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(1, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(157, 13);
			this.label5.TabIndex = 33;
			this.label5.Text = "Tiempo de Duracion del Evento";
			this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(270, 37);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 34;
			this.label6.Text = "horas.";
			this.label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(1, 99);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 35;
			this.label7.Text = "Observaciones";
			this.textBox1.Location = new Point(183, 197);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 36;
			this.textBox2.Location = new Point(434, 197);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 37;
			this.textBox3.Location = new Point(183, 245);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 38;
			this.textBox4.Location = new Point(434, 245);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 39;
			this.textBox5.Location = new Point(183, 289);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 40;
			this.textBox6.Location = new Point(481, 289);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 41;
			this.textBox7.Location = new Point(164, 34);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 20);
			this.textBox7.TabIndex = 42;
			this.textBox9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox9.Location = new Point(4, 117);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(401, 102);
			this.textBox9.TabIndex = 44;
			this.label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(61, 156);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 13);
			this.label11.TabIndex = 45;
			this.label11.Text = "Identificador";
			this.textBox10.Location = new Point(183, 153);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(100, 20);
			this.textBox10.TabIndex = 46;
			this.buttonValidar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.buttonValidar.Location = new Point(439, 516);
			this.buttonValidar.Name = "buttonValidar";
			this.buttonValidar.Size = new System.Drawing.Size(75, 23);
			this.buttonValidar.TabIndex = 47;
			this.buttonValidar.Text = "Validar ID";
			this.buttonValidar.UseVisualStyleBackColor = true;
			this.buttonValidar.Click += new EventHandler(this.buttonValidar_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new Point(61, 329);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 13);
			this.label12.TabIndex = 48;
			this.label12.Text = "Fecha de Inicio";
			this.dateTimePicker1.Format = DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new Point(183, 323);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 49;
			this.dateTimePicker2.Format = DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new Point(100, 67);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2.TabIndex = 51;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(1, 73);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(92, 13);
			this.label13.TabIndex = 50;
			this.label13.Text = "Dia de lo Ocurrido";
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.textBox9);
			this.panel1.Controls.Add(this.textBox7);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new Point(64, 144);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(543, 231);
			this.panel1.TabIndex = 52;
			this.panel1.Visible = false;
			this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(407, 378);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(98, 13);
			this.label14.TabIndex = 53;
			this.label14.Text = "Ocurrio un evento?";
			this.radioButtonSi.AutoSize = true;
			this.radioButtonSi.Location = new Point(511, 374);
			this.radioButtonSi.Name = "radioButtonSi";
			this.radioButtonSi.Size = new System.Drawing.Size(34, 17);
			this.radioButtonSi.TabIndex = 54;
			this.radioButtonSi.TabStop = true;
			this.radioButtonSi.Text = "Si";
			this.radioButtonSi.UseVisualStyleBackColor = true;
			this.radioButtonSi.CheckedChanged += new EventHandler(this.radioButtonSi_CheckedChanged);
			this.radioButtonNo.AutoSize = true;
			this.radioButtonNo.Location = new Point(551, 374);
			this.radioButtonNo.Name = "radioButtonNo";
			this.radioButtonNo.Size = new System.Drawing.Size(39, 17);
			this.radioButtonNo.TabIndex = 55;
			this.radioButtonNo.TabStop = true;
			this.radioButtonNo.Text = "No";
			this.radioButtonNo.UseVisualStyleBackColor = true;
			this.radioButtonNo.CheckedChanged += new EventHandler(this.radioButtonNo_CheckedChanged);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(684, 561);
			base.Controls.Add(this.radioButtonNo);
			base.Controls.Add(this.radioButtonSi);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.dateTimePicker1);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.buttonValidar);
			base.Controls.Add(this.textBox10);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.textBox6);
			base.Controls.Add(this.textBox5);
			base.Controls.Add(this.textBox4);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.buttonSave);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.buttonExit);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form3";
			this.Text = "Form3";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void limpiarCampos()
		{
			this.textBox1.Text = "";
			this.textBox2.Text = "";
			this.textBox3.Text = "";
			this.textBox4.Text = "";
			this.textBox5.Text = "";
			this.textBox6.Text = "";
			this.textBox7.Text = "";
			this.textBox9.Text = "";
			this.textBox10.Text = "";
		}

		private void ocultarPanel()
		{
			if (this.radioButtonSi.Checked)
			{
				this.panel1.Visible = true;
				this.panel1.Enabled = true;
				this.panel1.BringToFront();
			}
			else if (this.radioButtonNo.Checked)
			{
				this.panel1.Visible = false;
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
		{
			this.ocultarPanel();
		}

		private void radioButtonSi_CheckedChanged(object sender, EventArgs e)
		{
			this.ocultarPanel();
		}

		private bool validacionCamposVacios()
		{
			bool flag;
			if ((this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox5.Text == "" || this.textBox6.Text == "" || this.textBox10.Text == "" || this.textBox4.Text == "" ? false : this.dateTimePicker1.Text != ""))
			{
				flag = true;
			}
			else
			{
				MessageBox.Show("Debe llenar todos los campos para poder guardar");
				flag = false;
			}
			return flag;
		}
	}
}
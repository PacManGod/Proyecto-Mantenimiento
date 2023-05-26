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
            this.buttonSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.buttonValidar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButtonSi = new System.Windows.Forms.RadioButton();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(533, 450);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "EVENTO";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Meta de Horas Para el Mantenimiento";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Horas Por Dia Activo";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(61, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Unidades Conformes";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(294, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Unidades Producidas";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Unidades a Producir";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(576, 21);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Unidades No Conformes";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tiempo de Duracion del Evento";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "horas.";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Observaciones";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(183, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 36;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(434, 131);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 24);
            this.textBox2.TabIndex = 37;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(183, 179);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 24);
            this.textBox3.TabIndex = 38;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(434, 179);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 24);
            this.textBox4.TabIndex = 39;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(183, 223);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 24);
            this.textBox5.TabIndex = 40;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(518, 223);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 24);
            this.textBox6.TabIndex = 41;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(249, 34);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 24);
            this.textBox7.TabIndex = 42;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox9.Location = new System.Drawing.Point(4, 117);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(401, 102);
            this.textBox9.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(61, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 45;
            this.label11.Text = "Identificador";
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(183, 87);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 24);
            this.textBox10.TabIndex = 46;
            // 
            // buttonValidar
            // 
            this.buttonValidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonValidar.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValidar.Location = new System.Drawing.Point(439, 450);
            this.buttonValidar.Name = "buttonValidar";
            this.buttonValidar.Size = new System.Drawing.Size(75, 23);
            this.buttonValidar.TabIndex = 47;
            this.buttonValidar.Text = "Validar ID";
            this.buttonValidar.UseVisualStyleBackColor = true;
            this.buttonValidar.Click += new System.EventHandler(this.buttonValidar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(61, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 16);
            this.label12.TabIndex = 48;
            this.label12.Text = "Fecha de Inicio";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 257);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 49;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(110, 67);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker2.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 50;
            this.label13.Text = "Dia de lo Ocurrido";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(64, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 231);
            this.panel1.TabIndex = 52;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(394, 312);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 16);
            this.label14.TabIndex = 53;
            this.label14.Text = "Ocurrio un evento?";
            // 
            // radioButtonSi
            // 
            this.radioButtonSi.AutoSize = true;
            this.radioButtonSi.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSi.Location = new System.Drawing.Point(511, 311);
            this.radioButtonSi.Name = "radioButtonSi";
            this.radioButtonSi.Size = new System.Drawing.Size(35, 20);
            this.radioButtonSi.TabIndex = 54;
            this.radioButtonSi.TabStop = true;
            this.radioButtonSi.Text = "Si";
            this.radioButtonSi.UseVisualStyleBackColor = true;
            this.radioButtonSi.CheckedChanged += new System.EventHandler(this.radioButtonSi_CheckedChanged);
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNo.Location = new System.Drawing.Point(551, 311);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(41, 20);
            this.radioButtonNo.TabIndex = 55;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.CheckedChanged += new System.EventHandler(this.radioButtonNo_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.radioButtonNo);
            this.Controls.Add(this.radioButtonSi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonValidar);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
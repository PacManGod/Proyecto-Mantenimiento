using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form2 : Form
	{
		private IContainer components = null;

		private Label label10;

		private Label label9;

		private Label label8;

		private Button buttonExit;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private TextBox textBox5;

		private MonthCalendar monthCalendar1;

		private Button buttonSave;

		private Label label4;

		private TextBox textBox6;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private RadioButton radioButton4;

		public Form2()
		{
			this.InitializeComponent();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			string nombreEquipo = this.textBox1.Text;
			string marca = this.textBox2.Text;
			string id = this.textBox6.Text;
			string modelo = this.textBox3.Text;
			string area = this.radiobutton().ToString();
			string fabricante = this.textBox5.Text;
			string[] str = new string[5];
			int year = this.monthCalendar1.SelectionStart.Year;
			str[0] = year.ToString();
			str[1] = "/";
			year = this.monthCalendar1.SelectionStart.Month;
			str[2] = year.ToString();
			str[3] = "/";
			year = this.monthCalendar1.SelectionStart.Day;
			str[4] = year.ToString();
			string fecha = string.Concat(str);
			if (this.validacionCampos())
			{
				string query = string.Concat(new string[] { "INSERT INTO hvequipo (id, marca, nombre_equipo, especificaciones, area, fabricante, fecha) VALUES ('", id, "', '", marca, "', '", nombreEquipo, "', '", modelo, "', '", area, "', '", fabricante, "', '", fecha, "')" });
				MySqlConnection conexionDB = Conectar.Conecta();
				conexionDB.Open();
				try
				{
					(new MySqlCommand(query, conexionDB)).ExecuteNonQuery();
					MessageBox.Show("La hoja de vida del equipo se agrego correctamente");
					this.limpiarCampos();
				}
				catch (Exception exception)
				{
					Exception ex = exception;
					MessageBox.Show(string.Concat("Error al agregar la hoja de vida del equipo: ", ex.Message));
				}
				conexionDB.Close();
			}
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
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.buttonExit = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.textBox3 = new TextBox();
			this.textBox5 = new TextBox();
			this.monthCalendar1 = new MonthCalendar();
			this.buttonSave = new Button();
			this.label4 = new Label();
			this.textBox6 = new TextBox();
			this.radioButton1 = new RadioButton();
			this.radioButton2 = new RadioButton();
			this.radioButton3 = new RadioButton();
			this.radioButton4 = new RadioButton();
			base.SuspendLayout();
			this.label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(45, 171);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(133, 13);
			this.label10.TabIndex = 7;
			this.label10.Text = "Modelo y Especificaciones";
			this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(45, 98);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Marca";
			this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(45, 136);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Nombre Del Equipo";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(581, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 4;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
			this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(45, 252);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Area del Equipo";
			this.label1.Click += new EventHandler(this.label1_Click);
			this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(45, 286);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Fabricante";
			this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(45, 328);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Fecha de Adquisición";
			this.label3.Click += new EventHandler(this.label3_Click);
			this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox1.Location = new Point(247, 133);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 20);
			this.textBox1.TabIndex = 11;
			this.textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox2.Location = new Point(247, 95);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 12;
			this.textBox3.Location = new Point(247, 168);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(224, 57);
			this.textBox3.TabIndex = 13;
			this.textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox5.Location = new Point(247, 283);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 15;
			this.monthCalendar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.monthCalendar1.Location = new Point(247, 315);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 16;
			this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);
			this.buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.buttonSave.Location = new Point(538, 513);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 17;
			this.buttonSave.Text = "Guardar";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(45, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Identificador";
			this.label4.Click += new EventHandler(this.label4_Click);
			this.textBox6.Location = new Point(247, 54);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 19;
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new Point(247, 252);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(90, 17);
			this.radioButton1.TabIndex = 20;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Administrativo";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new Point(339, 252);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(67, 17);
			this.radioButton2.TabIndex = 21;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Industrial";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new Point(412, 252);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(67, 17);
			this.radioButton3.TabIndex = 22;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Finanzas";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new Point(486, 252);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(109, 17);
			this.radioButton4.TabIndex = 23;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Servicio al Cliente";
			this.radioButton4.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(668, 606);
			base.Controls.Add(this.radioButton4);
			base.Controls.Add(this.radioButton3);
			base.Controls.Add(this.radioButton2);
			base.Controls.Add(this.radioButton1);
			base.Controls.Add(this.textBox6);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.buttonSave);
			base.Controls.Add(this.monthCalendar1);
			base.Controls.Add(this.textBox5);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.buttonExit);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form2";
			this.Text = "Form2";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void limpiarCampos()
		{
			this.textBox1.Text = "";
			this.textBox2.Text = "";
			this.textBox3.Text = "";
			this.textBox5.Text = "";
			this.textBox6.Text = "";
		}

		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
		}

		private int radiobutton()
		{
			int num;
			if (this.radioButton1.Checked)
			{
				num = 1;
			}
			else if (this.radioButton2.Checked)
			{
				num = 2;
			}
			else if (!this.radioButton3.Checked)
			{
				num = (!this.radioButton4.Checked ? 0 : 4);
			}
			else
			{
				num = 3;
			}
			return num;
		}

		private bool validacionCampos()
		{
			bool flag;
			if ((this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox5.Text == "" || this.textBox6.Text == "" ? false : this.radiobutton() != 0))
			{
				flag = true;
			}
			else
			{
				MessageBox.Show("Debe llenar todos los campos para poder agregar la hoja de vida del equipo");
				flag = false;
			}
			return flag;
		}
	}
}
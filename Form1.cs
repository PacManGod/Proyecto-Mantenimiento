using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form1 : Form
	{
		private Form formularioActivo = null;

		private IContainer components = null;

		private Panel panelMenuLateral;

		private Panel panelPlanYOrdenSubmenu;

		private Button button4;

		private Button button5;

		private Button buttonPlanYOrden;

		private Panel panelDatosSubmenu;

		private Button button3;

		private Button button2;

		private Button buttonMedios;

		private Panel panelLogo;

		private Panel panelIndicadoresSubmenu;

		private Button button9;

		private Button button8;

		private Button button7;

		private Button buttonIndicadores;

		private Panel panelContenedor;

		public Form1()
		{
			this.InitializeComponent();
			this.PersonalizarDiseño();
			this.mensajeAlerta();
		}

		private void abrirFormularioHijo(Form formularioHijo)
		{
			if (this.formularioActivo != null)
			{
				this.formularioActivo.Close();
			}
			this.formularioActivo = formularioHijo;
			formularioHijo.TopLevel = false;
			formularioHijo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			formularioHijo.Dock = DockStyle.Fill;
			this.panelContenedor.Controls.Add(formularioHijo);
			this.panelContenedor.Tag = formularioHijo;
			formularioHijo.BringToFront();
			formularioHijo.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.MostrarSubmenu(this.panelPlanYOrdenSubmenu);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form2());
			this.OcultarSubmenu();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form3());
			this.OcultarSubmenu();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form5());
			this.OcultarSubmenu();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form4());
			this.OcultarSubmenu();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form6());
			this.OcultarSubmenu();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.abrirFormularioHijo(new Form7());
			this.OcultarSubmenu();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.OcultarSubmenu();
		}

		private void buttonIndicadores_Click(object sender, EventArgs e)
		{
			this.MostrarSubmenu(this.panelIndicadoresSubmenu);
		}

		private void buttonMedios_Click(object sender, EventArgs e)
		{
			this.MostrarSubmenu(this.panelDatosSubmenu);
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void InitializeComponent()
		{
			this.panelMenuLateral = new Panel();
			this.panelIndicadoresSubmenu = new Panel();
			this.button9 = new Button();
			this.button8 = new Button();
			this.button7 = new Button();
			this.buttonIndicadores = new Button();
			this.panelPlanYOrdenSubmenu = new Panel();
			this.button4 = new Button();
			this.button5 = new Button();
			this.buttonPlanYOrden = new Button();
			this.panelDatosSubmenu = new Panel();
			this.button3 = new Button();
			this.button2 = new Button();
			this.buttonMedios = new Button();
			this.panelLogo = new Panel();
			this.panelContenedor = new Panel();
			this.panelMenuLateral.SuspendLayout();
			this.panelIndicadoresSubmenu.SuspendLayout();
			this.panelPlanYOrdenSubmenu.SuspendLayout();
			this.panelDatosSubmenu.SuspendLayout();
			base.SuspendLayout();
			this.panelMenuLateral.AutoScroll = true;
			this.panelMenuLateral.BackColor = Color.FromArgb(11, 7, 17);
			this.panelMenuLateral.Controls.Add(this.panelIndicadoresSubmenu);
			this.panelMenuLateral.Controls.Add(this.buttonIndicadores);
			this.panelMenuLateral.Controls.Add(this.panelPlanYOrdenSubmenu);
			this.panelMenuLateral.Controls.Add(this.buttonPlanYOrden);
			this.panelMenuLateral.Controls.Add(this.panelDatosSubmenu);
			this.panelMenuLateral.Controls.Add(this.buttonMedios);
			this.panelMenuLateral.Controls.Add(this.panelLogo);
			this.panelMenuLateral.Dock = DockStyle.Left;
			this.panelMenuLateral.Location = new Point(0, 0);
			this.panelMenuLateral.Name = "panelMenuLateral";
			this.panelMenuLateral.Size = new System.Drawing.Size(250, 561);
			this.panelMenuLateral.TabIndex = 2;
			this.panelIndicadoresSubmenu.BackColor = Color.FromArgb(35, 32, 39);
			this.panelIndicadoresSubmenu.Controls.Add(this.button9);
			this.panelIndicadoresSubmenu.Controls.Add(this.button8);
			this.panelIndicadoresSubmenu.Controls.Add(this.button7);
			this.panelIndicadoresSubmenu.Dock = DockStyle.Top;
			this.panelIndicadoresSubmenu.Location = new Point(0, 423);
			this.panelIndicadoresSubmenu.Name = "panelIndicadoresSubmenu";
			this.panelIndicadoresSubmenu.Size = new System.Drawing.Size(233, 139);
			this.panelIndicadoresSubmenu.TabIndex = 6;
			this.button9.Dock = DockStyle.Top;
			this.button9.Enabled = false;
			this.button9.FlatAppearance.BorderSize = 0;
			this.button9.FlatStyle = FlatStyle.Flat;
			this.button9.ForeColor = SystemColors.ControlLight;
			this.button9.Location = new Point(0, 90);
			this.button9.Name = "button9";
			this.button9.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button9.Size = new System.Drawing.Size(233, 45);
			this.button9.TabIndex = 2;
			this.button9.Text = "Indicador de Tiempo Promedio";
			this.button9.TextAlign = ContentAlignment.MiddleLeft;
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Visible = false;
			this.button9.Click += new EventHandler(this.button9_Click);
			this.button8.Dock = DockStyle.Top;
			this.button8.FlatAppearance.BorderSize = 0;
			this.button8.FlatStyle = FlatStyle.Flat;
			this.button8.ForeColor = SystemColors.ControlLight;
			this.button8.Location = new Point(0, 45);
			this.button8.Name = "button8";
			this.button8.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button8.Size = new System.Drawing.Size(233, 45);
			this.button8.TabIndex = 1;
			this.button8.Text = "Eficiencia y calidad";
			this.button8.TextAlign = ContentAlignment.MiddleLeft;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new EventHandler(this.button8_Click);
			this.button7.Dock = DockStyle.Top;
			this.button7.FlatAppearance.BorderSize = 0;
			this.button7.FlatStyle = FlatStyle.Flat;
			this.button7.ForeColor = SystemColors.ControlLight;
			this.button7.Location = new Point(0, 0);
			this.button7.Name = "button7";
			this.button7.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button7.Size = new System.Drawing.Size(233, 45);
			this.button7.TabIndex = 0;
			this.button7.Text = "Calendario";
			this.button7.TextAlign = ContentAlignment.MiddleLeft;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new EventHandler(this.button7_Click);
			this.buttonIndicadores.Dock = DockStyle.Top;
			this.buttonIndicadores.FlatAppearance.BorderSize = 0;
			this.buttonIndicadores.FlatStyle = FlatStyle.Flat;
			this.buttonIndicadores.ForeColor = SystemColors.ControlLightLight;
			this.buttonIndicadores.Location = new Point(0, 378);
			this.buttonIndicadores.Name = "buttonIndicadores";
			this.buttonIndicadores.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.buttonIndicadores.Size = new System.Drawing.Size(233, 45);
			this.buttonIndicadores.TabIndex = 5;
			this.buttonIndicadores.Text = "Indicadores";
			this.buttonIndicadores.TextAlign = ContentAlignment.MiddleLeft;
			this.buttonIndicadores.UseVisualStyleBackColor = true;
			this.buttonIndicadores.Click += new EventHandler(this.buttonIndicadores_Click);
			this.panelPlanYOrdenSubmenu.BackColor = Color.FromArgb(35, 32, 39);
			this.panelPlanYOrdenSubmenu.Controls.Add(this.button4);
			this.panelPlanYOrdenSubmenu.Controls.Add(this.button5);
			this.panelPlanYOrdenSubmenu.Dock = DockStyle.Top;
			this.panelPlanYOrdenSubmenu.Location = new Point(0, 284);
			this.panelPlanYOrdenSubmenu.Name = "panelPlanYOrdenSubmenu";
			this.panelPlanYOrdenSubmenu.Size = new System.Drawing.Size(233, 94);
			this.panelPlanYOrdenSubmenu.TabIndex = 4;
			this.button4.Dock = DockStyle.Top;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = FlatStyle.Flat;
			this.button4.ForeColor = SystemColors.ControlLight;
			this.button4.Location = new Point(0, 45);
			this.button4.Name = "button4";
			this.button4.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button4.Size = new System.Drawing.Size(233, 45);
			this.button4.TabIndex = 1;
			this.button4.Text = "Orden de Trabajo";
			this.button4.TextAlign = ContentAlignment.MiddleLeft;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new EventHandler(this.button4_Click);
			this.button5.Dock = DockStyle.Top;
			this.button5.FlatAppearance.BorderSize = 0;
			this.button5.FlatStyle = FlatStyle.Flat;
			this.button5.ForeColor = SystemColors.ControlLight;
			this.button5.Location = new Point(0, 0);
			this.button5.Name = "button5";
			this.button5.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button5.Size = new System.Drawing.Size(233, 45);
			this.button5.TabIndex = 0;
			this.button5.Text = "Plan de Mantenimiento";
			this.button5.TextAlign = ContentAlignment.MiddleLeft;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new EventHandler(this.button5_Click);
			this.buttonPlanYOrden.Dock = DockStyle.Top;
			this.buttonPlanYOrden.FlatAppearance.BorderSize = 0;
			this.buttonPlanYOrden.FlatStyle = FlatStyle.Flat;
			this.buttonPlanYOrden.ForeColor = SystemColors.ControlLightLight;
			this.buttonPlanYOrden.Location = new Point(0, 239);
			this.buttonPlanYOrden.Name = "buttonPlanYOrden";
			this.buttonPlanYOrden.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.buttonPlanYOrden.Size = new System.Drawing.Size(233, 45);
			this.buttonPlanYOrden.TabIndex = 3;
			this.buttonPlanYOrden.Text = "Plan y Orden";
			this.buttonPlanYOrden.TextAlign = ContentAlignment.MiddleLeft;
			this.buttonPlanYOrden.UseVisualStyleBackColor = true;
			this.buttonPlanYOrden.Click += new EventHandler(this.button1_Click);
			this.panelDatosSubmenu.BackColor = Color.FromArgb(35, 32, 39);
			this.panelDatosSubmenu.Controls.Add(this.button3);
			this.panelDatosSubmenu.Controls.Add(this.button2);
			this.panelDatosSubmenu.Dock = DockStyle.Top;
			this.panelDatosSubmenu.Location = new Point(0, 145);
			this.panelDatosSubmenu.Name = "panelDatosSubmenu";
			this.panelDatosSubmenu.Size = new System.Drawing.Size(233, 94);
			this.panelDatosSubmenu.TabIndex = 2;
			this.button3.Dock = DockStyle.Top;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = FlatStyle.Flat;
			this.button3.ForeColor = SystemColors.ControlLight;
			this.button3.Location = new Point(0, 45);
			this.button3.Name = "button3";
			this.button3.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button3.Size = new System.Drawing.Size(233, 45);
			this.button3.TabIndex = 1;
			this.button3.Text = "Hoja de Producción";
			this.button3.TextAlign = ContentAlignment.MiddleLeft;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new EventHandler(this.button3_Click);
			this.button2.Dock = DockStyle.Top;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = FlatStyle.Flat;
			this.button2.ForeColor = SystemColors.ControlLight;
			this.button2.Location = new Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
			this.button2.Size = new System.Drawing.Size(233, 45);
			this.button2.TabIndex = 0;
			this.button2.Text = "Hoja de Vida del Equipo";
			this.button2.TextAlign = ContentAlignment.MiddleLeft;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.buttonMedios.Dock = DockStyle.Top;
			this.buttonMedios.FlatAppearance.BorderSize = 0;
			this.buttonMedios.FlatStyle = FlatStyle.Flat;
			this.buttonMedios.ForeColor = SystemColors.ControlLightLight;
			this.buttonMedios.Location = new Point(0, 100);
			this.buttonMedios.Name = "buttonMedios";
			this.buttonMedios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.buttonMedios.Size = new System.Drawing.Size(233, 45);
			this.buttonMedios.TabIndex = 1;
			this.buttonMedios.Text = "Datos";
			this.buttonMedios.TextAlign = ContentAlignment.MiddleLeft;
			this.buttonMedios.UseVisualStyleBackColor = true;
			this.buttonMedios.Click += new EventHandler(this.buttonMedios_Click);
			this.panelLogo.Dock = DockStyle.Top;
			this.panelLogo.Location = new Point(0, 0);
			this.panelLogo.Name = "panelLogo";
			this.panelLogo.Size = new System.Drawing.Size(233, 100);
			this.panelLogo.TabIndex = 0;
			this.panelContenedor.BackColor = Color.FromArgb(32, 30, 45);
			this.panelContenedor.Dock = DockStyle.Fill;
			this.panelContenedor.Location = new Point(250, 0);
			this.panelContenedor.Name = "panelContenedor";
			this.panelContenedor.Size = new System.Drawing.Size(684, 561);
			this.panelContenedor.TabIndex = 3;
			this.panelContenedor.Paint += new PaintEventHandler(this.panelContenedor_Paint);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(934, 561);
			base.Controls.Add(this.panelContenedor);
			base.Controls.Add(this.panelMenuLateral);
			this.MinimumSize = new System.Drawing.Size(950, 600);
			base.Name = "Form1";
			this.Text = "Form1";
			base.Load += new EventHandler(this.Form1_Load);
			this.panelMenuLateral.ResumeLayout(false);
			this.panelIndicadoresSubmenu.ResumeLayout(false);
			this.panelPlanYOrdenSubmenu.ResumeLayout(false);
			this.panelDatosSubmenu.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void mensajeAlerta()
		{
			string hoy = DateTime.Now.ToString("dd/MM/yyyy");
			string cmd = string.Concat("SELECT * FROM calendario WHERE fecha =  '", hoy, "' ");
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			MySqlDataReader reader = (new MySqlCommand(cmd, conexionDB)).ExecuteReader();
			if (reader.Read())
			{
				string nombre = reader.GetString(1);
				string fecha = reader.GetString(2);
				string herramientas = reader.GetString(3);
				string descripcion = reader.GetString(4);
				MessageBox.Show(string.Concat(new string[] { "Hoy es: ", fecha, "\nNombre: ", nombre, "\nHerramientas: ", herramientas, "\nDescripcion: ", descripcion }), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			conexionDB.Close();
		}

		private void MostrarSubmenu(Panel submenu)
		{
			if (submenu.Visible)
			{
				submenu.Visible = false;
			}
			else
			{
				this.OcultarSubmenu();
				submenu.Visible = true;
			}
		}

		private void OcultarSubmenu()
		{
			if (this.panelDatosSubmenu.Visible)
			{
				this.panelDatosSubmenu.Visible = false;
			}
			if (this.panelPlanYOrdenSubmenu.Visible)
			{
				this.panelPlanYOrdenSubmenu.Visible = false;
			}
			if (this.panelIndicadoresSubmenu.Visible)
			{
				this.panelIndicadoresSubmenu.Visible = false;
			}
		}

		private void panelContenedor_Paint(object sender, PaintEventArgs e)
		{
		}

		private void PersonalizarDiseño()
		{
			this.panelDatosSubmenu.Visible = false;
			this.panelPlanYOrdenSubmenu.Visible = false;
			this.panelIndicadoresSubmenu.Visible = false;
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}
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

		private Panel panelIndicadoresSubmenu;

		private Button button9;

		private Button button8;

		private Button button7;

		private Button buttonIndicadores;
        private PictureBox pictureBox1;
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
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelIndicadoresSubmenu = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonIndicadores = new System.Windows.Forms.Button();
            this.panelPlanYOrdenSubmenu = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonPlanYOrden = new System.Windows.Forms.Button();
            this.panelDatosSubmenu = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonMedios = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelIndicadoresSubmenu.SuspendLayout();
            this.panelPlanYOrdenSubmenu.SuspendLayout();
            this.panelDatosSubmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.AutoScroll = true;
            this.panelMenuLateral.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMenuLateral.Controls.Add(this.pictureBox1);
            this.panelMenuLateral.Controls.Add(this.panelIndicadoresSubmenu);
            this.panelMenuLateral.Controls.Add(this.buttonIndicadores);
            this.panelMenuLateral.Controls.Add(this.panelPlanYOrdenSubmenu);
            this.panelMenuLateral.Controls.Add(this.buttonPlanYOrden);
            this.panelMenuLateral.Controls.Add(this.panelDatosSubmenu);
            this.panelMenuLateral.Controls.Add(this.buttonMedios);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(934, 122);
            this.panelMenuLateral.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_09.Properties.Resources.Imagen;
            this.pictureBox1.InitialImage = global::Proyecto_09.Properties.Resources.Imagen;
            this.pictureBox1.Location = new System.Drawing.Point(66, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelIndicadoresSubmenu
            // 
            this.panelIndicadoresSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelIndicadoresSubmenu.Controls.Add(this.button9);
            this.panelIndicadoresSubmenu.Controls.Add(this.button8);
            this.panelIndicadoresSubmenu.Controls.Add(this.button7);
            this.panelIndicadoresSubmenu.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelIndicadoresSubmenu.Location = new System.Drawing.Point(687, 56);
            this.panelIndicadoresSubmenu.Name = "panelIndicadoresSubmenu";
            this.panelIndicadoresSubmenu.Size = new System.Drawing.Size(233, 56);
            this.panelIndicadoresSubmenu.TabIndex = 6;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Enabled = false;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button9.Location = new System.Drawing.Point(0, 56);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(233, 26);
            this.button9.TabIndex = 2;
            this.button9.Text = "Indicador de Tiempo Promedio";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button8.Location = new System.Drawing.Point(0, 28);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(233, 28);
            this.button8.TabIndex = 1;
            this.button8.Text = "Eficiencia y calidad";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(233, 28);
            this.button7.TabIndex = 0;
            this.button7.Text = "Calendario";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonIndicadores
            // 
            this.buttonIndicadores.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonIndicadores.FlatAppearance.BorderSize = 0;
            this.buttonIndicadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIndicadores.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIndicadores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonIndicadores.Location = new System.Drawing.Point(687, 11);
            this.buttonIndicadores.Name = "buttonIndicadores";
            this.buttonIndicadores.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonIndicadores.Size = new System.Drawing.Size(233, 45);
            this.buttonIndicadores.TabIndex = 5;
            this.buttonIndicadores.Text = "Indicadores";
            this.buttonIndicadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIndicadores.UseVisualStyleBackColor = false;
            this.buttonIndicadores.Click += new System.EventHandler(this.buttonIndicadores_Click);
            // 
            // panelPlanYOrdenSubmenu
            // 
            this.panelPlanYOrdenSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelPlanYOrdenSubmenu.Controls.Add(this.button4);
            this.panelPlanYOrdenSubmenu.Controls.Add(this.button5);
            this.panelPlanYOrdenSubmenu.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPlanYOrdenSubmenu.Location = new System.Drawing.Point(493, 56);
            this.panelPlanYOrdenSubmenu.Name = "panelPlanYOrdenSubmenu";
            this.panelPlanYOrdenSubmenu.Size = new System.Drawing.Size(188, 56);
            this.panelPlanYOrdenSubmenu.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Location = new System.Drawing.Point(0, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 28);
            this.button4.TabIndex = 1;
            this.button4.Text = "Orden de Trabajo";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 28);
            this.button5.TabIndex = 0;
            this.button5.Text = "Plan de Mantenimiento";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonPlanYOrden
            // 
            this.buttonPlanYOrden.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonPlanYOrden.FlatAppearance.BorderSize = 0;
            this.buttonPlanYOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlanYOrden.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlanYOrden.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonPlanYOrden.Location = new System.Drawing.Point(493, 11);
            this.buttonPlanYOrden.Name = "buttonPlanYOrden";
            this.buttonPlanYOrden.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonPlanYOrden.Size = new System.Drawing.Size(188, 45);
            this.buttonPlanYOrden.TabIndex = 3;
            this.buttonPlanYOrden.Text = "Plan y Orden";
            this.buttonPlanYOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlanYOrden.UseVisualStyleBackColor = false;
            this.buttonPlanYOrden.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelDatosSubmenu
            // 
            this.panelDatosSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelDatosSubmenu.Controls.Add(this.button3);
            this.panelDatosSubmenu.Controls.Add(this.button2);
            this.panelDatosSubmenu.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDatosSubmenu.Location = new System.Drawing.Point(254, 56);
            this.panelDatosSubmenu.Name = "panelDatosSubmenu";
            this.panelDatosSubmenu.Size = new System.Drawing.Size(233, 56);
            this.panelDatosSubmenu.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Location = new System.Drawing.Point(0, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(233, 28);
            this.button3.TabIndex = 1;
            this.button3.Text = "Hoja de Producción";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "Hoja de Vida del Equipo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonMedios
            // 
            this.buttonMedios.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonMedios.FlatAppearance.BorderSize = 0;
            this.buttonMedios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMedios.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMedios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMedios.Location = new System.Drawing.Point(254, 11);
            this.buttonMedios.Name = "buttonMedios";
            this.buttonMedios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonMedios.Size = new System.Drawing.Size(233, 45);
            this.buttonMedios.TabIndex = 1;
            this.buttonMedios.Text = "Datos";
            this.buttonMedios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMedios.UseVisualStyleBackColor = false;
            this.buttonMedios.Click += new System.EventHandler(this.buttonMedios_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.Silver;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 122);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(934, 639);
            this.panelContenedor.TabIndex = 3;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 761);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenuLateral);
            this.MinimumSize = new System.Drawing.Size(950, 750);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelIndicadoresSubmenu.ResumeLayout(false);
            this.panelPlanYOrdenSubmenu.ResumeLayout(false);
            this.panelDatosSubmenu.ResumeLayout(false);
            this.ResumeLayout(false);

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
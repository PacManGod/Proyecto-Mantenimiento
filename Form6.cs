using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form6 : Form
	{
		private IContainer components = null;

		private DataGridView dataGridView1;

		private Label label1;

		private Button buttonExit;

		private CheckBox checkBoxFechasCercanas;

		private CheckBox checkBoxFechasMedias;

		private CheckBox checkBoxFechasLejanas;

		private CheckBox checkBoxFechasExpiradas;

		private CheckBox checkBoxTodo;

		public Form6()
		{
			this.InitializeComponent();
			this.llenarTabla();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void checkBoxFechasCercanas_CheckedChanged(object sender, EventArgs e)
		{
			this.filtoPorColor();
		}

		private void checkBoxFechasExpiradas_CheckedChanged(object sender, EventArgs e)
		{
			this.filtoPorColor();
		}

		private void checkBoxFechasLejanas_CheckedChanged(object sender, EventArgs e)
		{
			this.filtoPorColor();
		}

		private void checkBoxFechasMedias_CheckedChanged(object sender, EventArgs e)
		{
			this.filtoPorColor();
		}

		private void checkBoxTodo_CheckedChanged(object sender, EventArgs e)
		{
			this.filtoPorColor();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (this.dataGridView1.Columns[e.ColumnIndex].Name == "fecha")
			{
				if (e.Value != null)
				{
					if (e.Value.GetType() != typeof(DBNull))
					{
						DateTime fecha = Convert.ToDateTime(e.Value);
						DateTime hoy = DateTime.Today;
						if (fecha == hoy)
						{
							e.CellStyle.BackColor = Color.OrangeRed;
						}
						if (fecha == hoy.AddDays(1))
						{
							e.CellStyle.BackColor = Color.LightYellow;
						}
						DateTime fecha3 = hoy.AddDays(3);
						DateTime fecha5 = hoy.AddDays(5);
						if ((fecha < fecha3 ? false : fecha <= fecha5))
						{
							e.CellStyle.BackColor = Color.Orange;
						}
						if (fecha >= hoy.AddDays(6))
						{
							e.CellStyle.BackColor = Color.LightGreen;
						}
					}
				}
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

		private void filtoPorColor()
		{
			string[] str = new string[] { "fecha = '", null, null, null, null };
			DateTime now = DateTime.Now;
			str[1] = now.ToString("dd/MM/yyyy");
			str[2] = "' OR fecha = '";
			now = DateTime.Now.AddDays(1);
			str[3] = now.ToString("dd/MM/yyyy");
			str[4] = "'";
			string fechasCercanas = string.Concat(str);
			string[] strArrays = new string[] { "fecha >= '", null, null, null, null };
			now = DateTime.Now.AddDays(3);
			strArrays[1] = now.ToString("dd/MM/yyyy");
			strArrays[2] = "' AND fecha <= '";
			now = DateTime.Now.AddDays(5);
			strArrays[3] = now.ToString("dd/MM/yyyy");
			strArrays[4] = "'";
			string fechasMedias = string.Concat(strArrays);
			now = DateTime.Now.AddDays(6);
			string fechasLejanas = string.Concat("fecha >= '", now.ToString("dd/MM/yyyy"), "'");
			now = DateTime.Now;
			string fechasExpiradas = string.Concat("fecha < '", now.ToString("dd/MM/yyyy"), "'");
			MySqlConnection conexionDB = Conectar.Conecta();
			conexionDB.Open();
			MySqlCommand cmd = conexionDB.CreateCommand();
			if ((!this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat(new string[] { "SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasMedias, " OR ", fechasLejanas, " OR ", fechasExpiradas });
			}
			else if ((!this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat(new string[] { "SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasMedias, " OR ", fechasLejanas });
			}
			else if ((!this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat(new string[] { "SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasMedias, " OR ", fechasExpiradas });
			}
			else if ((!this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat(new string[] { "SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasLejanas, " OR ", fechasExpiradas });
			}
			else if ((this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat(new string[] { "SELECT * FROM calendario WHERE ", fechasMedias, " OR ", fechasLejanas, " OR ", fechasExpiradas });
			}
			else if ((!this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasMedias);
			}
			else if ((!this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasLejanas);
			}
			else if ((!this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasCercanas, " OR ", fechasExpiradas);
			}
			else if ((this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasMedias, " OR ", fechasLejanas);
			}
			else if ((this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasMedias, " OR ", fechasExpiradas);
			}
			else if ((this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasLejanas, " OR ", fechasExpiradas);
			}
			else if ((!this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasCercanas);
			}
			else if ((this.checkBoxFechasCercanas.Checked || !this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasMedias);
			}
			else if ((this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || !this.checkBoxFechasLejanas.Checked ? false : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasLejanas);
			}
			else if ((this.checkBoxFechasCercanas.Checked || this.checkBoxFechasMedias.Checked || this.checkBoxFechasLejanas.Checked ? true : !this.checkBoxFechasExpiradas.Checked))
			{
				cmd.CommandText = "SELECT * FROM calendario";
			}
			else
			{
				cmd.CommandText = string.Concat("SELECT * FROM calendario WHERE ", fechasExpiradas);
			}
			cmd.ExecuteNonQuery();
			DataTable dt = new DataTable();
			(new MySqlDataAdapter(cmd)).Fill(dt);
			this.dataGridView1.DataSource = dt;
			conexionDB.Close();
		}

		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			this.dataGridView1 = new DataGridView();
			this.label1 = new Label();
			this.buttonExit = new Button();
			this.checkBoxFechasCercanas = new CheckBox();
			this.checkBoxFechasMedias = new CheckBox();
			this.checkBoxFechasLejanas = new CheckBox();
			this.checkBoxFechasExpiradas = new CheckBox();
			this.checkBoxTodo = new CheckBox();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
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
			this.dataGridView1.ColumnHeadersHeight = 30;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new Point(12, 113);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(644, 273);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(9, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Calendario";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(581, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 21;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
			this.checkBoxFechasCercanas.AutoSize = true;
			this.checkBoxFechasCercanas.Location = new Point(13, 409);
			this.checkBoxFechasCercanas.Name = "checkBoxFechasCercanas";
			this.checkBoxFechasCercanas.Size = new System.Drawing.Size(108, 17);
			this.checkBoxFechasCercanas.TabIndex = 22;
			this.checkBoxFechasCercanas.Text = "Fechas cercanas";
			this.checkBoxFechasCercanas.UseVisualStyleBackColor = true;
			this.checkBoxFechasCercanas.CheckedChanged += new EventHandler(this.checkBoxFechasCercanas_CheckedChanged);
			this.checkBoxFechasMedias.AutoSize = true;
			this.checkBoxFechasMedias.Location = new Point(127, 409);
			this.checkBoxFechasMedias.Name = "checkBoxFechasMedias";
			this.checkBoxFechasMedias.Size = new System.Drawing.Size(97, 17);
			this.checkBoxFechasMedias.TabIndex = 23;
			this.checkBoxFechasMedias.Text = "Fechas medias";
			this.checkBoxFechasMedias.UseVisualStyleBackColor = true;
			this.checkBoxFechasMedias.CheckedChanged += new EventHandler(this.checkBoxFechasMedias_CheckedChanged);
			this.checkBoxFechasLejanas.AutoSize = true;
			this.checkBoxFechasLejanas.Location = new Point(230, 409);
			this.checkBoxFechasLejanas.Name = "checkBoxFechasLejanas";
			this.checkBoxFechasLejanas.Size = new System.Drawing.Size(97, 17);
			this.checkBoxFechasLejanas.TabIndex = 24;
			this.checkBoxFechasLejanas.Text = "Fechas lejanas";
			this.checkBoxFechasLejanas.UseVisualStyleBackColor = true;
			this.checkBoxFechasLejanas.CheckedChanged += new EventHandler(this.checkBoxFechasLejanas_CheckedChanged);
			this.checkBoxFechasExpiradas.AutoSize = true;
			this.checkBoxFechasExpiradas.Location = new Point(333, 409);
			this.checkBoxFechasExpiradas.Name = "checkBoxFechasExpiradas";
			this.checkBoxFechasExpiradas.Size = new System.Drawing.Size(109, 17);
			this.checkBoxFechasExpiradas.TabIndex = 25;
			this.checkBoxFechasExpiradas.Text = "Fechas expiradas";
			this.checkBoxFechasExpiradas.UseVisualStyleBackColor = true;
			this.checkBoxFechasExpiradas.CheckedChanged += new EventHandler(this.checkBoxFechasExpiradas_CheckedChanged);
			this.checkBoxTodo.AutoSize = true;
			this.checkBoxTodo.Enabled = false;
			this.checkBoxTodo.Location = new Point(449, 409);
			this.checkBoxTodo.Name = "checkBoxTodo";
			this.checkBoxTodo.Size = new System.Drawing.Size(51, 17);
			this.checkBoxTodo.TabIndex = 26;
			this.checkBoxTodo.Text = "Todo";
			this.checkBoxTodo.UseVisualStyleBackColor = true;
			this.checkBoxTodo.Visible = false;
			this.checkBoxTodo.CheckedChanged += new EventHandler(this.checkBoxTodo_CheckedChanged);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(668, 522);
			base.Controls.Add(this.checkBoxTodo);
			base.Controls.Add(this.checkBoxFechasExpiradas);
			base.Controls.Add(this.checkBoxFechasLejanas);
			base.Controls.Add(this.checkBoxFechasMedias);
			base.Controls.Add(this.checkBoxFechasCercanas);
			base.Controls.Add(this.buttonExit);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.dataGridView1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form6";
			this.Text = "Form6";
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void llenarTabla()
		{
			string query = "SELECT * FROM calendario";
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
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
	public class Form4 : Form
	{
		private IContainer components = null;

		private DataGridView dataGridView1;

		private Button buttonExit;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private Button button1;

		private Label labelTexto1;

		private Label labelTexto2;

		private Label labelTexto3;

		private Label labelTexto4;

		private Label labelTexto5;

		private Label labelTexto6;

		private Label labelTexto7;

		private Label labelTexto8;

		private Label labelTexto9;

		private Label labelTexto10;

		private Label labelTexto11;

		private Label labelTexto12;

		private Label labelTexto13;

		private Label labelTexto14;

		public Form4()
		{
			this.InitializeComponent();
			this.llenarTabla();
		}

		private bool alertaHoras(string num_horas_para_mantenimiento, int tiempoHorasPasadas)
		{
			bool flag;
			bool alerta = false;
			if (tiempoHorasPasadas < int.Parse(num_horas_para_mantenimiento) * 90 / 100)
			{
				flag = alerta;
			}
			else
			{
				alerta = true;
				flag = alerta;
			}
			return flag;
		}

		private bool alertaUnidades(string num_meta, int numeroUnidades)
		{
			bool flag;
			flag = (numeroUnidades < int.Parse(num_meta) * 90 / 100 ? false : true);
			return flag;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int num;
			string id = this.textBox1.Text;
			string query = string.Concat("SELECT * FROM hojaprod WHERE id = '", id, "'");
			MySqlConnection conexion = Conectar.Conecta();
			conexion.Open();
			try
			{
				MySqlDataReader reader = (new MySqlCommand(query, conexion)).ExecuteReader();
				if (!reader.Read())
				{
					MessageBox.Show("No se encontro el registro");
				}
				else
				{
					string num_meta = reader["numero_meta"].ToString();
					string num_actual = reader["numero_actual"].ToString();
					string num_completo_satisfractorio = reader["numero_completo_satisfractorio"].ToString();
					string num_completo_no_satisfactorio = reader["numero_completo_no_satisfactorio"].ToString();
					string num_horas_activo_por_dia = reader["numero_horas_activo_por_dia"].ToString();
					string num_horas_para_mantenimiento = reader["numero_horas_para_mantenimiento"].ToString();
					string fecha_de_inicio_hora = reader["fecha_de_inicio_horas"].ToString();
					string tiempo_duracion_even = reader["tiempo_duracion_evento"].ToString();
					string dia_del_even = reader["dia_del_evento"].ToString();
					string descripcion_del_even = reader["descripcion_del_evento"].ToString();
					tiempo_duracion_even = ((string.IsNullOrEmpty(tiempo_duracion_even) ? false : tiempo_duracion_even != "") ? reader["tiempo_duracion_evento"].ToString() : "0");
					DateTime DateObject = Convert.ToDateTime(fecha_de_inicio_hora, new CultureInfo("en-US"));
					TimeSpan TimeObject = DateTime.Now - DateObject;
					int tiempoHorasPasadas = this.calculoHorasPasadas(num_horas_activo_por_dia, TimeObject.Days, num_horas_para_mantenimiento);
					int numeroUnidades = this.unidades(num_completo_satisfractorio, num_completo_no_satisfactorio);
					DateTime fecha = this.calculoDiasEstimados(num_horas_activo_por_dia, num_horas_para_mantenimiento, fecha_de_inicio_hora);
					bool alerta1 = this.alertaHoras(num_horas_para_mantenimiento, tiempoHorasPasadas);
					bool alerta2 = this.alertaUnidades(num_meta, numeroUnidades);
					if ((!alerta1 ? false : alerta2))
					{
						this.consulta3(id, 3, "Alerta de Horas y Unidades");
					}
					else if ((!alerta1 ? false : !alerta2))
					{
						this.consulta3(id, 1, "Alerta de Horas");
					}
					else if ((!alerta2 ? true : alerta1))
					{
						this.consulta3(id, 0, "Sin Alerta");
					}
					else
					{
						this.consulta3(id, 2, "Alerta de Unidades");
					}
					int consul = this.consulta2(id);
					if (consul == 1)
					{
						string texto1 = string.Concat("ID: ", id);
						string texto2 = string.Concat("Casos a Atender: ", num_meta);
						string texto3 = string.Concat("Casos Atendidos: ", num_actual);
						string texto4 = string.Concat("Numero de Casos Conformes: ", num_completo_satisfractorio);
						string texto5 = string.Concat("Numero de Casos No Conformes: ", num_completo_no_satisfactorio);
						string texto6 = string.Concat("Numero de horas activo por dia: ", num_horas_activo_por_dia);
						string texto7 = string.Concat("Numero de horas para mantenimiento: ", num_horas_para_mantenimiento);
						string texto8 = string.Concat("Fecha de inicio horas: ", fecha_de_inicio_hora);
						string texto9 = string.Concat("Tiempo de duracion del evento: ", tiempo_duracion_even);
						string texto10 = string.Concat("Dia del evento: ", dia_del_even);
						string texto11 = string.Concat("Descripcion del evento: ", this.verificarTexto(descripcion_del_even));
						string[] str = new string[] { "Horas pasadas hasta el dia de hoy: ", tiempoHorasPasadas.ToString(), " horas se recomienda realizar mantenimiento al llegar a ", null, null };
						num = Convert.ToInt32(num_horas_para_mantenimiento) * 90 / 100;
						str[3] = num.ToString();
						str[4] = " horas";
						string texto12 = string.Concat(str);
						string[] strArrays = new string[] { "Numero de unidades: ", numeroUnidades.ToString(), " se le notificara al usuario cuando llegue a ", null, null };
						num = Convert.ToInt32(num_meta) * 90 / 100;
						strArrays[3] = num.ToString();
						strArrays[4] = " unidades";
						string texto13 = string.Concat(strArrays);
						string texto14 = string.Concat("Fecha estimada de finalizacion: ", fecha.ToString());
						this.labelTexto1.Text = texto1;
						this.labelTexto2.Text = texto2;
						this.labelTexto3.Text = texto3;
						this.labelTexto4.Text = texto4;
						this.labelTexto5.Text = texto5;
						this.labelTexto6.Text = texto6;
						this.labelTexto7.Text = texto7;
						this.labelTexto8.Text = texto8;
						this.labelTexto9.Text = texto9;
						this.labelTexto10.Text = texto10;
						this.labelTexto11.Text = texto11;
						this.labelTexto12.Text = texto12;
						this.labelTexto13.Text = texto13;
						this.labelTexto14.Text = texto14;
					}
					else if (consul == 2)
					{
						string texto1 = string.Concat("ID: ", id);
						string texto2 = string.Concat("Numero de meta: ", num_meta);
						string texto3 = string.Concat("Numero actual: ", num_actual);
						string texto4 = string.Concat("Numero de unidades conformes: ", num_completo_satisfractorio);
						string texto5 = string.Concat("Numero de unidades rechazadas: ", num_completo_no_satisfactorio);
						string texto6 = string.Concat("Numero de horas activo por dia: ", num_horas_activo_por_dia);
						string texto7 = string.Concat("Numero de horas para mantenimiento: ", num_horas_para_mantenimiento);
						string texto8 = string.Concat("Fecha de inicio horas: ", fecha_de_inicio_hora);
						string texto9 = string.Concat("Tiempo de duracion del evento: ", tiempo_duracion_even);
						string texto10 = string.Concat("Dia del evento: ", dia_del_even);
						string texto11 = string.Concat("Descripcion del evento: ", this.verificarTexto(descripcion_del_even));
						string[] str1 = new string[] { "Horas pasadas hasta el dia de hoy: ", tiempoHorasPasadas.ToString(), " horas se recomienda realizar mantenimiento al llegar a ", null, null };
						num = Convert.ToInt32(num_horas_para_mantenimiento) * 90 / 100;
						str1[3] = num.ToString();
						str1[4] = " horas";
						string texto12 = string.Concat(str1);
						string[] strArrays1 = new string[] { "Numero de unidades: ", numeroUnidades.ToString(), " se le notificara al usuario cuando llegue a ", null, null };
						num = Convert.ToInt32(num_meta) * 90 / 100;
						strArrays1[3] = num.ToString();
						strArrays1[4] = " unidades";
						string texto13 = string.Concat(strArrays1);
						string texto14 = string.Concat("Fecha estimada de finalizacion: ", fecha.ToString());
						this.labelTexto1.Text = texto1;
						this.labelTexto2.Text = texto2;
						this.labelTexto3.Text = texto3;
						this.labelTexto4.Text = texto4;
						this.labelTexto5.Text = texto5;
						this.labelTexto6.Text = texto6;
						this.labelTexto7.Text = texto7;
						this.labelTexto8.Text = texto8;
						this.labelTexto9.Text = texto9;
						this.labelTexto10.Text = texto10;
						this.labelTexto11.Text = texto11;
						this.labelTexto12.Text = texto12;
						this.labelTexto13.Text = texto13;
						this.labelTexto14.Text = texto14;
					}
					else if (consul == 3)
					{
						string texto1 = string.Concat("ID: ", id);
						string texto2 = string.Concat("Ingresos Estimados: ", num_meta);
						string texto3 = string.Concat("Ingresos Reales: ", num_actual);
						string texto4 = string.Concat("Ingresos Conformes", num_completo_satisfractorio);
						string texto5 = string.Concat("Ingresos No Conformes: ", num_completo_no_satisfactorio);
						string texto6 = string.Concat("Numero de horas activo por dia: ", num_horas_activo_por_dia);
						string texto7 = string.Concat("Numero de horas para mantenimiento: ", num_horas_para_mantenimiento);
						string texto8 = string.Concat("Fecha de inicio horas: ", fecha_de_inicio_hora);
						string texto9 = string.Concat("Tiempo de duracion del evento: ", tiempo_duracion_even);
						string texto10 = string.Concat("Dia del evento: ", dia_del_even);
						string texto11 = string.Concat("Descripcion del evento: ", this.verificarTexto(descripcion_del_even));
						string[] str2 = new string[] { "Horas pasadas hasta el dia de hoy: ", tiempoHorasPasadas.ToString(), " horas se recomienda realizar mantenimiento al llegar a ", null, null };
						num = Convert.ToInt32(num_horas_para_mantenimiento) * 90 / 100;
						str2[3] = num.ToString();
						str2[4] = " horas";
						string texto12 = string.Concat(str2);
						string[] strArrays2 = new string[] { "Numero de unidades: ", numeroUnidades.ToString(), " se le notificara al usuario cuando llegue a ", null, null };
						num = Convert.ToInt32(num_meta) * 90 / 100;
						strArrays2[3] = num.ToString();
						strArrays2[4] = " unidades";
						string texto13 = string.Concat(strArrays2);
						string texto14 = string.Concat("Fecha estimada de finalizacion: ", fecha.ToString());
						this.labelTexto1.Text = texto1;
						this.labelTexto2.Text = texto2;
						this.labelTexto3.Text = texto3;
						this.labelTexto4.Text = texto4;
						this.labelTexto5.Text = texto5;
						this.labelTexto6.Text = texto6;
						this.labelTexto7.Text = texto7;
						this.labelTexto8.Text = texto8;
						this.labelTexto9.Text = texto9;
						this.labelTexto10.Text = texto10;
						this.labelTexto11.Text = texto11;
						this.labelTexto12.Text = texto12;
						this.labelTexto13.Text = texto13;
						this.labelTexto14.Text = texto14;
					}
					else if (consul == 4)
					{
						string texto1 = string.Concat("ID: ", id);
						string texto2 = string.Concat("Llamadas a Atender: ", this.verificarTexto(num_meta));
						string texto3 = string.Concat("Llamadas Atendidas: ", this.verificarTexto(num_actual));
						string texto4 = string.Concat("Llamadas Conformes: ", this.verificarTexto(num_completo_satisfractorio));
						string texto5 = string.Concat("Llamadas No Conformes: ", this.verificarTexto(num_completo_no_satisfactorio));
						string texto6 = string.Concat("Numero de horas activo por dia: ", this.verificarTexto(num_horas_activo_por_dia));
						string texto7 = string.Concat("Numero de horas para mantenimiento: ", this.verificarTexto(num_horas_para_mantenimiento));
						string texto8 = string.Concat("Fecha de inicio horas: ", this.verificarTexto(fecha_de_inicio_hora));
						string texto9 = string.Concat("Tiempo de duracion del evento: ", this.verificarTexto(tiempo_duracion_even));
						string texto10 = string.Concat("Dia del evento: ", this.verificarTexto(dia_del_even));
						string texto11 = string.Concat("Descripcion del evento: ", this.verificarTexto(descripcion_del_even));
						string[] str3 = new string[] { "Horas pasadas hasta el dia de hoy: ", tiempoHorasPasadas.ToString(), " horas se recomienda realizar mantenimiento al llegar a ", null, null };
						num = Convert.ToInt32(num_horas_para_mantenimiento) * 90 / 100;
						str3[3] = num.ToString();
						str3[4] = " horas";
						string texto12 = string.Concat(str3);
						string[] strArrays3 = new string[] { "Numero de unidades: ", numeroUnidades.ToString(), " se le notificara al usuario cuando llegue a ", null, null };
						num = Convert.ToInt32(num_meta) * 90 / 100;
						strArrays3[3] = num.ToString();
						strArrays3[4] = " unidades";
						string texto13 = string.Concat(strArrays3);
						string texto14 = string.Concat("Fecha estimada de finalizacion: ", fecha.ToString());
						this.labelTexto1.Text = texto1;
						this.labelTexto2.Text = texto2;
						this.labelTexto3.Text = texto3;
						this.labelTexto4.Text = texto4;
						this.labelTexto5.Text = texto5;
						this.labelTexto6.Text = texto6;
						this.labelTexto7.Text = texto7;
						this.labelTexto8.Text = texto8;
						this.labelTexto9.Text = texto9;
						this.labelTexto10.Text = texto10;
						this.labelTexto11.Text = texto11;
						this.labelTexto12.Text = texto12;
						this.labelTexto13.Text = texto13;
						this.labelTexto14.Text = texto14;
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
			conexion.Close();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private DateTime calculoDiasEstimados(string horaPorDia, string horaTope, string fechaInicio)
		{
			int horaPorDiaInt = int.Parse(horaPorDia);
			int horaTopeInt = int.Parse(horaTope);
			DateTime DateObject = Convert.ToDateTime(fechaInicio);
			int resultado = 0;
			int dias = 0;
			while (horaPorDiaInt <= horaTopeInt)
			{
				horaPorDiaInt += horaPorDiaInt;
				resultado += horaPorDiaInt;
				dias++;
			}
			return DateObject.AddDays((double)dias);
		}

		private int calculoHorasPasadas(string horaPorDia, int fechaInicio, string horasEvento)
		{
			int num;
			int horaPorDiaInt = int.Parse(horaPorDia);
			int horasEventoInt = int.Parse(horasEvento);
			int resultado = 0;
			int dias = fechaInicio;
			for (int i = 0; i <= dias; i++)
			{
				resultado += horaPorDiaInt;
			}
			if (horasEventoInt != 0)
			{
				num = resultado;
			}
			else
			{
				resultado -= horasEventoInt;
				num = resultado;
			}
			return num;
		}

		private int consulta2(string id)
		{
			int num;
			string identificador = this.textBox1.Text;
			string query = string.Concat("SELECT * FROM hvequipo WHERE id = '", id, "'");
			MySqlConnection conexion = Conectar.Conecta();
			conexion.Open();
			try
			{
				try
				{
					MySqlDataReader reader = (new MySqlCommand(query, conexion)).ExecuteReader();
					if (!reader.Read())
					{
						num = 0;
						return num;
					}
					else if (reader["area"].ToString() == "1")
					{
						num = 1;
						return num;
					}
					else if (reader["area"].ToString() == "2")
					{
						num = 2;
						return num;
					}
					else if (reader["area"].ToString() == "3")
					{
						num = 3;
						return num;
					}
					else if (reader["area"].ToString() == "4")
					{
						num = 4;
						return num;
					}
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
				num = 0;
				return num;
			}
			finally
			{
				conexion.Close();
			}
			return num;
		}

		private void consulta3(string id, int alerta, string descripcionAlerta)
		{
			int tipoAlerta = alerta;
			string query = string.Concat(new string[] { "INSERT INTO alertas (id, tipo_alerta, descripcion_alerta) VALUES ('", id, "', '", tipoAlerta.ToString(), "', '", descripcionAlerta, "')" });
			MySqlConnection conexion = Conectar.Conecta();
			conexion.Open();
			try
			{
				try
				{
					(new MySqlCommand(query, conexion)).ExecuteNonQuery();
				}
				catch (Exception exception)
				{
					Exception ex = exception;
					MessageBox.Show(string.Concat("Error: ", ex.Message));
				}
			}
			finally
			{
				conexion.Close();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTexto1 = new System.Windows.Forms.Label();
            this.labelTexto2 = new System.Windows.Forms.Label();
            this.labelTexto3 = new System.Windows.Forms.Label();
            this.labelTexto4 = new System.Windows.Forms.Label();
            this.labelTexto5 = new System.Windows.Forms.Label();
            this.labelTexto6 = new System.Windows.Forms.Label();
            this.labelTexto7 = new System.Windows.Forms.Label();
            this.labelTexto8 = new System.Windows.Forms.Label();
            this.labelTexto9 = new System.Windows.Forms.Label();
            this.labelTexto10 = new System.Windows.Forms.Label();
            this.labelTexto11 = new System.Windows.Forms.Label();
            this.labelTexto12 = new System.Windows.Forms.Label();
            this.labelTexto13 = new System.Windows.Forms.Label();
            this.labelTexto14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 15, 5, 15);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(660, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(597, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(203, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Generar plan de mantenimiento para:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Numero de identificación";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(334, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTexto1
            // 
            this.labelTexto1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto1.AutoSize = true;
            this.labelTexto1.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto1.Location = new System.Drawing.Point(16, 287);
            this.labelTexto1.Name = "labelTexto1";
            this.labelTexto1.Size = new System.Drawing.Size(0, 16);
            this.labelTexto1.TabIndex = 24;
            // 
            // labelTexto2
            // 
            this.labelTexto2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto2.AutoSize = true;
            this.labelTexto2.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto2.Location = new System.Drawing.Point(16, 303);
            this.labelTexto2.Name = "labelTexto2";
            this.labelTexto2.Size = new System.Drawing.Size(0, 16);
            this.labelTexto2.TabIndex = 25;
            // 
            // labelTexto3
            // 
            this.labelTexto3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto3.AutoSize = true;
            this.labelTexto3.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto3.Location = new System.Drawing.Point(16, 319);
            this.labelTexto3.Name = "labelTexto3";
            this.labelTexto3.Size = new System.Drawing.Size(0, 16);
            this.labelTexto3.TabIndex = 26;
            // 
            // labelTexto4
            // 
            this.labelTexto4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto4.AutoSize = true;
            this.labelTexto4.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto4.Location = new System.Drawing.Point(16, 335);
            this.labelTexto4.Name = "labelTexto4";
            this.labelTexto4.Size = new System.Drawing.Size(0, 16);
            this.labelTexto4.TabIndex = 27;
            // 
            // labelTexto5
            // 
            this.labelTexto5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto5.AutoSize = true;
            this.labelTexto5.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto5.Location = new System.Drawing.Point(16, 351);
            this.labelTexto5.Name = "labelTexto5";
            this.labelTexto5.Size = new System.Drawing.Size(0, 16);
            this.labelTexto5.TabIndex = 28;
            // 
            // labelTexto6
            // 
            this.labelTexto6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto6.AutoSize = true;
            this.labelTexto6.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto6.Location = new System.Drawing.Point(16, 367);
            this.labelTexto6.Name = "labelTexto6";
            this.labelTexto6.Size = new System.Drawing.Size(0, 16);
            this.labelTexto6.TabIndex = 29;
            // 
            // labelTexto7
            // 
            this.labelTexto7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto7.AutoSize = true;
            this.labelTexto7.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto7.Location = new System.Drawing.Point(16, 383);
            this.labelTexto7.Name = "labelTexto7";
            this.labelTexto7.Size = new System.Drawing.Size(0, 16);
            this.labelTexto7.TabIndex = 30;
            // 
            // labelTexto8
            // 
            this.labelTexto8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto8.AutoSize = true;
            this.labelTexto8.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto8.Location = new System.Drawing.Point(16, 399);
            this.labelTexto8.Name = "labelTexto8";
            this.labelTexto8.Size = new System.Drawing.Size(0, 16);
            this.labelTexto8.TabIndex = 31;
            // 
            // labelTexto9
            // 
            this.labelTexto9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto9.AutoSize = true;
            this.labelTexto9.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto9.Location = new System.Drawing.Point(16, 415);
            this.labelTexto9.Name = "labelTexto9";
            this.labelTexto9.Size = new System.Drawing.Size(0, 16);
            this.labelTexto9.TabIndex = 32;
            // 
            // labelTexto10
            // 
            this.labelTexto10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto10.AutoSize = true;
            this.labelTexto10.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto10.Location = new System.Drawing.Point(16, 431);
            this.labelTexto10.Name = "labelTexto10";
            this.labelTexto10.Size = new System.Drawing.Size(0, 16);
            this.labelTexto10.TabIndex = 33;
            // 
            // labelTexto11
            // 
            this.labelTexto11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto11.AutoSize = true;
            this.labelTexto11.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto11.Location = new System.Drawing.Point(16, 447);
            this.labelTexto11.Name = "labelTexto11";
            this.labelTexto11.Size = new System.Drawing.Size(0, 16);
            this.labelTexto11.TabIndex = 34;
            // 
            // labelTexto12
            // 
            this.labelTexto12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto12.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto12.Location = new System.Drawing.Point(335, 309);
            this.labelTexto12.Name = "labelTexto12";
            this.labelTexto12.Size = new System.Drawing.Size(337, 48);
            this.labelTexto12.TabIndex = 35;
            // 
            // labelTexto13
            // 
            this.labelTexto13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto13.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto13.Location = new System.Drawing.Point(335, 373);
            this.labelTexto13.Name = "labelTexto13";
            this.labelTexto13.Size = new System.Drawing.Size(337, 48);
            this.labelTexto13.TabIndex = 36;
            this.labelTexto13.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelTexto14
            // 
            this.labelTexto14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTexto14.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto14.Location = new System.Drawing.Point(335, 437);
            this.labelTexto14.Name = "labelTexto14";
            this.labelTexto14.Size = new System.Drawing.Size(337, 48);
            this.labelTexto14.TabIndex = 37;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.labelTexto14);
            this.Controls.Add(this.labelTexto13);
            this.Controls.Add(this.labelTexto12);
            this.Controls.Add(this.labelTexto11);
            this.Controls.Add(this.labelTexto10);
            this.Controls.Add(this.labelTexto9);
            this.Controls.Add(this.labelTexto8);
            this.Controls.Add(this.labelTexto7);
            this.Controls.Add(this.labelTexto6);
            this.Controls.Add(this.labelTexto5);
            this.Controls.Add(this.labelTexto4);
            this.Controls.Add(this.labelTexto3);
            this.Controls.Add(this.labelTexto2);
            this.Controls.Add(this.labelTexto1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void llenarTabla()
		{
			DataTable dt = new DataTable();
			MySqlConnection conexion = Conectar.Conecta();
			string query = "SELECT * FROM hvequipo";
			conexion.Open();
			try
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand(query, conexion);
					(new MySqlDataAdapter(cmd)).Fill(dt);
					this.dataGridView1.DataSource = dt;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
			finally
			{
				conexion.Close();
			}
		}

		private int unidades(string unidadesConformes, string unidadesRechazadas)
		{
			int unidadesConformesInt = int.Parse(unidadesConformes);
			return unidadesConformesInt - int.Parse(unidadesRechazadas);
		}

		private string verificarTexto(string texto)
		{
			return (texto != "" ? texto : "No hay datos");
		}
	}
}
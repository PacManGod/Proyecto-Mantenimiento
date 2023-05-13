using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_09
{
	public class Form8 : Form
	{
		private IContainer components = null;

		private Label label1;

		private Button buttonExit;

		public Form8()
		{
			this.InitializeComponent();
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
			this.label1 = new Label();
			this.buttonExit = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(12, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Indicador de calidad";
			this.buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.buttonExit.Location = new Point(597, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 22;
			this.buttonExit.Text = "X";
			this.buttonExit.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(684, 561);
			base.Controls.Add(this.buttonExit);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form8";
			this.Text = "Form8";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
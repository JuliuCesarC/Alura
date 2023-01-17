namespace Formularios_Componente_e_Eventos
{
  partial class Frm_Question
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if( disposing && (components != null) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Question));
      this.lbl_question = new System.Windows.Forms.Label();
      this.btn_run = new System.Windows.Forms.Button();
      this.btn_stop = new System.Windows.Forms.Button();
      this.pcb_question = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pcb_question)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_question
      // 
      this.lbl_question.AutoSize = true;
      this.lbl_question.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbl_question.Location = new System.Drawing.Point(34, 41);
      this.lbl_question.Name = "lbl_question";
      this.lbl_question.Size = new System.Drawing.Size(453, 59);
      this.lbl_question.TabIndex = 0;
      this.lbl_question.Text = "Deseja Validar o CPF?";
      // 
      // btn_run
      // 
      this.btn_run.Location = new System.Drawing.Point(474, 163);
      this.btn_run.Name = "btn_run";
      this.btn_run.Size = new System.Drawing.Size(199, 86);
      this.btn_run.TabIndex = 1;
      this.btn_run.Text = "OK";
      this.btn_run.UseVisualStyleBackColor = true;
      this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
      // 
      // btn_stop
      // 
      this.btn_stop.Location = new System.Drawing.Point(474, 275);
      this.btn_stop.Name = "btn_stop";
      this.btn_stop.Size = new System.Drawing.Size(199, 86);
      this.btn_stop.TabIndex = 2;
      this.btn_stop.Text = "Cancel";
      this.btn_stop.UseVisualStyleBackColor = true;
      this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
      // 
      // pcb_question
      // 
      this.pcb_question.Image = global::Formularios_Componente_e_Eventos.Properties.Resources.Frm_Question;
      this.pcb_question.Location = new System.Drawing.Point(47, 114);
      this.pcb_question.Name = "pcb_question";
      this.pcb_question.Size = new System.Drawing.Size(298, 290);
      this.pcb_question.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pcb_question.TabIndex = 3;
      this.pcb_question.TabStop = false;
      // 
      // Frm_Question
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(699, 432);
      this.Controls.Add(this.pcb_question);
      this.Controls.Add(this.btn_stop);
      this.Controls.Add(this.btn_run);
      this.Controls.Add(this.lbl_question);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Frm_Question";
      this.Text = " ";
      ((System.ComponentModel.ISupportInitialize)(this.pcb_question)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lbl_question;
    private Button btn_run;
    private Button btn_stop;
    private PictureBox pcb_question;
  }
}
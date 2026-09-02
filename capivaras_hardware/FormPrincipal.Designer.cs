
namespace capivaras_hardware
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnPriCad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadCli = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadFun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadCar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadPro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadCat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBtnCadMar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPriCon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPriRel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPriVen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPriSai = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPrincipal = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuslbData = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuslbHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPriCad,
            this.mnPriCon,
            this.mnPriRel,
            this.mnPriVen,
            this.mnPriSai});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 58);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuPrincipal";
            // 
            // mnPriCad
            // 
            this.mnPriCad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBtnCadCli,
            this.mnBtnCadFun,
            this.mnBtnCadCar,
            this.mnBtnCadPro,
            this.mnBtnCadCat,
            this.mnBtnCadMar});
            this.mnPriCad.ForeColor = System.Drawing.Color.White;
            this.mnPriCad.Image = ((System.Drawing.Image)(resources.GetObject("mnPriCad.Image")));
            this.mnPriCad.Name = "mnPriCad";
            this.mnPriCad.Size = new System.Drawing.Size(120, 54);
            this.mnPriCad.Text = "Cadastro";
            // 
            // mnBtnCadCli
            // 
            this.mnBtnCadCli.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadCli.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadCli.Name = "mnBtnCadCli";
            this.mnBtnCadCli.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadCli.Text = "Clientes";
            this.mnBtnCadCli.Click += new System.EventHandler(this.btnCadCliMenu_Click);
            // 
            // mnBtnCadFun
            // 
            this.mnBtnCadFun.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadFun.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadFun.Name = "mnBtnCadFun";
            this.mnBtnCadFun.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadFun.Text = "Funcionarios";
            this.mnBtnCadFun.Click += new System.EventHandler(this.cadFuncionarios_Click);
            // 
            // mnBtnCadCar
            // 
            this.mnBtnCadCar.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadCar.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadCar.Name = "mnBtnCadCar";
            this.mnBtnCadCar.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadCar.Text = "Cargos";
            this.mnBtnCadCar.Click += new System.EventHandler(this.cadCargo_Click);
            // 
            // mnBtnCadPro
            // 
            this.mnBtnCadPro.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadPro.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadPro.Name = "mnBtnCadPro";
            this.mnBtnCadPro.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadPro.Text = "Produtos";
            this.mnBtnCadPro.Click += new System.EventHandler(this.mnBtnCadPro_Click);
            // 
            // mnBtnCadCat
            // 
            this.mnBtnCadCat.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadCat.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadCat.Name = "mnBtnCadCat";
            this.mnBtnCadCat.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadCat.Text = "Categorias";
            this.mnBtnCadCat.Click += new System.EventHandler(this.mnBtnCadCat_Click);
            // 
            // mnBtnCadMar
            // 
            this.mnBtnCadMar.BackColor = System.Drawing.Color.Black;
            this.mnBtnCadMar.ForeColor = System.Drawing.Color.White;
            this.mnBtnCadMar.Name = "mnBtnCadMar";
            this.mnBtnCadMar.Size = new System.Drawing.Size(180, 22);
            this.mnBtnCadMar.Text = "Marcas";
            this.mnBtnCadMar.Click += new System.EventHandler(this.mnBtnCadMar_Click);
            // 
            // mnPriCon
            // 
            this.mnPriCon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionarioToolStripMenuItem});
            this.mnPriCon.ForeColor = System.Drawing.Color.White;
            this.mnPriCon.Image = ((System.Drawing.Image)(resources.GetObject("mnPriCon.Image")));
            this.mnPriCon.Name = "mnPriCon";
            this.mnPriCon.Size = new System.Drawing.Size(118, 54);
            this.mnPriCon.Text = "Consulta";
            // 
            // mnPriRel
            // 
            this.mnPriRel.ForeColor = System.Drawing.Color.White;
            this.mnPriRel.Image = ((System.Drawing.Image)(resources.GetObject("mnPriRel.Image")));
            this.mnPriRel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnPriRel.Name = "mnPriRel";
            this.mnPriRel.Size = new System.Drawing.Size(136, 54);
            this.mnPriRel.Text = "Relatórios";
            // 
            // mnPriVen
            // 
            this.mnPriVen.ForeColor = System.Drawing.Color.White;
            this.mnPriVen.Image = ((System.Drawing.Image)(resources.GetObject("mnPriVen.Image")));
            this.mnPriVen.Name = "mnPriVen";
            this.mnPriVen.Size = new System.Drawing.Size(108, 54);
            this.mnPriVen.Text = "Vendas";
            // 
            // mnPriSai
            // 
            this.mnPriSai.ForeColor = System.Drawing.Color.White;
            this.mnPriSai.Image = ((System.Drawing.Image)(resources.GetObject("mnPriSai.Image")));
            this.mnPriSai.Name = "mnPriSai";
            this.mnPriSai.Size = new System.Drawing.Size(86, 54);
            this.mnPriSai.Text = "Sair";
            this.mnPriSai.Click += new System.EventHandler(this.btnSairPrincipal_Click);
            // 
            // timerPrincipal
            // 
            this.timerPrincipal.Enabled = true;
            this.timerPrincipal.Interval = 1000;
            this.timerPrincipal.Tick += new System.EventHandler(this.timerPrincipal_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslbData,
            this.statuslbHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1120, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuslbData
            // 
            this.statuslbData.Name = "statuslbData";
            this.statuslbData.Size = new System.Drawing.Size(41, 20);
            this.statuslbData.Text = "Data";
            // 
            // statuslbHora
            // 
            this.statuslbHora.Name = "statuslbHora";
            this.statuslbHora.Size = new System.Drawing.Size(42, 20);
            this.statuslbHora.Text = "Hora";
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.funcionarioToolStripMenuItem.Text = "Funcionario";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1120, 710);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "capivaras_hardware";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnPriCad;
        private System.Windows.Forms.ToolStripMenuItem mnPriCon;
        private System.Windows.Forms.ToolStripMenuItem mnPriRel;
        private System.Windows.Forms.ToolStripMenuItem mnPriVen;
        private System.Windows.Forms.ToolStripMenuItem mnPriSai;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadFun;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadCar;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadCli;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadPro;
        private System.Windows.Forms.Timer timerPrincipal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuslbData;
        private System.Windows.Forms.ToolStripStatusLabel statuslbHora;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadCat;
        private System.Windows.Forms.ToolStripMenuItem mnBtnCadMar;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
    }
}


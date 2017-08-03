namespace CheatInjector
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Namespace = new System.Windows.Forms.TextBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.Method = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Inject = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Namespace";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Method";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "C:\\CriticalOps\\MonoInvoke.dll";
            // 
            // Namespace
            // 
            this.Namespace.Location = new System.Drawing.Point(121, 84);
            this.Namespace.Name = "Namespace";
            this.Namespace.ReadOnly = true;
            this.Namespace.Size = new System.Drawing.Size(190, 20);
            this.Namespace.TabIndex = 5;
            this.Namespace.Text = "UnityGameObject";
            // 
            // Class
            // 
            this.Class.Location = new System.Drawing.Point(121, 110);
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            this.Class.Size = new System.Drawing.Size(190, 20);
            this.Class.TabIndex = 6;
            this.Class.Text = "Loader";
            // 
            // Method
            // 
            this.Method.Location = new System.Drawing.Point(121, 136);
            this.Method.Name = "Method";
            this.Method.ReadOnly = true;
            this.Method.Size = new System.Drawing.Size(190, 20);
            this.Method.TabIndex = 7;
            this.Method.Text = "Load";
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(317, 30);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(59, 23);
            this.Browse.TabIndex = 8;
            this.Browse.Text = "Browse...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Inject
            // 
            this.Inject.Location = new System.Drawing.Point(261, 162);
            this.Inject.Name = "Inject";
            this.Inject.Size = new System.Drawing.Size(115, 45);
            this.Inject.TabIndex = 9;
            this.Inject.Text = "Inject!";
            this.Inject.UseVisualStyleBackColor = true;
            this.Inject.Click += new System.EventHandler(this.Inject_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(121, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "923976180967261.fbunity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Application";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "MonoInvoke.dll";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "UnityGameObject.dll";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(121, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "C:\\CriticalOps\\UnityGameObject.dll";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 219);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Inject);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Method);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.Namespace);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Unity3D Cheat Injector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Namespace;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.TextBox Method;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Inject;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
    }
}


﻿namespace Panda
{
    partial class Ventas
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgVenta = new System.Windows.Forms.DataGridView();
            this.VentaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(305, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar Por Producto:";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(216, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // dgVenta
            // 
            this.dgVenta.AllowUserToAddRows = false;
            this.dgVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VentaNombre,
            this.VentaCantidad,
            this.VentaPrecio});
            this.dgVenta.Location = new System.Drawing.Point(514, 61);
            this.dgVenta.Name = "dgVenta";
            this.dgVenta.ReadOnly = true;
            this.dgVenta.RowHeadersVisible = false;
            this.dgVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVenta.Size = new System.Drawing.Size(278, 254);
            this.dgVenta.TabIndex = 12;
            this.dgVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVenta_CellDoubleClick);
            this.dgVenta.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgVenta_UserDeletedRow);
            // 
            // VentaNombre
            // 
            this.VentaNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VentaNombre.DataPropertyName = "VentaNombre";
            this.VentaNombre.HeaderText = "Venta";
            this.VentaNombre.Name = "VentaNombre";
            this.VentaNombre.ReadOnly = true;
            // 
            // VentaCantidad
            // 
            this.VentaCantidad.DataPropertyName = "VentaCantidad";
            this.VentaCantidad.HeaderText = "Cantidad";
            this.VentaCantidad.Name = "VentaCantidad";
            this.VentaCantidad.ReadOnly = true;
            // 
            // VentaPrecio
            // 
            this.VentaPrecio.DataPropertyName = "VentaPrecio";
            this.VentaPrecio.HeaderText = "Precio";
            this.VentaPrecio.Name = "VentaPrecio";
            this.VentaPrecio.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(567, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 40);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cerrar Venta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 40);
            this.button3.TabIndex = 14;
            this.button3.Text = "Empanada";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(113, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 40);
            this.button4.TabIndex = 15;
            this.button4.Text = "Manito";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(209, 105);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 40);
            this.button5.TabIndex = 16;
            this.button5.Text = "De Ambato";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(305, 105);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 40);
            this.button6.TabIndex = 17;
            this.button6.Text = "Gusano";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(401, 105);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 40);
            this.button7.TabIndex = 18;
            this.button7.Text = "Integral";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(17, 151);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(90, 40);
            this.button8.TabIndex = 19;
            this.button8.Text = "Pan De Agua";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(113, 151);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(90, 40);
            this.button9.TabIndex = 20;
            this.button9.Text = "Pan De Chocolate";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(209, 151);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(90, 40);
            this.button10.TabIndex = 21;
            this.button10.Text = "Yogurt Lenutrit 0.10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(305, 151);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(90, 40);
            this.button11.TabIndex = 22;
            this.button11.Text = "Huevos";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(401, 151);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(90, 40);
            this.button12.TabIndex = 23;
            this.button12.Text = "Chocolatada 250ml.";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(401, 243);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(90, 40);
            this.button13.TabIndex = 33;
            this.button13.Text = "Avena 1/4";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(305, 243);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(90, 40);
            this.button14.TabIndex = 32;
            this.button14.Text = "Leche 1/2";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(209, 243);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(90, 40);
            this.button15.TabIndex = 31;
            this.button15.Text = "Leche Semidescre.";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(113, 243);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(90, 40);
            this.button16.TabIndex = 30;
            this.button16.Text = "Leche Entera";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(17, 243);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(90, 40);
            this.button17.TabIndex = 29;
            this.button17.Text = "ReyLeche 1Lt.";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(401, 197);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(90, 40);
            this.button18.TabIndex = 28;
            this.button18.Text = "Jamón LD";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(305, 197);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(90, 40);
            this.button19.TabIndex = 27;
            this.button19.Text = "Mortadela Mr. Pollo 85gr.";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(209, 197);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(90, 40);
            this.button20.TabIndex = 26;
            this.button20.Text = "Mortadela LD 100gr.";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(113, 197);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(90, 40);
            this.button21.TabIndex = 25;
            this.button21.Text = "Queso 150gr.";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(17, 197);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(90, 40);
            this.button22.TabIndex = 24;
            this.button22.Text = "Queso 500gr.";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(401, 335);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(90, 40);
            this.button23.TabIndex = 43;
            this.button23.Text = "Coca Original 1.350ml.";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(305, 335);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(90, 40);
            this.button24.TabIndex = 42;
            this.button24.Text = "Coca Original 350ml.";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(209, 335);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(90, 40);
            this.button25.TabIndex = 41;
            this.button25.Text = "Coca Cero 350ml.";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(113, 335);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(90, 40);
            this.button26.TabIndex = 40;
            this.button26.Text = "Dasani 1L";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(17, 335);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(90, 40);
            this.button27.TabIndex = 39;
            this.button27.Text = "Cielo 1L.";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(401, 289);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(90, 40);
            this.button28.TabIndex = 38;
            this.button28.Text = "Colcafé 10gr.";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(305, 289);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(90, 40);
            this.button29.TabIndex = 37;
            this.button29.Text = "Sí Café 10gr.";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(209, 289);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(90, 40);
            this.button30.TabIndex = 36;
            this.button30.Text = "Nescafé 10gr.";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(113, 289);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(90, 40);
            this.button31.TabIndex = 35;
            this.button31.Text = "Azucar 1/2 Lb.";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(17, 289);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(90, 40);
            this.button32.TabIndex = 34;
            this.button32.Text = "Azucar 1Lb.";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(401, 59);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(90, 40);
            this.button33.TabIndex = 48;
            this.button33.Text = "Reventado";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(305, 59);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(90, 40);
            this.button34.TabIndex = 47;
            this.button34.Text = "Caracol";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(209, 59);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(90, 40);
            this.button35.TabIndex = 46;
            this.button35.Text = "Cacho con queso";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(113, 59);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(90, 40);
            this.button36.TabIndex = 45;
            this.button36.Text = "Cacho";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(17, 59);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(90, 40);
            this.button37.TabIndex = 44;
            this.button37.Text = "Enrollado";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(581, 336);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(194, 30);
            this.textBox1.TabIndex = 54;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 55;
            this.label2.Text = "Total:";
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgVenta);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.VisibleChanged += new System.EventHandler(this.Ventas_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.DataGridView dgVenta;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaPrecio;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button button2;
    }
}
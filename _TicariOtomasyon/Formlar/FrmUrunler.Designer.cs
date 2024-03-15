using System.Drawing;
using System.Windows.Forms;

namespace _TicariOtomasyon.Formlar
{
    partial class FrmUrunler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUrunler));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BtnReflesh = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.Btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.Nudadet = new System.Windows.Forms.NumericUpDown();
            this.Rchdetay = new System.Windows.Forms.RichTextBox();
            this.Txtsatıs = new DevExpress.XtraEditors.TextEdit();
            this.Txtyıl = new DevExpress.XtraEditors.TextEdit();
            this.Txtmodel = new DevExpress.XtraEditors.TextEdit();
            this.Txtmarka = new DevExpress.XtraEditors.TextEdit();
            this.Txtad = new DevExpress.XtraEditors.TextEdit();
            this.Txtıd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.Txtfiyat = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nudadet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtsatıs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtyıl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmodel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtıd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtfiyat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1336, 1059);
            this.gridControl1.TabIndex = 99;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableGroupRowMenu = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.BtnReflesh);
            this.groupControl1.Controls.Add(this.BtnGuncelle);
            this.groupControl1.Controls.Add(this.BtnSil);
            this.groupControl1.Controls.Add(this.Btnkaydet);
            this.groupControl1.Controls.Add(this.Nudadet);
            this.groupControl1.Controls.Add(this.Rchdetay);
            this.groupControl1.Controls.Add(this.Txtfiyat);
            this.groupControl1.Controls.Add(this.Txtsatıs);
            this.groupControl1.Controls.Add(this.Txtyıl);
            this.groupControl1.Controls.Add(this.Txtmodel);
            this.groupControl1.Controls.Add(this.Txtmarka);
            this.groupControl1.Controls.Add(this.Txtad);
            this.groupControl1.Controls.Add(this.Txtıd);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(1342, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(586, 1059);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "ÜRÜN EKLEME";
            // 
            // BtnReflesh
            // 
            this.BtnReflesh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnReflesh.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnReflesh.Appearance.Options.UseFont = true;
            this.BtnReflesh.Appearance.Options.UseForeColor = true;
            this.BtnReflesh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnReflesh.ImageOptions.Image")));
            this.BtnReflesh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnReflesh.Location = new System.Drawing.Point(5, 37);
            this.BtnReflesh.Name = "BtnReflesh";
            this.BtnReflesh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnReflesh.Size = new System.Drawing.Size(90, 39);
            this.BtnReflesh.TabIndex = 25;
            this.BtnReflesh.Text = "TEMİZLE";
            this.BtnReflesh.Click += new System.EventHandler(this.BtnReflesh_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.ImageOptions.Image")));
            this.BtnGuncelle.Location = new System.Drawing.Point(193, 694);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(301, 46);
            this.BtnGuncelle.TabIndex = 11;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(194, 622);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(301, 46);
            this.BtnSil.TabIndex = 10;
            this.BtnSil.Text = "SİL";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // Btnkaydet
            // 
            this.Btnkaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.Btnkaydet.Appearance.Options.UseFont = true;
            this.Btnkaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btnkaydet.ImageOptions.Image")));
            this.Btnkaydet.Location = new System.Drawing.Point(195, 551);
            this.Btnkaydet.Name = "Btnkaydet";
            this.Btnkaydet.Size = new System.Drawing.Size(301, 46);
            this.Btnkaydet.TabIndex = 9;
            this.Btnkaydet.Text = "KAYDET";
            this.Btnkaydet.Click += new System.EventHandler(this.Btnkaydet_Click);
            // 
            // Nudadet
            // 
            this.Nudadet.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Nudadet.Location = new System.Drawing.Point(195, 279);
            this.Nudadet.Name = "Nudadet";
            this.Nudadet.Size = new System.Drawing.Size(162, 26);
            this.Nudadet.TabIndex = 5;
            // 
            // Rchdetay
            // 
            this.Rchdetay.Location = new System.Drawing.Point(195, 416);
            this.Rchdetay.Name = "Rchdetay";
            this.Rchdetay.Size = new System.Drawing.Size(301, 112);
            this.Rchdetay.TabIndex = 8;
            this.Rchdetay.Text = "";
            // 
            // Txtsatıs
            // 
            this.Txtsatıs.EditValue = "0,00";
            this.Txtsatıs.Location = new System.Drawing.Point(195, 326);
            this.Txtsatıs.Name = "Txtsatıs";
            this.Txtsatıs.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Txtsatıs.Properties.Appearance.Options.UseFont = true;
            this.Txtsatıs.Size = new System.Drawing.Size(301, 24);
            this.Txtsatıs.TabIndex = 6;
            // 
            // Txtyıl
            // 
            this.Txtyıl.Location = new System.Drawing.Point(195, 235);
            this.Txtyıl.Name = "Txtyıl";
            this.Txtyıl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtyıl.Properties.Appearance.Options.UseFont = true;
            this.Txtyıl.Size = new System.Drawing.Size(301, 24);
            this.Txtyıl.TabIndex = 4;
            // 
            // Txtmodel
            // 
            this.Txtmodel.Location = new System.Drawing.Point(194, 191);
            this.Txtmodel.Name = "Txtmodel";
            this.Txtmodel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtmodel.Properties.Appearance.Options.UseFont = true;
            this.Txtmodel.Size = new System.Drawing.Size(301, 24);
            this.Txtmodel.TabIndex = 3;
            // 
            // Txtmarka
            // 
            this.Txtmarka.Location = new System.Drawing.Point(195, 144);
            this.Txtmarka.Name = "Txtmarka";
            this.Txtmarka.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtmarka.Properties.Appearance.Options.UseFont = true;
            this.Txtmarka.Size = new System.Drawing.Size(301, 24);
            this.Txtmarka.TabIndex = 2;
            // 
            // Txtad
            // 
            this.Txtad.Location = new System.Drawing.Point(194, 99);
            this.Txtad.Name = "Txtad";
            this.Txtad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtad.Properties.Appearance.Options.UseFont = true;
            this.Txtad.Size = new System.Drawing.Size(301, 24);
            this.Txtad.TabIndex = 1;
            // 
            // Txtıd
            // 
            this.Txtıd.Enabled = false;
            this.Txtıd.Location = new System.Drawing.Point(194, 54);
            this.Txtıd.Name = "Txtıd";
            this.Txtıd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtıd.Properties.Appearance.Options.UseFont = true;
            this.Txtıd.Size = new System.Drawing.Size(301, 24);
            this.Txtıd.TabIndex = 0;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(109, 416);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(71, 23);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "DETAY:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(51, 374);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(129, 23);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "SATIŞ FİYAT:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(64, 325);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(116, 23);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "ALIŞ FİYAT:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(122, 282);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 23);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "ADET:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(140, 238);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 23);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "YIL:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(104, 190);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 23);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "MODEL:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(103, 147);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 23);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "MARKA:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(146, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 23);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "AD:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(150, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID:";
            // 
            // Txtfiyat
            // 
            this.Txtfiyat.EditValue = "0,00";
            this.Txtfiyat.Location = new System.Drawing.Point(195, 371);
            this.Txtfiyat.Name = "Txtfiyat";
            this.Txtfiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtfiyat.Properties.Appearance.Options.UseFont = true;
            this.Txtfiyat.Size = new System.Drawing.Size(301, 24);
            this.Txtfiyat.TabIndex = 7;
            // 
            // FrmUrunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmUrunler";
            this.Text = "ÜRÜNLER";
            this.Load += new System.EventHandler(this.FrmUrunler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nudadet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtsatıs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtyıl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmodel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtmarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtıd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtfiyat.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RichTextBox Rchdetay;
        private DevExpress.XtraEditors.TextEdit Txtsatıs;
        private DevExpress.XtraEditors.TextEdit Txtyıl;
        private DevExpress.XtraEditors.TextEdit Txtmodel;
        private DevExpress.XtraEditors.TextEdit Txtmarka;
        private DevExpress.XtraEditors.TextEdit Txtad;
        private DevExpress.XtraEditors.TextEdit Txtıd;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Btnkaydet;
        private System.Windows.Forms.NumericUpDown Nudadet;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnReflesh;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TextEdit Txtfiyat;
    }
}
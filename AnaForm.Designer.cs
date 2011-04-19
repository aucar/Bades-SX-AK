/****************************************************************************
 * BADES SX AK 1.0 
 * BADES Sistemi için XML Ayıklama ve Kodlama Aracı 
 * 
 * Bu program BDDK tarafından geliştirilen BADES sisteminden XML alarak bu 
 * verileri işlemek ve sonrasında tekrar BADES'e yüklenmek üzere XML
 * oluşturmak üzere hazırlanmıştır.
 * 
 * Bu kaynak kodu ve yazılım GPL lisansı ile lisanslanmıştır.
 * http://www.gnu.org/licenses/gpl.html
 * 
 * Her hakkı saklıdır.
 * Copyright @ Ahmet UÇAR
 * http://www.ahmetucar.com
 * 
 * Turklandbank Teftiş Kurulu Başkanlığı
 * http://www.tbank.com.tr
 * 
 * *************************************************************************/

namespace bades
{
    partial class FrmBades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBades));
            this.mMenu = new System.Windows.Forms.MenuStrip();
            this.bulguDosyasıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mXMLAl = new System.Windows.Forms.ToolStripMenuItem();
            this.mXMLVer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mExceleAktar = new System.Windows.Forms.ToolStripMenuItem();
            this.mYonetimBeyani = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.mGruplandirma = new System.Windows.Forms.ToolStripMenuItem();
            this.tKonusunaGore = new System.Windows.Forms.ToolStripMenuItem();
            this.tNiteligineGore = new System.Windows.Forms.ToolStripMenuItem();
            this.tOnemDerecesineGore = new System.Windows.Forms.ToolStripMenuItem();
            this.tTariheGore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tTutarsizligaGore = new System.Windows.Forms.ToolStripMenuItem();
            this.tIlgiliBolumeGore = new System.Windows.Forms.ToolStripMenuItem();
            this.tGiderilmeDurumunaGore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tGruplandırma = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mYardim = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mDestek = new System.Windows.Forms.ToolStripMenuItem();
            this.mHataBildir = new System.Windows.Forms.ToolStripMenuItem();
            this.mOzellikEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tXMLAl = new System.Windows.Forms.ToolStripButton();
            this.tXMLVer = new System.Windows.Forms.ToolStripButton();
            this.tKapat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tExcelAktar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tLblGroup = new System.Windows.Forms.ToolStripLabel();
            this.tCmbGrupla = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tYardim = new System.Windows.Forms.ToolStripButton();
            this.tDestek = new System.Windows.Forms.ToolStripButton();
            this.tHataBildir = new System.Windows.Forms.ToolStripButton();
            this.tOzellikEkle = new System.Windows.Forms.ToolStripButton();
            this.sBar = new System.Windows.Forms.StatusStrip();
            this.tlTumu = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlPlanlama = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlDuzeltme = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlGiderilen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlGiderilmeyecek = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlIlgi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlTutarsiz = new System.Windows.Forms.ToolStripStatusLabel();
            this.DlgAc = new System.Windows.Forms.OpenFileDialog();
            this.DlgKaydet = new System.Windows.Forms.SaveFileDialog();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.AnaSayfa = new System.Windows.Forms.TabPage();
            this.BulguLst = new System.Windows.Forms.ListView();
            this.Tab = new System.Windows.Forms.TabControl();
            this.SIcons = new System.Windows.Forms.ImageList(this.components);
            this.mMenu.SuspendLayout();
            this.tBar.SuspendLayout();
            this.sBar.SuspendLayout();
            this.AnaSayfa.SuspendLayout();
            this.Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mMenu
            // 
            this.mMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulguDosyasıToolStripMenuItem,
            this.mGruplandirma,
            this.yardımToolStripMenuItem});
            this.mMenu.Location = new System.Drawing.Point(0, 0);
            this.mMenu.Name = "mMenu";
            this.mMenu.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.mMenu.Size = new System.Drawing.Size(1002, 24);
            this.mMenu.TabIndex = 2;
            this.mMenu.Text = "menuStrip1";
            this.mMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mMenu_ItemClicked);
            // 
            // bulguDosyasıToolStripMenuItem
            // 
            this.bulguDosyasıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mXMLAl,
            this.mXMLVer,
            this.toolStripSeparator2,
            this.mKapat,
            this.toolStripSeparator1,
            this.mExceleAktar,
            this.mYonetimBeyani,
            this.toolStripSeparator3,
            this.mCikis});
            this.bulguDosyasıToolStripMenuItem.Name = "bulguDosyasıToolStripMenuItem";
            this.bulguDosyasıToolStripMenuItem.Size = new System.Drawing.Size(85, 18);
            this.bulguDosyasıToolStripMenuItem.Text = "Bulgu Dosyası";
            // 
            // mXMLAl
            // 
            this.mXMLAl.Image = ((System.Drawing.Image)(resources.GetObject("mXMLAl.Image")));
            this.mXMLAl.Name = "mXMLAl";
            this.mXMLAl.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mXMLAl.Size = new System.Drawing.Size(246, 22);
            this.mXMLAl.Text = "XML Dosyası İçe Aktar...";
            this.mXMLAl.Click += new System.EventHandler(this.mXMLAl_Click);
            // 
            // mXMLVer
            // 
            this.mXMLVer.Image = ((System.Drawing.Image)(resources.GetObject("mXMLVer.Image")));
            this.mXMLVer.Name = "mXMLVer";
            this.mXMLVer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mXMLVer.Size = new System.Drawing.Size(246, 22);
            this.mXMLVer.Text = "XML Dosyası Dışa Aktar...";
            this.mXMLVer.Click += new System.EventHandler(this.mXMLVer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // mKapat
            // 
            this.mKapat.Image = ((System.Drawing.Image)(resources.GetObject("mKapat.Image")));
            this.mKapat.Name = "mKapat";
            this.mKapat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mKapat.Size = new System.Drawing.Size(246, 22);
            this.mKapat.Text = "XML Dosyasını Kapat";
            this.mKapat.Click += new System.EventHandler(this.mKapat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // mExceleAktar
            // 
            this.mExceleAktar.Image = ((System.Drawing.Image)(resources.GetObject("mExceleAktar.Image")));
            this.mExceleAktar.Name = "mExceleAktar";
            this.mExceleAktar.Size = new System.Drawing.Size(246, 22);
            this.mExceleAktar.Text = "Dosyayı Excel\'e Aktar...";
            this.mExceleAktar.Click += new System.EventHandler(this.mExceleAktar_Click);
            // 
            // mYonetimBeyani
            // 
            this.mYonetimBeyani.Image = global::bades.Properties.Resources.std_word_icon;
            this.mYonetimBeyani.ImageTransparentColor = System.Drawing.Color.White;
            this.mYonetimBeyani.Name = "mYonetimBeyani";
            this.mYonetimBeyani.Size = new System.Drawing.Size(246, 22);
            this.mYonetimBeyani.Text = "Yönetim Beyanı Oluştur...";
            this.mYonetimBeyani.Click += new System.EventHandler(this.mYonetimBeyani_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // mCikis
            // 
            this.mCikis.Image = ((System.Drawing.Image)(resources.GetObject("mCikis.Image")));
            this.mCikis.Name = "mCikis";
            this.mCikis.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mCikis.Size = new System.Drawing.Size(246, 22);
            this.mCikis.Text = "Çıkış";
            this.mCikis.Click += new System.EventHandler(this.mCikis_Click);
            // 
            // mGruplandirma
            // 
            this.mGruplandirma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tKonusunaGore,
            this.tNiteligineGore,
            this.tOnemDerecesineGore,
            this.tTariheGore,
            this.toolStripSeparator11,
            this.tTutarsizligaGore,
            this.tIlgiliBolumeGore,
            this.tGiderilmeDurumunaGore,
            this.toolStripSeparator10,
            this.tGruplandırma});
            this.mGruplandirma.Name = "mGruplandirma";
            this.mGruplandirma.Size = new System.Drawing.Size(82, 18);
            this.mGruplandirma.Text = "Gruplandırma";
            // 
            // tKonusunaGore
            // 
            this.tKonusunaGore.CheckOnClick = true;
            this.tKonusunaGore.Name = "tKonusunaGore";
            this.tKonusunaGore.Size = new System.Drawing.Size(229, 22);
            this.tKonusunaGore.Text = "Konusuna Göre Grupla";
            this.tKonusunaGore.Click += new System.EventHandler(this.tKonusunaGore_Click);
            // 
            // tNiteligineGore
            // 
            this.tNiteligineGore.CheckOnClick = true;
            this.tNiteligineGore.Name = "tNiteligineGore";
            this.tNiteligineGore.Size = new System.Drawing.Size(229, 22);
            this.tNiteligineGore.Text = "Niteliğine Göre Grupla";
            this.tNiteligineGore.Click += new System.EventHandler(this.tNiteligineGore_Click);
            // 
            // tOnemDerecesineGore
            // 
            this.tOnemDerecesineGore.CheckOnClick = true;
            this.tOnemDerecesineGore.Name = "tOnemDerecesineGore";
            this.tOnemDerecesineGore.Size = new System.Drawing.Size(229, 22);
            this.tOnemDerecesineGore.Text = "Önem Derecesine Göre Grupla";
            this.tOnemDerecesineGore.Click += new System.EventHandler(this.tOnemDerecesineGore_Click);
            // 
            // tTariheGore
            // 
            this.tTariheGore.CheckOnClick = true;
            this.tTariheGore.Name = "tTariheGore";
            this.tTariheGore.Size = new System.Drawing.Size(229, 22);
            this.tTariheGore.Text = "Tespit Yılına Göre Grupla";
            this.tTariheGore.Click += new System.EventHandler(this.tTariheGore_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(226, 6);
            // 
            // tTutarsizligaGore
            // 
            this.tTutarsizligaGore.Name = "tTutarsizligaGore";
            this.tTutarsizligaGore.Size = new System.Drawing.Size(229, 22);
            this.tTutarsizligaGore.Text = "Tutarsızlığa Göre Grupla";
            this.tTutarsizligaGore.Click += new System.EventHandler(this.tTutarsizligaGore_Click);
            // 
            // tIlgiliBolumeGore
            // 
            this.tIlgiliBolumeGore.Name = "tIlgiliBolumeGore";
            this.tIlgiliBolumeGore.Size = new System.Drawing.Size(229, 22);
            this.tIlgiliBolumeGore.Text = "İlgili Bölüme Göre Grupla";
            this.tIlgiliBolumeGore.Click += new System.EventHandler(this.tIlgiliBolumeGore_Click);
            // 
            // tGiderilmeDurumunaGore
            // 
            this.tGiderilmeDurumunaGore.CheckOnClick = true;
            this.tGiderilmeDurumunaGore.Name = "tGiderilmeDurumunaGore";
            this.tGiderilmeDurumunaGore.Size = new System.Drawing.Size(229, 22);
            this.tGiderilmeDurumunaGore.Text = "Alınan Aksiyona Göre Grupla";
            this.tGiderilmeDurumunaGore.Click += new System.EventHandler(this.tGiderilmeDurumunaGore_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(226, 6);
            // 
            // tGruplandırma
            // 
            this.tGruplandırma.CheckOnClick = true;
            this.tGruplandırma.Name = "tGruplandırma";
            this.tGruplandırma.Size = new System.Drawing.Size(229, 22);
            this.tGruplandırma.Text = "Gruplandırmaları Kaldır";
            this.tGruplandırma.Click += new System.EventHandler(this.tGruplandırma_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mYardim,
            this.toolStripSeparator5,
            this.mDestek,
            this.mHataBildir,
            this.mOzellikEkle,
            this.toolStripSeparator4,
            this.mHakkinda});
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(51, 18);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // mYardim
            // 
            this.mYardim.Image = ((System.Drawing.Image)(resources.GetObject("mYardim.Image")));
            this.mYardim.Name = "mYardim";
            this.mYardim.Size = new System.Drawing.Size(170, 22);
            this.mYardim.Text = "Yardım Konuları...";
            this.mYardim.Click += new System.EventHandler(this.mYardim_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(167, 6);
            // 
            // mDestek
            // 
            this.mDestek.Image = ((System.Drawing.Image)(resources.GetObject("mDestek.Image")));
            this.mDestek.Name = "mDestek";
            this.mDestek.Size = new System.Drawing.Size(170, 22);
            this.mDestek.Text = "Destek...";
            this.mDestek.Click += new System.EventHandler(this.mDestek_Click);
            // 
            // mHataBildir
            // 
            this.mHataBildir.Image = ((System.Drawing.Image)(resources.GetObject("mHataBildir.Image")));
            this.mHataBildir.Name = "mHataBildir";
            this.mHataBildir.Size = new System.Drawing.Size(170, 22);
            this.mHataBildir.Text = "Hata Bildir...";
            this.mHataBildir.Click += new System.EventHandler(this.mHataBildir_Click);
            // 
            // mOzellikEkle
            // 
            this.mOzellikEkle.Image = ((System.Drawing.Image)(resources.GetObject("mOzellikEkle.Image")));
            this.mOzellikEkle.Name = "mOzellikEkle";
            this.mOzellikEkle.Size = new System.Drawing.Size(170, 22);
            this.mOzellikEkle.Text = "Yeni Özellik...";
            this.mOzellikEkle.Click += new System.EventHandler(this.mOzellikEkle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(167, 6);
            // 
            // mHakkinda
            // 
            this.mHakkinda.Name = "mHakkinda";
            this.mHakkinda.Size = new System.Drawing.Size(170, 22);
            this.mHakkinda.Text = "Hakkında...";
            this.mHakkinda.Click += new System.EventHandler(this.mHakkinda_Click);
            // 
            // tBar
            // 
            this.tBar.CanOverflow = false;
            this.tBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.tXMLAl,
            this.tXMLVer,
            this.tKapat,
            this.toolStripSeparator8,
            this.tExcelAktar,
            this.toolStripSeparator9,
            this.tLblGroup,
            this.tCmbGrupla,
            this.toolStripSeparator6,
            this.tYardim,
            this.tDestek,
            this.tHataBildir,
            this.tOzellikEkle});
            this.tBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tBar.Location = new System.Drawing.Point(0, 24);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBar.Size = new System.Drawing.Size(1002, 29);
            this.tBar.TabIndex = 3;
            this.tBar.Text = "Gruplandır";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // tXMLAl
            // 
            this.tXMLAl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tXMLAl.Image = ((System.Drawing.Image)(resources.GetObject("tXMLAl.Image")));
            this.tXMLAl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tXMLAl.Name = "tXMLAl";
            this.tXMLAl.Size = new System.Drawing.Size(23, 20);
            this.tXMLAl.Text = "XML Dosyası İçe Aktar...";
            this.tXMLAl.Click += new System.EventHandler(this.mXMLAl_Click);
            // 
            // tXMLVer
            // 
            this.tXMLVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tXMLVer.Image = ((System.Drawing.Image)(resources.GetObject("tXMLVer.Image")));
            this.tXMLVer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tXMLVer.Name = "tXMLVer";
            this.tXMLVer.Size = new System.Drawing.Size(23, 20);
            this.tXMLVer.Text = "XML Dosyası Dışa Aktar...";
            this.tXMLVer.Click += new System.EventHandler(this.mXMLVer_Click);
            // 
            // tKapat
            // 
            this.tKapat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tKapat.Image = ((System.Drawing.Image)(resources.GetObject("tKapat.Image")));
            this.tKapat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tKapat.Name = "tKapat";
            this.tKapat.Size = new System.Drawing.Size(23, 20);
            this.tKapat.Text = "Dosyayı Kapat";
            this.tKapat.Click += new System.EventHandler(this.mKapat_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // tExcelAktar
            // 
            this.tExcelAktar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tExcelAktar.Image = ((System.Drawing.Image)(resources.GetObject("tExcelAktar.Image")));
            this.tExcelAktar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tExcelAktar.Name = "tExcelAktar";
            this.tExcelAktar.Size = new System.Drawing.Size(23, 20);
            this.tExcelAktar.Text = "Dosyayı Excel Aktar";
            this.tExcelAktar.Click += new System.EventHandler(this.mExceleAktar_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // tLblGroup
            // 
            this.tLblGroup.AutoSize = false;
            this.tLblGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tLblGroup.Name = "tLblGroup";
            this.tLblGroup.Size = new System.Drawing.Size(73, 19);
            this.tLblGroup.Text = "Gruplandır : ";
            // 
            // tCmbGrupla
            // 
            this.tCmbGrupla.AutoSize = false;
            this.tCmbGrupla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tCmbGrupla.DropDownWidth = 250;
            this.tCmbGrupla.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tCmbGrupla.Items.AddRange(new object[] {
            "Bulgu Konusuna Göre",
            "Bulgu Niteliğine Göre",
            "Bulgunun Önem Derecesine Göre",
            "Bulgu Tespit Yılına Göre",
            "Bulgudaki Tutarsızlığa Göre",
            "Bulgunun İlgili Olduğu Bölüme Göre",
            "Bulguya Alınan Aksiyona Göre",
            "Gruplandırmayı Kaldır"});
            this.tCmbGrupla.Margin = new System.Windows.Forms.Padding(2);
            this.tCmbGrupla.Name = "tCmbGrupla";
            this.tCmbGrupla.Size = new System.Drawing.Size(250, 21);
            this.tCmbGrupla.SelectedIndexChanged += new System.EventHandler(this.CmbGrupla_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // tYardim
            // 
            this.tYardim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tYardim.Image = ((System.Drawing.Image)(resources.GetObject("tYardim.Image")));
            this.tYardim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tYardim.Name = "tYardim";
            this.tYardim.Size = new System.Drawing.Size(23, 20);
            this.tYardim.Text = "toolStripButton3";
            this.tYardim.ToolTipText = "Yardım Konuları...";
            this.tYardim.Click += new System.EventHandler(this.mYardim_Click);
            // 
            // tDestek
            // 
            this.tDestek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tDestek.Image = ((System.Drawing.Image)(resources.GetObject("tDestek.Image")));
            this.tDestek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tDestek.Name = "tDestek";
            this.tDestek.Size = new System.Drawing.Size(23, 20);
            this.tDestek.Text = "Destek...";
            this.tDestek.Click += new System.EventHandler(this.mDestek_Click);
            // 
            // tHataBildir
            // 
            this.tHataBildir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tHataBildir.Image = ((System.Drawing.Image)(resources.GetObject("tHataBildir.Image")));
            this.tHataBildir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tHataBildir.Name = "tHataBildir";
            this.tHataBildir.Size = new System.Drawing.Size(23, 20);
            this.tHataBildir.Text = "Hata Bildir...";
            this.tHataBildir.Click += new System.EventHandler(this.mHataBildir_Click);
            // 
            // tOzellikEkle
            // 
            this.tOzellikEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tOzellikEkle.Image = ((System.Drawing.Image)(resources.GetObject("tOzellikEkle.Image")));
            this.tOzellikEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tOzellikEkle.Name = "tOzellikEkle";
            this.tOzellikEkle.Size = new System.Drawing.Size(23, 20);
            this.tOzellikEkle.Text = "Yeni Özellik...";
            this.tOzellikEkle.Click += new System.EventHandler(this.mOzellikEkle_Click);
            // 
            // sBar
            // 
            this.sBar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlTumu,
            this.tlPlanlama,
            this.tlDuzeltme,
            this.tlGiderilen,
            this.tlGiderilmeyecek,
            this.tlIlgi,
            this.tlTutarsiz});
            this.sBar.Location = new System.Drawing.Point(0, 669);
            this.sBar.Name = "sBar";
            this.sBar.Size = new System.Drawing.Size(1002, 22);
            this.sBar.TabIndex = 4;
            this.sBar.Text = "statusStrip1";
            // 
            // tlTumu
            // 
            this.tlTumu.Name = "tlTumu";
            this.tlTumu.Size = new System.Drawing.Size(81, 17);
            this.tlTumu.Text = "Toplam Bulgu";
            // 
            // tlPlanlama
            // 
            this.tlPlanlama.Name = "tlPlanlama";
            this.tlPlanlama.Size = new System.Drawing.Size(119, 17);
            this.tlPlanlama.Text = "Planlama Aşamasında";
            // 
            // tlDuzeltme
            // 
            this.tlDuzeltme.Name = "tlDuzeltme";
            this.tlDuzeltme.Size = new System.Drawing.Size(124, 17);
            this.tlDuzeltme.Text = "Düzeltme Aşamasında";
            // 
            // tlGiderilen
            // 
            this.tlGiderilen.Name = "tlGiderilen";
            this.tlGiderilen.Size = new System.Drawing.Size(109, 17);
            this.tlGiderilen.Text = "Giderilmiş Durumda";
            // 
            // tlGiderilmeyecek
            // 
            this.tlGiderilmeyecek.Name = "tlGiderilmeyecek";
            this.tlGiderilmeyecek.Size = new System.Drawing.Size(122, 17);
            this.tlGiderilmeyecek.Text = "Giderilmeyecek Bulgu";
            // 
            // tlIlgi
            // 
            this.tlIlgi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tlIlgi.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.tlIlgi.Name = "tlIlgi";
            this.tlIlgi.Size = new System.Drawing.Size(60, 17);
            this.tlIlgi.Text = "İlgili Bulgu";
            // 
            // tlTutarsiz
            // 
            this.tlTutarsiz.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tlTutarsiz.ForeColor = System.Drawing.Color.DarkRed;
            this.tlTutarsiz.Name = "tlTutarsiz";
            this.tlTutarsiz.Size = new System.Drawing.Size(83, 17);
            this.tlTutarsiz.Text = "Tutarsız Bulgu";
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "ok.ico");
            this.Icons.Images.SetKeyName(1, "duzeltme.ico");
            this.Icons.Images.SetKeyName(2, "planlama.ico");
            this.Icons.Images.SetKeyName(3, "cancel.ico");
            this.Icons.Images.SetKeyName(4, "question.ico");
            this.Icons.Images.SetKeyName(5, "std_word_icon.gif");
            this.Icons.Images.SetKeyName(6, "close.png");
            // 
            // AnaSayfa
            // 
            this.AnaSayfa.Controls.Add(this.BulguLst);
            this.AnaSayfa.Location = new System.Drawing.Point(4, 25);
            this.AnaSayfa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnaSayfa.Name = "AnaSayfa";
            this.AnaSayfa.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnaSayfa.Size = new System.Drawing.Size(994, 587);
            this.AnaSayfa.TabIndex = 2;
            this.AnaSayfa.Text = "Genel Görünüm";
            this.AnaSayfa.UseVisualStyleBackColor = true;
            // 
            // BulguLst
            // 
            this.BulguLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BulguLst.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BulguLst.Location = new System.Drawing.Point(3, 4);
            this.BulguLst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BulguLst.MultiSelect = false;
            this.BulguLst.Name = "BulguLst";
            this.BulguLst.ShowItemToolTips = true;
            this.BulguLst.Size = new System.Drawing.Size(988, 579);
            this.BulguLst.TabIndex = 19;
            this.BulguLst.UseCompatibleStateImageBehavior = false;
            this.BulguLst.View = System.Windows.Forms.View.Details;
            this.BulguLst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.BulguLst_ColumnClick);
            this.BulguLst.ItemActivate += new System.EventHandler(this.BulguLst_ItemActivate);
            this.BulguLst.SelectedIndexChanged += new System.EventHandler(this.BulguLst_SelectedIndexChanged);
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.AnaSayfa);
            this.Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tab.Location = new System.Drawing.Point(0, 53);
            this.Tab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(1002, 616);
            this.Tab.TabIndex = 6;
            this.Tab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
            // 
            // SIcons
            // 
            this.SIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SIcons.ImageStream")));
            this.SIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SIcons.Images.SetKeyName(0, "icon_close_16px.gif");
            // 
            // FrmBades
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 691);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.sBar);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.mMenu);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmBades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bades SX AK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBades_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmBades_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmBades_DragEnter);
            this.mMenu.ResumeLayout(false);
            this.mMenu.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.sBar.ResumeLayout(false);
            this.sBar.PerformLayout();
            this.AnaSayfa.ResumeLayout(false);
            this.Tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mMenu;
        private System.Windows.Forms.ToolStripMenuItem bulguDosyasıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mXMLAl;
        private System.Windows.Forms.ToolStripMenuItem mXMLVer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mCikis;
        private System.Windows.Forms.ToolStripMenuItem mGruplandirma;
        private System.Windows.Forms.ToolStripMenuItem tTariheGore;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mHakkinda;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.StatusStrip sBar;
        private System.Windows.Forms.OpenFileDialog DlgAc;
        private System.Windows.Forms.SaveFileDialog DlgKaydet;
        private System.Windows.Forms.ToolStripMenuItem mKapat;
        private System.Windows.Forms.ToolStripMenuItem mExceleAktar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.ToolStripComboBox tCmbGrupla;
        private System.Windows.Forms.ToolStripLabel tLblGroup;
        private System.Windows.Forms.ToolStripStatusLabel tlTumu;
        private System.Windows.Forms.TabPage AnaSayfa;
        private System.Windows.Forms.ListView BulguLst;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.ToolStripMenuItem mOzellikEkle;
        private System.Windows.Forms.ToolStripMenuItem mHataBildir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mYardim;
        private System.Windows.Forms.ToolStripMenuItem mDestek;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tXMLAl;
        private System.Windows.Forms.ToolStripButton tXMLVer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tKapat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tExcelAktar;
        private System.Windows.Forms.ToolStripButton tYardim;
        private System.Windows.Forms.ToolStripButton tDestek;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tHataBildir;
        private System.Windows.Forms.ToolStripButton tOzellikEkle;
        private System.Windows.Forms.ToolStripMenuItem tNiteligineGore;
        private System.Windows.Forms.ToolStripMenuItem tKonusunaGore;
        private System.Windows.Forms.ToolStripMenuItem tOnemDerecesineGore;
        private System.Windows.Forms.ToolStripMenuItem tGiderilmeDurumunaGore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem tGruplandırma;
        private System.Windows.Forms.ToolStripStatusLabel tlPlanlama;
        private System.Windows.Forms.ToolStripStatusLabel tlDuzeltme;
        private System.Windows.Forms.ToolStripStatusLabel tlGiderilen;
        private System.Windows.Forms.ToolStripStatusLabel tlGiderilmeyecek;
        private System.Windows.Forms.ToolStripStatusLabel tlTutarsiz;
        private System.Windows.Forms.ToolStripStatusLabel tlIlgi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem tTutarsizligaGore;
        private System.Windows.Forms.ToolStripMenuItem tIlgiliBolumeGore;
        private System.Windows.Forms.ToolStripMenuItem mYonetimBeyani;
        private System.Windows.Forms.ImageList SIcons;
    }
}


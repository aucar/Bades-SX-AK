/****************************************************************************
 * BADES SX AK 2.0 
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Globalization;



namespace bades
{
    public partial class FrmBades : Form
    {

        private ListViewColumnSorter lvwColumnSorter;

        private Point _imageLocation = new Point(20, 5);
        private Point _imgHitArea = new Point(13, 2);

        //XMl nesneleri
        string XmlDosyasi;
        XmlElement root;
        XmlDocument doc = new XmlDocument();
        DateTime DummyDate = new DateTime(1800,1,1);
        string ComboText = "Bulgu Konusuna Göre";
        int BulguListIndex = 0;

        string[] BulguKodlari = { 
			
			"PO01", "PO02", "PO03", "PO04", "PO05", "PO06", "PO07", "PO08", "PO09", "PO10", 
			"AI01", "AI02", "AI03", "AI04", "AI05", "AI06", "AI07", 
			"DS01", "DS02", "DS03", "DS04", "DS05", "DS06", "DS07", "DS08", "DS09", "DS10", "DS11", "DS12", "DS13", 
			"ME01", "ME02", "ME03", "ME04", 
			"MVDT", "KURK", "BRYK", "KKRT", "MHSB", "HZNE", "ADKN", "ÖSİS", "FRPR", "DİĞR", "İÇKS"
		};

        string[] BulguKonulari = {   
			
			"PO.01 - Stratejik bilgi teknolojileri planının tanımlanması", 
			"PO.02 - Bilgi mimarisinin tanımlanması", 
			"PO.03 - Teknolojik yönün belirlenmesi", 
			"PO.04 - Bilgi teknolojisi süreçlerinin, organizasyonunun ve ilişkilerinin tanımlanması", 
			"PO.05 - Bilgi teknolojisi yatırımlarının yönetimi", 
			"PO.06 - Yönetimin amaçlarının ve talimatlarının iletilmesi", 
			"PO.07 - İnsan kaynakları yönetimi", 
			"PO.08 - Kalite yönetimi", 
			"PO.09 - Bilgi sistemleri riskinin değerlendirilmesi ve yönetimi", 
			"PO.10 - Proje yönetimi", 

			"AI.01 - Otomasyon çözümlerinin belirlenmesi", 
			"AI.02 - Uygulama yazılımının geliştirilmesi ve bakımı", 
			"AI.03 - Teknoloji alt yapısının oluşturulması ve bakımı", 
			"AI.04 - Operasyon ve kullanımın sağlanması", 
			"AI.05 - Bilgi sistemleri kaynaklarının karşılanması", 
			"AI.06 - Değişiklik yönetimi", 
			"AI.07 - Sistem çözümlerinin ve değişikliklerin uygulanması ve akredite edilmesi", 

			"DS.01 - Hizmet seviyelerinin tanımlanması ve yönetimi", 
			"DS.02 - Üçüncü kişilerden alınan hizmetlerin yönetimi", 
			"DS.03 - Performans ve kapasite yönetimi", 
			"DS.04 - Hizmet sürekliliğinin sağlanması", 
			"DS.05 - Sistem güvenliğinin sağlanması", 
			"DS.06 - Maliyetlerin belirlenmesi ve dağıtılması", 
			"DS.07 - Kullanıcıların eğitimi", 
			"DS.08 - Hizmet sunumu yönetimi ve olay yönetimi", 
			"DS.09 - Konfigürasyon yönetimi", 
			"DS.10 - Problem yönetimi", 
			"DS.11 - Veri yönetimi", 
			"DS.12 - Fiziksel çevre yönetimi", 
			"DS.13 - Operasyon yönetimi", 

			"ME.01 - Bilgi sistemleri performansının izlenmesi ve değerlendirilmesi", 
			"ME.02 - İç kontrolün izlenmesi ve değerlendirilmesi", 
			"ME.03 - Denetlenenin iç usul ve esasları dahil ilgili mevzuata uyumun sağlanması", 
			"ME.04 - Bilgi sistemlerine ilişkin kurumsal yönetişimin temini", 
			
			"Mevduat", "Kurumsal krediler ", "Bireysel krediler", "Kredi Kartları", "Muhasebe", "Hazine", "Alternatif dağıtım kanalları", "Ödeme sistemleri", "Finansal Raporlama", "Diğer", "İç kontrol sistemi"
			
		};

        string[] AksiyonDurumlari = { "", "Planlama", "Düzeltme", "Giderildi", "Yapılmayacak" };




        /*
        * Bu prosedür aldığı dizeyi 100 karaktere kadar kısaltarak sonuna "..." ekler.
        */
        private string kisalt(string KisaltilacakMetin)
        {

            int uzunluk; string KisaltmaEki;

            if (KisaltilacakMetin.Length > 100)
            {
                uzunluk = 100;
                KisaltmaEki = "...";
            }
            else
            {
                uzunluk = KisaltilacakMetin.Length;
                KisaltmaEki = "";
            }

            string sonuc = KisaltilacakMetin.Substring(0, uzunluk) + KisaltmaEki;
            return sonuc.Trim();
        }



        /*
        * Bu prosedür XML'de yer alan bulgulara ilişkin sayma işlemini gerçekleştirir.
        * xpath : Yürütülecek XPath ifadesidir.
        */
        private int BulguSay(string xpath)
        {

            // XML dosyasını yükle
            XmlDocument doküman = new XmlDocument();
            doküman.Load(XmlDosyasi);
            XmlElement kok;

            // Sorgula
            XmlNodeList Liste;
            kok = doküman.DocumentElement;
            Liste = kok.SelectNodes(xpath);

            return Liste.Count;

        }


        /*
        * Bu prosedür durum çubuğunda yer alan etiketleri gösterir ve biçimlendirir.
        */
        private void DurumCubuguEtiketiGoster(ToolStripStatusLabel Etiket, string metin)
        {
            Etiket.Text = metin;
            Etiket.BorderStyle = Border3DStyle.Sunken;
            Etiket.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        /*
        * Bu prosedür durum çubuğunda yer alan etiketleri temizler ve gizler.
        */
        private void DurumCubuguEtiketiGizle(ToolStripStatusLabel Etiket)
        {
            Etiket.Text = "";
            Etiket.BorderStyle = Border3DStyle.Flat;
            Etiket.BorderSides = ToolStripStatusLabelBorderSides.None;
        }

        /*
        * Bu prosedür Bulgu Listesine üzerinde çalışılan XML dosyasının son halini yükler.
        * XML Aç olayından ve dokümanın güncellenmesini gerektiren diğer olaylardan çağrılır.
        */
        private void DokumaniYukle()
        {

            string logtext = "";
            string HataMetni = "";

            try
            {

                // XML dosyasını yükle
                doc.Load(XmlDosyasi);

                // Tüm nodları seç
                XmlNodeList nodeList;
                root = doc.DocumentElement;
                nodeList = root.SelectNodes("/Bulgular/Bulgu");

                logtext += "XML dosyasında " + nodeList.Count.ToString() + " adet bulgu bulundu.\n\r";

                // Displayi oluştur ve aç
                BulguLst.Visible = true;
                BulguLst.ShowItemToolTips = true;
                BulguLst.Clear();
                BulguLst.BeginUpdate();
                BulguLst.SmallImageList = Icons;

                // Grupları ekle
                int BulguSayaci = 0;
                string bkodulog = "", AksiyonDurumulog = "", Durumlog = "", IlgiliBolumlog = "", AksiyonKodulog = "", baslangictarihilog = "", bitistarihilog = "", TedbirAciklamalog = "";

                foreach (XmlNode title in nodeList)
                {
                    BulguSayaci++;                    

                    string bkodu = "";
                    //int bkodusayaci = 0;
                    try
                    {
                        bkodu = Oku(title["BulguKodu"]);
                   }
                    catch (Exception eerr)
                    {
                        bkodulog += BulguSayaci.ToString() + " nolu bulgudaki BulguKodu okunamadı :" + eerr.ToString() + "\n\r";
                    }
                    

                    int bonem = -1;
                    Color brenk = Color.Black;

                    //Bulgunun aksiyon durumunu bul ve eklenecek ikonu seç
                    string AksiyonD = "";
                    try
                    {
                        AksiyonD = Oku(title["AksiyonDurumu"]);
                    }
                    catch (Exception eerr)
                    {
                        AksiyonDurumulog += BulguSayaci.ToString() + " nolu bulgudaki AksiyonDurumu okunamadı :" + eerr.ToString() + "\n\r";
                    }

                    ListViewItem item = new ListViewItem();
                    try
                    {
                        switch (AksiyonD)
                        {
                            case "T":
                                bonem = 0;
                                break;

                            case "D":
                                bonem = 1;
                                break;

                            case "P":
                                bonem = 2;
                                break;

                            case "X":
                                bonem = 3;
                                break;

                            default:
                                bonem = 4;
                                break;
                        }

                        item = new ListViewItem(bkodu, bonem);
                        item.SubItems.Add(BulguAlaniniGetir(bkodu.Substring(7, 4)));
                    }
                    catch 
                    {
                        MessageBox.Show("Bulgu kodu ve önem derecesi işlenirken hata oluştu. BulguKodu = " + bkodu);
                    }


                    //Bulguyu yaz
                    string durum = "";
                    try
                    {
                        durum = Oku(title["Durum"]);
                        item.SubItems.Add(kisalt(durum));
                        item.ToolTipText = durum.Trim();
                    }
                    catch (Exception eerr)
                    {
                        Durumlog += BulguSayaci.ToString() + " nolu bulgudaki Durum okunamadı :" + eerr.ToString() + "\n\r";
                    }

                    


                    //İlgili Bölümü Yaz
                    string IlgiliBolum = "";
                    try
                    {
                        IlgiliBolum = Oku(title["IlgiliBolum"]);
                        item.SubItems.Add(IlgiliBolum);
                    }
                    catch (Exception eerr)
                    {
                        IlgiliBolumlog += BulguSayaci.ToString() + " nolu bulgudaki IlgiliBolum okunamadı :" + eerr.ToString() + "\n\r";
                    }



                    //Aksiyon Durumunu yaz
                    string AksiyonDurumu;
                    string AksiyonKodu = "";
                    try
                    {
                        AksiyonKodu = Oku(title["AksiyonDurumu"]);
                        switch (AksiyonKodu)
                        {
                            case "P":
                                AksiyonDurumu = "Planlama";
                                break;

                            case "D":
                                AksiyonDurumu = "Düzeltme";
                                break;

                            case "T":
                                AksiyonDurumu = "Giderildi";
                                break;

                            case "X":
                                AksiyonDurumu = "Yapılmayacak";
                                break;

                            default:
                                AksiyonDurumu = AksiyonKodu;
                                brenk = Color.Black;
                                break;
                        }

                        item.SubItems.Add(AksiyonDurumu);
                    }
                    catch (Exception eerr)
                    {
                        AksiyonKodulog += BulguSayaci.ToString() + " nolu bulgudaki AksiyonDurumu okunamadı :" + eerr.ToString() + "\n\r";
                    }




                    DateTime bitis = new DateTime(), baslangic = new DateTime();
                    string baslangictarihitxt = "", bitistarihitxt = "";

                    //Başlangıç tarihini al
                    try
                    {
                        baslangictarihitxt = Oku(title["AksiyonBasTarih"]);
                        baslangic = TarihiOku(baslangictarihitxt);

                        if (baslangic != DummyDate)
                        {
                            baslangictarihitxt = baslangic.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
                        }
                        else
                        {
                            baslangictarihitxt = "";
                        }

                    }
                    catch (Exception eerr)
                    {
                        baslangictarihilog += BulguSayaci.ToString() + " nolu bulgudaki AksiyonBasTarih okunamadı :" + eerr.ToString() + "\n\r";
                    }


                    //Aksiyon Tamamlanma Tarihini yaz
                    try
                    {
                        bitistarihitxt = Oku(title["AksiyonTamTarih"]);
                        bitis = TarihiOku(bitistarihitxt);
                        
                        if (bitis != DummyDate)
                        {
                            bitistarihitxt = bitis.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
                        }
                        else
                        {
                            bitistarihitxt = "";
                        }
                        
                        item.SubItems.Add(bitistarihitxt);
                    }
                    catch (Exception eerr)
                    {
                        bitistarihilog += BulguSayaci.ToString() + " nolu bulgudaki AksiyonTamTarih okunamadı :" + eerr.ToString() + "\n\r";
                    }



                    //Tedbir Açıklamayı yaz
                    string TedbirAciklama = "";
                    try
                    {
                        TedbirAciklama = Oku(title["TedbirAciklama"]);
                        item.SubItems.Add(TedbirAciklama);
                    }
                    catch (Exception eerr)
                    {
                        TedbirAciklamalog += BulguSayaci.ToString() + " nolu bulgudaki TedbirAciklama okunamadı :" + eerr.ToString() + "\n\r";
                    }

                    //Tutarsızlığı yaz
                    string tutarsizlik = "Tutarsızlık Yok";

                    //Aksiyon planı çok kısa
                    if (Oku(title["TedbirAciklama"]).Trim().Length < 40) tutarsizlik = "[İLGİ] Aksiyon Detayları Çok Kısa.";

                    //Tamamlanma tarihi çok uzun
                    TimeSpan zamanaraligi = bitis - DateTime.Today;                    
                    if ((zamanaraligi.Days >= 500 ) && ((Oku(title["AksiyonDurumu"]).Trim() == "D") || (Oku(title["AksiyonDurumu"]).Trim() == "P"))) tutarsizlik = "[İLGİ] Tamamlanma tarihi çok uzun.";
                    
                    //Giderilmeyecek Dendiği Halde Tamamlanma Tarihi Olan Bulgu
                    if ((bitis != DummyDate) && (Oku(title["AksiyonDurumu"]).Trim() == "X")) tutarsizlik = "[İLGİ] Bulgu Giderilmeyecek Görünüyor Ancak Tamamlanma Tarihi Verilmiş.";
                    
                    //Tamamlanma Tarihi Başlangıç Tarihinden Önce
                    if (bitis < baslangic) tutarsizlik = "[HATA] Tamamlanma Tarihi Başlangıç Tarihinden Önce.";

                    //Bulgu tarihinden önce başlanmış bulgu
                    if ((baslangic < TarihiOku(bkodu.Substring(0, 4))) && (baslangic != DummyDate)) tutarsizlik = "[HATA] Aksiyon Başlama Tarihi Bulgu Tarihinden Önce.";

                    //Bulgu tarihinden önce tamamlanmış bulgu
                    if ((bitis < TarihiOku(bkodu.Substring(0, 4))) && (bitis != DummyDate)) tutarsizlik = "[HATA] Aksiyon Bitiş Tarihi Bulgu Tarihinden Önce.";

                    //Aksiyon Tamamlanma Tarihi Geçmiş Bulgu
                    if ((bitis <= DateTime.Today) && (Oku(title["AksiyonDurumu"]).Trim() == "D" || Oku(title["AksiyonDurumu"]).Trim() == "P")) tutarsizlik = "[HATA] Aksiyon Planlama/Düzeltme Aşamasında Görünüyor Ancak Tamamlanma Tarihi Geçmiş.";

                    //Giderildi Dendiği Halde Tamamlanma Tarihi Gelecekte Olan Bulgu
                    if ((bitis >= DateTime.Today) && (Oku(title["AksiyonDurumu"]).Trim() == "T")) tutarsizlik = "[HATA] Bulgu Giderilmiş Görünüyor Ancak Tamamlanma Tarihi İleriki Bir Tarih.";

                    //Aksiyon Durumu Belirtilmemiş Bulgu
                    if (Oku(title["AksiyonDurumu"]).Trim() == "") tutarsizlik = "[HATA] Aksiyon Durumu Belirtilmemiş.";

                    //Aksiyon Tamamlanma Tarihi Belirtilmemiş Bulgu
                    if ((bitis == DummyDate) && (Oku(title["AksiyonDurumu"]).Trim() != "X")) tutarsizlik = "[HATA] Aksiyon Tamamlanma Tarihi Belirtilmemiş.";

                    //Tedbir Açıklama Belirtilmemiş Bulgu
                    if (Oku(title["TedbirAciklama"]).Trim() == "") tutarsizlik = "[HATA] Alınan Aksiyon Belirtilmemiş.";

                    //Aksiyon Belirtilmemiş Bulgu
                    if ((bitis == DummyDate) && (Oku(title["AksiyonDurumu"]).Trim() == "") && (Oku(title["TedbirAciklama"]).Trim() == "")) tutarsizlik = "[HATA] Aksiyon Planı Yok.";


                    //Satırı tutarsızlık koduna göre renklendir
                    item.SubItems.Add(tutarsizlik);

                    if (tutarsizlik.Substring(0, 6) == "[HATA]")
                    {
                        brenk = Color.DarkRed;
                    }
                    else
                    {
                        if (tutarsizlik.Substring(0, 6) == "[İLGİ]")
                        {
                            brenk = Color.DarkOrange;
                        }
                    }

                    //Satır rengini belirle
                    item.ForeColor = brenk;
                    BulguLst.Items.Add(item);

                }

                // Sütun başlıklarını yaz
                BulguLst.Columns.Add("Bulgu Kodu", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Konu", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Bulgu", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("İlgili Bölüm", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Aksiyon Durumu", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Tamamlanma Tarihi", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Alınan Aksiyon", -1, HorizontalAlignment.Left);
                BulguLst.Columns.Add("Tutarsızlık", -1, HorizontalAlignment.Left);

                //Sütunları genişlet
                BulguLst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                //Listeyi göster
                BulguLst.EndUpdate();

                //Comboyu aç ve grupla - Denetim Konuları
                tCmbGrupla.Enabled = true;
                CmbGrupla_Degistir(ComboText);
                //(tCmbGrupla as IPostBackDataHandler).RaisePostDataChangedEvent(null, null);
                BulguLst.Items[BulguListIndex].Selected = true;
                BulguLst.EnsureVisible(BulguListIndex);

                //KonusunaGoreGrupla();


                BulguLst.Refresh();

                //Status barı düzenle
                DurumCubuguEtiketiGoster(tlTumu, "Toplam Bulgu: " + nodeList.Count.ToString());
                DurumCubuguEtiketiGoster(tlPlanlama, "Planlanmış Bulgu: " + BulguSay("/Bulgular/Bulgu/AksiyonDurumu[.  ='P']").ToString());
                DurumCubuguEtiketiGoster(tlDuzeltme, "Düzeltilen Bulgu: " + BulguSay("/Bulgular/Bulgu/AksiyonDurumu[.  ='D']").ToString());
                DurumCubuguEtiketiGoster(tlGiderilen, "Giderilmiş Bulgu: " + BulguSay("/Bulgular/Bulgu/AksiyonDurumu[.  ='T']").ToString());
                DurumCubuguEtiketiGoster(tlGiderilmeyecek, "Giderilmeyecek Bulgu: " + BulguSay("/Bulgular/Bulgu/AksiyonDurumu[.  ='X']").ToString());
                //DurumCubuguEtiketiGoster(tlTutarsiz, "Aksiyon Belirtilmemiş Bulgu: " + BulguSay("/Bulgular/Bulgu[not(AksiyonDurumu) or  AksiyonDurumu ='']").ToString());

                //Tutarsız bulgu sayısını
                int tutarsizbulgusayisi = 0;
                foreach (ListViewItem item in BulguLst.Items)
                    if (item.SubItems[7].Text.Substring(0, 6) == "[HATA]") tutarsizbulgusayisi++;
                DurumCubuguEtiketiGoster(tlTutarsiz, "Tutarsız Bulgu: " + tutarsizbulgusayisi.ToString());

                //İlgi gerektiren bulgu sayısını yaz
                int ilgilibulgusayisi = 0;
                foreach (ListViewItem item in BulguLst.Items)
                    if (item.SubItems[7].Text.Substring(0, 6) == "[İLGİ]") ilgilibulgusayisi++;
                DurumCubuguEtiketiGoster(tlIlgi, "İlgilenilecek Bulgu: " + ilgilibulgusayisi.ToString());


                //Menüleri düzenle
                mKapat.Enabled = true;
                tKapat.Enabled = true;
                mXMLVer.Enabled = true;
                tXMLVer.Enabled = true;
                mExceleAktar.Enabled = true;
                tExcelAktar.Enabled = true;
                mYonetimBeyani.Enabled = true;

                //Gruplandırma menüsünü aktif et
                foreach (ToolStripItem item in mGruplandirma.DropDownItems)
                {
                    if (item.GetType().Name == "ToolStripMenuItem")
                    {
                        (item as ToolStripMenuItem).Enabled = true;

                    }
                }

                HataMetni = bkodulog + AksiyonDurumulog + Durumlog + IlgiliBolumlog + AksiyonKodulog + baslangictarihilog + bitistarihilog + TedbirAciklamalog;


            }
            catch (Exception ex)
            {
                MessageBox.Show("XML Dosyası yüklenirken bir hata oluştu : \n\r" 
                                + logtext + "\n\r" 
                                + HataMetni + "\n\r" 
                                + ex.ToString());
            }
        }

        /*
        * Bu prosedür ekranı temizler.
        * Program ilk açıldığında ve doküman kapatıldığında çağrılır.
        */

        private void DokumaniKapat()
        {
            //Listeyi temizle
            BulguLst.Clear();
            BulguLst.Visible = false;

            //Comboyu kapat
            tCmbGrupla.SelectedIndex = -1;
            tCmbGrupla.Enabled = false;

            //Status barı düzenle
            DurumCubuguEtiketiGizle(tlTumu);
            DurumCubuguEtiketiGizle(tlPlanlama);
            DurumCubuguEtiketiGizle(tlDuzeltme);
            DurumCubuguEtiketiGizle(tlGiderilen);
            DurumCubuguEtiketiGizle(tlGiderilmeyecek);
            DurumCubuguEtiketiGizle(tlTutarsiz);
            DurumCubuguEtiketiGizle(tlIlgi);

            //Menüleri düzenle
            mKapat.Enabled = false;
            tKapat.Enabled = false;
            mXMLVer.Enabled = false;
            tXMLVer.Enabled = false;
            mExceleAktar.Enabled = false;
            tExcelAktar.Enabled = false;
            mYonetimBeyani.Enabled = false;


            //Gruplandırma menüsünü kapat
            foreach (ToolStripItem item in mGruplandirma.DropDownItems)
            {
                if (item.GetType().Name == "ToolStripMenuItem")
                {
                    (item as ToolStripMenuItem).Enabled = false;
                    (item as ToolStripMenuItem).Checked = false;

                }
            }

            //Diğer tabları kapat
            foreach (TabPage page in Tab.TabPages)
                if (page.Name != "AnaSayfa") Tab.TabPages.Remove(page);

        }


        /*
        * Bu prosedür BADES sistemine yüklenmek üzere XML dosyası oluşturur.
        * dosyaadi parametresiyle gelen dosyaya kayıt yapılır.
        */

        private void XMLVer(string dosyaadi)
        {
            XmlDocument KaynakDoc = new XmlDocument();
            KaynakDoc.Load(XmlDosyasi);

            XmlNode KaynakKok = KaynakDoc.DocumentElement;

            XmlDocument HedefDoc = new XmlDocument();
            HedefDoc.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + System.Environment.NewLine +
            "<Bulgular>" + System.Environment.NewLine +
            "</Bulgular>" + System.Environment.NewLine);

            XmlNode GonderilecekBulgu;

            foreach (XmlNode bulgu in KaynakKok.ChildNodes)
            {
                GonderilecekBulgu = HedefDoc.CreateElement("Bulgu");

                string yeniXML =

                "<Id>" + Oku(bulgu["Id"]) + "</Id>" + System.Environment.NewLine +
                "<BulguKodu>" + Oku(bulgu["BulguKodu"]) + "</BulguKodu>" + System.Environment.NewLine +
                "<Durum><![CDATA[" + Oku(bulgu["Durum"]) + "]]></Durum>" + System.Environment.NewLine +
                "<TedbirAciklama><![CDATA[" + Oku(bulgu["TedbirAciklama"]) + "]]></TedbirAciklama>" + System.Environment.NewLine +
                "<AksiyonBasTarih>" + Oku(bulgu["AksiyonBasTarih"]) + "</AksiyonBasTarih>" + System.Environment.NewLine +
                "<AksiyonTamTarih>" + Oku(bulgu["AksiyonTamTarih"]) + "</AksiyonTamTarih>" + System.Environment.NewLine +
                "<AksiyonDurumu>" + Oku(bulgu["AksiyonDurumu"]) + "</AksiyonDurumu>";

                GonderilecekBulgu.InnerXml = yeniXML;

                HedefDoc.DocumentElement.AppendChild(GonderilecekBulgu);

            }

            HedefDoc.Save(dosyaadi);
        }



        /*
        * Bu prosedür bulgu alanı kodunu parametre olarak alır. (PO01, AI02, MEVD vs.)
        * Bulgu konusunu döndürür ("PO.01 - Stratejik bilgi teknolojileri planının tanımlanması")
        */
        private string BulguAlaniniGetir(string kod)
        {
          
            string sonuc = "";
            try
            {
                sonuc = BulguKonulari[Array.IndexOf(BulguKodlari, kod)].Trim();
            }
            catch
            {
                sonuc = "Bilinmeyen Kod : " + kod;
            }

            return sonuc;
        }


        /*
        * Bu prosedür satır sonu karakteriyle ilgili sorunları düzeltir.
        */
        private string TextTemizle(string metin)
        {
            return metin.Replace("\n", Environment.NewLine).Trim();
        }


        /*
        * Bu prosedür oluşturulacak TAB'a label ekler.
        */
        private void LabelEkle(Label LabelAdi, string LabelText, int x, int y, int width, int height, TabPage parent)
        {
            LabelAdi.Location = new System.Drawing.Point(x, y);
            LabelAdi.Size = new System.Drawing.Size(width, height);
            LabelAdi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            LabelAdi.BackColor = Color.Transparent;
            LabelAdi.Text = LabelText;
            parent.Controls.Add(LabelAdi);
        }

        /*
        * Bu prosedür oluşturulacak TAB'a combo ekler.
        */
        private void ComboEkle(ComboBox ComboAdi, string ComboText, int x, int y, int width, int height, TabPage parent)
        {
            ComboAdi.Location = new System.Drawing.Point(x, y);
            ComboAdi.Size = new System.Drawing.Size(width, height);
            ComboAdi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            ComboAdi.BackColor = Color.White;
            ComboAdi.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboAdi.Text = ComboText;
            parent.Controls.Add(ComboAdi);
        }

        /*
        * Bu prosedür oluşturulacak TAB'a text ekler.
        */
        private void TextEkle(TextBox TextAdi, string TextText, int x, int y, int width, int height, bool multiline, bool saltokunur, TabPage parent)
        {
            TextAdi.Location = new System.Drawing.Point(x, y);
            TextAdi.Size = new System.Drawing.Size(width, height);
            TextAdi.Text = TextTemizle(TextText);
            TextAdi.Multiline = multiline;
            TextAdi.ReadOnly = saltokunur;
            TextAdi.BackColor = Color.White;
            parent.Controls.Add(TextAdi);
            TextAdi.Enter += new System.EventHandler(this.aktiftxtbox_Enter);
            TextAdi.Leave += new System.EventHandler(this.aktiftxtbox_Leave);
        }

        /*
        * Bu prosedür oluşturulacak TAB'a tarih biçimli formatted_text ekler.
        */
        private void TarihEkle(MaskedTextBox TarihAdi, string TarihText, int x, int y, int width, int height, TabPage parent)
        {

            TarihAdi.Mask = "00,00,0000";
            TarihAdi.Location = new System.Drawing.Point(x, y);
            TarihAdi.Size = new System.Drawing.Size(width, height);
            TarihAdi.Text = TarihText;
            TarihAdi.BackColor = Color.White;
            TarihAdi.TabStop = true;
            parent.Controls.Add(TarihAdi);

        }

        /*
        * Bu prosedür oluşturulacak TAB'a buton ekler.
        */
        private void ButonEkle(Button ButonAdi, string ButonText, int x, int y, int width, int height, TabPage parent)
        {
            ButonAdi.Location = new System.Drawing.Point(x, y);
            ButonAdi.Size = new System.Drawing.Size(width, height);
            ButonAdi.Text = ButonText;
            ButonAdi.UseVisualStyleBackColor = true;
            ButonAdi.TabStop = true;
            parent.Controls.Add(ButonAdi);
        }


        /*
        * Bu prosedür çift tıklanan bulguya dayanarak yeni text ekler.
        */
        private void TabEkle(string BulguKodu)
        {
            // İlgili nodu bul
            XmlNode title = root.SelectSingleNode("/Bulgular/Bulgu[BulguKodu='" + BulguKodu + "']");

            // Tabı oluştur
            TabPage tabPage = new TabPage();
            tabPage.Text = BulguKodu;
            tabPage.BackColor = Color.White;
            tabPage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

            // Tabı sayfalara ekle
            Tab.TabPages.Add(tabPage);

            Label LblBKodu, LblKriter, LblDurum, LblIsRiski, LblDenetleneninGorusu, LblSonucDegerlendirilmesi, LblBaslangicTarihi, LblBitisTarihi, LblAksiyonDurumu, LblTedbir, LblIlgiliBolum;
            TextBox TxtBKodu, TxtKriter, TxtDurum, TxtIsRiski, TxtDenetleneninGorusu, TxtSonucDegerlendirilmesi, TxtTedbir, TxtIlgiliBolum;
            ComboBox CmbAksiyonDurumu;
            MaskedTextBox DtpBaslangicTarihi, DtpBitisTarihi;


            ///
            /// SOL TARAF
            /// 

            //Bulgu Kodunu Yaz
            LabelEkle(LblBKodu = new Label(), "Bulgu Kodu", 4, 11, 85, 18, tabPage);
            TextEkle(TxtBKodu = new TextBox(), title["BulguKodu"].InnerText, 90, 11, 350, 100, false, true, tabPage);
            TxtBKodu.Name = "TxtBKodu";

            //Bulgu Kriterini Yaz
            LabelEkle(LblKriter = new Label(), "Kriter", 4, 38, 85, 18, tabPage);
            TextEkle(TxtKriter = new TextBox(), title["Kriter"].InnerText, 90, 38, 350, 100, true, true, tabPage);
            TxtKriter.Name = "TxtKriter";

            //Bulgu Durumunu Yaz
            LabelEkle(LblDurum = new Label(), "Durum", 4, 144, 85, 72, tabPage);
            TextEkle(TxtDurum = new TextBox(), title["Durum"].InnerText, 90, 144, 350, 100, true, true, tabPage);
            TxtDurum.ForeColor = Color.DarkRed;
            TxtDurum.Name = "TxtDurum";

            //İş Riskini Yaz
            LabelEkle(LblIsRiski = new Label(), "İş Riski", 4, 250, 85, 72, tabPage);
            TextEkle(TxtIsRiski = new TextBox(), title["IsRiski"].InnerText, 90, 250, 350, 100, true, true, tabPage);
            TxtIsRiski.Name = "TxtIsRiski";

            //Denetlenen Görüşünü Yaz
            LabelEkle(LblDenetleneninGorusu = new Label(), "Denetlenen Görüşü", 4, 356, 85, 72, tabPage);
            TextEkle(TxtDenetleneninGorusu = new TextBox(), title["DenetleneninGorusu"].InnerText, 90, 356, 350, 100, true, true, tabPage);
            TxtDenetleneninGorusu.Name = "TxtDenetleneninGorusu";

            //Sonuc Değerlendirmesini Yaz
            LabelEkle(LblSonucDegerlendirilmesi = new Label(), "Sonuç Değerlendirmesi", 4, 462, 85, 72, tabPage);
            TextEkle(TxtSonucDegerlendirilmesi = new TextBox(), title["SonucDegerlendirmesi"].InnerText, 90, 462, 350, 100, true, true, tabPage);
            TxtSonucDegerlendirilmesi.Name = "TxtSonucDegerlendirilmesi";

            ///
            /// SAĞ TARAF
            /// 

            //İlgili Bölüm
            LabelEkle(LblIlgiliBolum = new Label(), "İlgili Bölüm", 500, 11, 120, 18, tabPage);
            TextEkle(TxtIlgiliBolum = new TextBox(), Oku(title["IlgiliBolum"]), 625, 11, 150, 18, false, false, tabPage);
            TxtIlgiliBolum.Name = "TxtIlgiliBolum";
            TxtIlgiliBolum.TabIndex = 11;


            // BaşlangıçTarihi
            LabelEkle(LblBaslangicTarihi = new Label(), "Başlangıç Tarihi", 500, 38, 120, 18, tabPage);
            TarihEkle(DtpBaslangicTarihi = new MaskedTextBox(), Oku(title["AksiyonBasTarih"]), 625, 38, 150, 100, tabPage);
            DtpBaslangicTarihi.Name = "DtpBaslangicTarihi";
            DtpBaslangicTarihi.TabIndex = 12;

             // BitişTarihi
            LabelEkle(LblBitisTarihi = new Label(), "Bitiş Tarihi", 500, 65, 120, 18, tabPage);
            TarihEkle(DtpBitisTarihi = new MaskedTextBox(), Oku(title["AksiyonTamTarih"]), 625, 65, 150, 100, tabPage);
            DtpBitisTarihi.Name = "DtpBitisTarihi";
            DtpBitisTarihi.TabIndex = 13;

            //Aksiyon durumunu yaz
            LabelEkle(LblAksiyonDurumu = new Label(), "Aksiyon Durumu", 500, 92, 120, 18, tabPage);
            CmbAksiyonDurumu = new ComboBox();
            CmbAksiyonDurumu.Items.AddRange(AksiyonDurumlari);

            //Aksiyon Durumunu seç
            string AksiyonKodu = Oku(title["AksiyonDurumu"]);
            string AksiyonDurumu;

            switch (AksiyonKodu)
            {
                case "P":
                    AksiyonDurumu = "Planlama";
                    break;
                case "D":
                    AksiyonDurumu = "Düzeltme";
                    break;
                case "T":
                    AksiyonDurumu = "Giderildi";
                    break;
                case "X":
                    AksiyonDurumu = "Yapılmayacak";
                    break;

                default:
                    AksiyonDurumu = AksiyonKodu;
                    break;
            }


            ComboEkle(CmbAksiyonDurumu, AksiyonDurumu, 625, 92, 150, 100, tabPage);
            CmbAksiyonDurumu.Name = "CmbAksiyonDurumu";
            CmbAksiyonDurumu.TabIndex = 14;


            //Tedbir Açıklama Yaz
            LabelEkle(LblTedbir = new Label(), "Tedbir / Açıklama", 500, 119, 120, 18, tabPage);
            TextEkle(TxtTedbir = new TextBox(), Oku(title["TedbirAciklama"]), 625, 119, 350, 300, true, false, tabPage);
            TxtTedbir.Name = "TxtTedbir";
            TxtTedbir.TabIndex = 15;

            //Bu aksiyonu kaydet
            Button BtnAksiyonKaydet;
            ButonEkle(BtnAksiyonKaydet = new Button(), "Kaydet && Kapat", 625, 430, 150, 28, tabPage);
            BtnAksiyonKaydet.Click += new System.EventHandler(this.guncelle_click);
            BtnAksiyonKaydet.TabIndex = 16;

            //Kapat
            Button BtnKapat;
            ButonEkle(BtnKapat = new Button(), "Kapat", 790, 430, 150, 28, tabPage);
            BtnKapat.Click += new System.EventHandler(this.kapat_click);
            BtnKapat.TabIndex = 17;

            Tab.SelectTab(tabPage);
            TxtIlgiliBolum.Focus();
        }

        /*
        * Bu prosedür XML dosyasından ilgili nodu okur.
        */
        private string Oku(XmlNode title)
        {
            string val = "";
            if (title != null) val = title.InnerText.Trim();
            return val;

        }

        /*
        * Bu prosedür metni tarihe çevirir.
        */
        private DateTime TarihiOku(string metin)
        {
            DateTime val;

            //Eğer gelen veri 4 karakterse bu bir yıldır.
            if (metin.Length == 4) val = new DateTime(Convert.ToInt16(metin), 1, 1);
            else
            {
                if (metin != "")
                {
                    try
                    {
                        val = (DateTime)(TypeDescriptor.GetConverter(new DateTime(1981, 1, 4)).ConvertFrom(metin.Trim()));
                    }
                    catch (Exception)
                    {
                        //Metinde sorun varsa 01.01.1800 tarihini dönder
                        val = DummyDate;
                    }
                }
                else
                {
                    //Metinde sorun varsa 01.01.1800 tarihini dönder
                    val = DummyDate;
                }
            }
            return val;
        }


        /*
        * Bu prosedür üzerinde çalışılan bulguyu kaydeder.
        * Page parametresiyle üzerinde çalışılan sayfa BulguKodu parametresiyle de 
        * üzeinde çalışılan bulgu kodu alınır.
        */
        private void BulguGuncelle(TabPage Page, string BulguKodu)
        {
            XmlNode oldCd;
            XmlElement root = doc.DocumentElement;
            oldCd = root.SelectSingleNode("/Bulgular/Bulgu[BulguKodu='" + BulguKodu + "']");

            XmlElement newCd = doc.CreateElement("Bulgu");

            string AksiyonKodu;
            switch (Page.Controls["CmbAksiyonDurumu"].Text)
            {
                case "Planlama":
                    AksiyonKodu = "P";
                    break;

                case "Düzeltme":
                    AksiyonKodu = "D";
                    break;

                case "Giderildi":
                    AksiyonKodu = "T";
                    break;

                case "Yapılmayacak":
                    AksiyonKodu = "X";
                    break;

                default:
                    AksiyonKodu = "";
                    break;
            }


            DateTime bas, bit;
            string bastxt = Page.Controls["DtpBaslangicTarihi"].Text.Trim();
            string bittxt = Page.Controls["DtpBitisTarihi"].Text.Trim();

            //Eğer tarih formatlarında hata varsa tarih formatını boşluk olarak yaz
            try { bas = (DateTime)(TypeDescriptor.GetConverter(new DateTime(1981, 1, 4)).ConvertFrom(bastxt)); }
            catch { bastxt = ""; }

            try { bit = (DateTime)(TypeDescriptor.GetConverter(new DateTime(1981, 1, 4)).ConvertFrom(bittxt)); }
            catch { bittxt = ""; }


            string yeniXML =
            "<Id>" + Oku(oldCd["Id"]) + "</Id>" + System.Environment.NewLine +
            "<BulguKodu>" + Oku(oldCd["BulguKodu"]) + "</BulguKodu>" + System.Environment.NewLine +
            "<Istirak>" + Oku(oldCd["Istirak"]) + "</Istirak>" + System.Environment.NewLine +
            "<Kriter><![CDATA[" + Oku(oldCd["Kriter"]) + "]]></Kriter>" + System.Environment.NewLine +
            "<Durum><![CDATA[" + Oku(oldCd["Durum"]) + "]]></Durum>" + System.Environment.NewLine +
            "<IsRiski><![CDATA[" + Oku(oldCd["IsRiski"]) + "]]></IsRiski>" + System.Environment.NewLine +
            "<DenetleneninGorusu><![CDATA[" + Oku(oldCd["DenetleneninGorusu"]) + "]]></DenetleneninGorusu>" + System.Environment.NewLine +
            "<SonucDegerlendirmesi><![CDATA[" + Oku(oldCd["SonucDegerlendirmesi"]) + "]]></SonucDegerlendirmesi>" + System.Environment.NewLine +
            "<Konsolide>" + Oku(oldCd["Konsolide"]) + "</Konsolide>" + System.Environment.NewLine +
            "<KonsolideAciklama><![CDATA[" + Oku(oldCd["KonsolideAciklama"]) + "]]></KonsolideAciklama>" + System.Environment.NewLine +
            "<BulgununDurumu>" + Oku(oldCd["BulgununDurumu"]) + "</BulgununDurumu>" + System.Environment.NewLine + System.Environment.NewLine +

            "<IlgiliBolum>" + Page.Controls["TxtIlgiliBolum"].Text + "</IlgiliBolum>" + System.Environment.NewLine +
            "<TedbirAciklama><![CDATA[" + Page.Controls["TxtTedbir"].Text + "]]></TedbirAciklama>" + System.Environment.NewLine +
            "<AksiyonBasTarih>" + bastxt + "</AksiyonBasTarih>" + System.Environment.NewLine +
            "<AksiyonTamTarih>" + bittxt + "</AksiyonTamTarih>" + System.Environment.NewLine +
            "<AksiyonDurumu>" + AksiyonKodu + "</AksiyonDurumu>";


            newCd.InnerXml = yeniXML;

            root.ReplaceChild(newCd, oldCd);

            //Sonucu kaydet
            doc.Save(XmlDosyasi);

            //Tazele
            DokumaniYukle();

            this.Tab.TabPages.Remove(Tab.SelectedTab);
        }




        /****************************************************************************
         *
         * 
         *                           GRUPLANDIRMA PROSEDÜRLERİ
         * 
         * 
         ****************************************************************************/



        /*
        * Bu prosedür listeyi bulguların önem derecesine göre gruplar.
        */
        private void OnemDerecesineGoreGrupla()
        {
            //Menüleri düzelt
            tOnemDerecesineGore.Checked = true;
            MenuleriResetle_Click(tOnemDerecesineGore);
            tCmbGrupla.Text = "Bulgunun Önem Derecesine Göre";

            //Grupları ekle
            BulguLst.Groups.Add(new ListViewGroup("Önemli Kontrol Eksikliği", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Kayda Değer Kontrol Eksikliği", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Kontrol Zayıflığı", HorizontalAlignment.Left));

            //Öğeleri ekle
            foreach (ListViewItem item in BulguLst.Items)
            {

                //Grup seç
                //son iki karaktere bakarak önem derecesini bul
                switch (item.Text.Substring(item.Text.Length - 2))
                {
                    case "ÖK":
                        item.Group = BulguLst.Groups[0];
                        break;

                    case "KD":
                        item.Group = BulguLst.Groups[1];
                        break;

                    case "KZ":
                        item.Group = BulguLst.Groups[2];
                        break;

                    default:
                        break;
                };
            }
        }


        /*
        * Bu prosedür listeyi bulgulara alınan aksiyonlara göre gruplar.
        */
        private void GiderilmeDurumunaGoreGrupla()
        {
            //Menüleri düzelt
            tGiderilmeDurumunaGore.Checked = true;
            MenuleriResetle_Click(tGiderilmeDurumunaGore);
            tCmbGrupla.Text = "Bulguya Alınan Aksiyona Göre";

            //Grupları ekle
            BulguLst.Groups.Add(new ListViewGroup("Aksiyon Belirtilmemiş Bulgular", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Planlama Aşamasındaki Bulgular", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Düzeltme Aşamasındaki Bulgular", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Giderilen Bulgular", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Giderilmeyecek Bulgular", HorizontalAlignment.Left));

            //Öğeleri ekle
            foreach (ListViewItem item in BulguLst.Items)
            {

                //Grup seç
                switch (item.SubItems[4].Text)
                {
                    case "Planlama":
                        item.Group = BulguLst.Groups[1];
                        break;

                    case "Düzeltme":
                        item.Group = BulguLst.Groups[2];
                        break;

                    case "Giderildi":
                        item.Group = BulguLst.Groups[3];
                        break;

                    case "Yapılmayacak":
                        item.Group = BulguLst.Groups[4];
                        break;

                    default:
                        item.Group = BulguLst.Groups[0];
                        break;
                }

                ;

            }
        }


        /*
        * Bu prosedür listeyi bulguların niteliğine göre gruplar.
        */
        private void NiteligineGoreGrupla()
        {

            //Menüleri düzelt
            tNiteligineGore.Checked = true;
            MenuleriResetle_Click(tNiteligineGore);
            tCmbGrupla.Text = "Bulgu Niteliğine Göre";

            //Grupları ekle
            BulguLst.Groups.Add(new ListViewGroup("İç kontrol ve iç denetim yapısına ilişkin değerlendirme", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Banka bilgi sistemleri denetimi (COBIT)", HorizontalAlignment.Left));
            BulguLst.Groups.Add(new ListViewGroup("Bankacılık süreçleri denetimi (Uygulama Kontrolleri)", HorizontalAlignment.Left));


            //Öğeleri ekle
            foreach (ListViewItem item in BulguLst.Items)
            {

                //Grup seç
                switch (item.Text.Substring(7, 4))
                {
                    case "İÇKS":
                        item.Group = BulguLst.Groups[0];
                        break;

                    case "MVDT":
                    case "KURK":
                    case "BRYK":
                    case "KKRT":
                    case "MHSB":
                    case "HZNE":
                    case "ADKN":
                    case "ÖSİS":
                    case "FRPR":
                    case "DİĞR":
                        item.Group = BulguLst.Groups[2];
                        break;

                    default:
                        item.Group = BulguLst.Groups[1];
                        break;
                }

                ;

            }
        }

        /*
        * Bu prosedür listeyi bulguların yılına göre gruplar.
        */
        private void YilaGoreGrupla()
        {
            //Menüleri düzelt
            tCmbGrupla.Text = "Bulgu Tespit Yılına Göre";
            tTariheGore.Checked = true;
            MenuleriResetle_Click(tTariheGore);

            //Grupları ve öğeleri ekle
            List<string> yillar = new List<string>();

            foreach (ListViewItem item in BulguLst.Items)
            {
                string yil = item.Text.Substring(0, 4);
                int yilindex;

                if (yillar.IndexOf(yil) > -1)
                {
                    yilindex = yillar.IndexOf(yil);
                }
                else
                {
                    yillar.Add(yil);
                    BulguLst.Groups.Add(new ListViewGroup(yil, HorizontalAlignment.Left));
                    yilindex = yillar.Count - 1;
                }

                item.Group = BulguLst.Groups[yilindex];
            }

        }


        /*
        * Bu prosedür listeyi bulguların konusuna göre gruplar.
        */
        private void KonusunaGoreGrupla()
        {
            //Menüleri düzelt
            tCmbGrupla.Text = "Bulgu Konusuna Göre";
            tKonusunaGore.Checked = true;
            MenuleriResetle_Click(tKonusunaGore);

            //Grupları ekle
            foreach (string konu in BulguKodlari)
                BulguLst.Groups.Add(new ListViewGroup(BulguAlaniniGetir(konu), HorizontalAlignment.Left));

            //Hatalı grupları ekle
            BulguLst.Groups.Add(new ListViewGroup("Bilinmeyen Kod", HorizontalAlignment.Left));

            //Öğeleri ekle
            foreach (ListViewItem item in BulguLst.Items)
            {
                //Grup seç
                try
                {
                    item.Group = BulguLst.Groups[Array.IndexOf(BulguKodlari, item.Text.Substring(7, 4))];
                }
                catch
                {
                    item.Group = BulguLst.Groups[BulguLst.Groups.Count-1];
                }
            }
        }


        /*
        * Bu prosedür listeyi bulguların ilgili olduğu bölüme göre gruplar.
        */

        private void IlgiliBolumeGoreGrupla()
        {
            //Menüleri düzelt
            tCmbGrupla.Text = "Bulgunun İlgili Olduğu Bölüme Göre";
            tIlgiliBolumeGore.Checked = true;
            MenuleriResetle_Click(tIlgiliBolumeGore);

            //Grupları ve öğeleri ekle
            List<string> bolumler = new List<string>();

            foreach (ListViewItem item in BulguLst.Items)
            {
                string bolum = item.SubItems[3].Text;

                if (bolum == "") bolum = "Belirtilmemiş";

                int bolumindex;

                if (bolumler.IndexOf(bolum) > -1)
                {
                    bolumindex = bolumler.IndexOf(bolum);
                }
                else
                {
                    bolumler.Add(bolum);
                    BulguLst.Groups.Add(new ListViewGroup(bolum, HorizontalAlignment.Left));
                    bolumindex = bolumler.Count - 1;
                }

                item.Group = BulguLst.Groups[bolumindex];
            }

        }


        /*
        * Bu prosedür listeyi bulguların tutarsızlığına göre gruplar.
        */

        private void TutarsizligaGoreGrupla()
        {
            //Menüleri düzelt
            tCmbGrupla.Text = "Bulgudaki Tutarsızlığa Göre";
            tTutarsizligaGore.Checked = true;
            MenuleriResetle_Click(tTutarsizligaGore);


            //Grupları ve öğeleri ekle
            List<string> tutarsizliklar = new List<string>();

            foreach (ListViewItem item in BulguLst.Items)
            {
                string tutarsizlik = item.SubItems[7].Text;

                if (tutarsizlik != "Tutarsızlık Yok") tutarsizlik = tutarsizlik.Substring(7, tutarsizlik.Length - 8);
                else tutarsizlik = "Tutarsızlık Olmayan";

                int tutarsizlikindex;

                if (tutarsizliklar.IndexOf(tutarsizlik) > -1)
                {
                    tutarsizlikindex = tutarsizliklar.IndexOf(tutarsizlik);
                }
                else
                {
                    tutarsizliklar.Add(tutarsizlik);
                    BulguLst.Groups.Add(new ListViewGroup(tutarsizlik, HorizontalAlignment.Left));
                    tutarsizlikindex = tutarsizliklar.Count - 1;
                }

                item.Group = BulguLst.Groups[tutarsizlikindex];
            }

        }


        /*
        * Bu prosedür gruplandırmaları kaldırır.
        */
        private void Gruplandirma()
        {
            //Menüleri Düzelt
            tGruplandırma.Checked = true;
            MenuleriResetle_Click(tGruplandırma);
            tCmbGrupla.Text = "Gruplandırmayı Kaldır";

            BulguLst.Groups.Clear();
        }



        /****************************************************************************
         *
         * 
         *                      FORM OLAYLARINA İLİŞKİN PROSEDÜRLER
         * 
         * 
         ****************************************************************************/


        public FrmBades()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.BulguLst.ListViewItemSorter = lvwColumnSorter;

            //Set the Mode of Drawing as Owner Drawn
            this.Tab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;

            //Add the Handler to draw the Image on Tab Pages
            Tab.DrawItem += Tab_DrawItem; 

        }        
        
        /*
        * Form yüklenir ilk parametreler atanır.
        */

        private void FrmBades_Load(object sender, EventArgs e)
        {

            // Bulgu Listesini ayarla
            BulguLst.View = View.Details;
            BulguLst.AllowColumnReorder = true;
            BulguLst.FullRowSelect = true;
            BulguLst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            
            //Ekranı temizle
            DokumaniKapat();
        }

        /*
        * Bu prosedür gruplandırma combosundaki değişikliklere göre gruplama prosedürlerini çağırır.
        */


        private void CmbGrupla_Degistir(string metin)
        {
            BulguLst.BeginUpdate();
            BulguLst.Groups.Clear();

            switch (metin)
            {
                case "Bulgu Tespit Yılına Göre":
                    YilaGoreGrupla();
                    break;

                case "Bulgu Niteliğine Göre":
                    NiteligineGoreGrupla();
                    break;

                case "Bulgu Konusuna Göre":
                    KonusunaGoreGrupla();
                    break;

                case "Bulgunun Önem Derecesine Göre":
                    OnemDerecesineGoreGrupla();
                    break;

                case "Bulguya Alınan Aksiyona Göre":
                    GiderilmeDurumunaGoreGrupla();
                    break;

                case "Gruplandırmayı Kaldır":
                    Gruplandirma();
                    break;

                case "Bulgudaki Tutarsızlığa Göre":
                    TutarsizligaGoreGrupla();
                    break;

                case "Bulgunun İlgili Olduğu Bölüme Göre":
                    IlgiliBolumeGoreGrupla();
                    break;
                default:
                    break;
            }

            BulguLst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            BulguLst.EndUpdate();
        }

        private void CmbGrupla_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboText = this.tCmbGrupla.Text;
            CmbGrupla_Degistir(this.tCmbGrupla.Text);

        }


        /*
        * Bu prosedür bir text box aktif olunca scroll bar oluşmasını sağlar.
        */

        private void aktiftxtbox_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox aktiftxtbox;
            aktiftxtbox = (System.Windows.Forms.TextBox)sender;
            aktiftxtbox.ScrollBars = ScrollBars.Vertical;
        }


        /*
        * Bu prosedür bir text box pasif olunca scroll barın kaybolmasını sağlar.
        */

        private void aktiftxtbox_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox aktiftxtbox;
            aktiftxtbox = (System.Windows.Forms.TextBox)sender;
            aktiftxtbox.ScrollBars = ScrollBars.None;
        }

        /*
        * Bulgu satırına çift tıklanırsa yeni tab açılmasını sağlar.
        */
        private void BulguLst_ItemActivate(object sender, EventArgs e)
        {
            TabEkle(BulguLst.SelectedItems[0].Text);
        }


        /*
        * Bulgu sütunlarına tıklanarak sütunların sıralanmasını sağlar.
        */
        private void BulguLst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Tıklanan sütun zaten sıralanmış mı kontrol et
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Tersten sırala
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Artarak sırala
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Sırala
            this.BulguLst.Sort();

        }


        /*
        * Kaydet butonuna basıldığında bulgu güncelleme prosedürü çağrılır.
        */
        private void guncelle_click(object sender, EventArgs e)
        {
            BulguGuncelle(this.Tab.SelectedTab, this.Tab.SelectedTab.Controls["TxtBKodu"].Text);
        }


        /*
        * Kaydet butonuna basıldığında tab kapatılır.
        */
        private void kapat_click(object sender, EventArgs e)
        {
            DokumaniYukle();
            this.Tab.TabPages.Remove(this.Tab.SelectedTab);
        }




        /****************************************************************************
        *
        * 
        *                      MENÜ OLAYLARINA İLİŞKİN PROSEDÜRLER
        * 
        * 
        ****************************************************************************/


        /*
        * BADES'ten indirilen dosya bu prosedürle alınır.
        */
        private void mXMLAl_Click(object sender, EventArgs e)
        {

            //Ekranı temizle
            DokumaniKapat();

            //Uyarı penceresi göster
            MessageBox.Show("Birazdan BADES sisteminden indirdiğiniz XML dosyasını açmanız istenecektir. BADES sisteminden iki farklı XML dosyası indirilebilmektedir. \"Raporlar & Bulgular > Bulgular\" menüsünden indirdiğiniz XML dosyasında " +
                "bulguya ilişkin detaylar yer alırken \"Aksiyon Planı\" menüsünden indirdiğiniz XML dosyasında bu detaylar yer almamaktadır. Bu sayfada \"XML Oluştur\" butonunu kullanarak ilgili XML kaynağını görüntüleyin. Sonra \"Sayfa > Farklı Kaydet...\" menüsü aracılığıyla sayfayı XML uzantılı olarak kaydedin." + Environment.NewLine + Environment.NewLine + "Lütfen BADES Sistemi \"Raporlar & Bulgular > Bulgular\" menüsünden XML dosyası indirdiğinizden emin olun.", "Raporlar Menüsünden XML Dosyası İndirin", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Aç Diyaloğu
            DlgAc.Filter = "XML Dosyaları (*.xml)|*.xml|Tüm Dosyalar (*.*)|*.*";
            DlgAc.Title = "BADES sisteminden indirdiğiniz XML dosyasını açınız.";

            if (DlgAc.ShowDialog() == DialogResult.OK)
            {
                XmlDosyasi = DlgAc.FileName;
                DokumaniYukle();


    
            }

        

        }


        /*
        * BADES'e yüklenecek dosya bu prosedürle verilir.
        */
        private void mXMLVer_Click(object sender, EventArgs e)
        {
            //Eğer kaydedecek bir şey varsa
            if (BulguLst.Items.Count >= 1)
            {
                //Kaydet Diyaloğu
                DlgKaydet.Filter = "XML Dosyaları (*.xml)|*.xml|Tüm Dosyalar (*.*)|*.*";
                DlgKaydet.Title = "BADES sistemine yüklemek için bir XML dosyası oluşturunuz.";
                DlgKaydet.DefaultExt = ".xml";

                if (DlgKaydet.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XMLVer(DlgKaydet.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            else
            {
                MessageBox.Show("Kaydedecek veri bulunmuyor.");
            }
        }



        /*
        * Bu prosedürle Bulgu Listesi Excel'e aktarılabilir.
        */
        private void mExceleAktar_Click(object sender, EventArgs e)
        {
            //Uygulamayı oluştur
            Excel.Application app = new Excel.Application();
            app.Visible = true;

            //Çalışma sayfası ekle
            Excel.Workbook wb = app.Workbooks.Add(1);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            //Metni aktar
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in BulguLst.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                i2++;
            }
        }


        /*
        * Bu prosedürle doküman kapatılır.
        */
        private void mKapat_Click(object sender, EventArgs e)
        {
            DokumaniKapat();
        }


        /*
        * Programdan çıkılır.
        */
        private void mCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /*
        * SF'deki yardım menüsü çağrılır.
        */
        private void mYardim_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/badessxak/forums/forum/1234619");
        }


        /*
        * SF'deki feature request çağrılır.
        */
        private void mOzellikEkle_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/tracker/?func=add&group_id=352957&atid=1474651");

        }


        /*
        * SF'deki bug report çağrılır.
        */
        private void mHataBildir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/tracker/?func=add&group_id=352957&atid=1474648");
        }


        /*
        * SF'deki support çağrılır.
        */
        private void mDestek_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/badessxak/support");
        }


        /*
        * Hakkında formu gösterilir.
        */
        private void mHakkinda_Click(object sender, EventArgs e)
        {
            Hakkinda frm = new Hakkinda();
            frm.Show();
        }


        /*
        * Gruplandırma menüsündeki bir öğe seçildiğinde diğer öğeler attırılır.
        */
        private void MenuleriResetle_Click(object sender)
        {

            foreach (ToolStripItem item in mGruplandirma.DropDownItems)
            {
                if (item.GetType().Name == "ToolStripMenuItem")
                {
                    if ((sender as ToolStripMenuItem).Name != (item as ToolStripMenuItem).Name)
                        (item as ToolStripMenuItem).Checked = false;

                }
            }
        }


        /*
        * Tarihe göre gruplama.
        */
        private void tTariheGore_Click(object sender, EventArgs e)
        {
            YilaGoreGrupla();
            MenuleriResetle_Click(sender);
        }


        /*
        * Giderilme göre gruplama.
        */
        private void tGiderilmeDurumunaGore_Click(object sender, EventArgs e)
        {
            GiderilmeDurumunaGoreGrupla();
            MenuleriResetle_Click(sender);
        }


        /*
        * Niteliğine göre gruplama.
        */
        private void tNiteligineGore_Click(object sender, EventArgs e)
        {
            NiteligineGoreGrupla();
            MenuleriResetle_Click(sender);
        }


        /*
        * Konusuna göre gruplama.
        */
        private void tKonusunaGore_Click(object sender, EventArgs e)
        {
            KonusunaGoreGrupla();
            MenuleriResetle_Click(sender);
        }

        /*
        * Önem derecesine göre gruplama.
        */
        private void tOnemDerecesineGore_Click(object sender, EventArgs e)
        {
            OnemDerecesineGoreGrupla();
            MenuleriResetle_Click(sender);
        }
        
        /*
        * Gruplama.
        */
        private void tGruplandırma_Click(object sender, EventArgs e)
        {
            Gruplandirma();
            MenuleriResetle_Click(sender);
        }


        /*
        * Ilgili bolume göre gruplama.
        */
        private void tIlgiliBolumeGore_Click(object sender, EventArgs e)
        {
            IlgiliBolumeGoreGrupla();
            MenuleriResetle_Click(sender);
        }

        /*
        * Tutarsızlığa göre gruplama.
        */
        private void tTutarsizligaGore_Click(object sender, EventArgs e)
        {
            TutarsizligaGoreGrupla();
            MenuleriResetle_Click(sender);
        }


        private void mYonetimBeyani_Click(object sender, EventArgs e)
        {
            //Uygulamayı oluştur
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);

            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "YÖNETİM BEYANI EK-3";
            oPara1.Range.Font.Size = 16;
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Font.Size = 14;
            oPara2.Range.Text = "Bağımsız Denetim Bulgularının Takibi";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Font.Size = 12;
            oPara3.Range.Text = "Daha önceki bağımsız bilgi sistemleri ve bankacılık süreçleri denetimlerinde tespit edilip bankaya sunulmuş ve bağımsız denetim kuruluşu tarafından çözüldüğü onaylanmamış olan bulguların çözülüp çözülmediğine ilişkin mevcut durumuna Yönetim Beyanı ekinde yer verilmiştir.";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();


            //Insert a 5 x 2 table, fill it with data, and change the column widths.
            Word.Table oTable;
            Word.Range wrdRng;

            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, BulguLst.Items.Count + 1, 5, ref oMissing, ref oMissing);
            oTable.PreferredWidth = 100;
            oTable.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
            oTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Range.Font.Size = 11;
            oTable.Range.Font.Bold = 0;


            //Sütunları yaz

            oTable.Columns[1].Width = oWord.CentimetersToPoints(4);
            oTable.Columns[2].Width = oWord.CentimetersToPoints(7);
            oTable.Columns[3].Width = oWord.CentimetersToPoints(3);
            oTable.Columns[4].Width = oWord.CentimetersToPoints(3);
            oTable.Columns[5].Width = oWord.CentimetersToPoints(7);


            /*oTable.Columns[1].SetWidth(40, Word.WdRulerStyle.wdAdjustSameWidth);
            oTable.Columns[2].SetWidth(100, Word.WdRulerStyle.wdAdjustSameWidth);
            oTable.Columns[3].SetWidth(30, Word.WdRulerStyle.wdAdjustSameWidth);
            oTable.Columns[4].SetWidth(40, Word.WdRulerStyle.wdAdjustSameWidth);
            oTable.Columns[5].SetWidth(40, Word.WdRulerStyle.wdAdjustSameWidth);
            */
            oTable.Cell(1, 1).Range.Text = BulguLst.Columns[0].Text;        
            oTable.Cell(1, 2).Range.Text = BulguLst.Columns[2].Text;            
            oTable.Cell(1, 3).Range.Text = BulguLst.Columns[4].Text;
            oTable.Cell(1, 4).Range.Text = BulguLst.Columns[5].Text;
            oTable.Cell(1, 5).Range.Text = BulguLst.Columns[6].Text;


            oTable.Rows[1].Range.Font.Bold = 600;
            oTable.Rows[1].HeadingFormat = -1;

            //Metni aktar
            //int i = 1;
            int i2 = 2;
            foreach (ListViewItem lvi in BulguLst.Items)
            {

                oTable.Cell(i2, 1).Range.Text = lvi.SubItems[0].Text;

                //Bulgu kısaltıldığı için item text yerine tooltiptext kullanılıyor.
                //oTable.Cell(i2, 2).Range.Text = lvi.SubItems[2].Text;
                oTable.Cell(i2, 2).Range.Text = lvi.ToolTipText;
                
                oTable.Cell(i2, 3).Range.Text = lvi.SubItems[4].Text;        
                oTable.Cell(i2, 4).Range.Text = lvi.SubItems[5].Text;
                oTable.Cell(i2, 5).Range.Text = lvi.SubItems[6].Text;
                i2++;
 
            }

            

            //Add text after the chart.
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //wrdRng.InsertParagraphAfter();
            //wrdRng.InsertAfter("THE END.");


        }

        private void mMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Tab_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.Tab.TabPages[e.Index].Text;
            Rectangle r = e.Bounds;
            r = this.Tab.GetTabRect(e.Index);
            r.Offset(2, 2);


            if (e.Index != 0)
            {
                try
                {
                    //Close Image to draw
                    Image img = SIcons.Images[0];
                    e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
                    e.Graphics.DrawImage(img, new Point(r.X + (this.Tab.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
                }
                catch (Exception) { }

            }
            else
            {
                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            }
        }

        private void Tab_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.Tab.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.Tab.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (r.Contains(p))
            {
                TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                tc.TabPages.Remove(TabP);
            } 
        }

        private void BulguLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BulguLst.SelectedItems.Count > 0)
            {
                //MessageBox.Show(BulguLst.SelectedItems[0].Index.ToString());
                BulguListIndex = BulguLst.SelectedItems[0].Index;
            }
        }

        private void FrmBades_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FrmBades_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            XmlDosyasi = s[0];
            DokumaniYukle();

        }


    }

}


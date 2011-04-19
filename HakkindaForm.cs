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
using System.Reflection;
using System.Windows.Forms;

namespace bades
{
    partial class Hakkinda : Form
    {
        public Hakkinda()
        {
            InitializeComponent();
            this.Text = String.Format("{0} Hakkında", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Versiyon {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.labelDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelCompanyName_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:au@ahmetucar.com?subject=" + AssemblyTitle + "&body=" + AssemblyProduct + " - "+AssemblyVersion + "%0A%0a");
        }


    }
}

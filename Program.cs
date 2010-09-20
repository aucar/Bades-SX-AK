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

using System;
using System.Windows.Forms;


namespace bades
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBades());


        }
    }
}

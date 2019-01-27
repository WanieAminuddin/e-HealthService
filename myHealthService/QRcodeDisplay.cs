using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myHealthService
{
    public partial class QRcodeDisplay : Form
    {
        public QRcodeDisplay()
        {
            InitializeComponent();
        }

        public string userData;

        private void QRgenerate_Click(object sender, EventArgs e)
        {
            PagePortal pagePor = new PagePortal();
            QRCoder.QRCodeGenerator generateQR = new QRCoder.QRCodeGenerator();
            var QRdata = generateQR.CreateQrCode(QRcontent.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var QRcode = new QRCoder.QRCode(QRdata);
            var image = QRcode.GetGraphic(150);
            QRcodeImage.Image = image;
        }

    }
}

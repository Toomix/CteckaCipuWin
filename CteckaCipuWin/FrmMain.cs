using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CteckaCipuWin
{
    public partial class FrmMain : Form
    {
        System.IO.Ports.SerialPort serial;

        /// <summary>
        /// CRC 8 Dallas/Maxim Application Note 27
        /// </summary>
        readonly byte[] table = new byte[]
        {
            0, 94, 188, 226, 97, 63, 221, 131, 194, 156, 126, 32, 163, 253, 31, 65,
            157, 195, 33, 127, 252, 162, 64, 30, 95, 1, 227, 189, 62, 96, 130, 220,
            35, 125, 159, 193, 66, 28, 254, 160, 225, 191, 93, 3, 128, 222, 60, 98,
            190, 224, 2, 92, 223, 129, 99, 61, 124, 34, 192, 158, 29, 67, 161, 255,
            70, 24, 250, 164, 39, 121, 155, 197, 132, 218, 56, 102, 229, 187, 89, 7,
            219, 133, 103, 57, 186, 228, 6, 88, 25, 71, 165, 251, 120, 38, 196, 154,
            101, 59, 217, 135, 4, 90, 184, 230, 167, 249, 27, 69, 198, 152, 122, 36,
            248, 166, 68, 26, 153, 199, 37, 123, 58, 100, 134, 216, 91, 5, 231, 185,
            140, 210, 48, 110, 237, 179, 81, 15, 78, 16, 242, 172, 47, 113, 147, 205,
            17, 79, 173, 243, 112, 46, 204, 146, 211, 141, 111, 49, 178, 236, 14, 80,
            175, 241, 19, 77, 206, 144, 114, 44, 109, 51, 209, 143, 12, 82, 176, 238,
            50, 108, 142, 208, 83, 13, 239, 177, 240, 174, 76, 18, 145, 207, 45, 115,
            202, 148, 118, 40, 171, 245, 23, 73, 8, 86, 180, 234, 105, 55, 213, 139,
            87, 9, 235, 181, 54, 104, 138, 212, 149, 203, 41, 119, 244, 170, 72, 22,
            233, 183, 85, 11, 136, 214, 52, 106, 43, 117, 151, 201, 74, 20, 246, 168,
            116, 42, 200, 150, 21, 75, 169, 247, 182, 232, 10, 84, 215, 137, 107, 53
        };

        public FrmMain()
        {
            InitializeComponent();
            this.cbCOM.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (this.cbCOM.Items.Count > 0)
            {
                this.cbCOM.SelectedIndex = 0;
            }
        }
        private void BtnKopirovat_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.tbRFID.Text);
        }

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        private void BtnOdeslatRAK_Click(object sender, EventArgs e)
        {
            OdeslatDoRAK();
        }

        private void BtnOtevritZavrit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.serial == null || !this.serial.IsOpen)
                {
                    this.serial = new System.IO.Ports.SerialPort(this.cbCOM.Text, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    this.serial.DataReceived += Serial_DataReceived;
                    this.serial.Open();
                    this.btnOtevritZavrit.Text = "Zavřít";
                    this.lblCOMStatus.BackColor = Color.Green;
                    return;
                }

                if (this.serial.IsOpen)
                {
                    this.serial.Close();
                    this.btnOtevritZavrit.Text = "Otevřít";
                    this.lblCOMStatus.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(250);
            byte[] buff = new byte[512];
            this.serial.Read(buff, 0, serial.BytesToRead);
            string data = Encoding.ASCII.GetString(buff);

            BeginInvoke((MethodInvoker)delegate
            {
                this.tbRFIDTemp.Text = data.Trim();
                this.tbRFID.Text = UpravitUIDSpocitatCRC(data.Trim()).ToLower();
                if (this.chbOdeslatRAKAuto.Checked)
                {
                    OdeslatDoRAK();
                }
            });

        }

        private void OdeslatDoRAK()
        {
            Process p = Process.GetProcessesByName("rak").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait(this.tbRFID.Text);
            }
            else
            {
                MessageBox.Show("Aplikace RAK není spuštěna", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 4 nuly na začátku (0000)
        /// + UID bez prvních dvou bajtů (customer code)  (např. EM02EF7C => 02EF7C)
        /// + zarovnat zprava nulami na délku 14
        /// + nakonec 2 bajty CRC-8 (Dallas/Maxim Application Note 27)
        /// Například EA02EF7C => 000002EF7C000004
        /// Kontrola CRC8 - https://tomeko.net/online_tools/crc8.php?lang=en
        /// </summary>
        /// <param name="textFromRFIDReader">Hexadecimal text from RFID reader</param>
        /// <returns></returns>
        private string UpravitUIDSpocitatCRC(string textFromRFIDReader)
        {

            if (string.IsNullOrWhiteSpace(textFromRFIDReader) || textFromRFIDReader.Length < 8)
            {
                return "Příliš krátný kód pro zpracování (kratší než 8 znaků)";
            }

            //Pryč mezery a prázdno
            string ret = textFromRFIDReader.Replace("\r\n", "").Replace("\0", "");

            ret = ret.Substring(ret.Length - 6, 6);               //Vezmeme posledních 6 znaků (tedy bez Customer code)
            ret = "0000" + ret;                                   //4 nuly na začátek
            ret = ret.PadRight(14, '0');                          //zarovnat zprava 0 na délku 14

            //Převod na byte array
            byte[] binary = Enumerable.Range(0, ret.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(ret.Substring(x, 2), 16)).ToArray();

            //Spočítat CRC (Example 3.1)
            //https://www.analog.com/en/technical-articles/understanding-and-using-cyclic-redundancy-checks-with-maxim-1wire-and-ibutton-products.html
            byte c = 0;
            foreach (byte b in binary)
            {
                c = table[c ^ b];
            }
            //spočítané CRC přidat nakonec
            ret += BitConverter.ToString(new byte[] { c });
            return ret;
        }
    }
}

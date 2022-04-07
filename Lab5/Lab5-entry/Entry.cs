using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Lab5_entry.IPC;


namespace Lab5_entry
{
    public partial class Entry : Form
    {
        Socket socket;
        string currentImageName;
        Communications comms;

        public Entry()
        {
            InitializeComponent();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            comms = new Communications(5565, 5566);
            comms.Start();
        }



        private void SetImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentImageName = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(currentImageName);
            }
        }



        private void PasteStructureButton_Click(object sender, EventArgs e)
        {
            DataFormats.Format fullnameFormat = DataFormats.GetFormat("FullName");
            IDataObject retrievedObject = Clipboard.GetDataObject();
            FullName receivedFullName = (FullName) retrievedObject.GetData(fullnameFormat.Name);

            if (receivedFullName != null)
            {
                FirstNameTextBox.Text = receivedFullName.first;
                SecondNameTextBox.Text = receivedFullName.second;
                ThirdNameTextBox.Text = receivedFullName.third;
            }
        }

        private void CopyStructureButton_Click(object sender, EventArgs e)
        {
            DataFormats.Format fullnameFormat = DataFormats.GetFormat("FullName");
            FullName fullName = new FullName(FirstNameTextBox.Text, SecondNameTextBox.Text, ThirdNameTextBox.Text);
            DataObject fullNameDataObject = new DataObject(fullnameFormat.Name, fullName);
            Clipboard.SetDataObject(fullNameDataObject);
        }
        private void CopyImageButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void CopyText_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
            }
        }





        private void sendTextSocket(object sender, EventArgs e)
        {
            //comms.SendImageSocket(new Bitmap(pictureBox1.Image));
            new Task(() =>
            {
                try
                {
                    socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("localhost", 7878);
                    var mstream = new MemoryStream();

                    var buffer = Encoding.UTF8.GetBytes(textBox1.Text);

                    buffer = Communications.StructToBytes(new MyDataStruct(DataType.Text, buffer));
                    socket.Send(buffer);

                    socket.Disconnect(false);
                }
                catch (SocketException)
                {
                }
            }).Start();
        }
        private void sendImageSocket(object sender, EventArgs e)
        {
            //comms.SendImageSocket(new Bitmap(pictureBox1.Image));
            new Task(() =>
            {
                try
                {
                    socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("localhost", 7878);
                    var mstream = new MemoryStream();
                    new Bitmap(pictureBox1.Image).Save(mstream, ImageFormat.Bmp);
                    
                    var buffer = new byte[(int)mstream.Length];
                    mstream.Seek(0, SeekOrigin.Begin);
                    mstream.Read(buffer, 0, (int)mstream.Length);

                    buffer = Communications.StructToBytes(new MyDataStruct(DataType.Image, buffer));
                    socket.Send(buffer);

                    socket.Disconnect(false);
                }
                catch (SocketException)
                {
                }
            }).Start();
        }

        private void sendStructureSocket(object sender, EventArgs e)
        {

        }




        private void sendTextWM(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //sendColor(Selected, "Storage");
                comms.SendTextWM(textBox1.Text);
                //sendTextWM(textBox1.Text, "Preview");
            }
        }

        private void sendStructureWM(object sender, EventArgs e)
        {
            FullName fullName = new FullName(FirstNameTextBox.Text, SecondNameTextBox.Text, ThirdNameTextBox.Text);
            comms.SendStructWM(fullName);
        }
        private void sendImageWM(object sender, EventArgs e)
        {
            comms.SendImageWM(new Bitmap(pictureBox1.Image));
        }

        private void sendTextWM(string str, string windowTitle)
        {
            IntPtr ptrWnd = NativeMethods.FindWindow(null, windowTitle);
            IntPtr ptrCopyData = IntPtr.Zero;
            try
            {
                // Create the data structure and fill with data
                NativeMethods.COPYDATASTRUCT copyData = new NativeMethods.COPYDATASTRUCT();
                copyData.dwData = new IntPtr(2); //type of data
                copyData.cbData = str.Length + 1; // bytes for string + \0 character
                copyData.lpData = Marshal.StringToHGlobalAnsi(str);

                // Allocate memory for the data and copy
                ptrCopyData = Marshal.AllocCoTaskMem(Marshal.SizeOf(copyData));
                Marshal.StructureToPtr(copyData, ptrCopyData, false);

                // Send the message
                NativeMethods.SendMessage(ptrWnd, NativeMethods.WM_COPYDATA, IntPtr.Zero, ptrCopyData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Entry WM_COPYDATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Free the allocated memory after the contol has been returned
                if (ptrCopyData != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(ptrCopyData);
            }
        }

    }
}
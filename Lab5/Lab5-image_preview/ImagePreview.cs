using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab5_entry.IPC;
using Lab5_entry;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5_image_preview
{
    public partial class ImagePreview : Form
    {
        DB db;

        TcpListener imageServerListener;
        Thread thread;
        public Image BgImage;

        IntPtr _ClipboardViewerNext;
        Communications comms;
        public ImagePreview()
        {
            InitializeComponent();
            imageServerListener = new TcpListener(IPAddress.Loopback, 7878);
            thread = new Thread(ReceiveData);
            thread.Start();
            db = new DB();
        }

        private void ImagePreview_Load(object sender, EventArgs e)
        {
            comms = new Communications(5566,5565);
            comms.Start();

            NativeMethods.CHANGEFILTERSTRUCT changeFilter = new NativeMethods.CHANGEFILTERSTRUCT();
            changeFilter.size = (uint)Marshal.SizeOf(changeFilter);
            changeFilter.info = 0;
            if (!NativeMethods.ChangeWindowMessageFilterEx(this.Handle, NativeMethods.WM_COPYDATA, NativeMethods.ChangeWindowMessageFilterExAction.Allow, ref changeFilter))
            {
                int error = Marshal.GetLastWin32Error();
                MessageBox.Show(String.Format("The error {0} occured.", error));
            }
            RegisterClipboardViewer();
        }

        /// <summary>
        /// Register this form as a Clipboard Viewer application
        /// </summary>
        private void RegisterClipboardViewer()
        {
            _ClipboardViewerNext = NativeMethods.SetClipboardViewer(this.Handle);
        }

        /// <summary>
        /// Remove this form from the Clipboard Viewer list
        /// </summary>
        private void UnregisterClipboardViewer()
        {
            NativeMethods.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
        }

        private DBRow GetClipboardData()
        {
            DateTime startTime = DateTime.Now;
            IDataObject iData = new DataObject();
            string command = "Буфер обмена";
            string context = "";

            try
            {
                iData = Clipboard.GetDataObject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "CLIPBOARD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DBRow(command, "ошибка определение содержимого буфера обмена", new TimeSpan(0));
            }

            DataFormats.Format fullnameFormat = DataFormats.GetFormat("FullName");

            if (iData.GetDataPresent(DataFormats.Text))
            {
                context = $"В буфер обмена был скопирован текст: {iData.GetData(DataFormats.Text)}";
            }
            else if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                context = $"В буфер обмена было скопировано изображение";
            }
            else if (iData.GetDataPresent(fullnameFormat.Name))
            {
                Lab5_entry.FullName receivedFullName = (Lab5_entry.FullName)iData.GetData(fullnameFormat.Name);
                context = $"В буфер обмена была скопирована структура FullName: {receivedFullName.second} {receivedFullName.first} {receivedFullName.third}";
            }
            else
            {
                context = "Невозможно отобразить скопированное содержимое";
            }

            return new DBRow(command, context, DateTime.Now - startTime);
        }

        protected override void WndProc(ref Message m)
        {
            DBRow newRow;

            switch ((NativeMethods.Msgs)m.Msg)
            {
                case NativeMethods.Msgs.WM_COPYDATA:
                    {
                        DateTime now = DateTime.Now;
                        // Extract the file name
                        NativeMethods.COPYDATASTRUCT copyData = (NativeMethods.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.COPYDATASTRUCT));
                        int dataType = (int)copyData.dwData;

                        if (dataType != 2)
                            return;

                        byte[] bytes = new byte[copyData.cbData];
                        Marshal.Copy(copyData.lpData, bytes, 0, copyData.cbData);

                        MyDataStruct mydata;
                        using (var mstream = new MemoryStream(bytes))
                        {
                            var bf = new BinaryFormatter();
                            mydata = (MyDataStruct)bf.Deserialize(mstream);
                        }

                        Receive(mydata.DataType, mydata.Data);
                        return;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }

            /*
			switch ((NativeMethods.Msgs)m.Msg)
			{
				case NativeMethods.Msgs.WM_DRAWCLIPBOARD:
					{
						newRow = GetClipboardData();
						InsertNewEntry(newRow);
						NativeMethods.SendMessage(_ClipboardViewerNext, (uint)m.Msg, m.WParam, m.LParam);
						break;
					}

				case NativeMethods.Msgs.WM_COPYDATA:
					{
						DateTime now = DateTime.Now;
						// Extract the file name
						NativeMethods.COPYDATASTRUCT copyData = (NativeMethods.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.COPYDATASTRUCT));
						int dataType = (int)copyData.dwData;

						if (dataType == 2)
						{
							string text = Marshal.PtrToStringAnsi(copyData.lpData);
							if (text != "")
							{
								postText.Text = text;
								InsertNewEntry("WM_CopyData", "Приём строки", DateTime.Now - now);
							}
						}
						else
						{
							MessageBox.Show(String.Format("Unrecognized data type = {0}.", dataType), "WM_COPYDATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						break;
					}
				default:
					base.WndProc(ref m);
					break;
			}
			*/
            /*
			if (m.Msg == NativeMethods.WM_DRAWCLIPBOARD)
			{
				string newMessage = GetClipboardData();
				textBox1.Text += newMessage + "\r\n";
				NativeMethods.SendMessage(_ClipboardViewerNext, (uint)m.Msg, m.WParam, m.LParam);
				break;
			}
			if (m.Msg == NativeMethods.WM_COPYDATA)
			{
				DateTime now = DateTime.Now;
				// Extract the file name
				NativeMethods.COPYDATASTRUCT copyData = (NativeMethods.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.COPYDATASTRUCT));
				int dataType = (int)copyData.dwData;
				if (dataType == 2)
				{
					string text = Marshal.PtrToStringAnsi(copyData.lpData);
					if (text != "")
					{
						postText.Text = text;
						db.Insert(new DBRow("WM_CopyData", "Приём строки", DateTime.Now - now));
					}
				}
				else
				{
					MessageBox.Show(String.Format("Unrecognized data type = {0}.", dataType), "SendMessageDemo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				base.WndProc(ref m);
			}
			*/
        }

        void SetImage(Image img)
        {
            if (pictureBox1.InvokeRequired)
                pictureBox1.Invoke(new Action<Image>(SetImage), img);
            else
            {
                BgImage = img;
                DrawImage();
            }
        }

        void DrawImage()
        {
            if (BgImage == null)
                return;
            pictureBox1.Image = BgImage;
        }

        void ReceiveData()
        {
            imageServerListener.Start();
            while (true)
            {
                using (var client = imageServerListener.AcceptTcpClient())
                {
                    int delay = 1;
                    while (client.Available <= 0 && delay < 200)
                        Thread.Sleep(delay += 20);

                    DateTime startTime = DateTime.Now;
                    MemoryStream memoryStream = new MemoryStream();
                    client.GetStream().CopyTo(memoryStream);
                    
                    var buffer = new byte[(int)memoryStream.Length];
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.Read(buffer, 0, (int)memoryStream.Length);

                    var data = Communications.StructFromBytes<MyDataStruct>(buffer);
                    switch (data.DataType)
                    {
                        case DataType.Image:
                            SetImage(Bitmap.FromStream(new MemoryStream(data.Data)));
                            break;
                        case DataType.Text:
                            var text = Encoding.UTF8.GetString(data.Data);
                            postText?.Invoke((Action)delegate () { postText.Text = text; });
                            break;
                        case DataType.Struct:
                            var fullName = Communications.StructFromBytes<FullName>(data.Data);
                            postText?.Invoke((Action)delegate () { setFullName(fullName); }); 
                            break;
                        default:
                            break;
                    }

                    InsertNewEntry("Socket TCP", "Получение изображения", DateTime.Now - startTime);
                }
            }
        }

        private void ImagePreview_SizeChanged(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void ImagePreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterClipboardViewer();

            InsertNewEntry("Статус приложения", "Завершение работы", new TimeSpan(0));

            imageServerListener.Stop();
            thread.Abort();
        }

        private void PasteStructureButton_Click(object sender, EventArgs e)
        {
            DateTime timeStart = DateTime.Now;
            DataFormats.Format fullnameFormat = DataFormats.GetFormat("FullName");
            IDataObject retrievedObject = Clipboard.GetDataObject();
            FullName receivedFullName = (FullName)retrievedObject.GetData(fullnameFormat.Name);

            setFullName(receivedFullName);
            InsertNewEntry("Вставка из буфера обмена", "Вставка структуры FullName", DateTime.Now - timeStart);
        }

        public void setFullName(FullName fullName)
        {
            if (fullName != null)
            {
                FirstNameTextBox.Text = fullName.first;
                SecondNameTextBox.Text = fullName.second;
                ThirdNameTextBox.Text = fullName.third;
            }
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Bitmap sourceImage = new Bitmap(pictureBox1.Image);
            DateTime startTime;
            TimeSpan amountTime;
            string command = "Применение фильтра";
            string context = "";
            startTime = DateTime.Now;

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    {
                        pictureBox1.Image = InvertColors(sourceImage);
                        context = "Инвертирование цветов";
                        break;
                    }
                case 2:
                    {
                        pictureBox1.Image = GrayscaleFunc(sourceImage);
                        context = "Оттенки серого";
                        break;
                    }
                case 3:
                    {
                        pictureBox1.Image = HighBrightnessFunc(sourceImage);
                        context = "Увеличение яркости";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            amountTime = DateTime.Now - startTime;
            InsertNewEntry(command, context, amountTime);
            timeLabel.Text = $"Применение фильтра заняло: {amountTime.TotalMilliseconds} мс.";
        }

        public Bitmap InvertColors(Bitmap sourceImage)
        {
            Bitmap invertedImage = new Bitmap(sourceImage);
            Color pixelColor;
            Color invertedColor;

            for (int j = 0; j < invertedImage.Height; j++)
            {
                for (int i = 0; i < invertedImage.Width; i++)
                {
                    pixelColor = sourceImage.GetPixel(i, j);
                    invertedColor = Color.FromArgb(255, 255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    invertedImage.SetPixel(i, j, invertedColor);
                }
            }

            return invertedImage;
        }

        public Bitmap GrayscaleFunc(Bitmap sourceImage)
        {
            Bitmap grayscaledImage = new Bitmap(sourceImage);
            Color pixelColor;
            Color grayscaledColor;
            int currentGrayScale;
            for (int j = 0; j < grayscaledImage.Height; j++)
            {
                for (int i = 0; i < grayscaledImage.Width; i++)
                {
                    pixelColor = sourceImage.GetPixel(i, j);
                    currentGrayScale = (int)(pixelColor.R * 0.2126f + pixelColor.G * 0.7152f + pixelColor.B * 0.0722f);
                    grayscaledColor = Color.FromArgb(255, currentGrayScale, currentGrayScale, currentGrayScale);
                    grayscaledImage.SetPixel(i, j, grayscaledColor);
                }
            }

            return grayscaledImage;
        }

        public Bitmap HighBrightnessFunc(Bitmap sourceImage)
        {
            Bitmap brightImage = new Bitmap(sourceImage);
            Color pixelColor;
            Color brightColor;
            float contrast = 3;
            int[] colorBuffer = new int[256];
            int midBright = 0;

            for (int j = 0; j < brightImage.Height; j++)
            {
                for (int i = 0; i < brightImage.Width; i++)
                {
                    pixelColor = sourceImage.GetPixel(i, j);
                    midBright += (int)(pixelColor.R * 0.299f + pixelColor.G * 0.587f + pixelColor.B * 0.114f);
                }
            }

            midBright /= (brightImage.Height * brightImage.Width);

            for (int i = 0; i < 256; i++)
            {
                int delta = (int)i - midBright;
                int temp = (int)(midBright + contrast * delta);
                if (temp < 0) colorBuffer[i] = 0;
                else if (temp > 255) colorBuffer[i] = 255;
                else colorBuffer[i] = temp;
            }

            for (int j = 0; j < brightImage.Height; j++)
            {
                for (int i = 0; i < brightImage.Width; i++)
                {
                    pixelColor = sourceImage.GetPixel(i, j);
                    brightColor = Color.FromArgb(255, colorBuffer[pixelColor.R], colorBuffer[pixelColor.G], colorBuffer[pixelColor.B]);
                    brightImage.SetPixel(i, j, brightColor);
                }
            }

            return brightImage;
        }

        private void InsertNewEntry(DBRow dbRow)
        {
            if (logTextBox.InvokeRequired)
                logTextBox.Invoke(new Action<DBRow>(InsertNewEntry), dbRow);
            else
            {
                db.Insert(dbRow);
                logTextBox.Text += dbRow.ToString() + "\r\n";
            }
        }

        private void InsertNewEntry(string command, string context, TimeSpan proceedTime)
        {
            DBRow newRow = new DBRow(command, context, proceedTime);
            if (logTextBox.InvokeRequired)
                logTextBox.Invoke(new Action<DBRow>(InsertNewEntry), newRow);
            else
            {
                db.Insert(newRow);
                logTextBox.Text += newRow.ToString() + "\r\n";
            }
        }

        private void CopyImageButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void PasteImageButton_Click(object sender, EventArgs e)
        {
            DateTime timeStart = DateTime.Now;

            Image img = Clipboard.GetImage();

            if (img == null)
                return;

            pictureBox1.Image = img;
            InsertNewEntry("Вставка из буфера обмена", "Вставка изображения", DateTime.Now - timeStart);
        }

        private void PasteTextButton_Click(object sender, EventArgs e)
        {
            string receivedString = Clipboard.GetText();

            if (receivedString == null)
                return;

            postText.Text = receivedString;
        }

        private void Receive(DataType dataType, byte[] bytes)
        {
            switch (dataType)
            {
                case DataType.Image:
                    using (var mstream = new MemoryStream(bytes))
                    {
                        var bformatter = new BinaryFormatter();
                        
                        var bitmap = Bitmap.FromStream(mstream);
                        pictureBox1?.Invoke((Action)delegate () { pictureBox1.Image = bitmap; });
                    }

                    break;
                case DataType.Text:
                    string text = Encoding.UTF8.GetString(bytes);
                    postText?.Invoke((Action)delegate () { postText.Text = text; });
                    break;
                case DataType.Struct:
                    using (var mstream = new MemoryStream(bytes))
                    {
                        var bformatter = new BinaryFormatter();
                        FullName obj = (FullName)bformatter.Deserialize(mstream);
                        postText?.Invoke((Action)delegate () { setFullName(obj); });
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Lab5_entry.IPC;

namespace Lab5_entry
{
    [Serializable]
    public enum DataType
    {
        Image = 1,
        Text = 2,
        Struct = 4
    }

    [Serializable]
    public class MyDataStruct
    {
        public DataType DataType;
        public byte[] Data;

        public MyDataStruct(DataType dataType, byte[] data)
        {
            DataType = dataType;
            Data = data;
        }
    }

    public class Communications
    {
        private TcpListener _listener;
        private TcpClient _client;
        private List<TcpClient> _clients;
        private Task<Task> clientLoop;
        private Task<Task> packetLoop;

        public event Action<Bitmap> ImageReceived;
        public event Action<string> TextReceived;
        public event Action<object> StructReceived;
        CancellationTokenSource _tSource;
        private readonly int cport;

        public Communications(int cport, int lport)
        {
            _listener = new TcpListener(IPAddress.Any, lport);
            _clients = new List<TcpClient>();
            _client = new TcpClient();
            this.cport = cport;
        }

        public static byte[] StructToBytes<T>(T obj) where T : class
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var mstream = new MemoryStream())
            {
                bf.Serialize(mstream, obj);

                var buffer = new byte[(int)mstream.Length];
                mstream.Seek(0, SeekOrigin.Begin);
                mstream.Read(buffer, 0, (int)mstream.Length);

                return buffer;
            }
        }

        public static T StructFromBytes<T>(byte[] data) where T : class
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var mstream = new MemoryStream(data))
            {
                return (T)bf.Deserialize(mstream);
            }
        }

        public void Start()
        {
            _tSource = new CancellationTokenSource();
            _listener.Start();
            _client.Connect(new IPEndPoint(IPAddress.Loopback, cport));
            clientLoop = Task.Factory.StartNew(handleClients, _tSource.Token);
            packetLoop = Task.Factory.StartNew(handlePackets, _tSource.Token);
        }


        public void Stop()
        {
            _listener.Stop();
            _tSource.Cancel();
        }

        public void SendImageSocket(Bitmap image)
        {
            byte[] buffer;
            using (var mstream = new MemoryStream())
            {
                image.Save(mstream, ImageFormat.Bmp);
                buffer = mstream.GetBuffer();
                buffer = StructToBytes(new MyDataStruct(DataType.Image, buffer));
                _client.GetStream().Write(buffer, 0, buffer.Length);
            }
        }

        public void SendImageWM(Bitmap image)
        {
            byte[] buffer;
            using (var mstream = new MemoryStream())
            {
                image.Save(mstream, ImageFormat.Bmp);
                buffer = mstream.GetBuffer();
                buffer = StructToBytes(new MyDataStruct(DataType.Image, buffer));
                sendBytesWM(buffer, DataType.Struct);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public void SendImageBoard(Bitmap image)
        {
            Clipboard.SetImage(image);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public void SendStructSocket<T>(T obj) where T : class
        {
            byte[] buffer = StructToBytes(obj);
            buffer = StructToBytes(new MyDataStruct(DataType.Struct, buffer));
            _client.GetStream().Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public void SendStructBoard<T>(T obj) where T : class
        {
            DataFormats.Format format = DataFormats.GetFormat($"object:{typeof(T).Name}");
            DataObject objDO = new DataObject(format.Name, obj);
            Clipboard.SetDataObject(objDO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public void SendStructWM<T>(T obj) where T : class
        {
            BinaryFormatter bf = new BinaryFormatter();
            byte[] buffer = StructToBytes(obj);
            buffer = StructToBytes(new MyDataStruct(DataType.Struct, buffer));
            sendBytesWM(buffer, DataType.Struct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SendTextSocket(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            buffer = StructToBytes(new MyDataStruct(DataType.Text, buffer));
            _client.GetStream().Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SendTextBoard(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SendTextWM(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            buffer = StructToBytes(new MyDataStruct(DataType.Text, buffer));

            //MyDataStruct struc = StructFromBytes<MyDataStruct>(buffer);
            sendBytesWM(buffer, DataType.Text);
        }



        private void sendBytesWM(byte[] bytes, DataType type, string windowTitle = "Preview")
        {
            IntPtr ptrWnd = NativeMethods.FindWindow(null, windowTitle);
            IntPtr ptrCopyData = IntPtr.Zero;

            // Create the data structure and fill with data
            NativeMethods.COPYDATASTRUCT copyData = new NativeMethods.COPYDATASTRUCT();
            copyData.dwData = (IntPtr)2; //type of data
            copyData.cbData = bytes.Length; // bytes for string + \0 character

            IntPtr unmanagedPointer = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, unmanagedPointer, bytes.Length);
            copyData.lpData = unmanagedPointer;

            // Allocate memory for the data and copy
            ptrCopyData = Marshal.AllocCoTaskMem(Marshal.SizeOf(copyData));
            Marshal.StructureToPtr(copyData, ptrCopyData, false);

            // Send the message
            NativeMethods.SendMessage(ptrWnd, NativeMethods.WM_COPYDATA, IntPtr.Zero, ptrCopyData);
            Marshal.FreeHGlobal(unmanagedPointer);
            if (ptrCopyData != IntPtr.Zero)
                Marshal.FreeCoTaskMem(ptrCopyData);
        }

        //TODO: нужно ли отлавливать клипборд?
        public bool handeWndProc(Message m)
        {
            switch ((NativeMethods.Msgs)m.Msg)
            {
                case NativeMethods.Msgs.WM_COPYDATA:
                    {
                        DateTime now = DateTime.Now;
                        // Extract the file name
                        NativeMethods.COPYDATASTRUCT copyData = (NativeMethods.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.COPYDATASTRUCT));
                        int dataType = (int)copyData.dwData;

                        if (dataType != 2)
                            return false;

                        byte[] bytes = new byte[copyData.cbData];
                        Marshal.Copy(copyData.lpData, bytes, 0, copyData.cbData);

                        MyDataStruct mydata;
                        using (var mstream = new MemoryStream(bytes))
                        {
                            var bf = new BinaryFormatter();
                            mydata = (MyDataStruct)bf.Deserialize(mstream);
                        }

                        Receive(mydata.DataType, mydata.Data);
                        return true;
                    }
                default:
                    return false;
            }
        }

        private async Task handlePackets()
        {
            while (true)
            {
                foreach (var client in _clients)
                {
                    if (!client.Connected)
                    {
                        _clients.Remove(client);
                        continue;
                    }
                    if (client.Available == 0) continue;

                    var stream = client.GetStream();
                    MyDataStruct mydata;
                    using (var mstream = new MemoryStream())
                    {
                        await stream.CopyToAsync(mstream);
                        var bf = new BinaryFormatter();
                        mydata = (MyDataStruct)bf.Deserialize(mstream);
                        Receive(mydata.DataType, mydata.Data);
                    }
                }
            }
        }

        private async Task handleClients()
        {
            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _clients.Add(client);
            }
        }
        private void Receive(DataType dataType, byte[] bytes)
        {
            switch (dataType)
            {
                case DataType.Image:
                    using (var mstream = new MemoryStream(bytes))
                    {
                        var bformatter = new BinaryFormatter();
                        var bitmap = (Bitmap)bformatter.Deserialize(mstream);
                        ImageReceived?.Invoke(bitmap);
                    }

                    break;
                case DataType.Text:
                    string text = Encoding.UTF8.GetString(bytes);
                    TextReceived?.Invoke(text);
                    break;
                case DataType.Struct:
                    using (var mstream = new MemoryStream(bytes))
                    {
                        var bformatter = new BinaryFormatter();
                        var obj = bformatter.Deserialize(mstream);
                        StructReceived?.Invoke(obj);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
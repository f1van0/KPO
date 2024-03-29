﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJPEG
{
	public delegate void FrameHandler (object sender, FrameReceivedEventArgs e);

	/// <summary>
	/// Источник потока изображения
	/// </summary>
	public class StreamDecoder
    {
        public event FrameHandler OnFrameReceived;

        public string _uri;

        private HttpClient _client;

        private byte[] _lastFrame;

        private object _locker = new object();

        Task tsk;

		public bool isWorking { get; protected set; } = false;
		public bool isStopped { get; protected set; } = true;

        public byte[] GetLastFrame() => _lastFrame;


        public StreamDecoder(string uri)
        {
            _client = new HttpClient();
			this._uri = uri;
		}


        public void StartDecodingAsync()
        {
			if ( _uri == null )
				return;
			tsk = Task.Factory.StartNew(DoWork, TaskCreationOptions.LongRunning);
        }

        public void Pause()
		{
            isWorking = false;
		}

        public void Stream()
        {
            isWorking = true;
			isStopped = false;
        }

        public void Stop()
		{
            isWorking = false;
            isStopped = true;
        }

        private async Task DoWork()
        {
            while (true)
            {
                try
                {
                    using (var stream = await _client.GetStreamAsync(_uri).ConfigureAwait(false))
                    {
                        while (isWorking)
                        {
                            if (isStopped) break;

                            int contentLength = GetContentLength(stream);

                            if (contentLength == 0) break;

                            var content = GetContent(stream, contentLength);

                            if (content == null) break;

                            lock (_locker)
                            {
                                _lastFrame = content;
                            }
                            OnFrameReceived?.Invoke(this, new FrameReceivedEventArgs()
                            {
                                Frame = content
                            });
                        }
                    }
                    if (isStopped)
                        return; 
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.StackTrace);
                }
            }
        }

        internal byte[] SliceStream(Stream stream, byte[] beginPattern, byte[] endPattern)
        {
            int offset = 0;
            bool beginCathed = false;

            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int x = stream.ReadByte();

                    if (x == -1) return null;

                    if (!beginCathed)
                    {
                        if (x == beginPattern[offset])
                        {
                            offset++;

                            ms.WriteByte((byte)x);

                            if (offset == beginPattern.Length)
                            {
                                beginCathed = true;
                                offset = 0;
                            }
                        }
                        else
                        {
                            ms.SetLength(0);
                            offset = 0;
                        }
                    }
                    else
                    {
                        ms.WriteByte((byte)x);

                        if (x == endPattern[offset])
                        {
                            offset++;

                            if (offset == endPattern.Length)
                            {
                                return ms.ToArray();
                            }
                        }
                        else
                        {
                            offset = 0;
                        }
                    }
                }
            }
        }

        internal int GetContentLength(Stream stream)
        {
            int res = 0;

            // Get header which starts with "--my" and ends with "\r\n\r\n"
            var header = SliceStream(stream, new byte[] { 0x2D, 0x2D, 0x6D, 0x79 }, new byte[] { 0x0D, 0x0A, 0x0D, 0x0A });

            if (header == null || header.Length < 7)
            {
                return 0;
            }

            for (int i = header.Length - 5; i >= 0; i--)
            {
                if (header[i] == 0x20)
                {
                    string s = Encoding.UTF8.GetString(header, i, header.Length - i - 4);

                    if (!int.TryParse(s, out res))
                    {
                        return 0;
                    }

                    break;
                }
            }

            return res;
        }

        internal byte[] GetContent(Stream stream, int contentLength)
        {
            int bytesProcessed = 0;

            byte[] res = new byte[contentLength];

            while (bytesProcessed != contentLength)
            {
                int bytesReceived = stream.Read(res, bytesProcessed, contentLength - bytesProcessed);

                if (bytesReceived == 0) return null;

                bytesProcessed += bytesReceived;
            }

            return res;
        }

    }
}

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lab3_KPO
{
    class VideoStream
    {
		PictureBox pictureBox;
		string baseStreamUrl;
		string streamUrl;
		bool isWorked = true;
		StreamDecoder decoder = null;
		Filters filters;
		public VideoStream(PictureBox pictureBox, string url, FlowLayoutPanel panel)
		{
			this.pictureBox = pictureBox;
			this.baseStreamUrl = url;
			this.streamUrl = url;
			filters = new Filters(panel);
		}
		private void OnFrameReceived(object sender, FrameReceivedEventArgs e)
		{
			using (var ms = new MemoryStream(e.Frame))
			{
				if (isWorked)
				{
					pictureBox.Image = Image.FromStream(ms);
				}
			}
		}
		public void Start(string sourceUrl)
		{
			if (sourceUrl == "")
				streamUrl = baseStreamUrl;
			else
				streamUrl = sourceUrl;

			if (decoder == null)
			{
				decoder = new StreamDecoder(filters);
				decoder.OnFrameReceived += OnFrameReceived;
				decoder.StartDecodingAsync(streamUrl);
			}
			else
			{
				decoder.Resume();
			}
			isWorked = true;
		}
		public void Stop()
		{
			if (decoder != null)
			{
				decoder.Stop();
				isWorked = false;
				decoder = null;
				pictureBox.Image = null;
			}
			else MessageBox.Show("Просмотр выключен, невозможно выключить просмотр");
		}
		public void Pause()
		{
			if (decoder != null)
			{
				decoder.Pause();
				isWorked = false;
			}
			else MessageBox.Show("Просмотр выключен, невозможно поставить на паузу");

		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Keygen
{
	[Serializable]
	public record Key
	{
		public string Username;
		public string USB;
		public string SerialNumber;
		public DateTime EndTime;
		public DateTime StartTime;

		public Key(string username, string usb, string serialNum, DateTime untillDate)
		{
			Username = username;
			USB = usb;
			SerialNumber = serialNum;
			EndTime = untillDate;
			StartTime = DateTime.Now;
		}

		public Key(string username, string usb, string serialNum, EncryptedKey encryptedKey)
		{
			Username = username;
			USB = usb;
			SerialNumber = serialNum;
			EndTime = encryptedKey.UntilDate;
			StartTime = encryptedKey.CreatedDate;
		}

		public override string ToString()
		{
			return $"{Username} [{StartTime} - {EndTime}]";
		}
	}

	public struct EncryptedKey
	{
		public byte[] Username;
		public byte[] USB;
		public byte[] SerialNumber;
		public DateTime UntilDate;
		public DateTime CreatedDate;

		public EncryptedKey(Key key)
		{
			RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
			SerialNumber = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key.SerialNumber));
			USB = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key.USB));
			Username = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key.Username));
			UntilDate = key.EndTime;
			CreatedDate = key.StartTime;
		}
	}

	public static class KeyFactory
	{
		private const string fileName = "key.key";
		public static void CreateKey(string path, Key key)
		{
			string fullPath = path + "\\" + fileName;
			EncryptedKey encryptKey = new EncryptedKey(key);
			string json = JsonConvert.SerializeObject(encryptKey, Formatting.Indented);
			File.WriteAllText(fullPath, json);
		}

		public static EncryptedKey? ReadKey(string path)
		{
			string fullPath = path + "\\" + fileName;
			if (!File.Exists(fullPath))
				return null;

			EncryptedKey key;
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				string json = File.ReadAllText(fullPath);
				key = JsonConvert.DeserializeObject<EncryptedKey>(json);
			}
			catch (System.Runtime.Serialization.SerializationException ex)
			{
				return null;
			}
			return key;
		}
	}
}

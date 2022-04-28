using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace MainProgram
{
	[Serializable]
	public struct Function
	{
		public int ID;
		public string Name;

		public Function(int id)
		{
			ID = id;
			Name = "Function " + id.ToString();
		}

		public override string ToString()
		{
			return Name;
		}
	}

	[Serializable]
	public struct Key
	{
		public string Username;
		public string SerialNumber;
		public DateTime UntilDate;
		public DateTime CreatedDate;
		public bool[] IsFuncsAvailable;

		public Key(bool[] isFuncsAvailable, string serialNum, string username, DateTime untillDate)
		{
			SerialNumber = serialNum;
			Username = username;
			UntilDate = untillDate;
			CreatedDate = DateTime.Now;
			IsFuncsAvailable = isFuncsAvailable;
		}

		public Key(string username, string serialNum, EncryptedKey encryptedKey)
		{
			Username = username;
			SerialNumber = serialNum;
			UntilDate = encryptedKey.UntilDate;
			CreatedDate = encryptedKey.CreatedDate;
			IsFuncsAvailable = encryptedKey.IsFuncsAvailable;
		}

		public override string ToString()
		{
			return $"{Username} [{CreatedDate} - {UntilDate}]";
		}
	}

	public struct EncryptedKey
	{
		public byte[] Username;
		public byte[] SerialNumber;
		public DateTime UntilDate;
		public DateTime CreatedDate;
		public bool[] IsFuncsAvailable;

		public EncryptedKey(Key key)
		{
			SerialNumber = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key.SerialNumber));
			Username = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key.Username));
			UntilDate = key.UntilDate;
			CreatedDate = key.CreatedDate;
			IsFuncsAvailable = key.IsFuncsAvailable;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.ComponentModel;

namespace BatchImageProcessing
{
	[Serializable]
	public record Key
	{
		public string Username;
		public string USB;
		public string SerialNumber;
		public DateTime EndTime;
		public DateTime StartTime;

		public Key(string username, string usb, string serialNum, DateTime endTime)
		{
			Username = username;
			USB = usb;
			SerialNumber = serialNum;
			StartTime = DateTime.Now;
			EndTime = endTime;
		}

		public Key(string username, string usb, string serialNum, DateTime startTime, DateTime endTime)
		{
			Username = username;
			USB = usb;
			SerialNumber = serialNum;
			StartTime = startTime;
			EndTime = endTime;
		}

		public Key(string username, string serialNum, string usb, EncryptedKey encryptedKey)
		{
			Username = username;
			USB = usb;
			SerialNumber = serialNum;
			StartTime = encryptedKey.StartTime;
			EndTime = encryptedKey.EndTime;
		}

		public override string ToString()
		{
			return $"{Username} [{StartTime} - {EndTime}]";
		}
	}

	public struct EncryptedKey
	{
		CspParameters _keyParameters;

		public byte[] Username;
		public byte[] USB;
		public byte[] SerialNumber;
		public DateTime EndTime;
		public DateTime StartTime;

		public EncryptedKey(Key key)
		{
			_keyParameters = new CspParameters();
			_keyParameters.KeyContainerName = "license";
			UnicodeEncoding byteConverter = new UnicodeEncoding();
			RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(_keyParameters);
			Username = RSAEncrypt(byteConverter.GetBytes(key.Username), RSA.ExportParameters(false), false);
			USB = RSAEncrypt(byteConverter.GetBytes(key.USB), RSA.ExportParameters(false), false);
			SerialNumber = RSAEncrypt(byteConverter.GetBytes(key.SerialNumber), RSA.ExportParameters(false), false);
			EndTime = key.EndTime;
			StartTime = key.StartTime;
		}

		public Key DecryptedKey()
		{
			_keyParameters = new CspParameters();
			_keyParameters.KeyContainerName = "license";
			UnicodeEncoding byteConverter = new UnicodeEncoding();
			RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(_keyParameters);
			byte[] temp = RSADecrypt(Username, RSA.ExportParameters(true), false);
			if (temp == null) return null;
			string username = byteConverter.GetString(temp);
			temp = RSADecrypt(USB, RSA.ExportParameters(true), false);
			if (temp == null) return null;
			string usb = byteConverter.GetString(temp);
			temp = RSADecrypt(SerialNumber, RSA.ExportParameters(true), false);
			if (temp == null) return null;
			string serialNumber = byteConverter.GetString(temp);

			Key resultKey = new Key(username, usb, serialNumber, StartTime, EndTime);
			return resultKey;
		}

		public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				byte[] encryptedData;
				//Create a new instance of RSACryptoServiceProvider.
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
				{

					//Import the RSA Key information. This only needs
					//toinclude the public key information.
					RSA.ImportParameters(RSAKeyInfo);

					//Encrypt the passed byte array and specify OAEP padding.  
					//OAEP padding is only available on Microsoft Windows XP or
					//later.  
					encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
				}
				return encryptedData;
			}
			//Catch and display a CryptographicException  
			//to the console.
			catch (CryptographicException e)
			{
				Console.WriteLine(e.Message);

				return null;
			}
		}

		public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				byte[] decryptedData;
				//Create a new instance of RSACryptoServiceProvider.
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
				{
					//Import the RSA Key information. This needs
					//to include the private key information.
					RSA.ImportParameters(RSAKeyInfo);

					//Decrypt the passed byte array and specify OAEP padding.  
					//OAEP padding is only available on Microsoft Windows XP or
					//later.  
					decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
				}
				return decryptedData;
			}
			//Catch and display a CryptographicException  
			//to the console.
			catch (CryptographicException e)
			{
				Console.WriteLine(e.ToString());

				return null;
			}
		}
	}

	public static class KeyFactory
	{
		private const string fileName = "key.key";
		public static EncryptedKey CreateKey(string path, Key key)
		{
			string fullPath = path + "\\" + fileName;
			EncryptedKey encryptKey = new EncryptedKey(key);
			string json = JsonConvert.SerializeObject(encryptKey, Formatting.Indented);
			File.WriteAllText(fullPath, json);
			return encryptKey;
		}

		public static Key ReadKey(string path)
		{
			string fullPath = path + "\\" + fileName;
			if (!File.Exists(fullPath))
				return null;

			EncryptedKey encryptedKey;
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				string json = File.ReadAllText(fullPath);
				encryptedKey = JsonConvert.DeserializeObject<EncryptedKey>(json);
				return encryptedKey.DecryptedKey();
			}
			catch (System.Runtime.Serialization.SerializationException ex)
			{
				return null;
			}
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;
using System.Diagnostics;

namespace MainProgram
{
	public struct USBFlash
	{
		public USBFlash(string driveName, string name, string serial)
		{
			DriveName = driveName;
			Name = $"({DriveName}) " + name;
			SerialNumber = serial;
		}

		public override string ToString()
		{
			return Name;
		}

		public string Name;
		public string SerialNumber;
		public string DriveName;
	}

	public class USBObserver
	{
		public List<USBFlash> Devices;
		public event Action<List<USBFlash>> UpdateDevices;
		public bool inRunning;
		Thread Updater;

		static USBObserver instance;
		public static USBObserver Instance
		{
			get
			{
				if (instance == null)
					instance = new USBObserver();
				return instance;
			}
		}

		USBObserver()
		{
			Devices = new List<USBFlash>();
		}


		List<USBFlash> loadUsbDevices()
		{
			ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType=2");
			List<USBFlash> devices = new List<USBFlash>();
			foreach (ManagementObject currentObject in theSearcher.Get())
			{
				try
				{

					string volumeName = currentObject["VolumeName"].ToString();
					string description = currentObject["Description"].ToString();

					string name = volumeName.Length > 2 ? volumeName : description;

					string driveName = currentObject["Caption"].ToString();
					string serial = (new USBSerialNumber()).getSerialNumberFromDriveLetter(driveName);

					devices.Add(new USBFlash(driveName, name, serial));
				}
				catch (NullReferenceException ex)
				{
					devices.Add(new USBFlash("0", "None", "null"));
				}
			}
			return devices;
		}

		public void runAutoUpdate()
		{
			if (Updater != null && Updater.IsAlive)
				return;

			Updater = new Thread(AutoUpdate);
			inRunning = true;
			Updater.Start();
		}

		public void stopAutoUpdate()
		{
			if (Updater != null && Updater.IsAlive)
			{
				inRunning = false;
				if (!Updater.Join(2000))
				{ // or an agreed resonable time
					Updater.Abort();
				}
			}
		}

		void AutoUpdate()
		{
			while (true)
			{
				refreshDevices();
				Thread.Sleep(700);
				if (!inRunning)
					break;
			}
		}

		public void clearDevices()
		{
			lock (Devices)
			{
				Devices.Clear();
			}
			UpdateDevices?.Invoke(Devices);
		}

		public void refreshDevices()
		{
			var devices = loadUsbDevices();
			var connectedDevices = devices.Except(Devices); //девайсы которых нет в старых (подключены)
			var removedDevices = Devices.Except(devices); // девайсы которых нет в новых (удалены)

			lock (Devices)
			{
				Devices = devices;
			}

			foreach (var device in removedDevices)
				USBLogger.Instance.AddLog($"Device {device.ToString()} was removed [{DateTime.Now}]");

			foreach (var device in connectedDevices)
				USBLogger.Instance.AddLog($"Device {device.ToString()} was located [{DateTime.Now}]");

			if (connectedDevices.Count() > 0 || removedDevices.Count() > 0)
				UpdateDevices?.Invoke(Devices);
		}
	}
}

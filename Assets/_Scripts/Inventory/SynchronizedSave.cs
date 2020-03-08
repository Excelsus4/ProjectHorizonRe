﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace com.meiguofandian.synchronizedSaver {
	public abstract class SynchronizedSave {
		public string saveID;

		public enum SynchronizeType {
			Save,
			Load
		}

		/// <summary>
		/// Save or Load on device.
		/// </summary>
		/// <param name="action">Either Save or Load</param>
		protected void SynchronizeSaveData(SynchronizeType action) {
			if (saveID == "")
				throw new Exception("saveID Not Set by " + GetType() + "!");
			string path = Application.persistentDataPath + "/" + saveID + ".exd";

			// Save or load according to the timestamp
			switch (action) {
			case SynchronizeType.Load:
				if (File.Exists(path)) {
					FileStream stream = new FileStream(path, FileMode.Open);
					LoadItem(stream);
					stream.Close();
				} else {
					LoadItem();
				}
				break;
			case SynchronizeType.Save:
				break;
			}
		}

		protected abstract void SaveItem(Stream stream);

		/// <summary>
		/// This will be called once every load
		/// </summary>
		protected abstract void LoadItem(Stream stream);

		/// <summary>
		/// This will be called when the game is fresh and no save data exists
		/// </summary>
		protected abstract void LoadItem();
	}
}
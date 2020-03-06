using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.meiguofandian.synchronizedSaver {
	public abstract class SynchronizedSave {
		public string saveID;
		public Time timestamp;

		public enum SynchronizeType {
			Save,
			Load
		}

		protected void SynchronizeSaveData(SynchronizeType action) {
			// Check timestamp of save data and inventory data

			// Save or load according to the timestamp
		}

		/// <summary>
		/// This will be called for each parsed token
		/// </summary>
		/// <param name="saveData">saved token</param>
		protected abstract void LoadItem(string saveData);
	}
}
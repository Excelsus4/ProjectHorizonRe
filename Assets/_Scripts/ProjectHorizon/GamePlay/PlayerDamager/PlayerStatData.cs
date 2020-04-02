using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.Modules.SynchronizedSaver;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace com.meiguofandian.ProjectHorizon.GamePlay.PlayerDamager {
	public class PlayerStatData : SynchronizedSave {
		private static PlayerStatData singleton;

		public static PlayerStatData getSingleton() {
			if (singleton != null)
				return singleton;
			else
				return createSingleton();
		}

		private static PlayerStatData createSingleton() {
			singleton = new PlayerStatData();
			return singleton;
		}
		
		public PlayerBindStat playerData;

		public PlayerStatData() {
			saveID = "playerData";
			SynchronizeSaveData(SynchronizeType.Load);
		}

		protected override void SaveItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, playerData);
		}

		protected override void LoadItem(Stream stream) {
			BinaryFormatter formatter = new BinaryFormatter();
			playerData = formatter.Deserialize(stream) as PlayerBindStat;
		}

		protected override void LoadItem() {
			playerData = new PlayerBindStat();
		}
	}
}
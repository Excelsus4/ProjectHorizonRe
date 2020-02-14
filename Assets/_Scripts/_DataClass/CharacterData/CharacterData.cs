using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterData {
	public static int ResourceTypeLength = 6;
	public enum ResourceType
	{
		Coin,
		Wood,
		Resin,
		Metal,
		Polymer,
		CarbonFibre
	}

	public static int Level = 1;

	public static int EXP_Required;
	public static int EXP_Current;

	public static int[] Resource = new int[ResourceTypeLength];

	public static void LoadCharacterData()
	{
		//New Data and Initializing
		Level = 1;

		if (File.Exists(@"SaveData\CharacterData.exa100"))
		{
			using (FileStream fs = new FileStream(@"SaveData\CharacterData.exa100", FileMode.Open, FileAccess.Read, FileShare.None))
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				SaveData100 recv = bf.Deserialize(fs) as SaveData100;
			}
		}
		else
		{
			SaveAllData();
		}
	}

	public static void AddResource(ResourceType thisType, int Amount)
	{
		Resource[(int)thisType] += Amount;
		if(ResourceManager.resourceManager!=null)
			ResourceManager.resourceManager.UpdateResourceAmount(thisType);
	}

	public static void SaveAllData()
	{
		Debug.Log("Created File");
		SaveData100 saveData = new SaveData100();

		saveData.Level = Level;

		using (FileStream fs = new FileStream(@"SaveData\CharacterData.exa100", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
		{
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			bf.Serialize(fs, saveData);
		}
	}
}

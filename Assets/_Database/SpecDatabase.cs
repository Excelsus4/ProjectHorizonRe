using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// SpecDatabase reads all data tables, parse and load it
/// </summary>
public class SpecDatabase : MonoBehaviour {
	public GameObject[] m_BlobTable;
	private WeaponPart.PartGrade m_nextGrade;

	private void Start()
	{
		GlobalDatabase.m_BlobTable = new GameObject[m_BlobTable.Length];
		for (int idi = 0; idi < GlobalDatabase.m_BlobTable.Length; idi++)
			GlobalDatabase.m_BlobTable = m_BlobTable;

		// Reading Tabled Data Files
		string[] SpecRaw = File.ReadAllLines(@"SaveData\SpecTable.csv");
		string[] DropRaw = File.ReadAllLines(@"SaveData\DropTable.csv");
		string[] BarrelRaw = File.ReadAllLines(@"SaveData\BarrelTable.csv");

		//SpecDatabase Split
		GlobalDatabase.m_SpecTable = new WeaponPart[SpecRaw.Length - 1];
		for (int ids = 1; ids < SpecRaw.Length; ids++)
		{
			GlobalDatabase.m_SpecTable[ids - 1] = new WeaponPart(SpecRaw[ids].Split(','));
		}

		//DropTable Split
		GlobalDatabase.ItemIDX = new int[DropRaw.Length - 1];
		string[] temp = DropRaw[0].Split(',');
		GlobalDatabase.BoxName = new string[temp.Length-1];
		for (int idi = 1; idi < temp.Length; idi++)
			GlobalDatabase.BoxName[idi - 1] = temp[idi];
		GlobalDatabase.DropEx = new float[GlobalDatabase.BoxName.Length][];
		for (int idh = 0; idh < GlobalDatabase.DropEx.Length; idh++)
			GlobalDatabase.DropEx[idh] = new float[GlobalDatabase.ItemIDX.Length];
		for(int idv = 0; idv < GlobalDatabase.ItemIDX.Length; idv++)
		{
			temp = DropRaw[idv + 1].Split(',');
			GlobalDatabase.ItemIDX[idv] = int.Parse(temp[0]);
			for (int idh = 0; idh < GlobalDatabase.BoxName.Length; idh++) 
			{
				GlobalDatabase.DropEx[idh][idv] = float.Parse(temp[idh + 1]);
			}
		}

		//BarrelTable Split
		GlobalDatabase.BarrelIDX = new int[BarrelRaw.Length - 1];
		GlobalDatabase.BarrelOffset = new float[BarrelRaw.Length - 1];
		GlobalDatabase.BarrelLength = new float[BarrelRaw.Length - 1];

		for(int idi = 1; idi < BarrelRaw.Length; idi++)
		{
			temp = BarrelRaw[idi].Split(',');
			GlobalDatabase.BarrelIDX[idi - 1] = int.Parse(temp[0]);
			GlobalDatabase.BarrelOffset[idi - 1] = float.Parse(temp[1]);
			GlobalDatabase.BarrelLength[idi - 1] = float.Parse(temp[2]);
		}
	}
}

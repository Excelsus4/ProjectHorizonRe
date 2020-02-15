using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This static class gathers data from specDatabase and spriteDatabase 
/// in the FakeMain Scene and creates this it.
/// 
/// During the game, all data can be fetched from here, probably.
/// </summary>
public class GlobalDatabase {
	public static GameObject[] m_BlobTable;

	//Renewal Database
	public static WeaponPart[] m_SpecTable;
	public static Sprite[] m_SpriteTable;
	public static Sprite[] m_Frame;
	public static Sprite[] m_Icon;

	public static string[] BoxName;
	public static int[] ItemIDX;
	public static float[][] DropEx;

	public static int[] BarrelIDX;
	public static float[] BarrelOffset;
	public static float[] BarrelLength;

	public static Sprite GetWeaponPartSprite(int spriteIndex)
	{
		try
		{
			return m_SpriteTable[spriteIndex];
		}
		catch (System.IndexOutOfRangeException e)
		{
			Debug.Log(e);
		}
		return null;
	}

	public static Sprite GetWeaponIconSprite(int spriteIDX, int layerIDX)
	{
		switch (layerIDX)
		{
			case 0:
				return m_Frame[spriteIDX];
			case 1:
				return m_Icon[spriteIDX];
		}
		return null;
	}

	/// <summary>
	/// Use this to target a weapon part and creates a new instance of it.
	/// 
	/// </summary>
	/// <param name="index">Weapon Part Instance Creator</param>
	/// <returns></returns>
	public static WeaponPart BasicPartCreator(int index)
	{
		return new WeaponPart(index);
	}

	public static int GetRandomLoot(string name)
	{
		//TODO: Generate Random Root
		int lineCode = -1;

		//1. Search for the Box
		for(int idb = 0; idb < BoxName.Length; idb++)
		{
			if (BoxName[idb] == name)
				lineCode = idb;
		}

		if (lineCode == -1)
		{
			Debug.Log("box with that name not found");
			return -1;
		}

		//2. Scan Through the matrix for the box
		//3. Add up
		float tempSum = 0;

		for(int idi = 0; idi < ItemIDX.Length; idi++)
		{
			tempSum += DropEx[lineCode][idi];
		}

		//4. Get Random number between 0~Sum
		tempSum = Random.Range(0, tempSum);

		//5. Scan-again to search into the number
		for (int idi = 0; idi < ItemIDX.Length; idi++)
		{
			if (tempSum < DropEx[lineCode][idi])
			{
				lineCode = idi;
				break;
			}
			else
				tempSum -= DropEx[lineCode][idi];
		}

		//6. return the IDX number
		return lineCode;
	}

	/// <summary>
	/// This is used for getting the offset for gun flare effect.
	/// </summary>
	/// <param name="BarrelIndex">The Barrel number, equivalant with sprite.</param>
	/// <returns></returns>
	public static float GetBarrelOffset(int BarrelIndex)
	{
		int temp = ScanBarrel(BarrelIndex);
		if (temp == -1)
			return temp;
		else
			return BarrelOffset[temp];
	}

	/// <summary>
	/// Similar to get barrel offset but it returns the length of the barrel instead.
	/// TODO: what is the difference exactly?
	/// </summary>
	/// <param name="BarrelIndex">The Barrel number, equivalant with sprite.</param>
	/// <returns></returns>
	public static float GetBarrelLength(int BarrelIndex)
	{
		int temp = ScanBarrel(BarrelIndex);
		if (temp == -1)
			return temp;
		else
			return BarrelLength[temp];
	}

	private static int ScanBarrel(int BarrelIndex)
	{
		for (int idi = 0; idi < BarrelIDX.Length; idi++)
		{
			if (BarrelIDX[idi] == BarrelIndex)
				return idi;
		}
		return -1;
	}
}

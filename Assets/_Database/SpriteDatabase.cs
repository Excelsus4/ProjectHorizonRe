using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDatabase : MonoBehaviour
{
	public Sprite[] m_UniversalParts;
	public Sprite[] m_Frame;
	public Sprite[] m_Icon;

	private void Start()
	{
		int idi;

		//RENWEAL SCRIPT
		GlobalDatabase.m_SpriteTable = new Sprite[m_UniversalParts.Length];
		for (idi = 0; idi < GlobalDatabase.m_SpriteTable.Length; idi++)
			GlobalDatabase.m_SpriteTable[idi] = m_UniversalParts[idi];

		GlobalDatabase.m_Frame = new Sprite[m_Frame.Length];
		for (idi = 0; idi < GlobalDatabase.m_Frame.Length; idi++)
			GlobalDatabase.m_Frame[idi] = m_Frame[idi];

		GlobalDatabase.m_Icon = new Sprite[m_Icon.Length];
		for (idi = 0; idi < GlobalDatabase.m_Icon.Length; idi++)
			GlobalDatabase.m_Icon[idi] = m_Icon[idi];

	}
}

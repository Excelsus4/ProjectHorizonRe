using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {
	public object[] m_CurrentStatus;

	protected WeaponPart.PartType[] m_partRequired;
	protected List<WeaponPart> m_WeaponPartInventory;

	public enum WeaponType
	{
		Primary,
		Pistol,
		Dagger
	}

	public Weapon()
	{
		m_CurrentStatus = new object[13];

		m_WeaponPartInventory = new List<WeaponPart>();
	}

	protected abstract void CreateBasicState();
	//protected abstract void CallbackRenderer();

	public int GetPartRequiredLength()
	{
		if (m_partRequired == null)
			return 0;
		else
			return m_partRequired.Length;
	}

	public WeaponPart GetPartByIndex(int index)
	{
		return m_WeaponPartInventory[index];
	}

	public WeaponPart ChangeWeaponPart(WeaponPart tryThis)
	{
		WeaponPart tempWeaponPart;

		for (int idi = 0; idi < m_partRequired.Length; idi++)
		{
			if (m_partRequired[idi] == tryThis.P_PartType)
			{
				tempWeaponPart = m_WeaponPartInventory[idi];
				m_WeaponPartInventory[idi] = tryThis;
				return tempWeaponPart;
			}
			else
			{
				//DO NOTHING
			}
		}

		return null;
	}

	//스펙 재계산 프로토콜
	public void RecalculateStats()
	{
		//다 초기화하고
		for (int idi = 0; idi < m_CurrentStatus.Length; idi++)
			m_CurrentStatus[idi] = null;

		//이중 리시버/블레이드 파트는 메인파트로 특별취급
		if (m_WeaponPartInventory[0] == null)
			return;
		else
			ProcessPartSpecification(m_WeaponPartInventory[0], true);

		//그 외 모든 파츠의
		for (int idw = 1; idw < m_WeaponPartInventory.Count; idw++)
		{
			if(m_WeaponPartInventory[idw]==null)
			{
				//슬롯이 비어있을때 스킵
				continue;
			}
			else
			{
				ProcessPartSpecification(m_WeaponPartInventory[idw], false);
			}
		}
	}

	private void ProcessPartSpecification(WeaponPart weaponPart, bool isMainPart)
	{
		for(int ids = 0; ids < weaponPart.P_SpecValue.Length; ids++)
		{
			switch (ids)
			{
				case 0:
				case 4:
				case 5:
				case 6:
				case 7:
				case 11:
					m_CurrentStatus[ids] = (float)weaponPart.P_SpecValue[ids] + (m_CurrentStatus[ids] != null ? (float)m_CurrentStatus[ids] : 0);
					break;
				case 1:
				case 2:
				case 8:
				case 9:
				case 10:
				case 12:
					if (isMainPart)
						m_CurrentStatus[ids] = (float)weaponPart.P_SpecValue[ids];
					else
						m_CurrentStatus[ids] = (float)weaponPart.P_SpecValue[ids] * (float)m_CurrentStatus[ids];
					break;
				case 3:
					break;
			}
		}
	}
}

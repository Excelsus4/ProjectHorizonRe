using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This weapon renderer is used in armory AND unit's hand
/// 
/// </summary>
public class WeaponRenderer : MonoBehaviour
{
	public int m_WeaponNumberIndicator;
	public Weapon.WeaponType m_WeaponType;
	public WeaponPart.PartType[] PartRequired;
	public SpriteRenderer[] PartSprites;

	private int BarrelNumber;

	public int BarrelLocation;
	public int MuzzleLocation;

	private void Start()
	{
		BarrelNumber = -1;
		GlobalWeaponData.WeaponRendererCallback.Add(this);
		UpdateToCurrent();
	}

	public void Enable(bool enable)
	{
		for(int idi = 0; idi < PartSprites.Length; idi++)
		{
			PartSprites[idi].enabled = enable;
		}
		if (enable)
			UpdateToCurrent();
	}

	public void ChangeSprite(WeaponPart toThisPart)
	{
		for (int idi = 0; idi < PartRequired.Length; idi++)
		{
			if (PartRequired[idi] == toThisPart.P_PartType)
			{
				if (toThisPart.P_PartType == WeaponPart.PartType.Barrel)
					BarrelNumber = toThisPart.P_SpriteIndex;
				else if (toThisPart.P_PartType == WeaponPart.PartType.Pistol)
					BarrelNumber = toThisPart.P_SpriteIndex;

				PartSprites[idi].sprite = GlobalDatabase.GetWeaponPartSprite(toThisPart.P_SpriteIndex);
				ResetMuzzleLocation();
				return;
			}
		}
	}
	
	//꽤나 무거운 전체업데이트 메서드
	public void UpdateToCurrent()
	{
		//모두 비활성화
		for(int idr = 0; idr < PartSprites.Length; idr++)
		{
			PartSprites[idr].enabled = false;
		}

		if (GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator] == null)
			return;

		//이중for문을 이용해 무기데이터와 렌더러를 행렬로 가상화하는 일종의 가상 매트릭스 형성
		for (int idi = 0; idi < GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartRequiredLength(); idi++)
		{
			for (int idr = 0; idr < PartSprites.Length; idr++)
			{
				//일치하는 파트에서
				if (GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi) == null)
					continue;
				else if (PartRequired[idr] == GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_PartType)
				{
					// 스프라이트 처리
					PartSprites[idr].enabled = true;
					PartSprites[idr].sprite =
						GlobalDatabase.GetWeaponPartSprite(
							GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_SpriteIndex);
					if (GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_PartType == WeaponPart.PartType.Barrel)
						BarrelNumber = GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_SpriteIndex;
					else if (GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_PartType == WeaponPart.PartType.Pistol)
						BarrelNumber = GlobalWeaponData.g_AllWeapon[m_WeaponNumberIndicator].GetPartByIndex(idi).P_SpriteIndex;
				}
			}
		}
		ResetMuzzleLocation();
	}

	//총열 길이에 따라 총구위치 보정
	public void ResetMuzzleLocation()
	{
		if (MuzzleLocation == -1)
		{
			//총구가 없는 총기(?)는 스킵
		}
		else if (BarrelNumber == -1)
		{
			//총열이 없는 총기는 스킵
			//PartSprites[MuzzleLocation].transform.Translate(-PartSprites[MuzzleLocation].transform.localPosition.x, PartSprites[MuzzleLocation].transform.localPosition.y, 0f);
		}
		else {
			PartSprites[BarrelLocation].transform.localPosition = new Vector3(0.85f, GlobalDatabase.GetBarrelOffset(BarrelNumber), 0f);
			PartSprites[MuzzleLocation].transform.localPosition = new Vector3(GlobalDatabase.GetBarrelLength(BarrelNumber), GlobalDatabase.GetBarrelOffset(BarrelNumber), 0f);
		}
	}

	public Transform GetMuzzle()
	{
		if (MuzzleLocation == -1)
			return null;
		else
			return PartSprites[MuzzleLocation].transform;
	}

	//단검 전용 콜라이더 리턴 메서드
	public Collider2D GetBayonetCollider()
	{
		return GetComponent<Collider2D>();
	}
}

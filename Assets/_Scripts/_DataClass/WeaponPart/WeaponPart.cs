using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPart {
	public enum AttackType
	{
		NA,
		Rifle,
		Pistol,
		LongRifle,
		Shotgun,
		Explosive
	}

	public enum PartType
	{
		Barrel,
		Blade,
		Handle,
		Magazine,
		Muzzle,
		Receiver,
		Sight,
		Stock,
		Pistol
	}

	public enum PartGrade
	{
		PrivateGrade,
		MilitaryGrade,
		ModifiedGrade,
		SpecialGrade
	}

	public enum Specification
	{
		//====무게1====
		Weight,
		//====깡뎀4====
		AttackDamage,
		AttackSpeed,
		AttackType,
		//====특뎀8====
		CriticalDamage,
		CriticalChance,
		PiercePercent,
		PierceAmount,
		//====반동11====
		Stability,		//총기 반동 생성량 제어
		Accuracy,		//초탄을 포함해서 항상 발생하는 손 흔들림 보정
		Recovery,		//반동이 발생한 후에 총구가 다시 원래위치로 돌아오는 속도
		//====장탄13====
		Rounds,
		ReloadSpeed
		//====※주의: 스텟 추가할경우 아래의 항목에서 수정필요====
		//Weapon.cs에서 m_CurrentStatus
		//WeaponPart.cs에서 WeaponPart(string[])생성자에 SpecValue초기화사이즈
	}

	public int m_ItemCode;

	protected PartGrade m_grade;

	protected PartType m_partType;
	protected string m_name;
	protected int m_spriteIndex;
	protected object[] m_SpecValue;

	public PartType P_PartType
	{
		get { return m_partType; }
	}
	public string P_Name
	{
		get { return m_name; }
	}
	public PartGrade P_PartGrade
	{
		get { return m_grade; }
	}
	public int P_SpriteIndex
	{
		get { return m_spriteIndex; }
	}
	public object[] P_SpecValue
	{
		get { return m_SpecValue; }
	}

	//리뉴얼 데이터베이스에서 csv로 초기화하기
	public WeaponPart(string[] rawData)
	{
		m_ItemCode = int.Parse(rawData[0]);
		m_name = rawData[1];
		m_spriteIndex = int.Parse(rawData[2]);
		switch (rawData[3])
		{
			case "Barrel":
				m_partType = PartType.Barrel;
				break;
			case "Magazine":
				m_partType = PartType.Magazine;
				break;
			case "Receiver":
				m_partType = PartType.Receiver;
				break;
			case "Sight":
				m_partType = PartType.Sight;
				break;
			case "Stock":
				m_partType = PartType.Stock;
				break;
			case "Muzzle":
				m_partType = PartType.Muzzle;
				break;
			case "Pistol":
				m_partType = PartType.Pistol;
				break;
			case "Blade":
				m_partType = PartType.Blade;
				break;
			case "Handle":
				m_partType = PartType.Handle;
				break;
		}
		switch (rawData[4])
		{
			case "Normal":
				m_grade = PartGrade.PrivateGrade;
				break;
			case "Special":
				m_grade = PartGrade.MilitaryGrade;
				break;
			case "Custom":
				m_grade = PartGrade.ModifiedGrade;
				break;
			case "Masterpiece":
				m_grade = PartGrade.SpecialGrade;
				break;
		}
		m_SpecValue = new object[13];
		for(int ids = 0; ids < m_SpecValue.Length; ids++)
		{
			switch (ids)
			{
				case 3:
					switch (rawData[ids + 5])
					{
						case "NA":
							m_SpecValue[ids] = AttackType.NA;
							break;
						case "Rifle":
							m_SpecValue[ids] = AttackType.Rifle;
							break;
						case "Pistol":
							m_SpecValue[ids] = AttackType.Pistol;
							break;
						case "LongRifle":
							m_SpecValue[ids] = AttackType.LongRifle;
							break;
						case "Shotgun":
							m_SpecValue[ids] = AttackType.Shotgun;
							break;
						case "Explosive":
							m_SpecValue[ids] = AttackType.Explosive;
							break;
					}
					break;
				default:
					m_SpecValue[ids] = float.Parse(rawData[ids + 5]);
					break;
			}
		}
	}

	//리뉴얼 데이터베이스에서 아이템코드로 복사해 생성하기
	public WeaponPart(int ItemCode)
	{
		WeaponPart Sample = GlobalDatabase.m_SpecTable[ItemCode];
		m_ItemCode = Sample.m_ItemCode;
		m_grade = Sample.P_PartGrade;
		m_partType = Sample.P_PartType;
		m_name = Sample.P_Name;
		m_spriteIndex = Sample.P_SpriteIndex;
		m_SpecValue = new object[Sample.P_SpecValue.Length];
		for(int idi =0; idi < Sample.P_SpecValue.Length; idi++)
		{
			m_SpecValue[idi] = Sample.P_SpecValue[idi];
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.meiguofandian.ProjectHorizon.WeaponNInventory;
using com.meiguofandian.ProjectHorizon.GamePlay.Shootables;

namespace com.meiguofandian.ProjectHorizon.GamePlay.Shooting {
	public class VoxelInputControl : MonoBehaviour, IDataUpdateCallback {
		public enum FireMode {
			Auto,
			Semi,
			Burst
		}

		//Interaction with Other Scripts
		public static Transform CharacterLocation;
		public VoxelAnimationControl m_AnimationControl;

		//STATUS FLAG
		public bool m_isLookingLeft { get; private set; }
		[HideInInspector]
		public bool m_LockAction;


		//public int m_MaxAmmo;		//장탄수
		private UserHandWeaponData m_weaponManager;
		private WeaponInstance m_weapon;
		private Statistics m_stats;
		/*public float m_Stability;   //추가반동 배율 (초탄에 적용안됨)
		public float m_Accuracy;    //기본 흔들림 배율
		public float m_Recover;     //반동회복 배율
		public float m_Recoil;      //반동량 배율*/

		//FIRE CONTROL
		private int m_CurrentAmmo;
		private float m_RecoilAngle;//현재 반동값
		public Transform[] m_MuzzleLocation;
		public LineRenderer m_BulletLine;

		private FireMode m_CurrentFireMode;
		private bool m_MouseState;
		private int m_DelayFire;

		//External UI Control
		//private bool[] isUIOn = new bool[4];
		//public GameObject[] UIPanel = new GameObject[4];

		//Weapon Graphics Control
		//public WeaponRenderer m_MainWeapon;

		private void Awake() {

			m_LockAction = false;
			//m_LockMovement = false;

			CharacterLocation = transform;

			m_weaponManager = UserHandWeaponData.getSingleton();
			m_weaponManager.RegisterObserver(this);
			m_CurrentAmmo = m_stats.rounds;
			m_DelayFire = 0;
		}

		private void UpdateWeapon() {
			m_weapon = m_weaponManager.weapon;
			m_stats = m_weapon.weaponStats;
			m_AnimationControl.UpdateBulletIndicator(m_stats.rounds, m_CurrentAmmo);
		}

		private void FixedUpdate() {
			if (Input.GetButtonDown("FireMode")) {
				switch (m_CurrentFireMode) {
				case FireMode.Semi:
					m_CurrentFireMode = FireMode.Burst;
					break;
				case FireMode.Burst:
					m_CurrentFireMode = FireMode.Auto;
					break;
				case FireMode.Auto:
					m_CurrentFireMode = FireMode.Semi;
					break;
				}
			}

			//CheckGround();
			//Movement();
			Action();
			//CheckUIKey();
		}

		private void Action() {
			if (!m_LockAction) {
				//SwitchWeapon();
				Aim();
				FireModeChecker();

				if (Input.GetButtonDown("Reload")) {
					m_AnimationControl.Reload();
					m_LockAction = true;
				}
			}
		}

		private void TryFire() {
			if (m_CurrentAmmo > 0) {
				FireMethod();
			} else if (m_CurrentAmmo == 0) {
				m_AnimationControl.Reload();
				m_LockAction = true;
			}
		}

		private void FireMethod() {
			m_LockAction = true;
			m_AnimationControl.Fire(m_stats.attackSpeed / 300f);
			//m_AnimationControl.Fire((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackSpeed] / 300f);
			m_AnimationControl.GenerateShell();
			m_AnimationControl.UpdateBulletIndicator(m_stats.rounds, --m_CurrentAmmo);
			//m_AnimationControl.UpdateBulletIndicator(Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]), m_CurrentAmmo);

			RaycastHit2D hitdata = Physics2D.Raycast(m_MuzzleLocation[0].position, -m_MuzzleLocation[0].forward, 100f, LayerMask.GetMask("Mob", "Terrain"));
			m_BulletLine.SetPosition(0, m_MuzzleLocation[0].position - new Vector3(0, 0, 0.7f));
			m_BulletLine.startColor = m_BulletLine.endColor = Color.yellow;
			if (hitdata.collider != null) {
				m_BulletLine.SetPosition(1, hitdata.point);
				MobHealthManager target = hitdata.collider.GetComponent<MobHealthManager>();

				DealDamageToThisMob(target);
			} else
				m_BulletLine.SetPosition(1, m_MuzzleLocation[0].position - m_MuzzleLocation[0].forward * 100f);
		}

		private void Aim() {
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 difference = worldPos - transform.position;
			m_isLookingLeft = difference.x < 0;
			m_AnimationControl.LookAt(Mathf.Rad2Deg * Mathf.Atan(difference.y / difference.x), m_isLookingLeft);
		}

		//Callback Function From VoxelHandCallback.cs
		public void ReloadComplete() {
			m_CurrentAmmo = m_stats.rounds;
			m_AnimationControl.UpdateBulletIndicator(m_stats.rounds, m_CurrentAmmo);
		}

		public void DealDamageToThisMob(MobHealthManager target) {
			if (target != null) {
				target.DealDamage(m_stats.damage, DamageRenderer.DamageType.Normal);
				//피해량 공식
				/*float TempPenetrationDamage =
					(float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage] *
					(float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.PiercePercent] +
					(float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.PierceAmount];
				if (TempPenetrationDamage > (float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage])
					target.DealDamage((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage],
						DamageRenderer.DamageType.Penetration);
				else if (TempPenetrationDamage > 0)
					target.DealDamage(TempPenetrationDamage, DamageRenderer.DamageType.Penetration);
				float TempNormalDamage =
					(float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage] -
					TempPenetrationDamage;
				if (TempNormalDamage > 0) {
					if (Random.Range(0f, 1f) < (float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalChance]) {
						TempNormalDamage *= (float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalDamage] + 1f;
						target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Critical);
					} else {
						target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Normal);
					}
				}*/
			
			}
		}

		public void OnMDown() {
			m_MouseState = true;
			if (m_CurrentFireMode == FireMode.Burst) {
				m_DelayFire += 3;
			} else if (m_CurrentFireMode == FireMode.Semi) {
				m_DelayFire += 1;
			}
		}

		public void OnMUp() {
			m_MouseState = false;
		}

		private void FireModeChecker() {
			if (m_MouseState && m_CurrentFireMode == FireMode.Auto)
				TryFire();
			else if (m_DelayFire > 0) {
				TryFire();
				m_DelayFire--;
			}
		}

		public void OnDataUpdate() {
			UpdateWeapon();
		}
	}
}
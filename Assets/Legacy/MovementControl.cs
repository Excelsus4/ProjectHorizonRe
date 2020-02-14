using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {
	/*public static Transform CharacterLocation;

	public float m_MovementSpeed;
	public float m_JumpPower;
	public float m_ShellUpForce;
	public float m_ShellBackForce;

	public AnimationControl m_AnimationControlScript;
	public Transform m_Arm;
	public LineRenderer m_BulletLine;
	public Transform m_Muzzle;
	public Transform m_Receiver;
	public GameObject m_Shell;
	public RightArmControl m_RightArm;
	public LeftArmControl m_LeftArm;
	public UnityEngine.UI.Slider m_BulletIndicator;
	public GameObject m_Grenade;
	public WeaponRenderer[] m_WeaponRenderer;
	public FireControl m_FireControl;

	private Rigidbody2D m_rigidbody;
	private float m_unstableDegree;
	private float m_delayedUnstable;
	private float m_weaponCooltime;
	private int m_bulletsLeft;
	private int m_currentWeaponNumber;

	[HideInInspector]
	public bool m_grenadeOnHand;
	[HideInInspector]
	public bool m_LockAction;
	[HideInInspector]
	public bool m_LockRotation;
	[HideInInspector]
	public bool m_LockMovement;

	// Use this for initialization
	void Start () {
		MovementControl.CharacterLocation = transform;
		m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
		m_unstableDegree = 0f;
		m_bulletsLeft = Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]);
		UpdateBulletIndicator();
		m_currentWeaponNumber = 1;
		ChangeWeapon(m_currentWeaponNumber);

		//Universal Lock boolean
		m_LockAction = false;
		m_LockRotation = false;
		m_LockMovement = false;
	}

	private void UpdateBulletIndicator()
	{
		m_BulletIndicator.value = m_bulletsLeft / Mathf.Ceil((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]);
	}

	public void CallbackReload()
	{
		m_bulletsLeft = Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]);
		UpdateBulletIndicator();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_RightArm.m_isReloading)
		{
			m_Arm.LookAt(m_Arm.transform.position + new Vector3(m_RightArm.m_isOpposite ? -1f : 1f, 0, 0));
		}
		else
		{
			Vector3 mousePos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			//스크린포인트하면 Z축 조정필요하므로 0으로 맞춰줌
			worldPos.z = 0f;
			m_Arm.LookAt(worldPos);
			if(m_RightArm.transform.rotation.eulerAngles.y < 90f)
			{
				m_AnimationControlScript.FlipBody(false);
			}
			else
			{
				m_AnimationControlScript.FlipBody(true);
			}

			//부드러운 반동효과
			if (m_delayedUnstable > 0.1f || m_delayedUnstable < -0.1f)
			{
				m_unstableDegree += m_delayedUnstable / 0.6f;
				m_delayedUnstable -= m_delayedUnstable / 0.6f;
			}

			//반동제어 효과
			if (m_unstableDegree > 0.1f || m_unstableDegree < -0.1f)
			{
				if(m_RightArm.transform.rotation.eulerAngles.y < 90f)
					m_Arm.Rotate(m_unstableDegree, 0f, 0f);
				else
					m_Arm.Rotate(-m_unstableDegree, 0f, 0f);

				if (m_unstableDegree > GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Accuracy] * Time.deltaTime)
					m_unstableDegree -= GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Accuracy] * Time.deltaTime;
				else if (m_unstableDegree < -GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Accuracy] * Time.deltaTime)
					m_unstableDegree += GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Accuracy] * Time.deltaTime;
				else if (m_unstableDegree != 0)
					m_unstableDegree = 0;
			}
		}
	}

	private void FixedUpdate()
	{
		//Fire
		m_weaponCooltime -= Time.deltaTime;

		//이동관련 액션
		if (!m_LockMovement)
		{
			//수평 이동
			float horizontalInput = Input.GetAxis("Horizontal");
			if (horizontalInput > 0)
			{
				transform.Translate(
					(m_MovementSpeed -
					GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Weight] * 0.01f)
					* Time.deltaTime * horizontalInput, 0, 0);
				m_AnimationControlScript.LegPlus();
			}
			else if (horizontalInput < 0)
			{
				transform.Translate(
					(m_MovementSpeed -
					GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Weight] * 0.01f)
					* Time.deltaTime * horizontalInput, 0, 0);
				m_AnimationControlScript.LegMinus();
			}
			else
			{
				m_AnimationControlScript.LegIdle();
			}

			//점프
			if (m_rigidbody.IsTouchingLayers(LayerMask.GetMask("Terrain")) && Input.GetButton("Jump") && m_rigidbody.velocity.y == 0)
			{
				m_rigidbody.AddForce(new Vector2(0, 300000f));
			}
		}

		//손을 사용하는 액션류
		if (!m_LockAction)
		{
			if (Input.GetButton("Reload") && !m_grenadeOnHand)
			{
				//재장전
				Reload();
			}
			else if (Input.GetButtonDown("Grenade") && !m_grenadeOnHand && !m_RightArm.m_isReloading)
			{
				//수류탄 준비
				m_grenadeOnHand = true;
				m_LeftArm.GrenadeReady(this);
			}
			else if (Input.GetButton("Reload") && m_grenadeOnHand)
			{
				//수류탄 핀뽑기
				m_LeftArm.GrenadeTick();
			}   //무기 교체 (1, 2, 3, 4)
			else if (Input.GetButton("Weapon1") && !m_grenadeOnHand && !m_RightArm.m_isReloading)
				ChangeWeapon(1);
			else if (Input.GetButton("Weapon2") && !m_grenadeOnHand && !m_RightArm.m_isReloading)
				ChangeWeapon(2);
			else if (Input.GetButton("Weapon3") && !m_grenadeOnHand && !m_RightArm.m_isReloading)
				ChangeWeapon(3);
			else if (Input.GetButton("Weapon4") && !m_grenadeOnHand && !m_RightArm.m_isReloading)
				ChangeWeapon(4);
		}
	}

	private void ChangeWeapon(int WeaponNumber)
	{
		m_currentWeaponNumber = WeaponNumber;
		GlobalWeaponData.g_CurrentWeapon = GlobalWeaponData.g_AllWeapon[WeaponNumber - 1];
		if (WeaponNumber == 1 || WeaponNumber == 2)
		{
			m_AnimationControlScript.ChangeRightArmSprite(1);
			m_AnimationControlScript.ChangeLeftArmSprite(0);
			//Rifle
			m_WeaponRenderer[0].Enable(true);
			m_WeaponRenderer[1].Enable(false);
			m_WeaponRenderer[2].Enable(false);
			m_Muzzle = m_WeaponRenderer[0].GetMuzzle();
			//TODO: Some Weapon Change Motion comes here and then call back the reload
			CallbackReload();
		}
		else if (WeaponNumber == 3)
		{
			m_AnimationControlScript.ChangeRightArmSprite(1);
			m_AnimationControlScript.ChangeLeftArmSprite(2);
			//Pistol
			m_WeaponRenderer[0].Enable(false);
			m_WeaponRenderer[1].Enable(true);
			m_WeaponRenderer[2].Enable(false);
			m_Muzzle = m_WeaponRenderer[1].GetMuzzle();
			//TODO: Some Weapon Change Motion comes here and then call back the reload
			CallbackReload();
		}
		else if (WeaponNumber == 4)
		{
			m_AnimationControlScript.ChangeRightArmSprite(1);
			m_AnimationControlScript.ChangeLeftArmSprite(0);
			//Dagger
			m_WeaponRenderer[0].Enable(false);
			m_WeaponRenderer[1].Enable(false);
			m_WeaponRenderer[2].Enable(true);
			//TODO: Some Weapon Change Motion comes here and then call back the reload
			CallbackReload();
		}
	}

	private void SwordFight()
	{
		m_LeftArm.StartAttack(this, 
			GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackSpeed],
			GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage]);
	}

	public void FireTry()
	{
		//손을 사용하는 액션류
		if (!m_LockAction)
		{
			if (Input.GetButton("Fire") && m_grenadeOnHand)
			{
				//수류탄 투척
				m_LeftArm.GrenadeThrow();
			}
			else if (Input.GetButton("Fire") && m_weaponCooltime < 0 && !m_RightArm.m_isReloading && !m_grenadeOnHand)
			{
				//공격시도 (사격 혹은 재장전)
				if (m_bulletsLeft > 0)
					Fire();
				else
					Reload();
			}
		}
	}

	private void Fire()
	{
		if (m_currentWeaponNumber == 4)
			//검격
			SwordFight();
		else
		{
			//사격
			m_bulletsLeft--;
			UpdateBulletIndicator();
			float Amount = 500f / GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Stability];
			float unstableness = Random.Range(0, Amount);
			if (unstableness < Amount / 2)
				unstableness -= Amount;
			m_delayedUnstable += unstableness;

			m_weaponCooltime = 60f / GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackSpeed];

			RaycastHit2D hitData = Physics2D.Raycast(m_Muzzle.position, m_Arm.forward, 100f, LayerMask.GetMask("Mob", "Terrain"));
			m_BulletLine.SetPosition(0, m_Muzzle.position - new Vector3(0, 0, 0.7f));
			m_BulletLine.startColor = m_BulletLine.endColor = Color.yellow;
			Instantiate(m_Shell, m_Receiver.position, Quaternion.Euler(0, 0, 0)).GetComponent<Rigidbody2D>().AddForce(Random.Range(0.9f, 1.1f) * m_Arm.up * m_ShellUpForce - m_Arm.forward * m_ShellBackForce);
			if (hitData.collider != null)
			{
				m_BulletLine.SetPosition(1, hitData.point);
				MobHealthManager target = hitData.collider.GetComponent<MobHealthManager>();

				DealDamageToThisMob(target, 1f);
			}
			else
				m_BulletLine.SetPosition(1, m_Muzzle.position + m_Arm.forward * 100f);
			m_AnimationControlScript.PutFlareHere(m_Muzzle);
		}
	}

	private void ThrowGrenade()
	{
		Instantiate(m_Grenade, m_Muzzle.position, Quaternion.Euler(0, 0, 0)).GetComponent<Rigidbody2D>().AddForce(m_Arm.forward*0.02f);
	}

	private void Reload()
	{
		if (m_RightArm.transform.rotation.eulerAngles.y < 90f)
		{
			m_Arm.LookAt(m_Arm.transform.position + new Vector3(1f, 0, 0));
		}
		else
		{
			m_Arm.LookAt(m_Arm.transform.position + new Vector3(-1f, 0, 0));
			m_RightArm.m_isOpposite = true;
		}
		m_RightArm.StartReload(GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.ReloadSpeed], this);
	}

	public void TurnWeaponSprite(bool isOn)
	{
		m_WeaponRenderer[m_currentWeaponNumber - 1].Enable(isOn);
	}

	public static void DealDamageToThisMob(MobHealthManager target, float Multiplier)
	{
		if (target != null)
		{
			//피해량 공식
			float TempPenetrationDamage =
				GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage] *
				GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.PiercePercent]/100 +
				GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.PierceAmount];
			if (TempPenetrationDamage > 0)
				target.DealDamage(TempPenetrationDamage, DamageRenderer.DamageType.Penetration);
			float TempNormalDamage =
				GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackDamage] -
				TempPenetrationDamage;
			if (TempNormalDamage > 0)
			{
				if (Random.Range(0f, 100f) < GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalChance])
				{
					TempNormalDamage *= GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalDamage]/100 + 1f;
					target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Critical);
				}
				else
				{
					target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Normal);
				}
			}
		}
	}*/
}

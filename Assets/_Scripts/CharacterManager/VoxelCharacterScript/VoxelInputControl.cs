using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelInputControl : MonoBehaviour {
	public enum WeaponNumber
	{
		PrimaryWeapon,
		SecondaryWeapon,
		Pistol,
		Dagger
	}
	
	public enum ExternalUI
	{
		Inventory,
		Equipment,
		Resource,
		Skill
	}

	public enum FireMode
	{
		Auto,
		Semi,
		Burst
	}

	//Interaction with Other Scripts
	public static Transform CharacterLocation;
	public VoxelAnimationControl m_AnimationControl;

	//GroundCheck
	//private Rigidbody2D m_rigidbody;
	//private LayerMask m_terrainLayerMask;
	//public Transform m_GroundCheck;

	//STATUS FLAG
	public bool m_isLookingLeft { get; private set; }
	//private bool m_isOnGround;
	//[HideInInspector]
	//public bool m_LockMovement;
	[HideInInspector]
	public bool m_LockAction;
	//private float m_horizontalMovement;

	//FINAL STATS
	//public float m_MovementSpeed;
	//public float m_JumpForce;
	//public float m_MaxSpeed;
	//public float m_FireSpeed;

	//public int m_MaxAmmo;		//장탄수

	public float m_Stability;	//추가반동 배율 (초탄에 적용안됨)
	public float m_Accuracy;	//기본 흔들림 배율
	public float m_Recover;		//반동회복 배율
	public float m_Recoil;      //반동량 배율

	//FIRE CONTROL
	private WeaponNumber m_CurrentWeapon;
	private int m_CurrentAmmo;
	private float m_RecoilAngle;//현재 반동값
	public Transform[] m_MuzzleLocation;
	public LineRenderer m_BulletLine;

	private FireMode m_CurrentFireMode;
	private bool m_MouseState;
	private int m_DelayFire;

	//External UI Control
	private bool[] isUIOn = new bool[4];
	public GameObject[] UIPanel = new GameObject[4];

	//Weapon Graphics Control
	public WeaponRenderer m_MainWeapon;

	private void Awake()
	{
		/*m_rigidbody = GetComponent<Rigidbody2D>();
		m_terrainLayerMask = LayerMask.GetMask("Terrain");
		m_horizontalMovement = 0f;*/

		m_LockAction = false;
		//m_LockMovement = false;

		CharacterLocation = transform;
		if (GlobalWeaponData.g_CurrentWeapon == null)
			return;
		m_CurrentAmmo = Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]);
		m_AnimationControl.UpdateBulletIndicator(Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]), m_CurrentAmmo);
		m_DelayFire = 0;

		for (int idi = 0; idi < isUIOn.Length; idi++)
		{
			isUIOn[idi] = true;
			//ToggleUI((ExternalUI)idi);
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetButtonDown("FireMode"))
		{
			switch (m_CurrentFireMode)
			{
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
	/*
	private void CheckGround()
	{
		RaycastHit2D hit2D = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_terrainLayerMask);
		if (hit2D)
		{
			m_isOnGround = true;
			m_AnimationControl.SetGrounded(true);
		}
		else
		{
			m_isOnGround = false;
			m_AnimationControl.SetGrounded(false);
		}
	}

	private void Movement()
	{
		if (!m_LockMovement)
		{
			Move();
			if (m_isOnGround)
			{
				//Move();
				Jump();
			}
		}
	}*/

	private void Action()
	{
		if (!m_LockAction)
		{
			SwitchWeapon();
			Aim();
			FireModeChecker();

			if (Input.GetButtonDown("Reload"))
			{
				m_AnimationControl.Reload();
				m_LockAction = true;
			}
		}
	}

	/*private void CheckUIKey()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			ToggleInventory();
		}
		if (Input.GetButtonDown("Equipment"))
		{
			ToggleEquipment();
		}
		if (Input.GetButtonDown("Resource"))
		{
			ToggleResource();
		}
		if (Input.GetButtonDown("Skill"))
		{
			ToggleSkill();
		}
	}*/

	private void TryFire()
	{
		if (m_CurrentAmmo > 0)
		{
			FireMethod();
		}
		else if (m_CurrentAmmo == 0)
		{
			m_AnimationControl.Reload();
			m_LockAction = true;
		}
	}

	private void FireMethod()
	{
		if (m_CurrentWeapon == WeaponNumber.PrimaryWeapon)
		{
			m_LockAction = true;
			m_AnimationControl.Fire((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.AttackSpeed] / 300f);
			m_AnimationControl.GenerateShell();
			m_CurrentAmmo--;
			m_AnimationControl.UpdateBulletIndicator(Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]), m_CurrentAmmo);

			RaycastHit2D hitdata = Physics2D.Raycast(m_MuzzleLocation[0].position, -m_MuzzleLocation[0].forward, 100f, LayerMask.GetMask("Mob", "Terrain"));
			m_BulletLine.SetPosition(0, m_MuzzleLocation[0].position - new Vector3(0, 0, 0.7f));
			m_BulletLine.startColor = m_BulletLine.endColor = Color.yellow;
			if (hitdata.collider != null)
			{
				m_BulletLine.SetPosition(1, hitdata.point);
				MobHealthManager target = hitdata.collider.GetComponent<MobHealthManager>();

				DealDamageToThisMob(target);
			}
			else
				m_BulletLine.SetPosition(1, m_MuzzleLocation[0].position - m_MuzzleLocation[0].forward * 100f);
		}
		else if (m_CurrentWeapon == WeaponNumber.Dagger)
		{
			m_LockAction = true;
			m_AnimationControl.Fire(1);
		}
	}

	/*private void Move()
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		if (m_isLookingLeft)
		{
			if (horizontalInput < 0f)
				m_rigidbody.velocity = new Vector2(m_MovementSpeed * horizontalInput, m_rigidbody.velocity.y);
			else
				m_rigidbody.velocity = new Vector2(m_MovementSpeed * horizontalInput * 0.6f, m_rigidbody.velocity.y);
			m_AnimationControl.SetWalkingSpeed(-horizontalInput);
		}
		else
		{
			if (horizontalInput > 0f)
				m_rigidbody.velocity = new Vector2(m_MovementSpeed * horizontalInput, m_rigidbody.velocity.y);
			else
				m_rigidbody.velocity = new Vector2(m_MovementSpeed * horizontalInput * 0.6f, m_rigidbody.velocity.y);
			m_AnimationControl.SetWalkingSpeed(horizontalInput);
		}
	}

	private void Jump()
	{
		if (Input.GetButton("Jump"))
		{
			m_rigidbody.AddForce(Vector2.up * m_JumpForce);
			m_isOnGround = false;
			m_AnimationControl.SetGrounded(false);
		}
	}*/

	private void SwitchWeapon()
	{
		if (Input.GetButton("Weapon1"))
		{
			m_MainWeapon.m_WeaponNumberIndicator = 0;
			m_MainWeapon.UpdateToCurrent();
			m_CurrentWeapon = WeaponNumber.PrimaryWeapon;
			m_AnimationControl.SetWeapon((int)m_CurrentWeapon);
		}
		else if (Input.GetButton("Weapon2"))
		{
			m_MainWeapon.m_WeaponNumberIndicator = 1;
			m_MainWeapon.UpdateToCurrent();
			m_CurrentWeapon = WeaponNumber.SecondaryWeapon;
			m_AnimationControl.SetWeapon((int)m_CurrentWeapon);
		}
		else if (Input.GetButton("Weapon3"))
		{
			m_CurrentWeapon = WeaponNumber.Pistol;
			m_AnimationControl.SetWeapon((int)m_CurrentWeapon);
		}
		else if (Input.GetButton("Weapon4"))
		{
			m_CurrentWeapon = WeaponNumber.Dagger;
			m_AnimationControl.SetWeapon((int)m_CurrentWeapon);
		}
	}

	private void Aim()
	{
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 difference = worldPos - transform.position;
		m_isLookingLeft = difference.x < 0;
		m_AnimationControl.LookAt(Mathf.Rad2Deg * Mathf.Atan(difference.y / difference.x), m_isLookingLeft);
	}

	//Callback Function From VoxelHandCallback.cs
	public void ReloadComplete()
	{
		if (GlobalWeaponData.g_CurrentWeapon == null)
			return;
		m_CurrentAmmo = Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]);
		m_AnimationControl.UpdateBulletIndicator(Mathf.CeilToInt((float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.Rounds]), m_CurrentAmmo);
	}

	public static void DealDamageToThisMob(MobHealthManager target)
	{
		if (target != null)
		{
			//피해량 공식
			float TempPenetrationDamage =
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
			if (TempNormalDamage > 0)
			{
				if (Random.Range(0f, 1f) < (float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalChance])
				{
					TempNormalDamage *= (float)GlobalWeaponData.g_CurrentWeapon.m_CurrentStatus[(int)WeaponPart.Specification.CriticalDamage] + 1f;
					target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Critical);
				}
				else
				{
					target.DealDamage(TempNormalDamage, DamageRenderer.DamageType.Normal);
				}
			}
		}
	}

	/*public void ToggleUI(ExternalUI ui)
	{
		if (ui == ExternalUI.Equipment)
			ToggleEquipment();
		else
		{
			isUIOn[(int)ui] = !isUIOn[(int)ui];
			if(UIPanel[(int)ui] != null)
				UIPanel[(int)ui].SetActive(isUIOn[(int)ui]);
		}
	}

	public void ToggleInventory()
	{
		ToggleUI(ExternalUI.Inventory);
	}

	public void ToggleEquipment()
	{
		isUIOn[(int)ExternalUI.Equipment] = !isUIOn[(int)ExternalUI.Equipment];
		if (isUIOn[(int)ExternalUI.Equipment])
			UIPanel[(int)ExternalUI.Equipment].GetComponent<EquipmentManager>().UIEnable();
		else
			UIPanel[(int)ExternalUI.Equipment].GetComponent<EquipmentManager>().UIDisable();
	}

	public void ToggleResource()
	{
		ToggleUI(ExternalUI.Resource);
	}

	public void ToggleSkill()
	{
		ToggleUI(ExternalUI.Skill);
	}*/

	public void OnMDown()
	{
		m_MouseState = true;
		if (m_CurrentFireMode == FireMode.Burst)
		{
			m_DelayFire += 3;
		}
		else if (m_CurrentFireMode == FireMode.Semi)
		{
			m_DelayFire += 1;
		}
	}

	public void OnMUp()
	{
		m_MouseState = false;
	}

	private void FireModeChecker()
	{
		if (m_MouseState && m_CurrentFireMode == FireMode.Auto)
			TryFire();
		else if (m_DelayFire > 0)
		{
			TryFire();
			m_DelayFire--;
		}
	}
}

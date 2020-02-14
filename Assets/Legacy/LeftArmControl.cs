using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmControl : MonoBehaviour {
	/*public AnimationControl m_CharacterAnimation;
	public SpriteRenderer m_GrenadeOnHand;
	public GameObject m_GrenadePrefab;

	public enum LeftArmMotion
	{
		Idle,
		StabOne,
		StabTwo,
		SwingOne,
		SwingTwo,
		GrenadeThrow
	}

	//SwordArt Temp Value
	public WeaponRenderer DaggerRenderer;
	private LeftArmMotion MotionStatus;
	private float Sword_Speed;
	private float Sword_Damage;
	private float SwingTime;

	//ArmShape
	public SpriteRenderer m_Arm;
	public Sprite m_GunGrabStyle;
	public Sprite m_GrenadeGrabStyle;

	private GameObject m_InstantitatedGrenade;
	private float m_RotateAxis;
	private MovementControl m_Parent;
	private ContactFilter2D m_bayonetAttackFilter;

	// Use this for initialization
	void Start () {
		MotionStatus = LeftArmMotion.Idle;
		m_bayonetAttackFilter = new ContactFilter2D();
		m_bayonetAttackFilter.SetLayerMask(LayerMask.GetMask("Mob"));
	}
	
	// Update is called once per frame
	void Update () {
		switch (MotionStatus)
		{
			case LeftArmMotion.StabOne:
				if (SwingTime > 30f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeRightArmSprite(3);
					m_CharacterAnimation.ChangeBodySprite(3);
					transform.Rotate(0, 0f, 80f);
					DaggerRenderer.transform.Translate(0.4f, -0.25f, 0f);
					DaggerRenderer.transform.Rotate(0, 0, -75f);
					DaggerRenderer.ChangeSprite4Bayonet(MotionStatus);
					Collider2D temp = DaggerRenderer.GetBayonetCollider();
					Collider2D[] result = new Collider2D[6];
					temp.OverlapCollider(m_bayonetAttackFilter, result);
					foreach(Collider2D mobInstance in result)
					{
						//직접 딜링보다는 패런트에게 돌려주는게 맞을듯;
						if (mobInstance != null)
							MovementControl.DealDamageToThisMob(mobInstance.GetComponent<MobHealthManager>(), 1f);
					}

					MotionStatus = LeftArmMotion.StabTwo;
				}
				else if (SwingTime > 15f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeBodySprite(2);
					SwingTime += Time.deltaTime;
				}
				else
				{
					SwingTime += Time.deltaTime;
				}
				break;
			case LeftArmMotion.StabTwo:
				if (SwingTime > 60f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeLeftArmSprite(0);
					m_CharacterAnimation.ChangeRightArmSprite(1);
					m_CharacterAnimation.ChangeBodySprite(1);
					MotionStatus = LeftArmMotion.Idle;
					transform.Rotate(0, 0, 10f);
					DaggerRenderer.transform.Rotate(0, 0, 75f);
					DaggerRenderer.transform.Translate(-0.4f, 0.25f, 0f);
					DaggerRenderer.ChangeSprite4Bayonet(MotionStatus);
					m_Parent.m_LockAction = false;
				}
				else if (SwingTime > 45f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeBodySprite(2);
					SwingTime += Time.deltaTime;
				}
				else
				{
					SwingTime += Time.deltaTime;
				}
				break;
			case LeftArmMotion.SwingOne:
				if (SwingTime > 30f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeRightArmSprite(3);
					m_CharacterAnimation.ChangeBodySprite(3);
					transform.Rotate(0, -180f, 20f);
					DaggerRenderer.transform.Translate(0.4f, -0.25f, 0f);
					DaggerRenderer.transform.Rotate(0, 0, -75f);
					DaggerRenderer.ChangeSprite4Bayonet(MotionStatus);
					MotionStatus = LeftArmMotion.SwingTwo;
					Collider2D temp = DaggerRenderer.GetBayonetCollider();
					Collider2D[] result = new Collider2D[6];
					temp.OverlapCollider(m_bayonetAttackFilter, result);
					foreach (Collider2D mobInstance in result)
					{
						//직접 딜링보다는 패런트에게 돌려주는게 맞을듯;
						if (mobInstance != null)
							MovementControl.DealDamageToThisMob(mobInstance.GetComponent<MobHealthManager>(), 1f);
					}
				}
				else if (SwingTime > 15f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeBodySprite(2);
					SwingTime += Time.deltaTime;
				}
				else
				{
					SwingTime += Time.deltaTime;
				}
				break;
			case LeftArmMotion.SwingTwo:
				if (SwingTime > 60f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeLeftArmSprite(0);
					m_CharacterAnimation.ChangeRightArmSprite(1);
					m_CharacterAnimation.ChangeBodySprite(1);
					MotionStatus = LeftArmMotion.Idle;
					transform.Rotate(0, 0, 20f);
					DaggerRenderer.transform.Rotate(0, 0, 75f);
					DaggerRenderer.transform.Translate(-0.4f, 0.25f, 0f);
					DaggerRenderer.ChangeSprite4Bayonet(MotionStatus);
					m_Parent.m_LockAction = false;
				}
				else if (SwingTime > 45f / Sword_Speed)
				{
					m_CharacterAnimation.ChangeBodySprite(2);
					SwingTime += Time.deltaTime;
				}
				else
				{
					SwingTime += Time.deltaTime;
				}
				break;
		}
		if (MotionStatus == LeftArmMotion.StabOne)
		{

		}else if (MotionStatus == LeftArmMotion.SwingOne)
		{
		}

		if (m_InstantitatedGrenade != null)
		{
			m_InstantitatedGrenade.transform.position = m_GrenadeOnHand.transform.position;
		}

		if (MotionStatus==LeftArmMotion.GrenadeThrow)
		{
			transform.Rotate(0, 0, Time.deltaTime * 720f);
			m_RotateAxis += Time.deltaTime * 720f;
			if (m_RotateAxis > 60f && m_InstantitatedGrenade != null)
			{
				m_CharacterAnimation.ChangeBodySprite(2);
				transform.Rotate(0, 0, 60f - m_RotateAxis);
				m_RotateAxis = 60f;
				m_InstantitatedGrenade.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				m_InstantitatedGrenade.GetComponent<Rigidbody2D>().AddForce(m_Arm.transform.up * 0.04f);
				m_InstantitatedGrenade.GetComponent<AllyGrenade>().LooseHandle();
				m_InstantitatedGrenade.GetComponent<Rigidbody2D>().freezeRotation = false;
				m_InstantitatedGrenade = null;
			}
			else if (m_InstantitatedGrenade!=null)
			{
			}
			else if (m_RotateAxis > 120f)
			{
				m_CharacterAnimation.ChangeBodySprite(1);
				MotionStatus = LeftArmMotion.Idle;
				transform.Rotate(0, 0, -m_RotateAxis);
				transform.Rotate(0, 180, 0);
				m_Arm.sprite = m_GunGrabStyle;
				m_Parent.m_grenadeOnHand = false;
				m_Parent.TurnWeaponSprite(true);
			}
			else if (m_RotateAxis > 90f)
			{
				m_CharacterAnimation.ChangeBodySprite(3);
			}
		}
	}

	public void GrenadeReady(MovementControl parent)
	{
		m_Parent = parent;
		m_CharacterAnimation.ChangeBodySprite(0);
		m_Arm.sprite = m_GrenadeGrabStyle;
		transform.Rotate(0, 180, 0);
		m_InstantitatedGrenade = Instantiate(m_GrenadePrefab, m_GrenadeOnHand.transform.position, Quaternion.Euler(0, 0, 0));
		m_InstantitatedGrenade.GetComponent<Rigidbody2D>().freezeRotation = true;
		m_RotateAxis = 0;
		m_Parent.TurnWeaponSprite(false);
	}

	public void GrenadeTick()
	{
		m_InstantitatedGrenade.GetComponent<AllyGrenade>().LooseHandle();
	}

	public void GrenadeThrow()
	{
		m_CharacterAnimation.ChangeBodySprite(1);

		MotionStatus = LeftArmMotion.GrenadeThrow;
	}

	//========SwordArt========
	public void StartAttack(MovementControl parent, float AttackSpeed, float AttackDamage)
	{
		if (1.0f < Random.Range(0f, 2f))
			StartStab(parent, AttackSpeed, AttackDamage);
		else
			StartSwing(parent, AttackSpeed, AttackDamage);
	}

	public void StartStab(MovementControl parent, float AttackSpeed, float AttackDamage)
	{
		m_CharacterAnimation.ChangeLeftArmSprite(2);
		m_CharacterAnimation.ChangeBodySprite(0);
		Sword_Speed = AttackSpeed;
		Sword_Damage = AttackDamage;
		parent.m_LockAction = true;
		m_Parent = parent;
		MotionStatus = LeftArmMotion.StabOne;
		transform.Rotate(0, 0, -90f);
		SwingTime = 0f;
	}

	public void StartSwing(MovementControl parent, float AttackSpeed, float AttackDamage)
	{
		m_CharacterAnimation.ChangeLeftArmSprite(2);
		m_CharacterAnimation.ChangeBodySprite(0);
		Sword_Speed = AttackSpeed;
		Sword_Damage = AttackDamage;
		parent.m_LockAction = true;
		m_Parent = parent;
		MotionStatus = LeftArmMotion.SwingOne;
		transform.Rotate(0, 180f, 40f);
		SwingTime = 0f;
	}*/
}

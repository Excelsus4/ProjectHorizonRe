using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmControl : MonoBehaviour {
	/*private float m_reloadSpeed;
	[HideInInspector]
	public bool m_isReloading;
	private bool m_isOnHand;
	private bool m_isPistolReload;

	public SpriteRenderer m_MagazineOnHand;
	public SpriteRenderer m_MagazineOnGun;
	public GameObject m_SomeRandomRigidbody2DPrefab;
	public float m_MovementAngle;
	public Sprite m_PistolMagazineFX;

	private Quaternion m_origin;
	private Quaternion m_target;
	private float m_AlreadyRotated;
	private MovementControl m_Callback;
	[HideInInspector]
	public bool m_isOpposite;

	private void Start()
	{
		m_isReloading = false;
		m_isOnHand = false;
		m_isOpposite = false;
		m_isPistolReload = false;
	}

	// Update is called once per frame
	void Update () {

		if (m_isOnHand)
		{
			m_AlreadyRotated += Time.deltaTime * m_reloadSpeed;
			transform.Rotate(0, 0, Time.deltaTime * m_reloadSpeed);
			if (m_AlreadyRotated > 0)
			{
				transform.rotation = m_origin;
				m_isOnHand = false;
				if(!m_isPistolReload)
					m_MagazineOnGun.enabled = true;
				m_MagazineOnHand.enabled = false;
				m_isReloading = false;
				m_isOpposite = false;
				m_Callback.CallbackReload();
			}
		}
		else if (m_isReloading)
		{
			m_AlreadyRotated -= Time.deltaTime * m_reloadSpeed;
			transform.Rotate(0, 0, -Time.deltaTime * m_reloadSpeed);
			if (m_AlreadyRotated < m_MovementAngle)
			{
				transform.rotation = m_target;
				m_isOnHand = true;
				m_MagazineOnHand.sprite = m_isPistolReload ? m_PistolMagazineFX : m_MagazineOnGun.sprite;
				m_MagazineOnHand.enabled = true;
				m_AlreadyRotated = m_MovementAngle;
			}
		}
	}

	public void StartReload(float ReloadSpeed, MovementControl Callback)
	{
		if (m_isReloading)
			return;
		if (GlobalWeaponData.g_CurrentWeapon == GlobalWeaponData.g_AllWeapon[2])
		{
			m_isPistolReload = true;
			m_reloadSpeed = ReloadSpeed * 5;
		}
		else
		{
			m_isPistolReload = false;
			m_reloadSpeed = ReloadSpeed;
		}
		m_MagazineOnGun.enabled = false;
		Instantiate(m_SomeRandomRigidbody2DPrefab, m_MagazineOnGun.transform.position, Quaternion.Euler(0, m_isOpposite ? 180f : 0f, 0)).
			GetComponent<SpriteRenderer>().sprite = m_isPistolReload ? m_PistolMagazineFX : m_MagazineOnGun.sprite;
		m_isReloading = true;

		m_origin = transform.rotation;
		transform.Rotate(0, 0, m_MovementAngle);
		m_target = transform.rotation;
		transform.rotation = m_origin;
		m_AlreadyRotated = 0f;
		m_isOnHand = false;
		m_Callback = Callback;
	}*/
}

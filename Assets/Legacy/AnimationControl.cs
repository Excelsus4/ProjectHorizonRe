using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	/*public SpriteRenderer m_LeftArmRenderer;
	public SpriteRenderer m_RightArmRenderer;
	public SpriteRenderer m_BodyRenderer;

	public SpriteRenderer m_LegRenderer;
	public SpriteRenderer m_FlareRenderer;
	public float m_AnimationSpeed;

	public Sprite[] m_BodySprite;
	public Sprite[] m_ArmSprite;
	public Sprite[] m_LegSprite;
	public Sprite[] m_FlareSprite;

	private int m_currentLegFrame;
	private float m_animationTimeLeft;
	private bool m_isFlipped;
	private int m_currentBodyIndex;

	// Use this for initialization
	void Start () {
		ChangeBodySprite(1);
		m_isFlipped = false;
	}
	
	// Update is called once per frame
	void Update () {
		m_animationTimeLeft -= m_AnimationSpeed * Time.deltaTime;
		if (m_animationTimeLeft < 0)
			m_animationTimeLeft = 0;
	}

	public bool OkayToAnimate()
	{
		if (m_animationTimeLeft <= 0)
			return true;
		else
			return false;
	}

	public void LegPlus()
	{
		if (OkayToAnimate())
		{
			m_currentLegFrame++;
			if (m_currentLegFrame >= m_LegSprite.Length)
				m_currentLegFrame = 1;
			RedrawLeg();
			m_animationTimeLeft = 1.0f;
		}
	}

	public void LegMinus()
	{
		if (OkayToAnimate())
		{
			m_currentLegFrame--;
			if (m_currentLegFrame < 1)
				m_currentLegFrame = m_LegSprite.Length - 1;
			RedrawLeg();
			m_animationTimeLeft = 1.0f;
		}
	}

	public void LegIdle()
	{
		m_currentLegFrame = 0;
		RedrawLeg();
	}

	private void RedrawLeg()
	{
		m_LegRenderer.sprite = m_LegSprite[m_currentLegFrame];
	}

	public void PutFlareHere(Transform muzzle)
	{
		m_FlareRenderer.transform.position = muzzle.position + new Vector3(0, 0, 0.3f);
		m_FlareRenderer.transform.rotation = muzzle.rotation;
		m_FlareRenderer.GetComponent<AutoFlare>().StartAnimation();
	}

	public void ChangeLeftArmSprite(int Code)
	{
		m_LeftArmRenderer.sprite = m_ArmSprite[Code];
	}

	public void ChangeRightArmSprite(int Code)
	{
		m_RightArmRenderer.sprite = m_ArmSprite[Code];
	}

	public void ChangeBodySprite(int Code)
	{
		if (m_isFlipped)
		{
			m_BodyRenderer.sprite = m_BodySprite[m_BodySprite.Length - Code - 1];
		}
		else
		{
			m_BodyRenderer.sprite = m_BodySprite[Code];
		}

		//몸 모양새에 따라 팔 위치 재조정
		switch (Code)
		{
			case 0:
				m_LeftArmRenderer.transform.localPosition = new Vector3(0.25f, -0.05f, 0.02f);
				m_RightArmRenderer.transform.localPosition = new Vector3(-0.23f, -0.04f, -0.05f);
				break;
			case 1:
				m_LeftArmRenderer.transform.localPosition = new Vector3(0.1f, -0.05f, 0.02f);
				m_RightArmRenderer.transform.localPosition = new Vector3(-0.14f, -0.04f, -0.05f);
				break;
			case 2:
				m_LeftArmRenderer.transform.localPosition = new Vector3(-0.22f, -0.05f, 0.02f);
				m_RightArmRenderer.transform.localPosition = new Vector3(0.2f, -0.04f, -0.05f);
				break;
			case 3:
				m_LeftArmRenderer.transform.localPosition = new Vector3(-0.25f, -0.05f, 0.02f);
				m_RightArmRenderer.transform.localPosition = new Vector3(0.3f, -0.04f, -0.05f);
				break;
		}

		m_currentBodyIndex = Code;
	}

	public void FlipBody(bool isFlip)
	{
		if (isFlip != m_isFlipped)
		{
			m_BodyRenderer.transform.Rotate(0f, 180f, 0f);
			m_LegRenderer.transform.Rotate(0f, 180f, 0f);
			m_isFlipped = isFlip;

			if (m_isFlipped)
			{
				m_BodyRenderer.sprite = m_BodySprite[m_BodySprite.Length - m_currentBodyIndex - 1];
			}
			else
			{
				m_BodyRenderer.sprite = m_BodySprite[m_currentBodyIndex];
			}
		}
	}*/
}

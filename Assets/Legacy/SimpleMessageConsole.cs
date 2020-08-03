using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMessageConsole : MonoBehaviour {
	public static SimpleMessageConsole g_GlobalOne;

	public UnityEngine.UI.Text m_TextBoard;

	private float timeElapse;

	private void Awake()
	{
		g_GlobalOne = this;
		gameObject.SetActive(false);
	}

	private void Update()
	{
		if (timeElapse < 0)
			gameObject.SetActive(false);
		else
			timeElapse -= Time.deltaTime;
	}

	public void MakeMessage(string Text)
	{
		m_TextBoard.text = Text;
		gameObject.SetActive(true);
		timeElapse = 2f;
	}
}

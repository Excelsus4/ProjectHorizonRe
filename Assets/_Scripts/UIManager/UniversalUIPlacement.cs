using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UniversalUIPlacement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
	public Transform theWholeObject;
	private Vector2 offset;
	private bool isPointerDown;

	private void Awake()
	{
		isPointerDown = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.pressPosition - new Vector2(theWholeObject.position.x, theWholeObject.position.y);
		Debug.Log(eventData.pressPosition);
		isPointerDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown = false;
		MoveTransformToOffset();
	}

	public void Update()
	{
		if (isPointerDown)
		{
			MoveTransformToOffset();
		}
	}

	public void MoveTransformToOffset()
	{
		theWholeObject.position = Input.mousePosition - new Vector3(offset.x, offset.y);
	}
}

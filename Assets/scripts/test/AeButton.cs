using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

[AddComponentMenu("Aeronauts/AeButton")]
public class AeButton : Button
{
	// Event delegate triggered on mouse or touch down.
	[SerializeField]
	ButtonDownEvent _onDown = new ButtonDownEvent();

	protected AeButton() { }

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);

		if (eventData.button != PointerEventData.InputButton.Left)
			return;

		_onDown.Invoke();
	}

	public ButtonDownEvent onDown
	{
		get { return _onDown; }
		set { _onDown = value; }
	}

	[Serializable]
	public class ButtonDownEvent : UnityEvent { }
}    
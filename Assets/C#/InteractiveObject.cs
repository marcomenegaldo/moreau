using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

	public string hintName;
	public string hintDescripton;

	void OnMouseEnter() {
		Cursor.SetCursor( InputHandler.instance.hintCursor, InputHandler.instance.cursorHotSpot, InputHandler.instance.cursorMode );

		InputHandler.instance.interactiveObjectHint.enabled = true;
		InputHandler.instance.interactiveObjectHint.text = string.Format( "<b>{0}</b>\n{1}", hintName, hintDescripton );
	}

	void OnMouseExit() {
		Cursor.SetCursor( InputHandler.instance.normalCursor, InputHandler.instance.cursorHotSpot, InputHandler.instance.cursorMode );

		InputHandler.instance.interactiveObjectHint.enabled = false;
	}

	void OnMouseOver() {
		Vector3 mouseViewportPoint = Camera.main.ScreenToViewportPoint( Input.mousePosition );

		InputHandler.instance.interactiveObjectHint.anchor = mouseViewportPoint.x > 0.5f ? TextAnchor.UpperRight : TextAnchor.UpperLeft;

		InputHandler.instance.interactiveObjectHint.transform.position = mouseViewportPoint + (Vector3)( InputHandler.instance.interactiveObjectHintViewportOffset * ( mouseViewportPoint.x > 0.5f ? -1.0f : 1.0f ) );
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour 
{
	public Vector2 mousePos;
	public string direction;
	//reference to inventory
	//references to any moving cameras
	public bool quickMenu;
	public float scrW, scrH;
	void Start()
	{
		Cursor.visible = false;
	}
	void Update () 
	{
		scrH = Screen.height / 9;
		scrW = Screen.width / 16;
		if(Input.GetButton("Quick Select Menu"))
		{
			quickMenu = true;
			Cursor.visible = true;
			mousePos = Input.mousePosition;
		}
		else
		{
			quickMenu = false;
		}
		if(quickMenu)
		{
			#region KeyBoard/Controller Menu Controls
			if(direction != "Left")
			{
				if(Input.GetAxis("Horizontal") < 0)
				{
					Debug.Log("Left");
					direction = "Left";
				}
			}
			if(direction != "Right")
			{
				if(Input.GetAxis("Horizontal") > 0)
				{
					Debug.Log("Right");
					direction = "Right";
				}
			}
			if(direction != "Down")
			{
				if(Input.GetAxis("Vertical") < 0)
				{
					Debug.Log("Down");
					direction = "Down";
				}
			}
			if(direction != "Up")
			{
				if(Input.GetAxis("Vertical") > 0)
				{
					Debug.Log("Up");
					direction = "Up";
				}
			}
			#endregion
			#region Mouse Input Menu Controls
			if(mousePos.y >= scrH * 4 && mousePos.y <= scrH *5)
			{
				if(mousePos.x >= scrW * 0 && mousePos.x <= scrW *7.5f)
				{
					Debug.Log("Left");
					direction = "Left";
				}
			}
			if(mousePos.y >= scrH * 4 && mousePos.y <= scrH *5)
			{
				if(mousePos.x >= scrW * 8.5f && mousePos.x <= scrW *16)
				{
					Debug.Log("Right");
					direction = "Right";
				}
			}
			if(-mousePos.y + Screen.height >= scrH * 5 && -mousePos.y + Screen.height <= scrH * 9)
			{
				if(mousePos.x >= scrW * 7.5f && mousePos.x <= scrW *8.5f)
				{
					Debug.Log("Down");
					direction = "Down";
				}
			}
			if(-mousePos.y + Screen.height >= scrH * 0 && -mousePos.y + Screen.height <= scrH * 4)
			{
				if(mousePos.x >= scrW * 7.5f && mousePos.x <= scrW *8.5f)
				{
					Debug.Log("Up");
					direction = "Up";
				}
			}
			#endregion
		}

	}
	void OnGUI()
	{
		if (quickMenu) {
			GUI.Box (new Rect (scrW * 0, scrH * 4, scrW * 7.5f, scrH), "Left");
			GUI.Box (new Rect (scrW * 8.5f, scrH * 4, scrW * 7.5f, scrH), "Right");		
			GUI.Box (new Rect (scrW * 7.5f, scrH * 0, scrW, scrH * 4), "Up");
			GUI.Box (new Rect (scrW * 7.5f, scrH * 5, scrW, scrH * 4), "Down");
		}
	}
}

using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour
{
	public Color fadeColor;
	public float time;
	public Texture2D theTexture;

	private float StartTime;

		// Use this for initialization
	void Start ()
	{
		StartTime = Time.time;
	}
	
		// Update is called once per frame
	void Update ()
	{
		if(Time.time - StartTime >= 3)
		{
			Destroy (gameObject);
		}
	}

	void OnGUI()
	{
		fadeColor.a = Mathf.Lerp(1.0f, 0.0f, Time.time - StartTime);
		GUI.color = fadeColor;

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), theTexture);
	}
}


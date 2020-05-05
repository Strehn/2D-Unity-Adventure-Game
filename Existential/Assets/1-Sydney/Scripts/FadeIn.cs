using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

	public void Fadeobject()
	{
		GameObject spriteRenderer = GameObject.Find("Tutorial");
		float AlphaValue = 1.0f;
		int FadeType = 0;
	
		// fade in 
		if (FadeType == 0)
		{
			AlphaValue -= 0.25f * Time.deltaTime;
			// limit the possible alpha value
			if (AlphaValue < 0.0f)
			{
				AlphaValue = 0.0f;
			}
		}

		spriteRenderer.SetActive(false);
	}

}

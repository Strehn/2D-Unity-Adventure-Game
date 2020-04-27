/* Created  by Sydney Petrehn
 * This is a script that fades the camera in at the start of the level
 */

/* Documentation for Script Prefab
* Written by Sydney Petrehn
* Have you ever wanted to create a seamless scene transitions?
* Well, look no further! The Fade Script Prefab contains everything you need!
* All you have to do is attatch it to the main camera!
* The prefab will come loaded with:
*  - The fade panel
* Prefab features:
*  - Complete flexibility to use with other sprites
*  - The freedom to scale the prefab
*  - The freedom to transform the prefab's position starting on screen
*  - The freedom to change how fast the camera fades in.
*  - The ability to change the sorting layer
* Tech Specs:
*  - Unity 2019
*  - Clean, well-documented C# scripts for all components
*  - Mobile friendly - Android
* Refund Policy:
*  - This prefab is free on the Unity Asset Store for a limited time - so download it now!
*  - Otherwise, we will not accept refunds due to short staffing :/
* Other Notes:
*  - We love to see our prefabs being used! Please tag us in your projects on social media @ StudioBlueBox 
*  - If you have any questions, please do not hesitate to contact our 24 hour customer care @ 208.999.8383
*/

using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
	#region Member Variables
	/// <summary>
	/// The sprite that represents the fade on screen
	/// </summary>
	private SpriteRenderer spriteRenderer;

	/// <summary>
	/// The alpha value of the fade
	/// </summary>
	private float AlphaValue;
	
	/// <summary>
	/// A toggle for turning this tiles functionality on or off
	/// </summary>
	public enum FADETYPE
	{
		IN = 0,
		OUT = 1,
		NONE = 2,
		RESPAWN = 3,
	}
	public FADETYPE FadeType;
	#endregion

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		FadeType = FADETYPE.IN;
		AlphaValue = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// fade in or fade out based on the objects state
		if(FadeType == FADETYPE.IN)
		{
			AlphaValue -= 0.25f * Time.deltaTime;
			// limit the possible alpha value
			if(AlphaValue < 0.0f)
			{
				AlphaValue = 0.0f;
				FadeType = FADETYPE.NONE;
			}
		}
		else if(FadeType == FADETYPE.OUT)
		{
			AlphaValue += Time.deltaTime;

			// limit the possible alpha value
			if(AlphaValue > 1.0f)
			{
				AlphaValue = 1.0f;
				FadeType = FADETYPE.NONE;
				ChangeLevel();
			}
		}
		else if(FadeType == FADETYPE.RESPAWN)
		{
			AlphaValue += (2.0f * Time.deltaTime);
			// limit the possible alpha value
			if(AlphaValue > 1.0f)
			{
				AlphaValue = 1.0f;
				FadeType = FADETYPE.IN;
				GameObject.Find("PlayerCharacter").GetComponent<PlayerMovement>().RespawnPlayerAtCheckpoint();
			}
		}

		// set the objects new colour
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, AlphaValue);
	}

	/// <summary>
	/// Set the fade out state	
	/// </summary>
	public void FadeOut()
	{
		FadeType = FADETYPE.OUT;
	}

	/// <summary>
	/// Respawns the fade
	/// </summary>
	public void RespawnFade()
	{
		// set the respawn state
		FadeType = FADETYPE.RESPAWN;
	}

	/// <summary>
	/// Changes the level to the next level in the list
	/// </summary>
	private void ChangeLevel()
	{
		int levelID = Application.loadedLevel + 1;
		if(levelID > Application.levelCount - 1){ levelID = 0; }
		Application.LoadLevel(levelID);
	}
}

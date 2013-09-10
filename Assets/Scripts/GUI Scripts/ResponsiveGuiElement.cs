using UnityEngine;
using System.Collections;

public class ResponsiveGuiElement : MonoBehaviour {

	float ratio = 1f;
	float previousScreenWidth = 1f;
	float previousScreenHeight = 1f;

	public bool updatePosition = true;
	public bool updateSize = true;
	public float size = 0.1f;
	public float x = 0.5f;
	public float y = 0.5f;

	void Awake() {

		if(guiTexture) {

			// Store texture ratio
			ratio = guiTexture.pixelInset.width / guiTexture.pixelInset.height;
		}
	}

	// Start
	void Start() {

		InvokeRepeating("Adjust", 0f, 0.5f);
	}

	// Set new size and offset
	void Adjust() {

		// Return if screen size did not change
		if(previousScreenWidth == Screen.width && previousScreenHeight == Screen.height) {

			return;	
		}

		// Store previous screen dimensions
		previousScreenWidth = Screen.width;
		previousScreenHeight = Screen.height;

		if(guiText) {

			// Set position and font size
			if(updatePosition) {

				guiText.pixelOffset = new Vector2(Screen.width * x, Screen.height * y);
			}

			if(updateSize && size > 0f) {

				guiText.fontSize = Mathf.RoundToInt(Screen.height * size);
			}
		}

		if(guiTexture) {

			// Set size and position
			float left = guiTexture.pixelInset.x;
			float top = guiTexture.pixelInset.y;
			float width = guiTexture.pixelInset.width;
			float height = guiTexture.pixelInset.height;

			if(updateSize && size > 0f) {

				height = Screen.height * size;
				width = height * ratio;
			}

			if(updatePosition) {

				left = Screen.width * x - width / 2f;
				top = Screen.height * y - height / 2f;
			}

			guiTexture.pixelInset = new Rect(left, top, width, height);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorCheck : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit hit;
		if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			return;

		Renderer renderer = hit.collider.GetComponent<Renderer>();
		Texture2D tex = renderer.material.mainTexture as Texture2D;
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;

		int x = (int)Mathf.Floor(pixelUV.x);
		int y = (int)Mathf.Floor(pixelUV.y);
		Debug.Log("Texture Name : " + hit.transform.gameObject.name + ", u=" + pixelUV.x + ", v=" + pixelUV.y + ", w=" + tex.width + ", h=" + tex.height + ", " + tex.GetPixel(x, y));
	}
}
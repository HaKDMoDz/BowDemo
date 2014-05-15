using UnityEngine;
using System.Collections;

public class ProceduralDotProductPixelDirection : MonoBehaviour 
{
    public int WidthHeight = 512;
    public Texture2D GeneratedTexture;

    private Material currentMaterial;
    private Vector2 centerPosition;

	// Use this for initialization
	void Start () 
    {
        if (!currentMaterial)
        {
            currentMaterial = transform.renderer.sharedMaterial;
            if (!currentMaterial)
            {
                Debug.Log("Cannot find a material on: " + transform.name);
            }
        }

        if (currentMaterial)
        {
            centerPosition = new Vector2(0.5f, 0.5f);
            GeneratedTexture = GenerateParabola();

            currentMaterial.SetTexture("_MainTex", GeneratedTexture);
        }
	}

    private Texture2D GenerateParabola()
    {
        Texture2D proceduralTexture = new Texture2D(WidthHeight, WidthHeight);

        Vector2 centerPixelPosition = centerPosition * WidthHeight;

        for (int x = 0; x < WidthHeight; x++)
        {
            for (int y = 0; y < WidthHeight; y++)
            {
                Vector2 currentPosition = new Vector2(x, y);
                float pixelDistance = Vector2.Distance(currentPosition, centerPixelPosition) / (WidthHeight * 0.5f);

                pixelDistance = Mathf.Abs(1 - Mathf.Clamp(pixelDistance, 0f, 1f));

                Vector2 pixelDirection = centerPixelPosition - currentPosition;
                pixelDirection.Normalize();
                float rightDirection = Vector2.Dot(pixelDirection, Vector3.right);
                float leftDirection = Vector2.Dot(pixelDirection, Vector3.left);
                float upDirection = Vector2.Dot(pixelDirection, Vector3.down);

                //Color PixelColor = new Color(pixelDistance, pixelDistance, pixelDistance, 1.0f);
                Color PixelColor = new Color(leftDirection, rightDirection, upDirection, 1.0f);
                proceduralTexture.SetPixel(x, y, PixelColor);
            }
        }

        proceduralTexture.Apply();

        return proceduralTexture;
    }


	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
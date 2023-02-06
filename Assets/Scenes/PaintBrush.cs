//PaintBrush will be attached to a game Object with a transform child that will be the location of the paint 
//brush. This is a VR project so the paint brush will be a grabbable object.
//The Paint brush should paint on the texture of a given canvas. The canvas will be a plane with a texture
using UnityEngine;

public class PaintBrush : MonoBehaviour {
    [SerializeField] private Transform paintBrushTip;
    [SerializeField] private float paintBrushRadius = 0.1f;
    [SerializeField] private float paintBrushStrength = 0.1f;
    //Color of the paint
    [SerializeField] private Color paintColor = Color.red;
    //Canvas to be painted
    [SerializeField] private GameObject canvas;
    //The texture of the canvas
    [SerializeField] private Texture2D canvasTexture;
    //The canvas will be a plane with a texture

    // Start is called before the first frame updatex
    void Start() {
        //Get the texture of the canvas
        //
    }
    //when the tip of the paint brush touches the canvas
    private void OnTriggerEnter(Collider other) {
        //validate the canvas
        if (other.gameObject != canvas) {
            return;
        }
        //Get the position of the paint brush tip
        Vector2 pixelUV = paintBrushTip.position;
        //Get the pixel coordinates of the paint brush tip
        Vector2 pixelPos = new Vector2(pixelUV.x * canvasTexture.width, pixelUV.y * canvasTexture.height);
        //Paint the canvas
        PaintPosition(pixelPos);
    }
    //apply the paint to the canvas using the paint brush tip's position applying the color
    private void PaintPosition(Vector2 pixelPos) {
        //Get the pixels of the canvas
        Color[] pixels = canvasTexture.GetPixels();
        //Get the pixel coordinates of the paint brush tip
        Vector2Int pixelPosInt = new Vector2Int(Mathf.RoundToInt(pixelPos.x), Mathf.RoundToInt(pixelPos.y));
        //Get the pixel coordinates of the paint brush tip
        int pixelIndex = pixelPosInt.y * canvasTexture.width + pixelPosInt.x;
        //Paint the canvas
        pixels[pixelIndex] = paintColor;
        //Apply the paint to the canvas
        canvasTexture.SetPixels(pixels);
        //Apply the paint to the canvas
        canvasTexture.Apply();
    }


}
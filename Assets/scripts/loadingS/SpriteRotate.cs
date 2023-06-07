using UnityEngine;
using UnityEngine.UI;

public class SpriteRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the speed of rotation
    public Color targetColor; // The color you want to transition to
    public float transitionDuration = 2f; // The duration of the color transition

    private Color startColor; // The initial color of the image
    private float elapsedTime; // The elapsed time since the color transition started
    private Image image; // Reference to the Image component
    private void Start()
    {
        image = GetComponent<Image>();
        startColor = image.color;
    }

    private void Update()
    {
        // Rotate the sprite around the Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the lerp factor based on the elapsed time and transition duration
        float lerpFactor = Mathf.Clamp01(elapsedTime / transitionDuration);

        // Lerp the color from the start color to the target color
        Color lerpedColor = Color.Lerp(startColor, targetColor, lerpFactor);

        // Apply the lerped color to the image
        image.color = lerpedColor;
        if (elapsedTime >= transitionDuration)
        {
            // Swap the start and target colors
            Color tempColor = startColor;
            startColor = targetColor;
            targetColor = tempColor;

            // Reset the elapsed time
            elapsedTime = 0f;
        }
    }
}




   
    

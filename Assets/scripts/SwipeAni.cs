using UnityEngine;
using System.Collections;
using static LeanTween;

public class SwipeAni : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float swipeDuration = 1f;
    public float delayBetweenLoops = 1f;
    public GameObject player;
   dragmove d;

    private void Start()
    {
        // Set the initial position of the object
        transform.localPosition = startPosition;
        d = player.GetComponent<dragmove>();
        // Start the swipe animation
        
           Swipe();
        
    }
    private void Update()
    {
       if(d.showAnimation == 0)
       {
           gameObject.SetActive(false);
       }
    }

    private void Swipe()
    {
        // Use LeanTween to animate the position of the object
        LeanTween.moveLocal(gameObject, endPosition, swipeDuration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(OnSwipeComplete);
    }

    private void OnSwipeComplete()
    {
        // Animation completed, you can add any additional logic here

        // Reset the object's position to the start position
        transform.localPosition = startPosition;

        // Wait for the specified delay before starting the next loop
        StartCoroutine(StartNextLoop());
    }

    private IEnumerator StartNextLoop()
    {
        yield return new WaitForSeconds(delayBetweenLoops);

        // Start the swipe animation again
        Swipe();
    }
}

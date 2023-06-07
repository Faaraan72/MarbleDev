using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class dragmove : MonoBehaviour
{
  // AUDIO
          [SerializeField] private AudioSource a;
        // [SerializeField]private AudioSource bgm;
         // [SerializeField] private AudioClip wining;

 //MOVEMENT RELATED
         private Vector3 mousePressDownPos;
         private Vector3 mouseReleasePos;
         private Rigidbody rb;
          public float constantspeed = 10f;

// UI RELATED
         public GameObject endscreen;
        public float showAnimation = 1;
         public int score = 0;
         public int chances = 0;
          public int marbles = 18;
         public Text Played;


// MECHANISM RELATED  
         
         private float forceMultiplier = 3;
       public LineRenderer linerenderer;
         public Vector3 velo;
    private bool shooting = false;


    // SCRIPTS 
    TrajectoryLine t;
         newthrow newthrow;


    //-----------------------------==================START()=========================-------------------------------------->
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
        t = GetComponent<TrajectoryLine>();
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.enabled = false;
        newthrow = GetComponent<newthrow>();
        endscreen.SetActive(false);
        t.landingAni.SetActive(false);
    }
    //-------------------------------------=================UPDATE()========================---------------------------------->
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if(marbles == 0)
        {
            
            Invoke(nameof(showendscreen), 1f);
        }
       

    }

    //-----------------=====================UI fns()=====================------------------------------->

    private void showendscreen()
    {
        endscreen.SetActive(true);
        //win.PlayOneShot(wining);
    }
    void updatechances()
    {
        Played.text = "" + chances;
    }


    //===============================----------Mechanism fns()--------------================================>

    private void OnMouseDown()
    {
        t.landingAni.SetActive(true);
        mousePressDownPos = Input.mousePosition;
        linerenderer.enabled = true;
        showAnimation = 0;

    }
    private void OnMouseDrag()
    {
        Vector3 Force = -mousePressDownPos + Input.mousePosition;
        velo = new Vector3(Force.x, Force.y/3, Force.y) * forceMultiplier;
         //p.UpdateTrajectory(velo, rb,transform.position);
       
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        
        Shoot( mousePressDownPos - mouseReleasePos);
        linerenderer.enabled = false;
        t.landingAni.SetActive(false);
        
       
   
    }
    
  
    void Shoot(Vector3 Force)
    {
        shooting = true;
       Vector3 landingpos = t.landingAni.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position,landingpos, 0.1f), 10f);
        Vector3 f = (landingpos - transform.position).normalized;
        rb.AddForce(f*constantspeed);

       //rb.AddForce(new Vector3(Force.x, Force.y/2, Force.y) * forceMultiplier);
       chances++;
       updatechances();
        a.Play();
      
       //Debug.Log("Shoot");
      // Destroy(p.temp);
     Invoke(nameof(instantiate),5f);
     Invoke(nameof(removetag), 5f);
        
    }
    
    //====================================================================================>
    // private void move()
    // {
    //     Vector3 landingpos = t.landingAni.transform.position;
    //     Debug.Log(landingpos);
    //     transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingpos.x, landingpos.z, landingpos.z), constantspeed * Time.deltaTime);
    // }
    //===================================================================================<
    public void removetag()
    {
        rb.transform.tag = "Untagged";
       // Debug.Log("tagremoved");
    }
    // bool red = false;
  
    void instantiate()
    {
        //Debug.Log("instantiate");
        newthrow.newThrow();
    }
    

}

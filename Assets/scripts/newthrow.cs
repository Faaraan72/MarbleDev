using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class newthrow : MonoBehaviour
{
    private Vector3 pos;
    private Quaternion rot;

    dragmove d;

    public GameObject marb;
    public GameObject Player1;
    public GameObject Player2;
    
    

    private void Start()
    {
        pos = transform.position;
        rot = transform.rotation;
        d = GetComponent<dragmove>();
       
    }
    GameObject g;
    public void newThrow()
    {
        //Debug.Log("red ");
        
       g =  Instantiate(Player1, pos, rot );
        g.transform.SetParent(marb.transform);
        g.transform.tag = "red";
        
    }
    
   
  // public void blueThrow()
  // {
  //     Debug.Log("blue ");
  //  
  //     GameObject p2 = Instantiate(Player2,pos, rot );
  //     p2.transform.SetParent(marb.transform);
  //     
  //     
  // }


}

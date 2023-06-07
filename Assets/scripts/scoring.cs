using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class scoring : MonoBehaviour
{
    dragmove d;
    public GameObject player;
    [SerializeField] private AudioSource score;
  
    public Text Score;
   
    //  string tag;
    //int blueScore = 0;
    // int redScore = 0;
     public void Start()
      {
        d = player.GetComponent<dragmove>();
        Score.text = "0" ;
       
     }
    private void Update()
    {
      UpdateScore();
      
    }

   
    private void OnTriggerExit(Collider other)
    {
        score.Play();
       d.score++;
        d.marbles--;
       // Debug.Log(d.marbles);
        //Debug.Log("" + d.score);
        //Destroy(gameObject, 5f);
       
    }
   public void UpdateScore()
    {
       Score.text = "" + d.score;
    }


}

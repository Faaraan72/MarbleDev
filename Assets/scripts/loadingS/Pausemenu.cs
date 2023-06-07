using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausescreen;
   // public GameObject m;
  //  public GameObject musiconButton;
   // public GameObject musicoffButton;

    public void Start()
    {
        pausescreen.SetActive(false);
       
    }
    public void showpausescreen()
    {
        pausescreen.SetActive(true);
       
    }
    public void resume()
    {
        pausescreen.SetActive(false);
        
    }
  //  public void musicon()
  //  {
  //      m.SetActive(true);
  //      musiconButton.SetActive(false);
  //      musicoffButton.SetActive(true);
  //  }
  //  public void musicoff()
  //  {
  //      m.SetActive(false);
  //      musiconButton.SetActive(true);
  //      musicoffButton.SetActive(false);
  //  }
}

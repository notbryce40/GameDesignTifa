using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BillsScript : MonoBehaviour
{
    public void OnBillsButton()
    {
        SceneManager.LoadScene("EndScene");

    }

     public void OnExitButton()
    {
        SceneManager.LoadScene("SampleScene");

    }



    /* // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }*/
}

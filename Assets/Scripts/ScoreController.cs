using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public UIController uIController;
    public Collider playerCol;
    // Start is called before the first frame update
    void Start()
    {
       // new nyawa =uIController.anything;
        //scriptUi.anything;
        
    }

    // Update is called once per frame
    void Update()
    {

    }        
    private void OnTriggerEnter(Collider col){
        if(col.tag=="baygon"){
            Debug.Log("kena musuh");
            uIController.nyawaPlayer=uIController.nyawaPlayer=1;
        }
        else if(col.tag=="mob"){
            Debug.Log("kena radar");
            uIController.nyawaMob=uIController.nyawaMob=1;
        }
        else if(col.tag=="radar"){
            Debug.Log("kena radar");
            uIController.rageTime=15;
        }}
    //   public void KurangDarah(string tipe){//function klo collide dgn baygon atau mob || BELUM KELAR
    //         if(tipe == "Player") 
    //         uIController.
    //         nyawaPlayer=nyawaPlayer-1;
    //     else if(tipe == "Mob") nyawaMob=nyawaMob-1;    }

}

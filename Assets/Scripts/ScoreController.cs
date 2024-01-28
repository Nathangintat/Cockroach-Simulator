using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    UI
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void KurangDarah(string tipe){//function klo collide dgn baygon atau mob || BELUM KELAR
            if(tipe == "Player") nyawaPlayer=nyawaPlayer-1;
        else if(tipe == "Mob") nyawaMob=nyawaMob-1;    }
}

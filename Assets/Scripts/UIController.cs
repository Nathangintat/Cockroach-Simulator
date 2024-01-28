using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [Header("UI")]
    public GameObject home;
    public GameObject HUD;
    [SerializeField] TextMeshProUGUI hud;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI rage;
    public GameObject rageUI;

    public GameObject pauseMenu;
    public GameObject loseMenu;
    public GameObject winMenu;
    public float nyawaPlayer;
    public float nyawaMob;
    float batasWaktu;
    public float rageTime;

    public UnityEvent customEvent;
    // Start is called before the first frame update
    void Start()
    {
       home.SetActive(true); 
       Time.timeScale=0;       
    }

    private void Update(){
        //left alt buat munculin kursor
        if(Input.GetKeyDown(KeyCode.Alpha0)) pause();
        else if(Input.GetKeyDown(KeyCode.LeftAlt)) Mouse();

        UpdateHUD();

        if(nyawaPlayer==1)
            losePlay();
        
        //timer
        if(batasWaktu>0){
        batasWaktu-=Time.deltaTime;
        int menit = Mathf.FloorToInt(batasWaktu/60);
        int detik=Mathf.FloorToInt(batasWaktu%60);
        timer.text=string.Format("{0:00}:{1:00}", menit, detik);
        //timer merah dan waktu habis
            if(batasWaktu<30) timer.color=Color.red;   
            else if(nyawaMob==1) winPlay();         
        }
        else if(batasWaktu<0) losePlay();

        // public void rageTime(float ragetime){

        if(rageTime>0){
        rageUI.SetActive(true);            
        rageTime-=Time.deltaTime;
        rage.color=Color.red; 
        int menit = Mathf.FloorToInt(rageTime/60);
        int detik=Mathf.FloorToInt(rageTime%60);
        rage.text=string.Format("{0:00}:{1:00}", menit, detik);        
        }
        else if(rageTime<=0) rageUI.SetActive(false);}
    

    public void pause(){//menu pause
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale=0;
    }

    public void lanjut(){//lanjut main
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale=1;
    }

    // public void rageTime(float ragetime){
    //     rageUI.SetActive(true);
    //     if(ragetime>0){
    //     ragetime-=Time.deltaTime;
    //     rage.color=Color.red; 
    //     int menit = Mathf.FloorToInt(ragetime/60);
    //     int detik=Mathf.FloorToInt(ragetime%60);
    //     rage.text=string.Format("{0:00}:{1:00}", menit, detik);        
    //     }
    //     else if(ragetime<0) rageUI.SetActive(false);
    // }

    public void Homie(){//balik homepage
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        home.SetActive(true);

        Time.timeScale=0;
    }

    public void losePlay(){//lose pop up
        Time.timeScale=0;
        HUD.SetActive(false);
        loseMenu.SetActive(true);
    }

        public void winPlay(){//lose pop up
        Time.timeScale=0;
        HUD.SetActive(false);
        winMenu.SetActive(true);
    }
    public void Mulai(){//mulai game
        home.SetActive(false);
        Time.timeScale=1;
        HUD.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        resetNilai();
    }

    public void keluar(){//exit game
        Application.Quit();
    }
    public void resetNilai(){//balikin value nyawa dan waktu
        nyawaPlayer=3;
        nyawaMob=5;
        batasWaktu=35;
    }

    private void Mouse(){//atur kursor
        if(Cursor.visible==true){ 
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;}
        else if(Cursor.visible==false){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;}
    }

        private void UpdateHUD(){ //tampilan HUD
        hud.text= "player : "+ nyawaPlayer.ToString()+"\n";
        hud.text+= "Mob : "+nyawaMob.ToString();
    }
}
    // public void Interact(){//belum jelas yg ini
    //     customEvent.Invoke();
    // }

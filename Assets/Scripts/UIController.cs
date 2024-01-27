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
    public GameObject pauseMenu;
    public GameObject loseMenu;
    public GameObject winMenu;
    public float nyawaPlayer;
    public float nyawaMob;
    public float batasWaktu;

    public UnityEvent customEvent;
    // Start is called before the first frame update
    void Start()
    {
       home.SetActive(true); 
       Time.timeScale=0;       
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha0)) pause();
        else if(Input.GetKeyDown(KeyCode.LeftAlt)) Mouse();

        UpdateHUD();

        batasWaktu-=Time.deltaTime;
        int menit = Mathf.FloorToInt(batasWaktu/60);
        int detik=Mathf.FloorToInt(batasWaktu%60);
        timer.text=string.Format("{0:00}:{1:00}", menit, detik);

        if(batasWaktu<30) timer.color=Color.red;
        else if(batasWaktu<0) {Time.timeScale=0;losePlay();}
    }

    public void pause(){
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale=0;
    }

    public void lanjut(){
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale=1;
    }

    public void Homie(){
        home.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale=0;
    }

    public void losePlay(){
        //Time.timeScale=0;
        HUD.SetActive(false);
        loseMenu.SetActive(true);
    }
    public void Mulai(){
        home.SetActive(false);
        Time.timeScale=1;
        HUD.SetActive(true);
        resetNilai();
    }

    public void keluar(){
        loseMenu.SetActive(true);
    }
    public void resetNilai(){
        nyawaPlayer=3;
        nyawaMob=3;
        batasWaktu=10;
    }

    private void Mouse(){
        if(Cursor.visible==true){ 
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;}
        else if(Cursor.visible==false){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;}
    }

        private void UpdateHUD(){ //HUD
        hud.text= "player : "+ nyawaPlayer.ToString()+"\n";
        hud.text+= "Mob : "+nyawaMob.ToString();
    }

    public void Interact(){
        customEvent.Invoke();
    }

  public void KurangDarah(string tipe){
            if(tipe == "Player") nyawaPlayer=nyawaPlayer-1;
        else if(tipe == "Mob") nyawaMob=nyawaMob-1;    }

}

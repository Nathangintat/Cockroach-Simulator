using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
//using Unity.VisualScripting;
//using Unity.VisualScripting.FullSerializer;

public class CameraController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hud;
    [SerializeField] TextMeshProUGUI timer;
    public GameObject losePage;
    public GameObject winPage;
    public GameObject homePage;
    public GameObject pausePage;
    public float nyawaPlayer;
    public float nyawaMob;
    public float batasWaktu;

    public UnityEvent customEvent;

    private void Update(){
        UpdateHUD();

        batasWaktu-=Time.deltaTime;
        int menit = Mathf.FloorToInt(batasWaktu/60);
        int detik=Mathf.FloorToInt(batasWaktu%60);
        timer.text=string.Format("{0:00}:{1:00}", menit, detik);

        if(batasWaktu<30) timer.color=Color.red;
        else if(batasWaktu<=0) playerDie();
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

    private void playerDie(){
        Time.timeScale=0;
        losePage.SetActive(true);
    }
    // [Header("referensi")]
    // //public Transform orientation;
    // public Transform player;
    // public Transform playerObj;
    // public Rigidbody rb;

    // public float rotationSpeed;

    // [SerializeField] Transform[] povs;
    // private int index=1;
    // private Vector3 target;

    // public CameraStyle currentStyle;

    // public enum CameraStyle{
    //     Basic,
    //     Topdown
    // }

    // private void Start(){
    //     Cursor.lockState=CursorLockMode.Locked;
    //     Cursor.visible=false;
    // }

    //private void Update(){
        // Vector3 viewDir = player.position-new Vector3(transform.position.x,player.position.y,transform.position.z);
        // orientation.forward=viewDir.normalized;

        // if(Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        // else if(Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.Topdown);


        // if(currentStyle==CameraStyle.Basic ||currentStyle==CameraStyle.Topdown){        
        //     float horizontalInput = Input.GetAxis("Horizontal");
        //     float verticalInput=Input.GetAxis("Vertical");
        //     Vector3 inputDir = orientation.forward * verticalInput+orientation.right*horizontalInput;

        //     if(inputDir!=Vector3.zero)
        //         playerObj.forward=Vector3.Slerp(playerObj.forward, inputDir.normalized,Time.deltaTime*rotationSpeed);
        // }
    //}
    // [SerializeField] float speed;
    // [SerializeField] Transform[] povs;

    // private int index=1;
    // private Vector3 target;

    // private void Update(){
    //     if(Input.GetKeyDown(KeyCode.Alpha1)) index=0;
    //     else if(Input.GetKeyDown(KeyCode.Alpha2)) index=1;
    //     else if(Input.GetKeyDown(KeyCode.Alpha3)) index=2;
    //     else if(Input.GetKeyDown(KeyCode.Alpha4)) index=3;

    //     target=povs[index].position;
    // }

    // private void FixedUpdate(){

    //     transform.position=Vector3.MoveTowards(transform.position,target, Time.deltaTime*speed);
    //     transform.forward=povs[index].forward;
    // }
}

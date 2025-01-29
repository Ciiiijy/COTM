using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr I;
    public UI_StartScene ui_StartScene;
    public UI_InsideTemple ui_InsideTewmple;
    public UI_FangsOldHouse ui_FangsOldHouse;
    public UI_DeadForest ui_DeadForest;
    public UI_Cemetery ui_Cemetery;
    public DarkCurtain darkCurtain;




    private void Awake()
    {
        I = this;
        //Init each module here.
        ui_StartScene.Init();
        ui_InsideTewmple.Init();
        ui_FangsOldHouse.Init();
        ui_DeadForest.Init();
        ui_Cemetery.Init();
        darkCurtain.Init();


        ui_StartScene.Show();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

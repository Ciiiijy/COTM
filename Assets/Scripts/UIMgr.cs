using Newtonsoft.Json.Bson;
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
    public UI_Chat ui_Chat;
    public LineBooks lineBooks;

    public Dictionary<string, SceneFunc> dic_UiObj = new Dictionary<string, SceneFunc>();       


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
        lineBooks.Init();
        ui_Chat.Init();
    

        ui_StartScene.Show();
        
        InitDictionary();

    }

    public void InitDictionary() 
    {
        dic_UiObj.Add("UI_FangsOldHouse", ui_FangsOldHouse);

    }
    
}

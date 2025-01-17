using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr I;
    public UI_StartScene ui_StartScene;

    private void Awake()
    {
        I = this;
        //Init each module here.
        ui_StartScene.Init();






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

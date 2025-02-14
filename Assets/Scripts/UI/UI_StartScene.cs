using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartScene : MonoBehaviour
{
    public Button btn_StartGame;
    public Button btn_Options;
    public Button btn_Quit;
    public Image darkImg;

    public void Init()
    {
        btn_StartGame.onClick.AddListener(() =>
        {
            DarkCurtain.I.ChangeScene(
                () =>
                { 
                    Hide(); 
                }, 
                () => 
                {
                    GameMgr.I.onTheBus.Show();
                    UI_Chat.I.Show();
                });
        });

        btn_Quit.onClick.AddListener(() =>
        {
            Hide();
            //TODO:Need to Quit the game.

        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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

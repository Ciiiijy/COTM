using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Wall : MonoBehaviour
{
    public Button btn;
    public string sceneName;        //The scene you will head to.
    public string lineBookName;     //The lines will be triggered and presented.

    public void Init()
    {
        string curtSceneName = this.transform.parent.gameObject.name;

        if (btn) 
        {
            btn.onClick.AddListener(() =>
            {
                DarkCurtain.I.ChangeScene(
                () =>
                {
                    if (sceneName is not null)
                    {
                        if (GameMgr.I.dic_SceneGameObj.ContainsKey(curtSceneName))
                            GameMgr.I.dic_SceneGameObj[curtSceneName].Hide();
                        if (UIMgr.I.dic_UiObj.ContainsKey("UI_" + curtSceneName))
                            UIMgr.I.dic_UiObj["UI_" + curtSceneName]?.Hide();
                    }

                },
                () =>
                {
                    if (sceneName is not null)
                    {
                        if (GameMgr.I.dic_SceneGameObj.ContainsKey(sceneName))
                            GameMgr.I.dic_SceneGameObj[sceneName].Show();
                        if (UIMgr.I.dic_UiObj.ContainsKey("UI_" + sceneName))
                            UIMgr.I.dic_UiObj["UI_" + sceneName].Show();
                    }
                });
            });
            btn.transform.localPosition = offStage;
            btn.gameObject.SetActive(false);
        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowBtn();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        HideBtn();
    }


    Vector2 offStage = new Vector2(1132,254);
    Vector2 onStage = new Vector2(795, 254);
    public void ShowBtn()
    {
        btn?.gameObject.SetActive(true);

        DOTween.Sequence()
            .Append(btn?.transform.DOLocalMoveX(onStage.x, 0.2f));
    }


    public void HideBtn()
    {
        DOTween.Sequence()
            .Append(btn?.transform.DOLocalMoveX(offStage.x, 0.2f))
            .AppendCallback(() => 
            {
                btn?.gameObject.SetActive(false);
            });
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

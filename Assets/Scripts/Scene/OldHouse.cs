using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldHouse : MonoBehaviour, SceneFunc
{

    private Vector2 startLocalPos;
    public void Init()
    {
        Hide();
        startLocalPos = new Vector2(-7, Player.I.transform.position.y);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Player.I.transform.localPosition = startLocalPos;
    }
    public void Hide() { gameObject.SetActive(false); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

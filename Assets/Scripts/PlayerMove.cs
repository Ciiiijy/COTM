using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CanMove(bool canMove)
    {
        this.canMove = canMove;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));

            Vector3 horizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            transform.position = transform.position + horizontal * Time.deltaTime * speed;
        }
    }
}

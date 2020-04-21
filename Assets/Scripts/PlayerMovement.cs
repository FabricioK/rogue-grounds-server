using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 direction;
    public Vector2 position;
    public Vector2 mouse;

    private bool mouseLeft;
    public void SetAnimation(Vector2 dir, Vector2 pos,Vector2 m,bool l)
    {
        direction = dir;
        position = pos;
        mouse = m;
        mouseLeft = l;
        float maxY = position.y - mouse.y;
        float maxX = position.x - mouse.x;
        if (maxY > 1) maxY = 1;
        if (maxY < -1) maxY = -1;
        if (maxX > 1) maxX = 1;
        if (maxX < -1) maxX = -1;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        animator.SetFloat("MouseY", maxY);
        animator.SetFloat("MouseX", maxX);
        animator.SetBool("MouseLeft", mouseLeft);
    }

    // Start is called before the first frame update
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        rb.transform.position = Vector3.Lerp(rb.transform.position, new Vector3(position.x, position.y, rb.transform.position.z), moveSpeed);        
    }
}

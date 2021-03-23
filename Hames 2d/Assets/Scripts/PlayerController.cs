using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private void Awake()
    {
        Debug.Log("Player controller awake");
    }
    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision: " + collision.gameObject.name);
        }*/

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal);

        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);               
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;            
   }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        Input.GetAxisRaw("Vertical");
        Input.GetKeyDown(KeyCode.Space);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class joystickmanager : MonoBehaviour
{
    private Image JoystickBg;
    private Image Joystick;
    private Vector2 possitionJoy, positions_xy,something;
    private Vector3 direction,thouchPosition;
    public Animator anim;
    public SpriteRenderer playerSprite;
    public BoxCollider2D playerBox; 

    [SerializeField] private float movespeed = 0.05f;
    [SerializeField] private int jumpup = 10;
    [SerializeField] private LayerMask jumpableGround;

    public Rigidbody2D rb;

    void Start()
    {
        JoystickBg = GetComponent<Image>();
        Joystick = transform.GetChild(0).GetComponent<Image>();
        positions_xy = Joystick.rectTransform.anchoredPosition;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch =  Input.GetTouch(0);
            thouchPosition = touch.position;
            thouchPosition.z = 0;
            direction = (thouchPosition - transform.position);
            if(thouchPosition.x < 135){
                anim.SetBool("walking",true);
                //playerSprite.flipX = true;
                Joystick.rectTransform.anchoredPosition = new Vector2(-6 - 15, -2);
                movePlayer();
                
            }
            else if(thouchPosition.x > 135 && thouchPosition.x < 500){
                anim.SetBool("walking",true);
                //playerSprite.flipX = false;
                Joystick.rectTransform.anchoredPosition = new Vector2(-6 + 30, -2);
                movePlayer();
            }
            if(touch.phase == TouchPhase.Ended){
                rb.velocity = Vector2.zero;
                Joystick.rectTransform.anchoredPosition = new Vector2(positions_xy.x, positions_xy.y);
                anim.SetBool("walking",false);
            }
            
        }
    }

    public void jumpingFunction(){
        if(IsGround()){
            rb.velocity = new Vector3(rb.velocity.x,jumpup,0);
        }
            
    }

    private void movePlayer(){
        rb.velocity = new Vector2(direction.x * movespeed, rb.velocity.y);
    }

    private bool IsGround(){
        return Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

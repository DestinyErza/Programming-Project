using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public CharacterController controller;
    public int health = 100;
    public float gravity = -9f;
    public float jumpHeight = 3f;
    //speeds
    public float speed = 5f;
    public float crouchspeed = 1f;
    public float currentspeed;
    public float runningspeed = 10;
    public float walkspeed = 5f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

   
   




    void Update()

       
    {
        speed = currentspeed;
        //jump checker, only able to jump when on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
            
        //crouch funtion
        if(Input.GetKeyDown(KeyCode.C))
        {
            controller.height = 1f;
           
           currentspeed = crouchspeed;

        }
      if(Input.GetKeyUp(KeyCode.C))
        {
            controller.height = 2f;
            currentspeed = walkspeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentspeed = runningspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift ))
        {
            currentspeed = walkspeed;
        }

            if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
           


        //character movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Hit(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            GameEvents.ReportPlayerDied(this.gameObject);
        }
        else
        {
            GameEvents.ReportPlayerHit(this.gameObject);
        }
    }

    //inventroy//notes
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Note"))
        {
            Debug.Log("note picked up");
            //ui prompt to open inventory w i
            _I.notes.Add(other.gameObject.GetComponent<Note>());
            _I.notesGO[_I.notes.Count].SetActive(true);
            _I.notesGO[_I.notes.Count].GetComponent<Note>().note = (other.gameObject.GetComponent<Note>().note);
            other.gameObject.SetActive(false);
            //instanstiate a new note button and adds note to the button//getcomponent buttonnotes.note = pickedupnote
   
        }
    }


}

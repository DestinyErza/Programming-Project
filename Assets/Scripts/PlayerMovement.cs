using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Audio;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public CharacterController controller;
    public int health = 1;
    public float gravity = -9f;
    public float jumpHeight = 3f;
    //speeds
    public float speed = 5f;
    public float crouchspeed = 1f;
    public float currentspeed;
    public float runningspeed = 10;
    public float walkspeed = 5f;

    //text
    public TMP_Text text;
    public float DisappearTime;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public string inputsound;
    bool playerismoving;
    public float walkingspeed;

    //reset stuff
    //  GameObject resetPoint;
    // bool resetting = false;
    //Color originalColour;
    // private Rigidbody rb;

    public AudioSource audioSource;




    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
   
    }



    void Update()
    {
       // plays footstep sounds with random sound and pitch
       if(controller.isGrounded == true  && speed >= 4f && audioSource.isPlaying == false )
        {
            audioSource.volume = Random.Range(0.5f, 0.8F);
            audioSource.pitch = Random.Range(0.9f, 1.1f);
           audioSource.Play();
        }
        

     
        speed = currentspeed;
        //jump checker, only able to jump when on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //crouch funtion, reduces height and speed

        if (Input.GetKeyDown(KeyCode.C))
        {
            controller.height = 1f;

            currentspeed = crouchspeed;
            

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            controller.height = 2f;
            currentspeed = walkspeed;
            playerismoving = true;
        }

        //increases speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentspeed = runningspeed;
            playerismoving = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentspeed = walkspeed;
            playerismoving = true;
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
        //does damage to player health//kills
        health -= _damage;
        if (health <= 0)
        {
            GameEvents.ReportPlayerDied(this.gameObject);
            Debug.Log("player" + health);
        }
        else
        {
            GameEvents.ReportPlayerHit(this.gameObject);
        }
    }

    //inventroy//notes
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.CompareTag("Note"))
        {
            //Debug.Log("note picked up");
            //ui prompt to open inventory with i
            text.text = ("Press 'I' to view this note in your inventory");
         
            StartCoroutine(ResetText());


            _I.notes.Add(other.gameObject.GetComponent<Note>());
            _I.notesGO[_I.notes.Count].SetActive(true);
            _I.notesGO[_I.notes.Count].GetComponent<Note>().note = (other.gameObject.GetComponent<Note>().note);
            other.gameObject.SetActive(false);
            //instanstiate a new note button and adds note to the button//getcomponent buttonnotes.note = pickedupnote

        }
    }
    
    //start couritine after being picked up


    //resets text after note is picked up but allows it to refresh on new pickup
    IEnumerator ResetText()
    {
        yield return new WaitForSeconds(2);
        text.text = "";
    }

}

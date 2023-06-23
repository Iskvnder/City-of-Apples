using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public PlayerController playerController;
    public SoundText soundTextScript;

    public AudioSource footstepsSound;
    public AudioSource jump;

    private Animator playerAnimator;
    
    private string[] animationsArray = {"isRun", "isJump",
    "isDoubleJump", "isFlying", "isFalling", "isFall"};

    private Vector2 velocity;
    private bool isGrounded = true;

    private bool secondJump = false;

    void Start() {
        playerAnimator = GetComponent<Animator>();
        isGrounded = playerController.grounded;
        velocity = playerController.GetComponent<Rigidbody2D>().velocity;
    }

    
    void Update() {
        animPlay();
        velocity = playerController.GetComponent<Rigidbody2D>().velocity;
        isGrounded = playerController.grounded;

        if (velocity.y != 0) {
            footstepsSound.enabled = false;
        } else 
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
           footstepsSound.enabled = true;
        } else {
            footstepsSound.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !soundTextScript.isDisplaying) {
            jump.Play();
        }
    }


    void animPlay(){
        
        bool rightPress = Input.GetKey(KeyCode.D);
        bool leftPress = Input.GetKey(KeyCode.A);

        bool jumpPress = Input.GetKeyDown(KeyCode.Space);

        bool leftUpPress = (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space));
        bool rightUpPress = (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space));


        if (leftPress ^ rightPress) {
            setAnimation(0);
            
        } else {
            resetAnimation(0);
        }

        if (velocity.y > 0) {
            if (secondJump) {
                setAnimation(2);
                secondJump = false;
            } else
                secondJump = true;
                setAnimation(1);
        } else 

        if (velocity.y < 0) {
            setAnimation(4);
            resetAnimation(2);
            resetAnimation(1);
        } else 

        if (velocity.y == 0) {
            resetAnimation(4);
            setAnimation(5);
        }

        if (isGrounded) {
            resetAnimation(5);
        }

    }

    void setAnimation(int num){
        for(int i = 0; i < animationsArray.Length; i++){
            if(i == num){playerAnimator.SetBool(animationsArray[i], true);}
        }
    }

    void resetAnimation(int num){
        for(int i = 0; i < animationsArray.Length; i++){
            if(i == num){playerAnimator.SetBool(animationsArray[i], false);}
        }
    }

    void resetAllAnimation(){
        for(int i = 0; i < animationsArray.Length; i++){
            playerAnimator.SetBool(animationsArray[i], false);
        }
    }

}

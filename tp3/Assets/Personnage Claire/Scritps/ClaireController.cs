using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireController : MonoBehaviour {

    Animator claireAnimator;
    AudioSource claireAudioSource;
    CapsuleCollider claireCapsule;
    Rigidbody rb;

    float axisH, axisV;

    [SerializeField]
    float walkSpeed = 2f, runSpeed = 8f, rotSpeed = 100f, jumpForce = 350;

    const float timeout = 60.0f;
    [SerializeField] float countdown = timeout;

    [SerializeField] AudioClip sndJump, sndImpact, sndLeftFoot, sndRightFoot;
    public ParticleSystem jumpParticleEffect;

    bool switchFoot = false;
    [SerializeField] bool isJumping = false;

    int jumpCount = 0;
    const int maxJumps = 3;

    private void Awake() {
        claireAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        claireAudioSource = GetComponent<AudioSource>();
        claireCapsule = GetComponent<CapsuleCollider>();
        if (jumpParticleEffect != null) {
            jumpParticleEffect.Stop();
        }
    }

    void Update() {
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        if (axisV > 0) {
            if (Input.GetKey(KeyCode.LeftControl)) {
                transform.Translate(Vector3.forward * runSpeed * axisV * Time.deltaTime);
                claireAnimator.SetFloat("run", axisV);
            } else {
                transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
                claireAnimator.SetBool("walk", true);
                claireAnimator.SetFloat("run", 0);
            }
        } else {
            claireAnimator.SetBool("walk", false);
        }

        if (axisH != 0 && axisV == 0) {
            claireAnimator.SetFloat("h", axisH);
        } else {
            claireAnimator.SetFloat("h", 0);
        }

        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * axisH);

        if (axisV < 0) {
            claireAnimator.SetBool("walkBack", true);
            claireAnimator.SetFloat("run", 0);
            transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
        } else {
            claireAnimator.SetBool("walkBack", false);
        }

        if (axisH == 0 && axisV == 0) {
            countdown -= Time.deltaTime;

            if (countdown <= 0) {
                claireAnimator.SetBool("dance", true);
                transform.Find("AudioDance").GetComponent<AudioSource>().enabled = true;
            }
        } else {
            countdown = timeout;
            claireAnimator.SetBool("dance", false);
            transform.Find("AudioDance").GetComponent<AudioSource>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.AltGr)) {
            ClaireDead();
        }

        if (isJumping) {
            claireCapsule.height = claireAnimator.GetFloat("colheight");
        }
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            Jump();
        }
    }

    private void Jump() {
        isJumping = true;
        jumpCount++;
        rb.AddForce(Vector3.up * jumpForce);
        claireAudioSource.pitch = 1f;
        claireAnimator.SetTrigger("jump");
        claireAudioSource.PlayOneShot(sndJump);

        if (jumpCount >= maxJumps) {
            ActivateJumpEffect();
        }
    }

    private void ActivateJumpEffect() {
        if (jumpParticleEffect != null) {
            jumpParticleEffect.Play();
        }
        jumpCount = 0;
    }

    public void SwitchIsJumping() {
        isJumping = false;
    }

    public void ClaireDead() {
        claireAnimator.SetTrigger("dead");
        GetComponent<ClaireController>().enabled = false;
    }

    public void PlaySoundImpact() {
        claireAudioSource.pitch = 1f;
        claireAudioSource.PlayOneShot(sndImpact);
    }

    public void PlayFootStep() {
        if (!claireAudioSource.isPlaying) {
            switchFoot = !switchFoot;

            if (switchFoot) {
                claireAudioSource.pitch = 2f;
                claireAudioSource.PlayOneShot(sndLeftFoot);
            } else {
                claireAudioSource.pitch = 2f;
                claireAudioSource.PlayOneShot(sndRightFoot);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System;

public class Playar : MonoBehaviour
{
    public bool EatMashrim {private set; get; }
    public bool SuperMod {private set; get; }
    public bool FlowerrMod {private set; get; }

    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpFors;
    [SerializeField] private float GravitiScale;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip JumpSound;

    private void Start() {

        EatMashrim = false;
        SuperMod = false;
        FlowerrMod = false;
    }

    private void Update() {

        _spriteRenderer.flipX = Input.GetAxis("Horizontal") < 0;

        Run(Input.GetAxis("Horizontal"));
        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        if(OnGround() == false) {
            CheckJumpGraviti();
        }

        SetAnimationParameters(OnGround(), Math.Abs(Input.GetAxis("Horizontal")));
    }
    
    public void HitJump() {

        _rigidbody.AddForce(Vector2.up * (JumpFors / 2f), ForceMode2D.Impulse);
    }
  
    public void PlayAudio(AudioClip clip) {

        _audio.clip = clip;
        _audio.Play();
    }

    public void StartBigPlayar() {

        EatMashrim = true;
        _animator.SetTrigger("Mashrum");
    }

    public void StarSuperPlayar() {

        SuperMod = true;
        _animator.SetBool("Star", SuperMod);

    }

    public void StartFlowerPlayar() {

        FlowerrMod = true;
        _animator.SetTrigger("Flower");
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(OnGround() == false) {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void Jump() {
        
        if(OnGround()) {
            _animator.SetTrigger("Jump");
            PlayAudio(JumpSound);
            _rigidbody.gravityScale = 1.5f;
            _rigidbody.AddForce(Vector2.up * JumpFors, ForceMode2D.Impulse);
        }
    }

    private void CheckJumpGraviti() {

        if(_rigidbody.velocity.y <= 0) {
            _rigidbody.gravityScale = GravitiScale;
        }
    }

    private void Run(float direction) {

        _rigidbody.velocity = new Vector2(direction * RunSpeed * Time.deltaTime, _rigidbody.velocity.y);
    }

    private bool OnGround()
    {
        
        var groundInfo = Physics2D.BoxCastAll(
            _collider.bounds.center - new Vector3(0, _collider.bounds.size.y/2, 0), 
            new Vector2(_collider.bounds.size.x, 0.3f), 0, Vector2.down, 0);

        if(groundInfo.Length > 1) {
            return true;
        }
        else
            return false;
    }

    private void SetAnimationParameters(bool onGround, float speed) {
        _animator.SetBool("OnGround", onGround);
        _animator.SetFloat("Speed", speed);
    }

    public void DestrioPlayar() {

    }


}

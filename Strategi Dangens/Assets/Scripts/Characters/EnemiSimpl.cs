using UnityEngine;

public class EnemiSimpl : MonoBehaviour, IEnemi {

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float MoveSpeed;

    private float Direction = 1;

    private void Start() {
        

    }

    private void Update() {

        Mov();
    }

    public void GetHit() {

        _animator.SetTrigger("Hit");
    }
    
    private void Mov() {

        _rigidbody.velocity = new Vector2(Direction * MoveSpeed * Time.deltaTime, _rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        collision.GetComponent<Playar>()?.DestrioPlayar();

        if(collision.GetComponent<ICreator>() != null) {
            return;
        }

        Direction = -Direction;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision) {


        if(collision.transform.GetComponent<Playar>() && collision.contacts[0].normal.y < 0.5f) {

            collision.transform.GetComponent<Playar>().HitJump();
            GetHit();
        }
    }

    private void DestroyEnemi() {
        
        Destroy(gameObject);
    }

}

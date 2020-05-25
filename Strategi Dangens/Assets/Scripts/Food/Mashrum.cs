using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashrum : MonoBehaviour, ICreator
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float SpeedMov;
    [SerializeField] private PlatformEffector2D _platformEffector;

    private float Direction;

    private void Start() {
        Direction = 1;
    }

    private void Update() {
        
        Mov(Direction);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Playar temp = collision.transform?.GetComponent<Playar>();

        if(temp != null) {

            temp.StartBigPlayar();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.GetComponent<IEnemi>() != null || collision.GetComponent<Playar>() == true) {
            return;
        }
        else {
            Direction = -Direction;
            _platformEffector.rotationalOffset = -_platformEffector.rotationalOffset;
        }

    }


    private void Mov(float direction) {

        _rigidbody.velocity = new Vector2(direction * SpeedMov * Time.deltaTime, _rigidbody.velocity.y);  
    }

    public void IsActiv() {
        transform.position += Vector3.up;
    }
}

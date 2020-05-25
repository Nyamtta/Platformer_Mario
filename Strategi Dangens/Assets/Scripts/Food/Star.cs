using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour, ICreator
{
    [SerializeField] private Rigidbody2D _rigetbody;
    [SerializeField] private float SpeedMov;
    [SerializeField] private float jumpFors;



    private void Update() {

        Mov();

    }


    private void Mov() {

        _rigetbody.velocity = new Vector2(SpeedMov * Time.deltaTime, _rigetbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Playar temp = collision.transform?.GetComponent<Playar>(); 

        if(temp != null) {

            temp.StarSuperPlayar();
            Destroy(gameObject);
        }
        else {

            _rigetbody.AddForce(Vector2.up * jumpFors, ForceMode2D.Impulse);
        }


    }

    public void IsActiv() {

        transform.position += Vector3.up; 
    }
}

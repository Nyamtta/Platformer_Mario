using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickBlock : MonoBehaviour
{
    [SerializeField] private UnityEvent Hit;
    [SerializeField] private UnityEvent DestroiHit;


    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.transform.GetComponent<Playar>() && collision.contacts[0].normal.y > 0.5f) {

            if(collision.transform.GetComponent<Playar>().EatMashrim == false) {

                Hit?.Invoke();
            }
            else {

                DestroiHit?.Invoke();
            }
        }
    }

    private void DestroiGameObgect() {

        Destroy(gameObject);
    }

    public void StartAnimation() {
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();
    }

}

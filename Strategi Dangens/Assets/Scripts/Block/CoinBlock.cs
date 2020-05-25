using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour {

    [SerializeField] private GameObject NewCoin;
    [SerializeField] private Animation _animation;
    [SerializeField] private AudioSource _audio;

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.transform.GetComponent<Playar>() && collision.contacts[0].normal.y > 0.5f) {

            TaceHIt();
        }
    }

    public void TaceHIt() {

        _audio.Play();
        _animation.Play();

        GameObject temp = Instantiate(NewCoin, transform.position, Quaternion.identity);
        temp.GetComponent<ICreator>()?.IsActiv();
        
        Destroy(this);
    }
}

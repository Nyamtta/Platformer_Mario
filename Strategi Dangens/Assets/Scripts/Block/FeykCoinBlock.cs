using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeykCoinBlock : MonoBehaviour{

    [SerializeField] private GameObject NewCoin;
    [SerializeField] private Sprite EmptyBlock;
    [SerializeField] private SpriteRenderer BlockSprite;
    [SerializeField] private Animation _animation;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private int HitNumber;

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.transform.GetComponent<Playar>() && collision.contacts[0].normal.y > 0.5f) {

            TaceHIt();
        }
    }

    public void TaceHIt() {

        if(HitNumber > 0) {

            HitNumber--;

            _audio.Play();
            _animation.Play();

            GameObject temp = Instantiate(NewCoin, transform.position, Quaternion.identity);
            temp.GetComponent<ICreator>()?.IsActiv();

        }
        else {

            BlockSprite.sprite = EmptyBlock;
            BlockSprite.color = Color.green;
            Destroy(this);
        }
    }
}

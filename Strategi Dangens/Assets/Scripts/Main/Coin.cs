using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Coin : MonoBehaviour, ICreator
{
    [SerializeField] private UnityEvent TaceCoin;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audio;
    private const int Value = 200; 
    private LevelInfo Info;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.GetComponent<Playar>() == true) {

            TaceCoin?.Invoke();
            UpdaitInfo();
            Invoke("DestroyCoin", _audio.clip.length);
        }
    }
   
    private void UpdaitInfo() {

        Info = Camera.main.GetComponent<LevelInfo>();
        Info.SetParametr(LevelInfo.Parameters.PlayarCoin, 1);
        Info.SetParametr(LevelInfo.Parameters.PlayarScore, Value);
        _audio.Play();
    }

    private void DestroyCoin() {
        Destroy(gameObject);
    }

    public void IsActiv() {

        _animator.SetTrigger("CoinUp");

        UpdaitInfo();
    }
}

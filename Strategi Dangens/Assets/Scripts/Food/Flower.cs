using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, ICreator
{

    [SerializeField] private float SpeedMov;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        Playar temp = collision?.GetComponent<Playar>();

        if(temp != null) {

            if(temp.EatMashrim == false) {

                temp.StartBigPlayar();
            }
            else {
                temp.StartFlowerPlayar();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

        transform.position += Vector3.up * SpeedMov * Time.deltaTime;
    }

    public void IsActiv() {

        

    }
}

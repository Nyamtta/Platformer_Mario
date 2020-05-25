using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMuving : MonoBehaviour
{

    [SerializeField] private Transform FollowObject;
    [SerializeField] private Transform MIdObject;

    private void Update() {

        if(FollowObject.position.x > MIdObject.position.x) {
            transform.position = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);
        }
    }

}

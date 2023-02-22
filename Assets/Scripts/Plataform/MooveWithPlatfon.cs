using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveWithPlatfon : MonoBehaviour
{

    CharacterController player;

    public Vector3 groundPosition;
    Vector3 lastGronudPosition;
    public string groundName;
    public string lastGroundName;
    public bool isGro;
    public float ancho;
    public Vector3 originOffset;


    // rotacion
    Quaternion actualRot;
    Quaternion lastRot;



    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            isGro = true;
            // Línea imaginaría desde un punto a otro
            RaycastHit hit;
            if (Physics.SphereCast(transform.position + originOffset,
                player.radius / ancho, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;


                ///Rot
                actualRot = groundedIn.transform.rotation;

                /// 
                /// 
                ///

                if (groundPosition != lastGronudPosition && groundName == lastGroundName)
                {
                    Debug.Log("Hit");
                    this.transform.position += groundPosition - lastGronudPosition;



                    /////
                    player.enabled = false;
                    player.transform.position = this.transform.position;
                    player.enabled = true;


                }


                ///Rot
                if (actualRot != lastRot && groundName == lastGroundName)
                {
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }

                lastRot = actualRot;

                ///





                lastGroundName = groundName;
                lastGronudPosition = groundPosition;
            }
        }
        else
        {
            isGro = false;
            lastGroundName = null;
            lastGronudPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);

        }
    }

    //Gizmos lineas de los objetos
    private void OnDrawGizmos()
    {
        // raycast más grande
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position + originOffset, player.radius / ancho); // ancho
    }
}

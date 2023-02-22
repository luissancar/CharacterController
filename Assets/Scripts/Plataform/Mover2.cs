using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Mover2 : MonoBehaviour
{
    public Transform plataforma;
    public CharacterController controlador;
    private Vector3 movimientoPlataformaAnterior;
    private Vector3 movimientoPersonajeAnterior;
    public bool enPlataforma = false;

    void Start()
    {
        // Obtener referencias al transform de la plataforma y al CharacterController del personaje
     //   plataforma = transform.parent;
       // controlador = GetComponent<CharacterController>();

        // Guardar el movimiento anterior de la plataforma y del personaje
        movimientoPlataformaAnterior = plataforma.position;
        movimientoPersonajeAnterior = transform.position;
    }

    void FixedUpdate()
    {
        if (enPlataforma)
        {
            // Obtener el movimiento de la plataforma en el �ltimo frame
            Vector3 movimientoPlataforma = plataforma.position - movimientoPlataformaAnterior;

            // Mover el personaje en la misma direcci�n que se movi� la plataforma
            controlador.Move(movimientoPlataforma);

            // Guardar el movimiento actual de la plataforma y del personaje para comparar en el pr�ximo frame
            movimientoPlataformaAnterior = plataforma.position;
            movimientoPersonajeAnterior = transform.position;
        }
    }


   
}


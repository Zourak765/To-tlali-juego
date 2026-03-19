using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad;
    float movimientoX;
    float movimientoY;
    bool aCorrer = false;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (aCorrer) { velocidad = 12f; } else { velocidad = 7f; }
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            if (aCorrer) { velocidad = 8f; } else { velocidad = 4f; }
        }

        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) { aCorrer = true; } else { aCorrer = false; }

        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");
        GetComponent<Transform>().Translate(new Vector3(movimientoX * velocidad, movimientoY * velocidad, 0) * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapasPer : MonoBehaviour
{
    Transform miTransform;
    SpriteRenderer miSprite;

    float valor;
    int pos;

    public int sumar;

    void Start()
    {
        miTransform = this.gameObject.GetComponent<Transform>();
        miSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        valor = miTransform.position.y;
        pos = Mathf.RoundToInt(valor) * -1;

        miSprite.sortingOrder = pos + sumar;
    }
}


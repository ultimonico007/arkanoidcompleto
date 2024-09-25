using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movimiento : MonoBehaviour
{
    public float velocidad = 10f;
    float movimientohorizontal;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        movimientohorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movimientohorizontal * velocidad * Time.deltaTime,0,0);
    }
}

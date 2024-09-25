using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pelota_mov : MonoBehaviour
{
    public Vector2 velocidadinicial;
    private Rigidbody2D pelotaRB;
    bool ismoving;
    public Puntos suma;
    public int puntaje;

    // Start is called before the first frame update
    void Start()
    {
        pelotaRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ismoving)
        {
            pelotaRB.velocity = velocidadinicial;
            ismoving = true;
        }
        ganar();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            suma.Contador(puntaje);
  
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("fast"))
        {
            Time.timeScale = 2f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("slow"))
        {
            Time.timeScale = 0.50f;
          Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("duplicar"))
        {
            GameObject duplicar = Instantiate(gameObject, transform.position, transform.rotation);
            pelota_mov scriptduplicar = duplicar.GetComponent<pelota_mov>();
            scriptduplicar.suma = suma;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("perder"))
        {
            perder();
        }

    }
    void ganar()
    {
        GameObject[] ladrillos2 = GameObject.FindGameObjectsWithTag("enemigo");
        if (ladrillos2.Length == 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("ganar");
        }
    }
    void perder()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("perder");
    }
    void nivel()
    {
        GameObject[] ladrillos1 = GameObject.FindGameObjectsWithTag("level");
        if (ladrillos1.Length == 0)
        {
            SceneManager.LoadScene("intro");
        }
    }
}

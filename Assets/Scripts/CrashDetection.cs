using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashDetection : MonoBehaviour
{
    public GameObject explosion;

    public GameObject roadsides;
    public Material defaultMaterial;
    public Material gameOverMaterial;

    public GameObject gameOverText;
    public GameObject resetButton;

    public void GameOver()
    {
        ExplodeGameObject(gameObject);

        gameOverText.SetActive(true);
        resetButton.SetActive(true);

        

        // Make roadsides red
        roadsides.gameObject.GetComponent<Renderer>().material = gameOverMaterial;
        

        // Show game over + score
    }

    public void ResetGame()
    {
        roadsides.gameObject.GetComponent<Renderer>().material = defaultMaterial;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        	GameOver();
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject g in gos)
            {
                g.GetComponent<EnemyCar>().movementSpeed = 0f;
                
            }
            
        }
        
    }

    void ExplodeGameObject(GameObject go)
    {
        Instantiate(explosion, go.transform.position, Quaternion.identity);
        Destroy(go.gameObject);
    }
    
}

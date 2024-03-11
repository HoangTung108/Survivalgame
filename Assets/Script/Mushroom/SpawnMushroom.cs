using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMushroom : MonoBehaviour
{
    public GameObject Mushroom;

    public static bool CanSpawnMushroom1 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanSpawnMushroom1 == true && SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Debug.Log("sadhjgkal");
            float x = Random.Range(-63f,63f);
            float y = Random.Range(-63f,70f);
            transform.position = new Vector3(x,-1,y);
            Instantiate(Mushroom,transform.position,Quaternion.identity);
            CanSpawnMushroom1 = false;
        }
    }
}

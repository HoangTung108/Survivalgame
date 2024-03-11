using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TinyThings : MonoBehaviour
{
    public GameObject[] Tree;
    public static float NumTree = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(NumTree);
        if(NumTree > 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            float x = Random.Range(-63f,63f);
            float y = Random.Range(-63f,70f);
            transform.position = new Vector3(x,-2,y);
            int rand = Random.Range(0,Tree.Length);
            GameObject TreeToSpawn = Tree[rand];
            Instantiate(TreeToSpawn,transform.position,Quaternion.identity);
            NumTree -= 1;
        }
    }
}

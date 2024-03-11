using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour
{
    private Rigidbody rb;
    private bool isLandingYet = false;
    public float TreeHeight;
    public LayerMask GroundLayer;
    public LayerMask Terrain;
    public float DetectiveRadius;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Droping();
    }

    private void DeleteObj()
    {
        //Debug.Log("TreeNearby");
        NewTree.NumTree += 1;
        Destroy(gameObject);
    }

    private void Droping()
    {
        isLandingYet = Physics.Raycast(transform.position,Vector3.down,TreeHeight*0.5f+0.2f,GroundLayer);
        if(isLandingYet)
        {
            Collider[] newColliders = Physics.OverlapSphere(transform.position,DetectiveRadius,Terrain);
            if(newColliders.Length > 1)
            {
                DeleteObj();
            }
            else
            {
                Destroy(rb);
            }

        }
        else if(!isLandingYet)
        {

            transform.Translate(Vector3.up*1f*Time.deltaTime);
            transform.rotation = new Quaternion(0f,0f,0f,0f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom1 : MonoBehaviour
{
    public GameObject Player;
    private bool isPlayerInReach = false;
    private Rigidbody rb;
    public LayerMask PlayerLayer;
    private bool isLandingYet = false;
    public float MushroomHeight;
    public LayerMask GroundLayer;
    private AudioManager audioManager;
    public float DetectiveRadius;
    public LayerMask Terrain;   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DeleteObj();
        Droping();
    }

    private void DeleteObj()
    {
        Vector3 directionToPlayer = new Vector3(Player.transform.position.x - transform.position.x,Player.transform.position.y - transform.position.y,Player.transform.position.z - transform.position.z);
        isPlayerInReach = Physics.Raycast(transform.position,directionToPlayer,1f,PlayerLayer);
        if(isPlayerInReach && Input.GetButtonDown("Fire1"))
        {
            SpawnMushroom.CanSpawnMushroom1 = true;
            audioManager.PlaySFX(audioManager.Collect);
            PlayerCanvas.Score += 1f;
            Destroy(gameObject);
        }
    }

    private void Droping()
    {
        isLandingYet = Physics.Raycast(transform.position,Vector3.down,MushroomHeight*0.5f+0.1f,GroundLayer);
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
                float Distance = Vector3.Distance(Player.transform.position, transform.position);
                float RoundedDistance = Mathf.Round(Distance);
                PlayerCanvas.Distancee = RoundedDistance;
            }

        }
        else if(!isLandingYet)
        {
            PlayerCanvas.Distancee = 0f;
            transform.Translate(Vector3.up*1f*Time.deltaTime);
            transform.rotation = new Quaternion(0f,0f,0f,0f);
        }
    }

}

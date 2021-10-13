using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float Velocidade;
    public Animator anim;
    public Camera MainCamera;
    float InputX; // A,D
    float InputZ; // W,S 
    Vector3 Direcao;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        Direcao = new Vector3(InputX,0,InputZ);
        
        if(InputX != 0 || InputZ != 0){
            
            var camrot = MainCamera.transform.rotation;
            camrot.x = 0;
            camrot.z = 0;

            transform.Translate(0,0,Velocidade * Time.deltaTime);
            anim.SetBool("Walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direcao) * camrot, 5 * Time.deltaTime);    
        }

     

        if( InputX == 0 & InputZ == 0){
            
            anim.SetBool("Walk", false);
        }

    }
}

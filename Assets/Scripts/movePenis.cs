using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight = true;
    public bool moveUp = false;
    public GameObject penia;
    public ButtonScript script;
    public float oldspeed;
    [SerializeField]public ObjectMovement movement;
    private GameObject peni;
    // public ObjectMovement movement;
    void Start(){
        moveRight = true;
        moveUp = false;
        movement = penia.GetComponent<ObjectMovement>();
        movement.speed =speed;
    }
    void Update()
    {
        if (moveRight)
        {
            if (transform.position.x >= 217)
            {
                moveRight = false;
            }
            else
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
        }
        else if (moveUp)
        {
            transform.Translate(transform.forward * -speed * Time.deltaTime);
        }
        else
        {
            
            if (transform.position.x <= 210)
            {
                moveRight = true;
            }
            else
            {
                transform.Translate(transform.right * -speed * Time.deltaTime);
                
            }

        }
        if(transform.position.z >=398){
            Destroy(gameObject);
            float a = Random.Range(210.44f,217f);
            peni = Instantiate(penia, new Vector3(a,5.43f,395.42f), Quaternion.Euler(new Vector3(90,0,0)));
            peni.name = peni.name.Replace("(Clone)","");
            movement = peni.GetComponent<ObjectMovement>();
            speed=script.oldspeed1;
            speed+=0.5f;
            movement.speed=speed;
            movement.enabled = true;
            script.status =1;
            
        }
    }
}
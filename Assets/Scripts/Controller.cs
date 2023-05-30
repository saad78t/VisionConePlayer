using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody rigid;
	Camera viewCamera;
	Vector3 velocity;

    float stamina = 3;
    float maxStamina = 3;
    
    float walkSpeed, runSpeed;
    bool isRunning;
    Rect staminaRect;
    Texture2D staminaTexture;


    void Start () {
		rigid = GetComponent<Rigidbody>();
		viewCamera = Camera.main;

        walkSpeed = moveSpeed;
        runSpeed = walkSpeed * 1.5f; //1.5 multiplier to sprint instead of 3x
    }

    void Update()
    {
       PlayerMovements();
        StartCoroutine(SprintPlayer());
    }

    void FixedUpdate() {
         rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
    }

    void PlayerMovements()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        //transform.LookAt (mousePos + Vector3.up * transform.position.y);
        mousePos.y = transform.position.y;
        transform.LookAt(mousePos);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }


    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        moveSpeed = isRunning ? runSpeed : walkSpeed;
    }


    IEnumerator SprintPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
            staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
            staminaTexture = new Texture2D(1, 1);
            staminaTexture.SetPixel(0, 0, Color.green);
            staminaTexture.Apply();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
           
            //To clear the time line bar
            //staminaTexture = new Texture2D(1, 1);
            //staminaTexture.SetPixel(0, 0, Color.clear);
            //staminaTexture.Apply();
        }

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }
        else if (stamina < maxStamina)
        {
            yield return new WaitForSeconds(1);
            
            //stamina += Time.deltaTime;
            stamina = Mathf.Clamp(stamina + Time.deltaTime, 0, maxStamina);
			 if (stamina == maxStamina)
            {
                yield return new WaitForSeconds(1);
                staminaTexture.SetPixel(0, 0, Color.clear);
                staminaTexture.Apply();
            }
        }
    }

    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }

    //this for FullAutomaticDoor
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Door" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (other.GetComponent<AutomaticDoor>().Moving == false)
    //        {
    //            other.GetComponent<AutomaticDoor>().Moving = true;
    //        }
    //    }
    //}
    //public PicUpKey key;
    //public Animator doorAnim;
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Door" && key.keyCollected == true)
    //    {
    //        Debug.Log(other.gameObject.tag);
    //        doorAnim.ResetTrigger("close");//
    //        doorAnim.SetTrigger("open");
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Door" && key.keyCollected == true)
    //    {
    //        doorAnim.ResetTrigger("open");
    //        doorAnim.SetTrigger("close");
    //        //objectMaterial.GetComponent<MeshRenderer>().material = defaultMaterial;
    //    }
    //}
}
using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody rigid;
	Camera viewCamera;
	Vector3 velocity;

    float stamina = 5, maxStamina = 5;
    float walkSpeed, runSpeed;
    bool isRunning;
    Rect staminaRect;
    Texture2D staminaTexture;


    void Start () {
		rigid = GetComponent<Rigidbody>();
		viewCamera = Camera.main;

        walkSpeed = moveSpeed;
        runSpeed = walkSpeed * 3;

    }

    void Update () {
        playerMovements();
        sprintPlayer();
    }

    void playerMovements()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        //transform.LookAt (mousePos + Vector3.up * transform.position.y);
        mousePos.y = transform.position.y;
        transform.LookAt(mousePos);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    void FixedUpdate() {
		rigid.MovePosition (rigid.position + velocity * Time.fixedDeltaTime);
	}


    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        moveSpeed = isRunning ? runSpeed : walkSpeed;
    }


    void sprintPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
            staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
            staminaTexture = new Texture2D(1, 1);
            staminaTexture.SetPixel(0, 0, Color.white);
            staminaTexture.Apply();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }
        //else if (stamina < maxStamina)
        //{
        //    stamina += Time.deltaTime;
        //}
    }

    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }
}
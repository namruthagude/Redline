using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private BulletController bulletController;
    [SerializeField]
    private GameObject go_sheild;
    [SerializeField]
    private PlayerUI playerUI;
    [SerializeField]
    private float cooldown_time = 5f;
    [SerializeField]
    private float rotation_speed =20f;

    InputSystem_Actions controls;
    private bool IsSheildActive = false;
    private Vector2 moveInput;
    private Vector2 mouseScreenPos;
    private float init_cooldown_time;

    private LivesManager livesMaanager;
    private GameManager gameManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
        controls = new InputSystem_Actions();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livesMaanager = LivesManager.Instance;
        gameManager = GameManager.Instance;
        go_sheild.SetActive(false);
        init_cooldown_time = cooldown_time;
        controls.Player.Move.performed += Move_performed;
        controls.Player.Move.canceled += Move_canceled;
        controls.Player.Shoot.performed += Shoot_performed;
        controls.Player.Sheild.performed += Sheild_performed;
        controls.Player.Sheild.canceled += Sheild_canceled;
        controls.Player.Look.performed += Look_performed;
    }

    private void Look_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseScreenPos = obj.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    private void Sheild_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsSheildActive = false ;
        go_sheild.SetActive(false);
    }

    private void Sheild_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsSheildActive = true;
        go_sheild.SetActive(true);
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        bulletController.Shoot();
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInput = Vector2.zero;
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetGameState() != GameManager.GameState.Playing)
        {
            return;
        }
        Move();
        RotateTowardsMouse();
        HandleSheild();
    }

    private void RotateTowardsMouse()
    {
        //Get Mouse position on screen
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        Vector2 dir = worldPos - transform.position;

        float targetangle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;

        //smooth rotation
        float angle = Mathf.Lerp(transform.eulerAngles.x, targetangle, rotation_speed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    private void HandleSheild()
    {
        if (IsSheildActive)
        {
            cooldown_time -= Time.deltaTime;
            playerUI.FillHeatBar(cooldown_time / init_cooldown_time);
            if (cooldown_time <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (cooldown_time <= init_cooldown_time)
            {
                cooldown_time += Time.deltaTime;
                playerUI.FillHeatBar(cooldown_time / init_cooldown_time);
            }
        }
    }

    private void Move()
    {
        Vector3 value = new Vector3(moveInput.x, moveInput.y, 0);
        transform.position += value * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsSheildActive)
        {
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if(gameManager.GetGameState() != GameManager.GameState.Playing)
                return;
            //Destroy(this.gameObject);
            livesMaanager.RemoveLife();
        }
    }
}

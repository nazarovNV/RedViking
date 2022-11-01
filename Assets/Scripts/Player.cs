using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    public Rigidbody2D PlayerRigidbody2D;
    [SerializeField] private float speed;
    public List<SpriteRenderer> SpriteRenders;
    [SerializeField] Animator animator;
    public GroundDetection groundDetection;
    public bool isJumping;
    public bool isFalling;
    public float force;
    private UICharacterController controller;
    public bool attackCooldawn;
    public bool BlockMovement;
    public PlayerInventory playerInventory;
    public AudioSource SwingSound;
    public AudioSource GainingCoinSound;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }



    void Start()
    {
        BlockMovement = false;
    }

    public void InitUIController(UICharacterController uiController)
    {
        controller = uiController;
        //controller.Jump.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        {
            if (!BlockMovement)
            {
                Move();

                if (controller.Jump.IsPressed)
                {
                    Jump();
                }
                if (controller.Fire.IsPressed && attackCooldawn == false)
                {
                    Attack();
                }


#if UNITY_EDITOR
                if (Input.GetKeyDown(KeyCode.Space))
                    Jump();
#endif
                animator.SetFloat("Speed", Mathf.Abs(direction.x));
            }
        }
    }
    private void Move()
    {
        if (isFalling == true && groundDetection.isGrounded == true)
        {
            SetBoolisFallingToFalse();
        }
        if (isFalling == false && groundDetection.isGrounded == false)
        {
            SetBoolisFallingToTrue();
        }
        /*
        if (isJumping == true && groundDetection.isGrounded == true)
        {
            isJumping = false;
            animator.SetTrigger("Grounding");
        }
        if (!groundDetection.isGrounded && !isJumping)
        {
            animator.SetBool("StartFall", true);
        }
        if (groundDetection.isGrounded)
            animator.SetBool("StartFall", false);
        isJumping = isJumping && !groundDetection.isGrounded;
        */
        direction = Vector3.zero;//(0;0)

#if UNITY_EDITOR
        if(!BlockMovement)
        {
            if (Input.GetKey(KeyCode.A))
                direction = Vector3.left;
            if (Input.GetKey(KeyCode.D))
                direction = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.OnClickPause();
        }
#endif
            if (controller.Left.IsPressed)
            {
                direction = Vector3.left;//(-1;0)
            }
            if (controller.Right.IsPressed)
            {
                direction = Vector3.right;//(1;0)
            }
            direction *= speed;
            direction.y = PlayerRigidbody2D.velocity.y;
            PlayerRigidbody2D.velocity = direction;

        if (direction.x > 0)
            foreach(SpriteRenderer i in SpriteRenders)
           i.flipX = false;
        if (direction.x < 0)
            foreach (SpriteRenderer i in SpriteRenders)
                i.flipX = true;

    }
    private void Jump()
    {
        if (groundDetection.isGrounded)
        {
            animator.SetBool("StartJump",true);
            Invoke("IsJumpingSettingTrue", 0.1F);
            PlayerRigidbody2D.AddForce(Vector2.up * force , ForceMode2D.Force);

        }
    }

    private void StartSwingsound()
    {
        SwingSound.Play();
    }

    public void StartGainingCoinsound()
    {
        GainingCoinSound.Play();
    }



    private void Attack()
    {
        attackCooldawn = true;
        animator.SetTrigger("Attack");
        StartCoroutine(TestCoroutine());
    }

    private void SetBoolJumpToFalse()
    {
        animator.SetBool("StartJump", false);
    }

    private void SetBoolisFallingToTrue()
    {
        animator.SetBool("isFalling", true);
        isFalling = true;
    }
    private void SetBoolisFallingToFalse()
    {
        animator.SetBool("isFalling", false);
        isFalling = false;
    }
    private void IsJumpingSettingTrue()
    {
        isJumping = true;
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1f);
        attackCooldawn = false;
    }
}

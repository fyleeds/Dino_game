using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private BoxCollider2D boxCollider;

    private bool isGrounded = false;
    private bool isJumping  = false;
    private bool canDoubleJump = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance,groundLayer);

        #region JUMPING..

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            canDoubleJump = true;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;

            }
            else
            {
                isJumping = false;
            }
        }
        if (canDoubleJump && isGrounded == false && Input.GetButtonDown("Jump")){
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            canDoubleJump = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
                isJumping = false;
                jumpTimer = 0f;
        }

        #endregion

        #region CROUCHING
        if (isGrounded && Input.GetButton("Crouch"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            boxCollider.size = GFX.localScale;
            if (isJumping)
            {
                GFX.localScale = new Vector3(GFX.localScale.x,1f, GFX.localScale.z);
                boxCollider.size = GFX.localScale;
            }
        }
            
        if (Input.GetButtonUp("Crouch"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f , GFX.localScale.z);
            boxCollider.size = GFX.localScale;
        }
        #endregion
    }


}

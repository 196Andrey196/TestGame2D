using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _animator.SetBool("OnGround", IsGrounded());
    }
    public void DoMove(Vector2 forceDirection)
    {
        if (IsGrounded())
        {
            if (forceDirection.x > 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            transform.Translate(forceDirection.x * _moveSpeed * Time.deltaTime, 0f, 0f, Space.World);
        }
    }
    public void DoJump(Vector2 forceDirection)
    {
        if (IsGrounded())
        {
            // Анимация прыжка
            _animator.CrossFade("Jump", 0.1f);
            float horizontal = forceDirection.x * _moveSpeed;
            _rb2D.linearVelocity = new Vector2(horizontal, _jumpForce);
        }
    }
    public void MoveAnimation(bool move)
    {
        if (IsGrounded()) _animator.SetBool("run", move);
        else _animator.SetBool("run", false);
    }

    private bool IsGrounded()
    {

        RaycastHit2D hitDown = Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, _groundCheckDistance, _groundLayer);


        RaycastHit2D hitLeft = Physics2D.Raycast(_groundCheckPoint.position, Vector2.left, _groundCheckDistance, _groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(_groundCheckPoint.position, Vector2.right, _groundCheckDistance, _groundLayer);


        return hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheckPoint != null)
        {
            Gizmos.color = Color.green;


            Gizmos.DrawLine(_groundCheckPoint.position, _groundCheckPoint.position + Vector3.down * _groundCheckDistance);

            float horizontalDistance = 0.3f;
            float verticalOffset = 0.1f;


            Vector3 startPos = _groundCheckPoint.position + Vector3.down * verticalOffset;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPos, startPos + Vector3.left * horizontalDistance);
            Gizmos.DrawLine(startPos, startPos + Vector3.right * horizontalDistance);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnvirormentItem")
            collision.GetComponent<IPickUpItem>().PickUp();
    }
}

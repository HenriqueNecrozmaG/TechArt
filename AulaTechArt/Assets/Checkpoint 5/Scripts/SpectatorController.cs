using UnityEngine;

public class SpectatorController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private Transform freeCamera;

    Vector2 move;
    Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        print("Press Arrows or WASD to move in the four directions");
        print("Press Space to move up");
        print("Press Control to move Down");
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        Vector3 camForward = freeCamera.forward;
        Vector3 camRight = freeCamera.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * move.y + camRight * move.x;

        rb.linearVelocity = moveDirection * speed;

        if (Input.GetButton("Jump"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        transform.rotation = freeCamera.rotation;
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isKicked;
    private bool canKick;
    private float restTimeAccumulator;
    [SerializeField] private AimLine2D aimLine;
    [SerializeField] private float forceMultiplier = 100f;
    [SerializeField] private float restVelocity = 0.1f;
    [SerializeField] private float restTime = 0.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {        
        aimLine.Hide();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isKicked = true;
        }
    }

    void FixedUpdate()
    {
        RestTimeFixedUpdate();
        CanKickFixedUpdate();
        MovementFixedUpdate();
    }

    private void RestTimeFixedUpdate()
    {
        if (rb.velocity.magnitude > restVelocity)
        {
            restTimeAccumulator = 0f;
        }
        else if (restTimeAccumulator < restTime)
        {
            restTimeAccumulator += Time.fixedDeltaTime;
        }
    }

    private void CanKickFixedUpdate()
    {
        if (canKick && restTimeAccumulator == 0f)
        {
            canKick = false;
            aimLine.Hide();
        }
        else if (!canKick && restTimeAccumulator >= restTime)
        {
            canKick = true;
            aimLine.Show();
        }
    }

    private void MovementFixedUpdate()
    {
        if (canKick && isKicked)
        {
            rb.AddForce(forceMultiplier * aimLine.Aim);
        }

        isKicked = false;
    }
}

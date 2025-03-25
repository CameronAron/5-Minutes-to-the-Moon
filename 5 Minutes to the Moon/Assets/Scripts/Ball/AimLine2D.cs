using UnityEngine;

public class AimLine2D : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 aim;
    [SerializeField] private Transform origin;
    [SerializeField] private float magnitudeLimit = 6f;
    [SerializeField] private float lineScale = 0.5f;

    public Vector2 Aim
    {
        get { return aim; }
    }

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector2 originPosition = origin.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim = Vector2.ClampMagnitude(mousePosition - originPosition, magnitudeLimit);
        lineRenderer.SetPosition(0, originPosition);
        lineRenderer.SetPosition(1, originPosition + lineScale * aim);
    }

    public void Show()
    {
        lineRenderer.enabled = true;
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}

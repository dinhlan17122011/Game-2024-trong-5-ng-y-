using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Vector3 target;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("pointA or pointB is not assigned in the Inspector.");
            enabled = false;
            return;
        }
        target = pointA.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if ((transform.position - target).sqrMagnitude < 0.01f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player đã gắn vào nền tảng");
            if (collision.transform != null)
            {
                collision.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player đã rời khỏi nền tảng");
            if (collision.transform != null)
            {
                collision.transform.SetParent(null);
            }
        }
    }
}

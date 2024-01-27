using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(moveX, moveY, 0f);
    }
}

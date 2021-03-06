using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   Camera playerCamera;
   Vector3 mousePosition;
   float lerpTime = 0.01f;
   [SerializeField] Vector3 offset = new Vector3(0, 0, -30);

  private void Start()
   {
      playerCamera = Camera.main;
   }

   void FixedUpdate()
   {
      playerCamera.transform.position = transform.position + offset;
      mousePosition = Input.mousePosition;
      mousePosition = playerCamera.ScreenToWorldPoint(mousePosition);
      transform.position = Vector2.Lerp(transform.position, mousePosition, lerpTime);
      PlayerConstraints();
   }

   void PlayerConstraints()
   {
      var xPos = transform.position.x;
      var yPos = transform.position.y;
     xPos = Mathf.Clamp(xPos, -50, 50);
     yPos = Mathf.Clamp(yPos, -50, 50);
     transform.position = new Vector3(xPos, yPos,1);
   }
}

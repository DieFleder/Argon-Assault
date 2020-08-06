using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("In [m/s]")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In [m/s]")] [SerializeField] float xMaxOffset = 5f;
    [Tooltip("In [m/s]")] [SerializeField] float ySpeed = 10f;
    [Tooltip("In [m/s]")] [SerializeField] float yMaxOffset = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        xOffset = Mathf.Clamp(xOffset + transform.localPosition.x, -xMaxOffset, xMaxOffset);

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;
        yOffset = Mathf.Clamp(yOffset + transform.localPosition.y, -yMaxOffset, yMaxOffset);

        transform.localPosition = new Vector3(xOffset, yOffset, transform.localPosition.z);
    }
}

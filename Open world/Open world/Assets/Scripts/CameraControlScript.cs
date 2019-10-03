using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{

    [SerializeField]
    public float Sensitivity = 1f;
    [SerializeField]
    public float Smoothening = 2.0f;
    // the chacter is the capsule
    public GameObject Character;
    // get the incremental value of mouse moving
    private Vector2 _mouseLook;
    // smooth the mouse moving
    private Vector2 _smoothV;

    // Use this for initialization
    void Start()
    {
        Character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(Sensitivity * Smoothening, Sensitivity * Smoothening));

        // the interpolated float result between the two float values
        _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDelta.x, 1f / Smoothening);
        _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDelta.y, 1f / Smoothening);

        // incrementally add to the camera look
        _mouseLook += _smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        Character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, Character.transform.up);
    }
}
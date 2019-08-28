using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float camSpeed;

    public int screenW;
    public int screenH;
    public int boundary = 50;
    // Start is called before the first frame update
    void Start()
    {
        screenW = Screen.width;
        screenH = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y < 0 && cam.orthographicSize < 8)
        {
            cam.orthographicSize += 0.5f;
        }
        else if(Input.mouseScrollDelta.y > 0 && cam.orthographicSize > 5)
        {
            cam.orthographicSize -= 0.5f;
        }
        
        if(Input.mousePosition.x >= screenW - boundary)
        {
            transform.Translate(camSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.x <= 0 + boundary)
        {
            transform.Translate(-camSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.y >= screenH - boundary)
        {
            transform.Translate(0, camSpeed * Time.deltaTime, 0);
        }
        if (Input.mousePosition.y <= 0 + boundary)
        {
            transform.Translate(0, -camSpeed * Time.deltaTime, 0);
        }
    }

    IEnumerator MoveCamera(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}

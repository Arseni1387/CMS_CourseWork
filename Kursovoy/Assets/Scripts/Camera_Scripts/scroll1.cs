using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scroll1 : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 10f;
    [SerializeField]	
	int maxdistance = 15;
	int mindistance =1;

	[SerializeField]
	Transform targetPos;

	int sensivity = 3;
	public Vector3 offset;
	public float sensitivity = 1; // чувствительность мышки
	public float limit = 10; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 5; // макс. увеличение
	public float zoomMin = 1; // мин. увеличение
	private float X, Y;


    void FixedUpdate()
    {
       	

        float x = Input.GetAxis("Horizontal"); // кнопки A D
        float y = Input.GetAxis("Vertical"); // кнопки W S

        if (x != 0 || y != 0)
        {
            Vector3 newpos = transform.position + (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.up * y) / sensivity;
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }
       
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(targetPos.position, Vector3.up, Input.GetAxis("Mouse X") * sensivity);
            //transform.Rotate(Vector3.left, Mathf.Clamp(Input.GetAxis("Mouse Y") * sensivity, -limit, limit)); //не работает ограничение
           
            Y += Input.GetAxis("Mouse Y") * sensitivity * 1.2f; // Новая позиция Y
            Y = Mathf.Clamp(Y, -50, 15); // Ограничение, чтобы не вылететь за пределы
            transform.localEulerAngles = new Vector3(-Y, transform.localEulerAngles.y, 0); // Установка поворота 
           
        }
    }

 /*   void Start()
	{
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
		transform.position = targetPos.position + offset;
	}*/

	
    bool ControlDistance(float distance)
    {
        if (distance > mindistance && distance < maxdistance) return true;
        return false;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickСoordinates : MonoBehaviour
{
    private Camera mainCamera; 
    private Vector3 ClickPosition = new (0,0,0);
    public Action<Vector3> MovingUnits;
    public Action<GameObject> AttackUnits;
    private float searchRadius = 5f;
    public bool SpecifyingPointUnits;
    private void Start()
    {
        mainCamera = Camera.main;
      
    }
    
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && SpecifyingPointUnits)
        {
            if (Physics.Raycast(ray, out hit))
            {
                ClickPosition = hit.point;
                Debug.Log("Координаты клика: " + ClickPosition);
            }
        }
       
        Collider[] colliders = Physics.OverlapSphere(ClickPosition, searchRadius);
        foreach (var collider in colliders)
        {
            IHealth Health = collider.GetComponent<IHealth>();
            if (Health != null)
            {
                            collider.gameObject.AddComponent<Outline>();

            }
        }
    
    }




}

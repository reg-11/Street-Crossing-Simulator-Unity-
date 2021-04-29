using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PathCreation; //For the Path Creator Asset

public class CarPathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5f;
    float distanceTravelled;
    public string lightColor;
    public bool stopCar = false;

    void Start()
    {
        if (pathCreator != null)
        {
            pathCreator.pathUpdated += OnPathChanged;
        }
        lightColor = LightIndicator.lightColor;
    }

    void Update()
    {
        lightColor = LightIndicator.lightColor;
        if (pathCreator != null && stopCar != true)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);            
        }
    }

    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (lightColor == "red")
        {
            stopCar = !stopCar;
            speed = 0f;
        }

        //Debug.Log("Enter");
    }

    void OnTriggerStay(Collider other)
    {
        if (lightColor == "green" && speed == 0f)
        {
            stopCar = !stopCar;
            speed = 5f;
        }
    }
}

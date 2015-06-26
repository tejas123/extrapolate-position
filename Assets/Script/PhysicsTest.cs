using UnityEngine;

public class PhysicsTest : MonoBehaviour {

    public Transform cubeUnderPhysics;
    public Transform extrapolatedCube;
    public Vector3 initialVelocity;

    private Vector3 intialPosition;
    bool isVelocityGiven;

    void Start() 
    {
        isVelocityGiven = false;
        intialPosition = cubeUnderPhysics.position;
    }

    void Update()
    {
        GiveVelocity();

        ExtrapolatingCube();
    }

    private void GiveVelocity() 
    {
        print(cubeUnderPhysics.GetComponent<Rigidbody>().velocity);
        if (!isVelocityGiven)
        {
            cubeUnderPhysics.GetComponent<Rigidbody>().velocity = initialVelocity;
            isVelocityGiven = true;
        }
    }

    private void ExtrapolatingCube(){
        Vector3 position;
        position.x = intialPosition.x + initialVelocity.x * Time.time;
        position.y = intialPosition.y + initialVelocity.y * Time.time - 0.5f * 9.81f * Time.time * Time.time;
        position.z = intialPosition.z + initialVelocity.z * Time.time;
        extrapolatedCube.position = position;
    }

}

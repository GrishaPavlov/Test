using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    public Camera cam;

    public GameObject Arrow;

    public NavMeshAgent agent;

    public LineRenderer lr;

    Queue<Vector3> Destinations;


    Vector3 CurrentDestination;

    private void Start()
    {
        CurrentDestination = transform.position;
        Destinations = new Queue<Vector3>();
    }

    void Update()
    {
        DrawLine();

        agent.SetDestination(CurrentDestination);

        if (Vector3.Distance(transform.position, CurrentDestination) < .6f && Destinations.Count > 0)
        {
            CurrentDestination = Destinations.Dequeue();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Destinations.Enqueue(hit.point + new Vector3(0, .4f, 0));
            }
        }
    }

    void DrawLine()
    {
        lr.positionCount = Destinations.Count + 2;
        List<Vector3> positions = Destinations.ToList();
        positions.Insert(0, transform.position);
        positions.Insert(1, CurrentDestination);
        lr.SetPositions(positions.ToArray());
    }
}

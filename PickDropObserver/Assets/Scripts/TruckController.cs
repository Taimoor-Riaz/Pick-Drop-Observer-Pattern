using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TruckController : MonoBehaviour,IGameStatus
{
    public static TruckController Instance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform destinationPoint;
    [SerializeField] private UIManager manager;
    public Transform truckDebrisPos;
    public Transform dropPosition;
    public int maxQuantity;
    private bool startTruck ;
    float distance;
    float yAxis;
    public Vector3 startingPosition;
    private void Awake()
    {
        startingPosition = this.transform.position;
        if(Instance == null)
        { Instance = this; }
        else
        {
            Destroy(Instance );
        }
    }

    private void Start()
    {
        manager = UIManager.Instance;
        manager.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTruck)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            distance = Vector3.Distance(transform.position, destinationPoint.position);


            if (distance <= 1)
            {
        
                startTruck = false;
                DestinationReached();
            }
        }
    }


    public void Notify(CurrentState currentState)
    {
        if(currentState == CurrentState.start)
        {
            startTruck = true;
         
        }
        
    }

    public void DestinationReached()
    {
     
        for(int i=0;i< maxQuantity; i++)
        {
            truckDebrisPos.GetChild(0).position = new Vector3(dropPosition.position.x,
              dropPosition.position.y + yAxis,
                dropPosition.position.z);
            truckDebrisPos.GetChild(0).parent = dropPosition;
            yAxis += 0.5f;
        }
        yAxis =0;
        manager.UpdateCollectecDebris(dropPosition.childCount);

        if(manager.debrisObject.childCount<=0)
        {
            manager.GameOverCalled();
        }
        else
        {
            this.transform.position = startingPosition;
            manager.RestartCalled();
        }
    }
    

}

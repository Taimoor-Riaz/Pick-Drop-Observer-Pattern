using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DebrisManager : MonoBehaviour,IGameStatus
{
    private UIManager uIManager;
    public int totalDebris;
    float yAxis;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = UIManager.Instance;
        uIManager.Add(this);
        totalDebris = this.transform.childCount;
        uIManager.UpdateValueDebris(this.transform.childCount);
    }


    public void Notify(CurrentState currentState)
    {
      if(currentState == CurrentState.pickdebris)
        {
            PickUpDebris();
        }
    }

    public void PickUpDebris()
    {
     
        for(int i = 0; i < TruckController.Instance.maxQuantity; i++)
        {
            this.transform.GetChild(0).position = new Vector3(TruckController.Instance.truckDebrisPos.position.x,
                TruckController.Instance.truckDebrisPos.position.y + yAxis,
                TruckController.Instance.truckDebrisPos.position.z);
            this.transform.GetChild(0).parent = TruckController.Instance.truckDebrisPos;
            yAxis += 0.5f;
        }
        yAxis = 0;
        uIManager.GameStartedCalled();
        uIManager.UpdateValueDebris(this.transform.childCount);
    }
}

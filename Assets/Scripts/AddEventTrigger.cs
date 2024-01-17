using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddEventTrigger : MonoBehaviour
{
    private int counter ;
    private void doStuff(BaseEventData eventData)
    {
        counter++;
        Debug.Log(counter);
    }
    // Start is called before the first frame update
    void Start()
    {
        // counter = 0;
        // AddEventTrigger evTrig = gameObject.AddComponent<AddEventTrigger>();
        // AddEventTrigger.Entry asteroid = new EventTrigger.Entry();
        // {
        //     eventID = EventTriggerType.PointerClick;
        // };
        // asteroid.callback.AddListener(doStuff());
        // evTrig.triggers.Add(asteroid);


    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

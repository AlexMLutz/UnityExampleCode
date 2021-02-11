using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StaticInterface : UserInterface
{
    //This intitializes the slots and close button for the StaticInterface menus
    public GameObject[] slots;
    public Button closeButton;

    //Here is the createSlots() function which creates each of the inventory slots on the StaticInterface inventory objects
    public override void CreateSlots()
    {
        //Check for a close button, then add the TaskOnClick to the closeButton
        if (closeButton)
        {
            Button exitbtn = this.closeButton.GetComponent<Button>();
            exitbtn.onClick.AddListener(TaskOnClick);
        }

        //create a dictionary representing the slots on the interface that holds the GameObject and the InventorySlot
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        //for each slot on the interface give it an EventTrigger for the pointer entering, exiting, dragging items out or in and dragging over the slot.
        //then the slots have their display updated with the current object they are holding and the slotsOnInterface dictionary is updated
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = slots[i];


            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            inventory.GetSlots[i].slotDisplay = obj;
            slotsOnInterface.Add(obj, inventory.GetSlots[i]);

        }
    }
    
    //When the close button is clicked, it will destory the object until it is reopened and reinstantiated 
    void TaskOnClick()
    {
        //this.gameObject.SetActive(false);
        Destroy(gameObject);
        //slotsOnInterface.Clear();
    }
}

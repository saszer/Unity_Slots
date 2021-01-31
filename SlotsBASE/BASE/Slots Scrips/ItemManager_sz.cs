using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Place DragHandler.cs on Items to be Dragged and Slot.cs on Slots
/// //On EquipmentSlots(final Slots), Enable Bool equipslot to differentiate from other placeholder slots
/// //Set tag of item object same as equip for its respective right slot.
/// </summary

namespace Slots
{
    public class ItemManager_sz : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
    {
        public bool isDrop3DGame;

        /*Mainly Used On Slots*/
        public bool isEquipSlot = false;
        //Called On Slots Item Manager when its filled or emptied
        public UnityEvent OnSlotEmpty;
        public UnityEvent OnSlotFill; 

        /*Mainly Used On Draggable Objects/Items*/
        //Called on Icons Item Manager.
        public UnityEvent OnPlacedOnRightEquipSlot;
        public UnityEvent OnPlacedWrongSlot;
        [Tooltip("OnDragging will be called continuosly while dragging, use cautiously")]
        public UnityEvent OnDragging;
        public UnityEvent OnDraggingEnd;

        //Can be common
        public UnityEvent OnHoverEnter;
        public UnityEvent OnHoverExit;



        //Checks if the item is placed in the right slot according to its tag //called on item
        public void PlacedInCheck()
        {
            ItemManager_sz itm = transform.parent.GetComponentInParent<ItemManager_sz>();

            if (itm)
            {
                if (transform.parent.GetComponentInParent<ItemManager_sz>().isEquipSlot == true
                    && transform.parent.GetComponentInParent<Transform>().tag == this.gameObject.tag)
                    {
                        Debug.Log("Place In Right Slot");
                        if (OnPlacedOnRightEquipSlot != null)
                        {
                            OnPlacedOnRightEquipSlot.Invoke();
                        }
                    }
                else
                {
                    Debug.Log("Place In Wrong Slot");
                    OnPlacedWrongSlot.Invoke();
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (OnHoverEnter != null)
            {
                OnHoverEnter.Invoke();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (OnDragging != null)
            {
                OnDragging.Invoke();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (OnDraggingEnd != null)
            {
                OnDraggingEnd.Invoke();
            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (OnHoverExit != null)
            {
                OnHoverExit.Invoke();
            }
        }

        public void SlotEmpty()
        {
            if (OnHoverExit != null)
            {
                OnSlotEmpty.Invoke();
            }
        }

        public void SlotFill()
        {
            if (OnHoverExit != null)
            {
                OnSlotFill.Invoke();
            }
        }

    }
}

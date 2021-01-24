using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Place On Slot
/// </summary>

namespace Slots
{
    [RequireComponent(typeof(ItemManager_sz))]
    public class Slot : MonoBehaviour, IDropHandler
    {
        public ItemManager_sz itemManager;
        Vector3 oneoneone = new Vector3(1, 1, 1);

        public GameObject item
        {
            get
            {
                if (transform.childCount > 0)
                {
                    return transform.GetChild(0).gameObject;
                }

                return null;
            }
        }

        void Awake()
        {
            itemManager = GetComponent<ItemManager_sz>();
        }

        #region IdropHandler implementation 
        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                DragHandler.item.transform.SetParent(transform);
                //SetLocal Transform to oneoneone to fit in parent.
                item.transform.localScale = oneoneone;

                //relevant when dragging between wordspace and screenspace
                item.transform.localPosition = oneoneone;
                item.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (item) //swap item
            {
                Transform temp = transform; //this slot
                GameObject olditem = item;
                GameObject olditemSlot = DragHandler.startParent.gameObject;

                olditem.transform.SetParent(DragHandler.startParent); //item in slot to parent of currently dragging item
                DragHandler.item.transform.SetParent(temp); //item being dragged gets this slot as parent

                //SetLocal Transform to oneoneone to fit in parent.
                olditem.transform.localScale = oneoneone;
                DragHandler.item.transform.localScale = oneoneone;

                //relevant when dragging between wordspace and screenspace
                olditem.transform.localPosition = oneoneone;
                DragHandler.item.transform.localPosition = oneoneone;

                olditem.transform.localRotation = Quaternion.Euler(0, 0, 0);
                DragHandler.item.transform.localRotation = Quaternion.Euler(0, 0, 0);
                olditemSlot.GetComponentInParent<Slot>().CheckSlotState(); //checkslot state of old slot
            }

            DragHandler.item.GetComponent<ItemManager_sz>().PlacedInCheck();
            CheckSlotState(); //checkslot state of this slot
        }
        #endregion

        public void CheckSlotState()
        {
            if(!item)
            {
                itemManager.SlotEmpty();
            }

            else if(item)
            {
                itemManager.SlotFill();
            }
        }
    }
}
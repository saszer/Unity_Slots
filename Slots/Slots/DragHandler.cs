using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// Place on Dragable Item
/// </summary>



namespace Slots
{
    [RequireComponent(typeof(ItemManager_sz))]
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject item; //itemBeingDragged
        public Transform TempCanvasprefab;
        Transform TempCanvas;
        Vector3 startPosition;
        public static Transform startParent;
        Vector3 oneoneone = new Vector3(1, 1, 1);
        ItemManager_sz itemManager;

        void Awake()
        {
            itemManager = GetComponent<ItemManager_sz>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            item = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            TempCanvas = Instantiate(TempCanvasprefab, new Vector3(0,0,0), Quaternion.identity);
            transform.SetParent(TempCanvas);
            DragHandler.item.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            item = null;

            if (transform.parent == startParent || transform.parent == TempCanvas)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
                transform.localScale = oneoneone;
                itemManager.PlacedInCheck();
            }
            Destroy(TempCanvas.gameObject);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class swipeController : MonoBehaviour
// {
//     [SerializeField] int maxPage = 3;
//     int currentPage;

//     Vector3 targetPos;

//     [SerializeField] Vector3 pageStep;
//     [SerializeField] RectTransform levelPageRect;

//     [SerializeField] float moveSpeed = 10f;
//     bool isMoving = false;

//     private void Awake()
//     {
//         currentPage = 1;
//         targetPos = levelPageRect.localPosition;
//     }
// // 
//     private void Update()
//     {
//         if (isMoving)
//         {
//             levelPageRect.localPosition = Vector3.Lerp(levelPageRect.localPosition, targetPos, Time.deltaTime * moveSpeed);

//             if (Vector3.Distance(levelPageRect.localPosition, targetPos) < 0.01f)
//             {
//                 levelPageRect.localPosition = targetPos;
//                 isMoving = false;
//             }
//         }
//     }

//     public void Next()
//     {
//         if (currentPage < maxPage)
//         {
//             currentPage++;
//             targetPos -= pageStep; // Move left
//             MovePage();
//         }
//     }

//     public void Previous()
//     {
//         if (currentPage > 1)
//         {
//             currentPage--;
//             targetPos += pageStep; // Move right
//             MovePage();
//         }
//     }

//     void MovePage()
//     {
//         isMoving = true;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class swipeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] int maxPage = 3;
    int currentPage;

    Vector3 targetPos;

    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPageRect;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float dragThreshold = 100f; // Drag distance in pixels

    bool isMoving = false;
    Vector2 dragStartPos;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPageRect.localPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            levelPageRect.localPosition = Vector3.Lerp(levelPageRect.localPosition, targetPos, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(levelPageRect.localPosition, targetPos) < 0.01f)
            {
                levelPageRect.localPosition = targetPos;
                isMoving = false;
            }
        }
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos -= pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos += pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        isMoving = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragStartPos = eventData.pressPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 dragEndPos = eventData.position;
        float deltaX = dragEndPos.x - dragStartPos.x;

        if (Mathf.Abs(deltaX) >= dragThreshold)
        {
            if (deltaX < 0)
                Next();
            else
                Previous();
        }
        else
        {
            // Not enough drag — optional: snap back
            MovePage();
        }
    }
}

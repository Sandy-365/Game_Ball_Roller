// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class swipeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
// {
//     [SerializeField] int maxPage = 3;
//     int currentPage;

//     Vector3 targetPos;

//     [SerializeField] Vector3 pageStep;
//     [SerializeField] RectTransform levelPageRect;

//     [SerializeField] float moveSpeed = 10f;
//     [SerializeField] float dragThreshold = 100f; // Drag distance in pixels

//     bool isMoving = false;
//     Vector2 dragStartPos;

//     private void Awake()
//     {
//         currentPage = 1;
//         targetPos = levelPageRect.localPosition;
//     }

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
//             targetPos -= pageStep;
//             MovePage();
//         }
//     }

//     public void Previous()
//     {
//         if (currentPage > 1)
//         {
//             currentPage--;
//             targetPos += pageStep;
//             MovePage();
//         }
//     }

//     void MovePage()
//     {
//         isMoving = true;
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         dragStartPos = eventData.pressPosition;
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         Vector2 dragEndPos = eventData.position;
//         float deltaX = dragEndPos.x - dragStartPos.x;

//         if (Mathf.Abs(deltaX) >= dragThreshold)
//         {
//             if (deltaX < 0)
//                 Next();
//             else
//                 Previous();
//         }
//         else
//         {
//             // Not enough drag — optional: snap back
//             MovePage();
//         }
//     }
// }





using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class swipeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] int maxPage = 3;
    int currentPage = 1;

    [SerializeField] RectTransform levelPageRect;
    [SerializeField] RectTransform scrollViewRect;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float dragThreshold = 100f;

    bool isMoving = false;
    Vector2 dragStartPos;
    Vector2 targetAnchoredPos;
    float pageWidth;
    float pageHeight;

    void Start()
    {
        if (scrollViewRect == null)
            scrollViewRect = GetComponent<RectTransform>();

        AdjustPagesAndGrid();
        UpdatePageMetrics();

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        int targetPage = Mathf.CeilToInt(unlockedLevel / 10f);
        targetPage = Mathf.Clamp(targetPage, 1, maxPage);
        currentPage = targetPage;

        SnapToPageInstant(currentPage);
    }

    void Update()
    {
        AdjustPagesAndGrid();
        UpdatePageMetrics();

        if (isMoving)
        {
            levelPageRect.anchoredPosition = Vector2.Lerp(levelPageRect.anchoredPosition, targetAnchoredPos, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(levelPageRect.anchoredPosition, targetAnchoredPos) < 0.01f)
            {
                levelPageRect.anchoredPosition = targetAnchoredPos;
                isMoving = false;
            }
        }
    }

    void AdjustPagesAndGrid()
    {
        if (scrollViewRect == null || levelPageRect == null) return;

        pageWidth = scrollViewRect.rect.width;
        pageHeight = scrollViewRect.rect.height;

        for (int i = 0; i < levelPageRect.childCount; i++)
        {
            RectTransform page = levelPageRect.GetChild(i).GetComponent<RectTransform>();
            if (page == null) continue;

            // keep anchor top-left
            page.anchorMin = new Vector2(0, 1);
            page.anchorMax = new Vector2(0, 1);
            page.pivot = new Vector2(0, 1);

            page.sizeDelta = new Vector2(pageWidth, pageHeight);
            page.anchoredPosition = new Vector2(i * pageWidth, 0);

            // adjust grid icons
            GridLayoutGroup grid = page.GetComponent<GridLayoutGroup>();
            if (grid != null)
            {
                float spacingRatio = 0.05f;
                int columns = 5;
                float spacing = pageWidth * spacingRatio;
                float cellWidth = (pageWidth - spacing * (columns + 1)) / columns;
                grid.cellSize = new Vector2(cellWidth, cellWidth);
                grid.spacing = new Vector2(spacing, spacing);
                grid.childAlignment = TextAnchor.MiddleCenter;
            }
        }

        levelPageRect.sizeDelta = new Vector2(pageWidth * levelPageRect.childCount, pageHeight);
        SnapToPageInstant(currentPage); // keep correct page centered on resize
    }

    void UpdatePageMetrics()
    {
        if (scrollViewRect != null)
            pageWidth = scrollViewRect.rect.width;
        else
            pageWidth = Screen.width;
    }

    void SnapToPageInstant(int pageIndex)
    {
        float x = Mathf.Round((pageIndex - 1) * pageWidth);
        levelPageRect.anchoredPosition = new Vector2(-x, 0f);
        targetAnchoredPos = levelPageRect.anchoredPosition;
        isMoving = false;
    }

    void SnapToPageSmooth(int pageIndex)
    {
        float x = Mathf.Round((pageIndex - 1) * pageWidth);
        targetAnchoredPos = new Vector2(-x, 0f);
        isMoving = true;
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            UpdatePageMetrics();
            SnapToPageSmooth(currentPage);
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            UpdatePageMetrics();
            SnapToPageSmooth(currentPage);
        }
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
            SnapToPageSmooth(currentPage);
        }
    }
}

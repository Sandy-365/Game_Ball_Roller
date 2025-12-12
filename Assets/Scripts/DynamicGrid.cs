using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGrid : MonoBehaviour
{
    // --- Public Configuration ---

    [Header("Layout Settings")]
    [Tooltip("The fixed number of columns for the grid.")]
    public int columns = 5;

    [Header("Spacing (Gap between Cells)")]
    [Tooltip("The horizontal gap between cells, as a ratio of the total container width (e.g., 0.05 for 5%).")]
    public float horizontalSpacingRatio = 0.05f;

    [Tooltip("The vertical gap between cells, as a ratio of the total container height (e.g., 0.05 for 5%).")]
    public float verticalSpacingRatio = 0f; // Defaulted to 0 to match previous behavior

    [Header("Padding (Margins around the Grid)")]
    [Tooltip("The left and right margin, as a ratio of the total container width.")]
    public float horizontalPaddingRatio = 0f; // Defaulted to 0

    [Tooltip("The top and bottom margin, as a ratio of the total container height.")]
    public float verticalPaddingRatio = 0f; // Defaulted to 0

    [Tooltip("Multiplier to increase or decrease the calculated cell size.")]
    public float iconSizeMultiplier = 1f;

    // --- Private Variables ---
    RectTransform rect;
    GridLayoutGroup grid;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        grid = GetComponent<GridLayoutGroup>();
        // Ensure initial calculation runs before the first frame
        AdjustGrid();
    }

    // Use LateUpdate to ensure the layout is adjusted after all other UI updates
    void LateUpdate()
    {
        AdjustGrid();
    }

    /// <summary>
    /// Calculates and applies dynamic cell size, spacing, and padding based on container ratios.
    /// </summary>
    void AdjustGrid()
    {
        if (rect == null || grid == null) return;

        // 1. Get total dimensions
        float totalWidth = rect.rect.width;
        float totalHeight = rect.rect.height;

        if (totalWidth <= 0 || totalHeight <= 0) return;

        // 2. Calculate Padding (Margins)
        float paddingX = totalWidth * horizontalPaddingRatio;
        float paddingY = totalHeight * verticalPaddingRatio;

        grid.padding.left = (int)paddingX;
        grid.padding.right = (int)paddingX;
        grid.padding.top = (int)paddingY;
        grid.padding.bottom = (int)paddingY;

        // 3. Calculate Spacing
        float horizontalSpacing = totalWidth * horizontalSpacingRatio;
        float verticalSpacing = totalHeight * verticalSpacingRatio;

        // 4. Calculate usable width (Total width minus left and right padding)
        float effectiveWidth = totalWidth - (paddingX * 2);

        // 5. Calculate Cell Width
        // Effective width = (Columns * Cell Width) + (Columns + 1 * Horizontal Spacing)
        // Rearranged: Cell Width = (Effective Width - Horizontal Spacing * (Columns + 1)) / Columns
        float cellWidth = (effectiveWidth - horizontalSpacing * (columns + 1)) / columns;

        // Apply size multiplier and ensure size is not negative
        float adjustedSize = Mathf.Max(0, cellWidth * iconSizeMultiplier);

        // 6. Apply calculated values
        grid.cellSize = new Vector2(adjustedSize, adjustedSize);
        grid.spacing = new Vector2(horizontalSpacing, verticalSpacing);
    }
}
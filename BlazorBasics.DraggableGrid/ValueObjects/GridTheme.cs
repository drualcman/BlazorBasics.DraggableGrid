namespace BlazorBasics.DraggableGrid.ValueObjects;

public partial class GridTheme
{
    // Main grid container
    public string GridBackground { get; set; } = "transparent";      // Grid background color
    public string GridBorderColor { get; set; } = "transparent";      // Grid outer border color

    // Regular item appearance
    public string ItemBorderColor { get; set; } = "transparent";      // Item border when not interacting
    public string ItemShadowColor { get; set; } = "none";             // Default shadow (none for clean look)
    public string ItemHoverShadowColor { get; set; } = "0 4px 12px rgba(0, 0, 0, 0.08)"; // Subtle hover shadow

    // Selected state
    public string SelectedColor { get; set; } = "#007bff";            // Primary color when item is selected
    public string SelectedGlowColor { get; set; } = "rgba(0, 123, 255, 0.25)"; // Soft glow around selected item

    // Dragging state
    public string DraggingColor { get; set; } = "#ff6b6b";            // Accent color while dragging
    public string DraggingGlowColor { get; set; } = "rgba(255, 107, 107, 0.3)"; // Glow while dragging

    // Drop zone highlighting
    public string DropAreaColor { get; set; } = "#00b894";            // Main drop zone accent color
    public string DropAreaBackground { get; set; } = "rgba(0, 184, 148, 0.15)"; // Subtle background when droppable
    public string DropAreaGlowColor { get; set; } = "rgba(0, 184, 148, 0.35)"; // Stronger glow for drop target
    public string DropAreaLightGlowColor { get; set; } = "rgba(0, 184, 148, 0.1)"; // Very light overlay glow

    /// <summary>
    /// Ultra–minimal theme with no borders, shadows or visual noise.
    /// Intended for the cleanest possible grid.
    /// </summary>
    public static GridTheme Clean => new GridTheme
    {
        GridBackground = "transparent",
        GridBorderColor = "transparent",

        // Items look flat with no borders or shadows
        ItemBorderColor = "transparent",
        ItemShadowColor = "none",
        ItemHoverShadowColor = "none",

        // Selection uses a subtle outline instead of a strong color
        SelectedColor = "transparent",
        SelectedGlowColor = "rgba(0, 0, 0, 0.08)", // Very soft halo for accessibility

        // Dragging state uses a light desaturated color instead of a bright accent
        DraggingColor = "rgba(0, 0, 0, 0.25)",
        DraggingGlowColor = "rgba(0, 0, 0, 0.15)",

        // Drop area uses extremely soft highlights
        DropAreaColor = "rgba(0, 0, 0, 0.3)",
        DropAreaBackground = "rgba(0, 0, 0, 0.05)",
        DropAreaGlowColor = "rgba(0, 0, 0, 0.15)",
        DropAreaLightGlowColor = "rgba(0, 0, 0, 0.03)"
    };

    public static GridTheme Default => new GridTheme();

}
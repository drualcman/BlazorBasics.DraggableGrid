namespace BlazorBasics.DraggableGrid.ValueObjects;

public class GridTheme
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


    /// <summary>
    /// Modern dark theme with slate colors and vibrant accents
    /// </summary>
    public static GridTheme Dark => new GridTheme
    {
        GridBackground = "#1a1f2e",
        GridBorderColor = "#2d3748",
        ItemBorderColor = "#4a5568",
        ItemShadowColor = "0 2px 8px rgba(0, 0, 0, 0.3)",
        ItemHoverShadowColor = "0 8px 25px rgba(0, 0, 0, 0.4)",
        SelectedColor = "#6c5ce7",               // Nice purple
        SelectedGlowColor = "rgba(108, 92, 231, 0.3)",
        DraggingColor = "#ff7675",
        DraggingGlowColor = "rgba(255, 118, 117, 0.4)",
        DropAreaColor = "#00cec9",
        DropAreaBackground = "rgba(0, 206, 201, 0.2)",
        DropAreaGlowColor = "rgba(0, 206, 201, 0.4)",
        DropAreaLightGlowColor = "rgba(0, 206, 201, 0.1)"
    };

    /// <summary>
    /// Soft pastel theme – gentle and friendly
    /// </summary>
    public static GridTheme Pastel => new GridTheme
    {
        GridBackground = "#fdfdfd",
        GridBorderColor = "#e9ecef",
        ItemBorderColor = "#ced4da",
        ItemShadowColor = "0 2px 10px rgba(173, 181, 189, 0.15)",
        ItemHoverShadowColor = "0 8px 20px rgba(173, 181, 189, 0.25)",
        SelectedColor = "#a29bfe",               // Soft violet
        SelectedGlowColor = "rgba(162, 155, 254, 0.3)",
        DraggingColor = "#fd79a8",
        DraggingGlowColor = "rgba(253, 121, 168, 0.3)",
        DropAreaColor = "#74b9ff",
        DropAreaBackground = "rgba(116, 185, 255, 0.15)",
        DropAreaGlowColor = "rgba(116, 185, 255, 0.35)",
        DropAreaLightGlowColor = "rgba(116, 185, 255, 0.08)"
    };

    /// <summary>
    /// High-contrast theme – great for accessibility or bold designs
    /// </summary>
    public static GridTheme HighContrast => new GridTheme
    {
        GridBackground = "#000000",
        GridBorderColor = "#ffffff",
        ItemBorderColor = "#ffffff",
        ItemShadowColor = "0 0 15px rgba(255, 255, 255, 0.2)",
        ItemHoverShadowColor = "0 0 20px rgba(255, 255, 255, 0.4)",
        SelectedColor = "#ffff00",               // Bright yellow
        SelectedGlowColor = "rgba(255, 255, 0, 0.5)",
        DraggingColor = "#ff00ff",               // Magenta
        DraggingGlowColor = "rgba(255, 0, 255, 0.5)",
        DropAreaColor = "#00ffff",               // Cyan
        DropAreaBackground = "rgba(0, 255, 255, 0.2)",
        DropAreaGlowColor = "rgba(0, 255, 255, 0.5)",
        DropAreaLightGlowColor = "rgba(0, 255, 255, 0.1)"
    };

    /// <summary>
    /// Material Design inspired – clean with subtle elevation
    /// </summary>
    public static GridTheme Material => new GridTheme
    {
        GridBackground = "#fafafa",
        GridBorderColor = "#e0e0e0",
        ItemBorderColor = "transparent",
        ItemShadowColor = "0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24)",
        ItemHoverShadowColor = "0 14px 28px rgba(0,0,0,0.15), 0 10px 10px rgba(0,0,0,0.12)",
        SelectedColor = "#6200ee",
        SelectedGlowColor = "rgba(98, 0, 238, 0.3)",
        DraggingColor = "#ff1744",
        DraggingGlowColor = "rgba(255, 23, 68, 0.3)",
        DropAreaColor = "#00bfa5",
        DropAreaBackground = "rgba(0, 191, 165, 0.15)",
        DropAreaGlowColor = "rgba(0, 191, 165, 0.4)",
        DropAreaLightGlowColor = "rgba(0, 191, 165, 0.08)"
    };

    public static GridTheme Default => new GridTheme();

}
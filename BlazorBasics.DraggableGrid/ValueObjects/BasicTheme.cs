namespace BlazorBasics.DraggableGrid.ValueObjects;

public partial class GridTheme
{



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


    /// <summary>
    /// Green monochromatic theme with fresh and energetic tones.
    /// </summary>
    public static GridTheme EmeraldGreen => new GridTheme
    {
        GridBackground = "#f0fff4",
        GridBorderColor = "#a3e635",

        ItemBorderColor = "#4ade80",
        ItemShadowColor = "0 2px 8px rgba(74, 222, 128, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(74, 222, 128, 0.40)",

        SelectedColor = "#22c55e",
        SelectedGlowColor = "rgba(34, 197, 94, 0.35)",

        DraggingColor = "#16a34a",
        DraggingGlowColor = "rgba(22, 163, 74, 0.35)",

        DropAreaColor = "#86efac",
        DropAreaBackground = "rgba(134, 239, 172, 0.20)",
        DropAreaGlowColor = "rgba(134, 239, 172, 0.45)",
        DropAreaLightGlowColor = "rgba(134, 239, 172, 0.10)"
    };

    /// <summary>
    /// Blue monochromatic theme inspired by ocean tones.
    /// </summary>
    public static GridTheme OceanBlue => new GridTheme
    {
        GridBackground = "#f0f9ff",
        GridBorderColor = "#38bdf8",

        ItemBorderColor = "#0ea5e9",
        ItemShadowColor = "0 2px 8px rgba(14, 165, 233, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(14, 165, 233, 0.40)",

        SelectedColor = "#0284c7",
        SelectedGlowColor = "rgba(2, 132, 199, 0.35)",

        DraggingColor = "#0369a1",
        DraggingGlowColor = "rgba(3, 105, 161, 0.35)",

        DropAreaColor = "#7dd3fc",
        DropAreaBackground = "rgba(125, 211, 252, 0.15)",
        DropAreaGlowColor = "rgba(125, 211, 252, 0.40)",
        DropAreaLightGlowColor = "rgba(125, 211, 252, 0.08)"
    };

    /// <summary>
    /// Purple monochromatic theme with strong modern accents.
    /// </summary>
    public static GridTheme RoyalPurple => new GridTheme
    {
        GridBackground = "#faf5ff",
        GridBorderColor = "#c084fc",

        ItemBorderColor = "#a855f7",
        ItemShadowColor = "0 2px 8px rgba(168, 85, 247, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(168, 85, 247, 0.40)",

        SelectedColor = "#9333ea",
        SelectedGlowColor = "rgba(147, 51, 234, 0.35)",

        DraggingColor = "#7e22ce",
        DraggingGlowColor = "rgba(126, 34, 206, 0.35)",

        DropAreaColor = "#d8b4fe",
        DropAreaBackground = "rgba(216, 180, 254, 0.15)",
        DropAreaGlowColor = "rgba(216, 180, 254, 0.40)",
        DropAreaLightGlowColor = "rgba(216, 180, 254, 0.08)"
    };

    /// <summary>
    /// Red monochromatic theme inspired by alert/danger colors.
    /// </summary>
    public static GridTheme CrimsonRed => new GridTheme
    {
        GridBackground = "#fef2f2",
        GridBorderColor = "#f87171",

        ItemBorderColor = "#ef4444",
        ItemShadowColor = "0 2px 8px rgba(239, 68, 68, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(239, 68, 68, 0.40)",

        SelectedColor = "#dc2626",
        SelectedGlowColor = "rgba(220, 38, 38, 0.35)",

        DraggingColor = "#b91c1c",
        DraggingGlowColor = "rgba(185, 28, 28, 0.35)",

        DropAreaColor = "#fecaca",
        DropAreaBackground = "rgba(254, 202, 202, 0.15)",
        DropAreaGlowColor = "rgba(254, 202, 202, 0.40)",
        DropAreaLightGlowColor = "rgba(254, 202, 202, 0.08)"
    };

}
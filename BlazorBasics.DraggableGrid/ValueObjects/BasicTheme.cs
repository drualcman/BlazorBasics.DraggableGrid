namespace BlazorBasics.DraggableGrid.ValueObjects;

public class BasicTheme
{
    public static GridTheme Default => new GridTheme();

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
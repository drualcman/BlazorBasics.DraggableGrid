namespace BlazorBasics.DraggableGrid.ValueObjects;

public partial class GridTheme
{

    public static GridTheme BulmaPrimary => new GridTheme
    {
        GridBackground = "#f0f6ff",
        GridBorderColor = "#485fc7",

        ItemBorderColor = "#3e4fb5",
        ItemShadowColor = "0 2px 8px rgba(72, 95, 199, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(72, 95, 199, 0.40)",

        SelectedColor = "#485fc7",
        SelectedGlowColor = "rgba(72, 95, 199, 0.40)",

        DraggingColor = "#3a4aa7",
        DraggingGlowColor = "rgba(58, 74, 167, 0.35)",

        DropAreaColor = "#b3c4ff",
        DropAreaBackground = "rgba(179, 196, 255, 0.15)",
        DropAreaGlowColor = "rgba(179, 196, 255, 0.45)",
        DropAreaLightGlowColor = "rgba(179, 196, 255, 0.08)"
    };

    public static GridTheme BulmaInfo => new GridTheme
    {
        GridBackground = "#eefcff",
        GridBorderColor = "#3e8ed0",

        ItemBorderColor = "#3490c5",
        ItemShadowColor = "0 2px 8px rgba(62, 142, 208, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(62, 142, 208, 0.40)",

        SelectedColor = "#3e8ed0",
        SelectedGlowColor = "rgba(62, 142, 208, 0.40)",

        DraggingColor = "#2c78b3",
        DraggingGlowColor = "rgba(44, 120, 179, 0.35)",

        DropAreaColor = "#a8d8f0",
        DropAreaBackground = "rgba(168, 216, 240, 0.20)",
        DropAreaGlowColor = "rgba(168, 216, 240, 0.45)",
        DropAreaLightGlowColor = "rgba(168, 216, 240, 0.08)"
    };

    public static GridTheme BulmaSuccess => new GridTheme
    {
        GridBackground = "#f3fff7",
        GridBorderColor = "#48c78e",

        ItemBorderColor = "#37b27c",
        ItemShadowColor = "0 2px 8px rgba(56, 199, 142, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(56, 199, 142, 0.40)",

        SelectedColor = "#48c78e",
        SelectedGlowColor = "rgba(72, 199, 142, 0.40)",

        DraggingColor = "#2fa371",
        DraggingGlowColor = "rgba(47, 163, 113, 0.35)",

        DropAreaColor = "#b8f2d4",
        DropAreaBackground = "rgba(184, 242, 212, 0.15)",
        DropAreaGlowColor = "rgba(184, 242, 212, 0.40)",
        DropAreaLightGlowColor = "rgba(184, 242, 212, 0.08)"
    };

    public static GridTheme BulmaWarning => new GridTheme
    {
        GridBackground = "#fffaf0",
        GridBorderColor = "#ffe08a",

        ItemBorderColor = "#ffd26b",
        ItemShadowColor = "0 2px 8px rgba(255, 208, 138, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(255, 208, 138, 0.40)",

        SelectedColor = "#ffe08a",
        SelectedGlowColor = "rgba(255, 224, 138, 0.40)",

        DraggingColor = "#eab55f",
        DraggingGlowColor = "rgba(234, 181, 95, 0.35)",

        DropAreaColor = "#ffecc2",
        DropAreaBackground = "rgba(255, 236, 194, 0.15)",
        DropAreaGlowColor = "rgba(255, 236, 194, 0.40)",
        DropAreaLightGlowColor = "rgba(255, 236, 194, 0.08)"
    };

    public static GridTheme BulmaDanger => new GridTheme
    {
        GridBackground = "#fff0f3",
        GridBorderColor = "#f14668",

        ItemBorderColor = "#e63950",
        ItemShadowColor = "0 2px 8px rgba(241, 70, 104, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(241, 70, 104, 0.40)",

        SelectedColor = "#f14668",
        SelectedGlowColor = "rgba(241, 70, 104, 0.40)",

        DraggingColor = "#c72d42",
        DraggingGlowColor = "rgba(199, 45, 66, 0.35)",

        DropAreaColor = "#ffb3c0",
        DropAreaBackground = "rgba(255, 179, 192, 0.15)",
        DropAreaGlowColor = "rgba(255, 179, 192, 0.40)",
        DropAreaLightGlowColor = "rgba(255, 179, 192, 0.08)"
    };

    public static GridTheme BulmaLink => new GridTheme
    {
        GridBackground = "#f5f7ff",
        GridBorderColor = "#3273dc",

        ItemBorderColor = "#275eb8",
        ItemShadowColor = "0 2px 8px rgba(50, 115, 220, 0.25)",
        ItemHoverShadowColor = "0 8px 20px rgba(50, 115, 220, 0.40)",

        SelectedColor = "#3273dc",
        SelectedGlowColor = "rgba(50, 115, 220, 0.40)",

        DraggingColor = "#2756c2",
        DraggingGlowColor = "rgba(39, 86, 194, 0.35)",

        DropAreaColor = "#b7ccff",
        DropAreaBackground = "rgba(183, 204, 255, 0.15)",
        DropAreaGlowColor = "rgba(183, 204, 255, 0.40)",
        DropAreaLightGlowColor = "rgba(183, 204, 255, 0.08)"
    };

}
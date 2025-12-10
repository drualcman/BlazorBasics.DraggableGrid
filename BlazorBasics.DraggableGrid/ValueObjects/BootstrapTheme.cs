namespace BlazorBasics.DraggableGrid.ValueObjects;

public class BootstrapTheme
{
    public static GridTheme Default => new GridTheme();

    public static GridTheme BootstrapPrimary => new GridTheme
    {
        GridBackground = "#e7f0ff",
        GridBorderColor = "#b7d1ff",

        ItemBorderColor = "#8fb8ff",
        ItemShadowColor = "0 2px 8px rgba(13, 110, 253, 0.2)",
        ItemHoverShadowColor = "0 8px 22px rgba(13, 110, 253, 0.25)",

        SelectedColor = "#0d6efd",
        SelectedGlowColor = "rgba(13, 110, 253, 0.35)",

        DraggingColor = "#0b5ed7",
        DraggingGlowColor = "rgba(11, 94, 215, 0.35)",

        DropAreaColor = "#0a58ca",
        DropAreaBackground = "rgba(10, 88, 202, 0.15)",
        DropAreaGlowColor = "rgba(10, 88, 202, 0.35)",
        DropAreaLightGlowColor = "rgba(10, 88, 202, 0.08)"
    };
    public static GridTheme BootstrapSecondary => new GridTheme
    {
        GridBackground = "#f1f3f5",
        GridBorderColor = "#d0d4d8",

        ItemBorderColor = "#b6bcc1",
        ItemShadowColor = "0 2px 8px rgba(108, 117, 125, 0.2)",
        ItemHoverShadowColor = "0 8px 22px rgba(108, 117, 125, 0.28)",

        SelectedColor = "#6c757d",
        SelectedGlowColor = "rgba(108, 117, 125, 0.35)",

        DraggingColor = "#5c636a",
        DraggingGlowColor = "rgba(92, 99, 106, 0.35)",

        DropAreaColor = "#4b5156",
        DropAreaBackground = "rgba(75, 81, 86, 0.15)",
        DropAreaGlowColor = "rgba(75, 81, 86, 0.35)",
        DropAreaLightGlowColor = "rgba(75, 81, 86, 0.08)"
    };
    public static GridTheme BootstrapSuccess => new GridTheme
    {
        GridBackground = "#e8f7f0",
        GridBorderColor = "#bbe3ce",

        ItemBorderColor = "#9ad6ba",
        ItemShadowColor = "0 2px 8px rgba(25, 135, 84, 0.18)",
        ItemHoverShadowColor = "0 8px 22px rgba(25, 135, 84, 0.28)",

        SelectedColor = "#198754",
        SelectedGlowColor = "rgba(25, 135, 84, 0.33)",

        DraggingColor = "#157347",
        DraggingGlowColor = "rgba(21, 115, 71, 0.35)",

        DropAreaColor = "#0f5132",
        DropAreaBackground = "rgba(15, 81, 50, 0.15)",
        DropAreaGlowColor = "rgba(15, 81, 50, 0.35)",
        DropAreaLightGlowColor = "rgba(15, 81, 50, 0.08)"
    };
    public static GridTheme BootstrapInfo => new GridTheme
    {
        GridBackground = "#e6fbff",
        GridBorderColor = "#b0eef8",

        ItemBorderColor = "#86e4f2",
        ItemShadowColor = "0 2px 8px rgba(13, 202, 240, 0.2)",
        ItemHoverShadowColor = "0 8px 22px rgba(13, 202, 240, 0.3)",

        SelectedColor = "#0dcaf0",
        SelectedGlowColor = "rgba(13, 202, 240, 0.35)",

        DraggingColor = "#0bb6d9",
        DraggingGlowColor = "rgba(11, 182, 217, 0.35)",

        DropAreaColor = "#0a98b0",
        DropAreaBackground = "rgba(10, 152, 176, 0.15)",
        DropAreaGlowColor = "rgba(10, 152, 176, 0.35)",
        DropAreaLightGlowColor = "rgba(10, 152, 176, 0.08)"
    };
    public static GridTheme BootstrapWarning => new GridTheme
    {
        GridBackground = "#fff7e6",
        GridBorderColor = "#ffe6b0",

        ItemBorderColor = "#ffd680",
        ItemShadowColor = "0 2px 8px rgba(255, 193, 7, 0.22)",
        ItemHoverShadowColor = "0 8px 22px rgba(255, 193, 7, 0.32)",

        SelectedColor = "#ffc107",
        SelectedGlowColor = "rgba(255, 193, 7, 0.35)",

        DraggingColor = "#e0a800",
        DraggingGlowColor = "rgba(224, 168, 0, 0.35)",

        DropAreaColor = "#c69500",
        DropAreaBackground = "rgba(198, 149, 0, 0.15)",
        DropAreaGlowColor = "rgba(198, 149, 0, 0.35)",
        DropAreaLightGlowColor = "rgba(198, 149, 0, 0.08)"
    };
    public static GridTheme BootstrapDanger => new GridTheme
    {
        GridBackground = "#fff0f3",
        GridBorderColor = "#ffc2cb",

        ItemBorderColor = "#ffa3b1",
        ItemShadowColor = "0 2px 8px rgba(220, 53, 69, 0.18)",
        ItemHoverShadowColor = "0 8px 22px rgba(220, 53, 69, 0.28)",

        SelectedColor = "#dc3545",
        SelectedGlowColor = "rgba(220, 53, 69, 0.35)",

        DraggingColor = "#bb2d3b",
        DraggingGlowColor = "rgba(187, 45, 59, 0.35)",

        DropAreaColor = "#a71c2c",
        DropAreaBackground = "rgba(167, 28, 44, 0.15)",
        DropAreaGlowColor = "rgba(167, 28, 44, 0.35)",
        DropAreaLightGlowColor = "rgba(167, 28, 44, 0.08)"
    };

}
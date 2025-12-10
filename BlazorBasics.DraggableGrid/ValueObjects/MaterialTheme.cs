namespace BlazorBasics.DraggableGrid.ValueObjects;

public class MaterialTheme
{
    public static GridTheme Default => new GridTheme();

    public static GridTheme Glass => new GridTheme
    {
        GridBackground = "rgba(255, 255, 255, 0.20)",
        GridBorderColor = "rgba(255, 255, 255, 0.30)",

        ItemBorderColor = "rgba(255, 255, 255, 0.25)",
        ItemShadowColor = "0 8px 32px rgba(0, 0, 0, 0.20)",
        ItemHoverShadowColor = "0 12px 50px rgba(0, 0, 0, 0.30)",

        SelectedColor = "rgba(255, 255, 255, 0.40)",
        SelectedGlowColor = "rgba(255, 255, 255, 0.45)",

        DraggingColor = "rgba(255, 255, 255, 0.50)",
        DraggingGlowColor = "rgba(255, 255, 255, 0.40)",

        DropAreaColor = "rgba(255, 255, 255, 0.45)",
        DropAreaBackground = "rgba(255, 255, 255, 0.10)",
        DropAreaGlowColor = "rgba(255, 255, 255, 0.30)",
        DropAreaLightGlowColor = "rgba(255, 255, 255, 0.05)"
    };
    public static GridTheme Neumorphism => new GridTheme
    {
        GridBackground = "#e0e5ec",
        GridBorderColor = "#d1d9e6",

        ItemBorderColor = "transparent",
        ItemShadowColor = "8px 8px 15px #b8bcc2, -8px -8px 15px #ffffff",
        ItemHoverShadowColor = "12px 12px 20px #b8bcc2, -12px -12px 20px #ffffff",

        SelectedColor = "#c7ccd3",
        SelectedGlowColor = "rgba(0, 0, 0, 0.05)",

        DraggingColor = "#aab1b9",
        DraggingGlowColor = "rgba(0, 0, 0, 0.10)",

        DropAreaColor = "#d7dce3",
        DropAreaBackground = "rgba(255, 255, 255, 0.35)",
        DropAreaGlowColor = "rgba(255, 255, 255, 0.50)",
        DropAreaLightGlowColor = "rgba(255, 255, 255, 0.15)"
    };
    public static GridTheme Cyberpunk => new GridTheme
    {
        GridBackground = "#0a0f1f",
        GridBorderColor = "#08f7fe",

        ItemBorderColor = "#fe53bb",
        ItemShadowColor = "0 2px 20px rgba(254, 83, 187, 0.50)",
        ItemHoverShadowColor = "0 2px 32px rgba(0, 255, 255, 0.50)",

        SelectedColor = "#09fbd3",
        SelectedGlowColor = "rgba(9, 251, 211, 0.40)",

        DraggingColor = "#fe53bb",
        DraggingGlowColor = "rgba(254, 83, 187, 0.40)",

        DropAreaColor = "#08f7fe",
        DropAreaBackground = "rgba(8, 247, 254, 0.10)",
        DropAreaGlowColor = "rgba(8, 247, 254, 0.50)",
        DropAreaLightGlowColor = "rgba(8, 247, 254, 0.05)"
    };

    public static GridTheme SoftGray => new GridTheme
    {
        GridBackground = "#f8f9fa",
        GridBorderColor = "#ced4da",

        ItemBorderColor = "#adb5bd",
        ItemShadowColor = "0 2px 8px rgba(108, 117, 125, 0.15)",
        ItemHoverShadowColor = "0 8px 20px rgba(108, 117, 125, 0.25)",

        SelectedColor = "#6c757d",
        SelectedGlowColor = "rgba(108, 117, 125, 0.30)",

        DraggingColor = "#495057",
        DraggingGlowColor = "rgba(73, 80, 87, 0.30)",

        DropAreaColor = "#dee2e6",
        DropAreaBackground = "rgba(222, 226, 230, 0.15)",
        DropAreaGlowColor = "rgba(222, 226, 230, 0.30)",
        DropAreaLightGlowColor = "rgba(222, 226, 230, 0.08)"
    };
    public static GridTheme DashboardTech => new GridTheme
    {
        GridBackground = "#131722",
        GridBorderColor = "#1e2635",

        ItemBorderColor = "#2d3547",
        ItemShadowColor = "0 2px 12px rgba(0, 0, 0, 0.40)",
        ItemHoverShadowColor = "0 4px 24px rgba(0, 0, 0, 0.55)",

        SelectedColor = "#37bff0",
        SelectedGlowColor = "rgba(55, 191, 240, 0.35)",

        DraggingColor = "#22a2d4",
        DraggingGlowColor = "rgba(34, 162, 212, 0.35)",

        DropAreaColor = "#4cc9f0",
        DropAreaBackground = "rgba(76, 201, 240, 0.15)",
        DropAreaGlowColor = "rgba(76, 201, 240, 0.40)",
        DropAreaLightGlowColor = "rgba(76, 201, 240, 0.08)"
    };

}
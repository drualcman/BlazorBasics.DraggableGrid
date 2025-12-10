namespace BlazorBasics.DraggableGrid.ValueObjects;

public class OsTheme
{
    public static GridTheme Default => new GridTheme();
    public static GridTheme Windows11Fluent => new GridTheme
    {
        GridBackground = "rgba(255, 255, 255, 0.6)",       // Soft acrylic
        GridBorderColor = "rgba(200, 200, 200, 0.35)",

        ItemBorderColor = "rgba(180, 180, 180, 0.45)",
        ItemShadowColor = "0 4px 25px rgba(0, 0, 0, 0.15)",
        ItemHoverShadowColor = "0 12px 45px rgba(0, 0, 0, 0.22)",

        SelectedColor = "#0a66c2",                         // Windows blue
        SelectedGlowColor = "rgba(10, 102, 194, 0.35)",

        DraggingColor = "#0959a9",
        DraggingGlowColor = "rgba(9, 89, 169, 0.35)",

        DropAreaColor = "#0a84ff",
        DropAreaBackground = "rgba(10, 132, 255, 0.18)",
        DropAreaGlowColor = "rgba(10, 132, 255, 0.35)",
        DropAreaLightGlowColor = "rgba(10, 132, 255, 0.10)"
    };
    public static GridTheme MacOSGlass => new GridTheme
    {
        GridBackground = "rgba(255, 255, 255, 0.50)",      // Light frosted glass
        GridBorderColor = "rgba(255, 255, 255, 0.35)",

        ItemBorderColor = "rgba(255, 255, 255, 0.55)",
        ItemShadowColor = "0 4px 18px rgba(0, 0, 0, 0.20)",
        ItemHoverShadowColor = "0 12px 35px rgba(0, 0, 0, 0.28)",

        SelectedColor = "#5e5ce6",                         // macOS lilac
        SelectedGlowColor = "rgba(94, 92, 230, 0.35)",

        DraggingColor = "#4f4bc7",
        DraggingGlowColor = "rgba(79, 75, 199, 0.35)",

        DropAreaColor = "#0a84ff",                         // macOS blue accent
        DropAreaBackground = "rgba(10, 132, 255, 0.18)",
        DropAreaGlowColor = "rgba(10, 132, 255, 0.38)",
        DropAreaLightGlowColor = "rgba(10, 132, 255, 0.08)"
    };

}
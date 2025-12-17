[![Nuget](https://img.shields.io/nuget/v/BlazorBasics.DraggableGrid?style=for-the-badge)](https://www.nuget.org/packages/BlazorBasics.DraggableGrid)
[![Nuget](https://img.shields.io/nuget/dt/BlazorBasics.DraggableGrid?style=for-the-badge)](https://www.nuget.org/packages/BlazorBasics.DraggableGrid)

# BlazorBasics.DraggableGrid
A lightweight, customizable, and fully-featured draggable grid component for Blazor applications. Perfect for building dashboards, admin panels, and any interface that requires rearrangeable layouts.
## Features
- Drag & Drop - Intuitive drag and drop with visual feedback
- Collision Detection - Prevents overlapping items automatically
- Fully Customizable - CSS variables and theme support
- Keyboard Controls - Navigate and manipulate with keyboard
- Generic Data Support - Works with any data type via TData
- Multiple Themes - Built-in dark and pastel themes
- Selection Management - Built-in item selection system
- Resizable Items - Programmatically resize items
- Accessible - Focus management and keyboard navigation

# Installation
```bash
Install-Package BlazorBasics.DraggableGrid
```
```bash
dotnet add package BlazorBasics.DraggableGrid
```

## Quick Start
In your _Imports.razor:
```
@using BlazorBasics.DraggableGrid
@using BlazorBasics.DraggableGrid.Models
@using BlazorBasics.DraggableGrid.ValueObjects
```
## Create a sample page
```razor
@page "/dashboard"
@using BlazorBasics.DraggableGrid
@using BlazorBasics.DraggableGrid.Models
@using BlazorBasics.DraggableGrid.ValueObjects

<PageTitle>Dashboard</PageTitle>

<h1>My Dashboard</h1>

<GridVisualization TData="WidgetData"
                   Layout="@_layout"
                   SelectedItem="@_selectedItem"
                   SelectedItemChanged="OnSelectedItemChanged"
                   LayoutChanged="OnLayoutChanged"
                   OnItemRemoved="OnItemRemoved"
                   Theme="@GridTheme.DarkTheme">
    
    <ChildContent Context="widget">
        <div class="widget-content">
            <h3>@widget.Title</h3>
            <p>@widget.Description</p>
            <small>Size: @widget.Size</small>
        </div>
    </ChildContent>
    
</GridVisualization>

@code {
    private GridLayout _layout = new()
    {
        Columns = 8,
        Rows = 10,
        Gap = "24px",
        ColumnSize = "minmax(50px, 1fr)",
        RowSize = "auto"
        Items = new List<GridItem>
        {
            new(new GridPosition(0,0), new GridSize(2,2)) {
                Data = "Título Principal"                           // this is a type of object to store any kind of data.
            },
            new(new GridPosition(0,2), new GridSize(2,2)) {
                Data = "Subtítulo o descripción breve"
            },
            new(new GridPosition(2,0), new GridSize(2,2)) {
                Data = "Contenido principal que puede ser más largo y ocupar múltiples celdas. Ideal para mostrar información detallada."
            },
            new(new GridPosition(2,2), new GridSize(2,2)) {
                Data = "Panel lateral o sidebar con información adicional"
            },
        }
    };
    
    private GridItem? _selectedItem;
    
    private void OnSelectedItemChanged(GridItem? item)
    {
        _selectedItem = item;
        Console.WriteLine($"Selected item: {item?.Id}");
    }
    
    private void OnLayoutChanged(GridLayout layout)
    {
        _layout = layout;
        Console.WriteLine("Layout changed!");
        // Here you would typically save the layout to your database
    }
    
    private void OnItemRemoved(GridItem item)
    {
        _layout.Items.Remove(item);
        Console.WriteLine($"Removed item: {item.Id}");
    }
    
    public class WidgetData
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Size { get; set; } = "Medium";
    }
}
```

## Customization
### Using Built-in Themes
```razor
<!-- Default theme (light) -->
<GridVisualization Theme="@GridTheme.Default" ...>

<!-- Dark theme -->
<GridVisualization Theme="@GridTheme.DarkTheme" ...>

<!-- Pastel theme -->
<GridVisualization Theme="@GridTheme.PastelTheme" ...>
```
### Creating Custom Themes
```csharp
var myCustomTheme = new GridTheme
{
    GridBackground = "#f0f8ff",          // Light blue background
    GridBorderColor = "#cce5ff",         // Light blue border
    ItemBorderColor = "#6c757d",         // Gray border for items
    SelectedColor = "#28a745",           // Green selection
    SelectedGlowColor = "rgba(40, 167, 69, 0.3)",
    DraggingColor = "#dc3545",           // Red dragging
    DraggingGlowColor = "rgba(220, 53, 69, 0.3)",
    DropAreaColor = "#17a2b8",           // Teal drop area
    DropAreaBackground = "rgba(23, 162, 184, 0.15)"
};
```

### Custom CSS Variables
You can also override CSS variables directly:
```css
/* In your own CSS file */
.draggable-grid-container {
    --grid-bg: #f8f9fa;
    --grid-border: #dee2e6;
    --item-border: #333;
    --item-shadow: rgba(0, 0, 0, 0.1);
    --hover-shadow: rgba(0, 0, 0, 0.15);
    --selected-color: #007bff;
    --selected-glow: rgba(0, 123, 255, 0.3);
    --dragging-color: #ff6b6b;
    --dragging-glow: rgba(255, 107, 107, 0.3);
    --drop-area-color: #00b7ff;
    --drop-area-bg: rgba(0, 183, 255, 0.2);
    --drop-area-glow: rgba(0, 183, 255, 0.3);
    --drop-area-light-glow: rgba(0, 183, 255, 0.1);
}
```

## Keyboard Controls
The component supports keyboard navigation when `AllowKeyboardControls="true"`:

- Arrow Keys: Move selected item
- Space: Select/deselect items
- Delete/Backspace: Remove selected item
- Escape: Deselect current item

# API Reference

## GridVisualization Component

| Parameter               | Type                        | Description                                      | Default            |
|-------------------------|-----------------------------|--------------------------------------------------|--------------------|
| `Layout`                | `GridLayout`                | Grid configuration and items                     | `new GridLayout()` |
| `ChildContent`          | `RenderFragment<TData>`     | Template for rendering item content              | `null`             |
| `SelectedItem`          | `GridItem?`                 | Currently selected item                          | `null`             |
| `SelectedItemChanged`   | `EventCallback<GridItem?>`  | Fires when selection changes                     | -                  |
| `LayoutChanged`         | `EventCallback<GridLayout>` | Fires when layout changes                        | -                  |
| `OnItemRemoved`         | `EventCallback<GridItem>`   | Fires when an item is removed                    | -                  |
| `AllowDragAndDrop`      | `bool`                      | Enable drag and drop                             | `true`             |
| `AllowKeyboardControls` | `bool`                      | Enable keyboard navigation                       | `false`            |
| `Theme`                 | `GridTheme`                 | Color theme configuration                        | `GridTheme.Default`|

## GridLayout Model

| Property      | Type               | Description                               | Default               |
|---------------|--------------------|-------------------------------------------|-----------------------|
| `Columns`     | `int`              | Number of grid columns                    | `10`                  |
| `Rows`        | `int`              | Number of grid rows                       | `10`                  |
| `ColumnSize`  | `string`           | Width of each cell in pixels              | `minmax(50px, 1fr)`   |
| `RowSize   `  | `string`           | Height of each cell in pixels             | `minmax(150px, auto)` |
| `Gap`         | `string`           | Gap between cells in pixels               | `0`                   |
| `Overflow`    | `string`           | Overflow CSS value                        | `auto`                |
| `Items`       | `List<GridItem>`   | Collection of grid items                  | `new()`               |

## GridItem Model inherits GridObject 

| Property     | Type           | Description                                              |
|--------------|----------------|----------------------------------------------------------|
| `Data`       | `object`       | Item data (use `GetData<T>()` to retrieve typed data)    |### Methods
### Methods
| Name              | Type   | Description                                             |
|-------------------|------------------------------------------------------------------|
| GetData<T>()      | `T`    | Recover the data from the object matching the `T` type  |
| IsDataOfType<T>() | `bool` | Check if data match with the `T` type                   |

## GridObject Model

| Property     | Type           | Description               |
|--------------|----------------|---------------------------|
| `Id`         | `srting`       | Unique identifier         |
| `Position`   | `GridPosition` | Starting column 0 row 0   |
| `Size`       | `GridSize`     | Starting 1x1              |
### Methods
| Name                                         | Type           | Description                                                         |
|----------------------------------------------|--------------------------------------------------------------------------------------|
| IsEmptyObject()                              | `bool`         | Inidicate this object it's only to set position is occuped          |
| Resize(GridSize)                             | `void`         | Update size                                                         |
| MoveTo(GridPosition)                         | `void`         | Move object to new position                                         |
| CanReplace(GridGridObjectSize, GridPosition) | `bool`         | Know if object can be replace by sender in exact position. Can swap |

## GridPosition ValueObject

| Property     | Type           | Description                |
|--------------|----------------|----------------------------|
| `Column`     | `int`          | Starting column (0-based)  |
| `Row`        | `int`          | Starting row (0-based)     |

## GridSize ValueObject

| Property     | Type           | Description        |
|--------------|----------------|--------------------|
| `Width`      | `int`          | Number of columns  |
| `Height`     | `int`          | Number of rows     |

### Methods
```csharp
public T GetData<T>();
public bool IsDataOfType<T>();
```

## Public Methods
```csharp
// Programmatically move items
await gridRef.MoveItem(3, 4);            // Move to column 3, row 4
await gridRef.MoveItemByDelta(1, 0);     // Move right by 1 cell

// Resize items
await gridRef.ResizeItemWidth(item, 1);  // Increase width by 1
await gridRef.ResizeItemHeight(item, -1);// Decrease height by 1

// Selection
await gridRef.DeselectItem();            // Deselect current item
```

#  Advanced Usage
## Dynamic Item Creation
```csharp
private void AddNewItem()
{
    var newItem = new GridItem
    {
        Data = new MyDataType { /* your data */ },
        Column = 1,
        Row = 1,
        ColumnSpan = 2,
        RowSpan = 1
    };
    
    _layout.Items.Add(newItem);
    StateHasChanged();
}
```
## Handling Events
```razor
<GridVisualization ...
                   @onitemclick="OnItemClick"
                   @onitemmoved="OnItemMoved"
                   @onitemresized="OnItemResized">
                   
@code {
    private void OnItemClick(GridItem item)
    {
        // Handle item click
    }
    
    private void OnItemMoved(GridItem item, int oldCol, int oldRow)
    {
        // Handle item movement
    }
    
    private void OnItemResized(GridItem item, int oldWidth, int oldHeight)
    {
        // Handle item resize
    }
}
```

# Examples
## Dashboard with Multiple Widget Types
```razor
<GridVisualization TData="object"
                   Layout="@_dashboardLayout"
                   Theme="@GridTheme.DarkTheme">
    
    <ChildContent Context="widgetData">
        @if (widgetData is ChartData chart)
        {
            <ChartWidget Data="@chart" />
        }
        else if (widgetData is StatsData stats)
        {
            <StatsWidget Data="@stats" />
        }
        else if (widgetData is ListData list)
        {
            <ListWidget Data="@list" />
        }
    </ChildContent>
    
</GridVisualization>
```

## Admin Panel with Toolbar
```razor
<div class="admin-panel">
    <div class="toolbar">
        <button @onclick="AddWidget">Add Widget</button>
        <button @onclick="ResetLayout">Reset</button>
        <button @onclick="SaveLayout">Save</button>
    </div>
    
    <GridVisualization @ref="_gridRef"
                       TData="AdminWidget"
                       Layout="@_adminLayout">
        
        <ChildContent Context="widget">
            <div class="admin-widget">
                <div class="widget-header">
                    <span>@widget.Name</span>
                    <button @onclick="() => RemoveWidget(widget)">×</button>
                </div>
                <div class="widget-body">
                    @widget.Content
                </div>
            </div>
        </ChildContent>
        
    </GridVisualization>
</div>

@code {
    private GridVisualization<AdminWidget> _gridRef;
    
    private async Task AddWidget()
    {
        // Add new widget logic
    }
    
    private async Task RemoveWidget(AdminWidget widget)
    {
        await _gridRef.DeselectItem();
        _adminLayout.Items.RemoveAll(i => i.GetData<AdminWidget>() == widget);
    }
}
```

# Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

- Fork the repository
- Create your feature branch (git checkout -b feature/AmazingFeature)
- Commit your changes (git commit -m 'Add some AmazingFeature')
- Push to the branch (git push origin feature/AmazingFeature)
- Open a Pull Request

# License
This project is licensed under the MIT License.

# Acknowledgments
- Built with love for the Blazor community
- Inspired by the need for simple, effective dashboard components
- Thanks to all contributors and users

# Made with love by DrUalcman

If you find this component useful, please consider giving it a star on GitHub!

# WPF小畫家應用程式

## 功能
- 使用滑鼠來畫圖
- 多種不同顏色
- 多種筆刷顏色

---

### 1. WPF 主視窗介面佈局（Layout Container）

* **DockPanel 應用**：作為視窗主要架構，將選單與工具列固定於上方（`DockPanel.Dock="Top"`）、狀態列固定於下方（`DockPanel.Dock="Bottom"`），並由 Canvas 自動填滿中間繪圖區域。
* **Canvas 繪圖畫布**：作為放置與繪製圖形元件的容器，提供絕對座標與繪圖環境。

---

### 2. 視窗選單與控制項選單列 (Menu, ToolBar & StatusBar)

* **Menu (功能選單)**：建立傳統下拉式選單（如「檔案」下的「開啟新畫布」、「儲存畫布」）。
* **ToolBarTray & ToolBar (工具列)**：收納常用功能，如色彩選擇器（ColorPicker）、筆刷粗細滑桿（Slider）以及形狀切換按鈕。
* **StatusBar (狀態列)**：視窗底部區域，包含多個 `StatusBarItem` 與 `Separator`，用於即時顯示當前選取的筆刷色彩、填滿色彩、筆刷粗細與繪圖形狀。

---

### 3. 第三方套件引進 (Extended WPF Toolkit)

* **NuGet 套件整合**：經由引入 `Xceed.Wpf.Toolkit` 命名空間（`xmlns:xctk="..."`）使用原生 WPF 欠缺的高級控制項。
* **xctk:ColorPicker 應用**：使用 `ColorPicker` 提供使用者選取筆刷與填滿色彩，並透過 `SelectedColorChanged` 事件捕捉顏色變更。

---

### 4. WPF UI 控制項與資料繫結 (Data Binding)

* **RadioButton 與 Tag 屬性**：透過 `RadioButton` 群組搭配 `Tag` 屬性（如 `"Line"`, `"Rectangle"`, `"Ellipse"`, `"Polyline"`）來切換繪圖模式。
* **Slider (滑桿)**：控制筆刷粗細（範圍 1~10），搭配 `IsSnapToTickEnabled` 進行數值調整。
* **XAML ElementName 資料繫結**：在 Label 中直接透過 `{Binding Value, ElementName=ThicknessSlider}` 動態顯示目前滑桿的數值。

---

### 5. C# 事件處理與狀態同步 (Code-Behind 邏輯)

* **事件觸發 (Event Handling)**：實作 `SelectedColorChanged`、`ValueChanged` 以及 `Checked` 事件處理函式。
* **類型轉換 (Type Casting)**：使用 `sender as RadioButton` 取得觸發元件並讀取 `Tag` 屬性。
* **狀態即時更新 (DisplayStatus)**：透過共用函式更新 `ColorLabel` 與 `ShapeLabel` 的顯示文字，將變數狀態同步呈現於 UI 狀態列。
using Jamesnet.Wpf.Global.Extensions;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Global.Wpf
{
    public class JamesGrid : Grid
    {
        public static readonly DependencyProperty ChildHorizontalAlignmentProperty = DependencyProperty.Register("ChildHorizontalAlignment", typeof(HorizontalAlignment?), typeof(JamesGrid), new FrameworkPropertyMetadata((HorizontalAlignment?)null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnChildHorizontalAlignmentChanged)));
        public static readonly DependencyProperty ChildMarginProperty = DependencyProperty.Register("ChildMargin", typeof(Thickness?), typeof(JamesGrid), new FrameworkPropertyMetadata((Thickness?)null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnChildMarginChanged)));

        public static readonly DependencyProperty ChildVerticalAlignmentProperty = DependencyProperty.Register("ChildVerticalAlignment", typeof(VerticalAlignment?), typeof(JamesGrid), new FrameworkPropertyMetadata((VerticalAlignment?)null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnChildVerticalAlignmentChanged)));
        public static readonly DependencyProperty ColumnCountProperty = DependencyProperty.RegisterAttached("ColumnCount", typeof(int), typeof(JamesGrid), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(ColumnCountChanged)));

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached("Columns", typeof(string), typeof(JamesGrid), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(ColumnsChanged)));
        public static readonly DependencyProperty ColumnWidthProperty = DependencyProperty.RegisterAttached("ColumnWidth", typeof(GridLength), typeof(JamesGrid), new FrameworkPropertyMetadata(GridLength.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FixedColumnWidthChanged)));
        public static readonly DependencyProperty IsAutoIndexingProperty = DependencyProperty.Register("IsAutoIndexing", typeof(bool), typeof(JamesGrid), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(JamesGrid), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty RowCountProperty = DependencyProperty.RegisterAttached("RowCount", typeof(int), typeof(JamesGrid), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(RowCountChanged)));
        public static readonly DependencyProperty RowHeightProperty = DependencyProperty.RegisterAttached("RowHeight", typeof(GridLength), typeof(JamesGrid), new FrameworkPropertyMetadata(GridLength.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FixedRowHeightChanged)));
        public static readonly DependencyProperty RowsProperty = DependencyProperty.RegisterAttached("Rows", typeof(string), typeof(JamesGrid), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(RowsChanged)));
        
        [Category("Layout"), Description("Presets the horizontal alignment of all child controls")]
        public HorizontalAlignment? ChildHorizontalAlignment
        {
            get { return (HorizontalAlignment?)GetValue(ChildHorizontalAlignmentProperty); }
            set { SetValue(ChildHorizontalAlignmentProperty, value); }
        }

        [Category("Layout"), Description("Presets the margin of all child controls")]
        public Thickness? ChildMargin
        {
            get { return (Thickness?)GetValue(ChildMarginProperty); }
            set { SetValue(ChildMarginProperty, value); }
        }

        [Category("Layout"), Description("Presets the vertical alignment of all child controls")]
        public VerticalAlignment? ChildVerticalAlignment
        {
            get { return (VerticalAlignment?)GetValue(ChildVerticalAlignmentProperty); }
            set { SetValue(ChildVerticalAlignmentProperty, value); }
        }

        [Category("Layout"), Description("Defines a set number of columns")]
        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        [Category("Layout"), Description("Defines all columns using comma separated grid length notation")]
        public string Columns
        {
            get { return (string)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        [Category("Layout"), Description("Presets the width of all columns set using the ColumnCount property")]
        public GridLength ColumnWidth
        {
            get { return (GridLength)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }

        [Category("Layout"), Description("Set to false to disable the auto layout functionality")]
        public bool IsAutoIndexing
        {
            get { return (bool)GetValue(IsAutoIndexingProperty); }
            set { SetValue(IsAutoIndexingProperty, value); }
        }

        [Category("Layout"), Description("Defines the directionality of the autolayout. Use vertical for a column first layout, horizontal for a row first layout.")]
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        [Category("Layout"), Description("Defines a set number of rows")]
        public int RowCount
        {
            get { return (int)GetValue(RowCountProperty); }
            set { SetValue(RowCountProperty, value); }
        }

        [Category("Layout"), Description("Presets the height of all rows set using the RowCount property")]
        public GridLength RowHeight
        {
            get { return (GridLength)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        [Category("Layout"), Description("Defines all rows using comma separated grid length notation")]
        public string Rows
        {
            get { return (string)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public static void ColumnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((int)e.NewValue < 0)
                return;

            var grid = d as JamesGrid;

            // look for an existing column definition for the height
            var width = GridLength.Auto;
            if (grid.ColumnDefinitions.Count > 0)
                width = grid.ColumnDefinitions[0].Width;

            // clear and rebuild
            grid.ColumnDefinitions.Clear();
            for (int i = 0; i < (int)e.NewValue; i++)
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = width });
        }

        public static void ColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((string)e.NewValue == string.Empty)
                return;

            var grid = d as JamesGrid;
            grid.ColumnDefinitions.Clear();

            var defs = Parse((string)e.NewValue);
            foreach (var def in defs)
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = def });
        }

        public static void FixedColumnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as JamesGrid;

            // add a default column if missing
            if (grid.ColumnDefinitions.Count == 0)
                grid.ColumnDefinitions.Add(new ColumnDefinition());

            // set all existing columns to this width
            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
                grid.ColumnDefinitions[i].Width = (GridLength)e.NewValue;
        }

        public static void FixedRowHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as JamesGrid;

            // add a default row if missing
            if (grid.RowDefinitions.Count == 0)
                grid.RowDefinitions.Add(new RowDefinition());

            // set all existing rows to this height
            for (int i = 0; i < grid.RowDefinitions.Count; i++)
                grid.RowDefinitions[i].Height = (GridLength)e.NewValue;
        }

        public static GridLength[] Parse(string text)
        {
            var tokens = text.Split(',');
            var definitions = new GridLength[tokens.Length];
            for (var i = 0; i < tokens.Length; i++)
            {
                var str = tokens[i];
                double value;

                // ratio
                if (str.Contains('*'))
                {
                    if (!double.TryParse(str.Replace("*", ""), out value))
                        value = 1.0;

                    definitions[i] = new GridLength(value, GridUnitType.Star);
                    continue;
                }

                // pixels
                if (double.TryParse(str, out value))
                {
                    definitions[i] = new GridLength(value);
                    continue;
                }

                // auto
                definitions[i] = GridLength.Auto;
            }
            return definitions;
        }

        public static void RowCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((int)e.NewValue < 0)
                return;

            var grid = d as JamesGrid;

            // look for an existing row to get the height
            var height = GridLength.Auto;
            if (grid.RowDefinitions.Count > 0)
                height = grid.RowDefinitions[0].Height;

            // clear and rebuild
            grid.RowDefinitions.Clear();
            for (int i = 0; i < (int)e.NewValue; i++)
                grid.RowDefinitions.Add(
                    new RowDefinition() { Height = height });
        }

        public static void RowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((string)e.NewValue == string.Empty)
                return;

            var grid = d as JamesGrid;
            grid.RowDefinitions.Clear();

            var defs = Parse((string)e.NewValue);
            foreach (var def in defs)
                grid.RowDefinitions.Add(new RowDefinition() { Height = def });
        }

        private static void OnChildHorizontalAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as JamesGrid;
            foreach (UIElement child in grid.Children)
            {
                if (grid.ChildHorizontalAlignment.HasValue)
                    child.SetValue(FrameworkElement.HorizontalAlignmentProperty, grid.ChildHorizontalAlignment);
                else
                    child.SetValue(FrameworkElement.HorizontalAlignmentProperty, DependencyProperty.UnsetValue);
            }
        }

        private static void OnChildMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as JamesGrid;
            foreach (UIElement child in grid.Children)
            {
                if (grid.ChildMargin.HasValue)
                    child.SetValue(FrameworkElement.MarginProperty, grid.ChildMargin);
                else
                    child.SetValue(FrameworkElement.MarginProperty, DependencyProperty.UnsetValue);
            }
        }

        private static void OnChildVerticalAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as JamesGrid;
            foreach (UIElement child in grid.Children)
            {
                if (grid.ChildVerticalAlignment.HasValue)
                    child.SetValue(FrameworkElement.VerticalAlignmentProperty, grid.ChildVerticalAlignment);
                else
                    child.SetValue(FrameworkElement.VerticalAlignmentProperty, DependencyProperty.UnsetValue);
            }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ApplyChildLayout(UIElement child)
        {
            if (ChildMargin != null)
            {
                child.SetIfDefault(FrameworkElement.MarginProperty, ChildMargin.Value);
            }
            if (ChildHorizontalAlignment != null)
            {
                child.SetIfDefault(FrameworkElement.HorizontalAlignmentProperty, ChildHorizontalAlignment.Value);
            }
            if (ChildVerticalAlignment != null)
            {
                child.SetIfDefault(FrameworkElement.VerticalAlignmentProperty, ChildVerticalAlignment.Value);
            }
        }

        private int Clamp(int value, int max)
        {
            return (value > max) ? max : value;
        }

        private void PerformLayout()
        {
            var fillRowFirst = this.Orientation == Orientation.Horizontal;
            var rowCount = this.RowDefinitions.Count;
            var colCount = this.ColumnDefinitions.Count;

            if (rowCount == 0 || colCount == 0)
                return;

            var position = 0;
            var skip = new bool[rowCount, colCount];
            foreach (UIElement child in Children)
            {
                var childIsCollapsed = child.Visibility == Visibility.Collapsed;
                if (IsAutoIndexing && !childIsCollapsed)
                {
                    if (fillRowFirst)
                    {
                        var row = Clamp(position / colCount, rowCount - 1);
                        var col = Clamp(position % colCount, colCount - 1);
                        if (skip[row, col])
                        {
                            position++;
                            row = (position / colCount);
                            col = (position % colCount);
                        }

                        Grid.SetRow(child, row);
                        Grid.SetColumn(child, col);
                        position += Grid.GetColumnSpan(child);

                        var offset = Grid.GetRowSpan(child) - 1;
                        while (offset > 0)
                        {
                            skip[row + offset--, col] = true;
                        }
                    }
                    else
                    {
                        var row = Clamp(position % rowCount, rowCount - 1);
                        var col = Clamp(position / rowCount, colCount - 1);
                        if (skip[row, col])
                        {
                            position++;
                            row = position % rowCount;
                            col = position / rowCount;
                        }

                        Grid.SetRow(child, row);
                        Grid.SetColumn(child, col);
                        position += Grid.GetRowSpan(child);

                        var offset = Grid.GetColumnSpan(child) - 1;
                        while (offset > 0)
                        {
                            skip[row, col + offset--] = true;
                        }
                    }
                }

                ApplyChildLayout(child);
            }
        }

        #region Overrides

        /// <summary>
        /// Measures the children of a <see cref="T:System.Windows.Controls.Grid"/> in anticipation of arranging them during the <see cref="M:ArrangeOverride"/> pass.
        /// </summary>
        /// <param name="constraint">Indicates an upper limit size that should not be exceeded.</param>
        /// <returns>
        /// 	<see cref="Size"/> that represents the required size to arrange child content.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            this.PerformLayout();
            return base.MeasureOverride(constraint);
        }

        #endregion Overrides
    }
}

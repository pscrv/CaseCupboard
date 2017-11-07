using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MVVM;

namespace CustomControls
{
    public class RoundedWindow : Window
    {
        #region static
        static RoundedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(RoundedWindow),
                new FrameworkPropertyMetadata(typeof(RoundedWindow)));
        }
        #endregion



        #region dependency properties
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(RoundedWindow),
                new PropertyMetadata(
                    new CornerRadius(10),
                    null,
                    new CoerceValueCallback(CoerceCornerRadius)));


        public Brush TitleBarBrush
        {
            get { return (Brush)GetValue(TitleBarBrushProperty); }
            set { SetValue(TitleBarBrushProperty, value); }
        }        
        public static readonly DependencyProperty TitleBarBrushProperty =
            DependencyProperty.Register(
                "TitleBarBrush", 
                typeof(Brush), 
                typeof(RoundedWindow), 
                new PropertyMetadata(Brushes.White));
                

        public double TitleBarHeight
        {
            get { return (double)GetValue(TitleBarHeightProperty); }
            set { SetValue(TitleBarHeightProperty, value); }
        }
        public static readonly DependencyProperty TitleBarHeightProperty =
            DependencyProperty.Register(
                "TitleBarHeight",
                typeof(double),
                typeof(RoundedWindow),
                new PropertyMetadata(20.0));

        

        public Brush DividerBrush
        {
            get { return (Brush)GetValue(DividerBrushProperty); }
            set { SetValue(DividerBrushProperty, value); }
        }
        public static readonly DependencyProperty DividerBrushProperty =
            DependencyProperty.Register(
                "DividerBrush",
                typeof(Brush),
                typeof(RoundedWindow),
                new PropertyMetadata(Brushes.Black));




        public double DividerHeight
        {
            get { return (double)GetValue(DividerHeightProperty); }
            set { SetValue(DividerHeightProperty, value); }
        }
        public static readonly DependencyProperty DividerHeightProperty =
            DependencyProperty.Register(
                "DividerHeight", 
                typeof(double), 
                typeof(RoundedWindow), 
                new PropertyMetadata(1.0));

        #endregion



        #region value coersion
        private static object CoerceCornerRadius(DependencyObject d, object baseValue)
        {
            if (d is RoundedWindow rw)
            {
                return (rw.WindowState == WindowState.Maximized) ? new CornerRadius(0) : baseValue;
            }

            throw new InvalidOperationException("CoerceCornerRadius called from non-RoundedWindow");
        }
        #endregion



        #region event handling
        protected override void OnStateChanged(EventArgs e)
        {
            CoerceValue(CornerRadiusProperty);
        }

        #endregion

        

        #region Commands
        public ICommand MinimizeCommand => new RelayCommand(x => true, x => Minimize());
        public ICommand RestoreCommand => new RelayCommand(x => true, x => Restore());
        public ICommand CloseCommand => new RelayCommand(x => true, x => Close());

        private void Minimize() => WindowState = WindowState.Minimized;
        private void Restore() => WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        #endregion

    }
}

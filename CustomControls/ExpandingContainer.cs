using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls
{

    public class ExpandingContainer : ContentControl
    {
        #region static
        static ExpandingContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ExpandingContainer),
                new FrameworkPropertyMetadata(typeof(ExpandingContainer)));
        }
        #endregion


        #region construction
        public ExpandingContainer()
            : base()
        {
            ContentSizeChanged = ContentSizeChangedHandler;
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
                typeof(ExpandingContainer),
                new PropertyMetadata(new CornerRadius(0)));


        public bool IsCollapsed
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                "IsCollapsed",
                typeof(bool),
                typeof(ExpandingContainer),
                new PropertyMetadata(true));


        public double CollapsedHeight
        {
            get { return (double)GetValue(CollapsedHeightProperty); }
            set { SetValue(CollapsedHeightProperty, value); }
        }
        public static readonly DependencyProperty CollapsedHeightProperty =
            DependencyProperty.Register(
                "CollapsedHeight",
                typeof(double),
                typeof(ExpandingContainer),
                new PropertyMetadata(
                    100.0,
                    new PropertyChangedCallback(CollapsedHeightChanged)));

        public bool IsHidingVerticalContent
        {
            get { return (bool)GetValue(IsHidingVerticalContentProperty); }
            protected set { SetValue(IsHidingVerticalContentPropertyKey, value); }
        }
        public static readonly DependencyPropertyKey IsHidingVerticalContentPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsHidingVerticalContent",
                typeof(bool),
                typeof(ExpandingContainer),
                null
                );
        public static readonly DependencyProperty IsHidingVerticalContentProperty = IsHidingVerticalContentPropertyKey.DependencyProperty;
        #endregion


        #region event handling
        public event SizeChangedEventHandler ContentSizeChanged;

        private void ContentSizeChangedHandler(object sender, SizeChangedEventArgs e)
        {
            EvaluateVerticalContentHiding();
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            if (ContentSizeChanged == null)
                return;

            if (oldContent is FrameworkElement oc)
            {
                oc.SizeChanged -= ContentSizeChanged;
            }
            if (newContent is FrameworkElement nc)
            {
                nc.SizeChanged += ContentSizeChanged;
            }

        }
        #endregion


        #region private methods
        private static void CollapsedHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ExpandingContainer ec)
                ec.EvaluateVerticalContentHiding();
        }

        private void EvaluateVerticalContentHiding()
        {
            if (IsCollapsed)
            {
                if (Content is FrameworkElement content)
                {
                    content.Measure(new Size(ActualWidth, double.PositiveInfinity));
                    if (content.DesiredSize.Height > CollapsedHeight)
                    {
                        IsHidingVerticalContent = true;
                        return;
                    }
                }
            }

            IsHidingVerticalContent = false;

        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVM;

namespace CustomControls
{
    public class ExpandingTextBlock : Control
    {
        #region static 
        static ExpandingTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ExpandingTextBlock), 
                new FrameworkPropertyMetadata(typeof(ExpandingTextBlock)));
        }
        #endregion


        #region dependency properties
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", 
                typeof(string), 
                typeof(ExpandingTextBlock), 
                new PropertyMetadata(string.Empty));
        


        public double CollapsedHeight
        {
            get { return (double)GetValue(CollapsedHeightProperty); }
            set { SetValue(CollapsedHeightProperty, value); }
        }
        public static readonly DependencyProperty CollapsedHeightProperty =
            DependencyProperty.Register(
                "CollapsedHeight", 
                typeof(double), 
                typeof(ExpandingTextBlock), 
                new PropertyMetadata(100.0));




        public double ExpandedHeight
        {
            get { return (double)GetValue(ExpandedHeightProperty); }
            set { SetValue(ExpandedHeightProperty, value); }
        }
        public static readonly DependencyProperty ExpandedHeightProperty =
            DependencyProperty.Register(
                "ExpandedHeight", 
                typeof(double), 
                typeof(ExpandingTextBlock), 
                new PropertyMetadata(200.0));



        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                "IsExpanded", 
                typeof(bool), 
                typeof(ExpandingTextBlock), 
                new PropertyMetadata(false));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius", 
                typeof(CornerRadius), 
                typeof(ExpandingTextBlock), 
                new PropertyMetadata(new CornerRadius(0)));



        #endregion


        #region property change handling

        #endregion



        #region event handling
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();            
        }
        #endregion
    }
}

using AppVD.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AppVD.Behaviors
{
    public class MarqueeBehavior : Behavior<StackLayout>
    {
        #region Properties

        private StackLayout stack { get; set; }
        private bool isStartTimer;

        public double PageWidth
        {
            get { return (double)GetValue(PageWidthProperty); }
            set { SetValue(PageWidthProperty, value); }
        }

        // Using a BindableProperty as the backing store for PageWidth. This enables animation, styling, binding, etc.
        public static readonly BindableProperty PageWidthProperty =
            BindableProperty.Create("PageWidth", typeof(double), typeof(MarqueeBehavior));

        #endregion

        #region Methods

        protected override void OnAttachedTo(StackLayout stackLayout)
        {
            base.OnAttachedTo(stackLayout);
            this.stack = stackLayout;
            isStartTimer = true;
            stackLayout.BindingContextChanged += StackLayout_BindingContextChanged;
        }

        /// <summary>
        /// This event is invoked when stacklayout binding context is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackLayout_BindingContextChanged(object sender, EventArgs e)
        {
            StackLayout stackLayout = sender as StackLayout;
            if (stackLayout.BindingContext != null && stackLayout.BindingContext is MainPageViewModel mainPageViewModel && mainPageViewModel != null)
            {
                if (mainPageViewModel.Msgs != null && mainPageViewModel.Msgs.Count > 0)
                {
                    foreach (var msg in mainPageViewModel.Msgs)
                    {
                        stackLayout.Children.Add(GetNewButton((msg.Msg), msg.Codigo));
                    }

                    StartAnimation();
                }
            }
        }

        /// <summary>
        /// This method is used for starting the marquee scrolling animation.
        /// </summary>
        private void StartAnimation()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                stack.TranslationX -= 5f;

                if (Math.Abs(stack.TranslationX) > stack.Width)
                {
                    stack.TranslationX = PageWidth;
                }
                return isStartTimer;
            });
        }

        /// <summary>
        /// This method is used for getting the marquee label content.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="PriorityId"></param>
        /// <returns></returns>
        private Label GetNewButton(string content, int priorityId, string imageName = "")
        {
            var Label = new Label
            {
                FontSize = 16,
                Text = content,
                HeightRequest = 45,
                Margin = new Thickness(0, 0, 8, 0),
                Padding = new Thickness(12, 0, 18, 0),
                TextColor = System.Drawing.Color.White,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = System.Drawing.Color.Transparent
                //BackgroundColor = GetPriorityColor(priorityId)
            };

            //var button = new SfButton()
            //{
            //    FontSize = 16,
            //    Text = content,
            //    HeightRequest = 45,
            //    HasShadow = false,
            //    Margin = new Thickness(0, 0, 8, 0),
            //    Padding = new Thickness(12, 0, 18, 0),
            //    ImageSource = imageName,
            //    ShowIcon = true,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    TextColor = (Color)Application.Current.Resources["ContentTextColor"],
            //    BackgroundColor = GetPriorityColor(priorityId),
            //    VerticalOptions = LayoutOptions.Center,

            //};

            //button.Clicked += (sender, args) =>
            //{
            //    //Perform marquee selected item.
            //};

            return Label;
        }

        /// <summary>
        /// This method is used to return the color based on priority level.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //private Color GetPriorityColor(int id)
        //{
        //    if (id == 1)
        //        return (Color)Application.Current.Resources["HighPriorityBackgroundColor"];
        //    else if (id == 2)
        //        return (Color)Application.Current.Resources["NormalPriorityBackgroundColor"];
        //    else
        //        return (Color)Application.Current.Resources["LowPriorityBackgroundColor"];
        //}

        protected override void OnDetachingFrom(StackLayout stackLayout)
        {
            stackLayout.BindingContextChanged -= StackLayout_BindingContextChanged;
            isStartTimer = false;
            base.OnDetachingFrom(stackLayout);
        }

        #endregion
    }
}

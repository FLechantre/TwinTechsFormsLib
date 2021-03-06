﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace TwinTechsForms.UWP
{
    public class FrameworkElementContainer : Page //FrameworkElement
    {
        public FrameworkElementContainer()
        {
            Background = new SolidColorBrush(Colors.Transparent);
        }

        public FrameworkElement ParentFrameworkElement { get; set; }

        private Frame _pageFrame;
        public Frame PageFrame
        {
            get { return _pageFrame; }

            set
            {
                _pageFrame = value;

                if (_pageFrame != null)
                    AddFrame();
            }
        }

        private void AddFrame()
        {
            if (ParentFrameworkElement == null)
                throw new Exception("No parent frame was found");

            Debug.WriteLine("Frame.CurrentSourcePageType is " + _pageFrame.CurrentSourcePageType);

            //ParentFrameworkElement.Child

            try
            {
                var frameParent = base.Frame; // this is null here


                //var container = new Canvas { Style = (Windows.UI.Xaml.Style)Windows.UI.Xaml.Application.Current.Resources["RootContainerStyle"] };
                //_pageFrame.Content = container;
                //container.Children.Add(ParentFrameworkElement);  // No installed components were detected. Element is already the child of another element.

                

                var container = new Windows.UI.Xaml.Controls.Canvas { Style = (Windows.UI.Xaml.Style)Windows.UI.Xaml.Application.Current.Resources["RootContainerStyle"] };
                container.Children.Add(PageFrame);
                PageFrame.Content = container;


                Window.Current.Content = PageFrame;


                //Frame.Content = container;  // How do I set the content of this Frame? Or make this Frame not null?

            }
            catch (Exception ex)
            {

            }
        }


    }
}

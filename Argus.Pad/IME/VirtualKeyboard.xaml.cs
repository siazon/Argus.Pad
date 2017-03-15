﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Argus.Pad.IME
{
    public sealed partial class VirtualKeyboard : UserControl
    {
        public VirtualKeyboard()
        {
            this.InitializeComponent();
        }


        internal void Letter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            int cursorPosition = inputTextField.SelectionStart;
            int selectionLength = inputTextField.SelectionLength;

            string tempText = inputTextField.Text;

            if (selectionLength > 0)
                tempText = tempText.Remove(cursorPosition, selectionLength);

            if (tempButton.Name == "Backspace")
            {
                if (cursorPosition > 0)
                {
                    tempText = tempText.Remove(cursorPosition - 1, 1);
                    cursorPosition -= 1;
                }
            }
            else
            {
                tempText = tempText.Insert(cursorPosition, tempButton.Content.ToString());
                cursorPosition += 1;
            }
            inputTextField.Text = tempText;
            inputTextField.Select(cursorPosition, 0);
        }

        // Handles the Tapped event of the 'OK' button simulating a save and close 
        private void OK_Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            inputTextField.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            // in this example we assume the parent of the UserControl is a Popup 
            Popup p = this.Parent as Popup;

            // close the Popup
            if (p != null) { p.IsOpen = false; }
        }
    }
}

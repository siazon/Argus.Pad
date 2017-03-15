using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using System.Diagnostics;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Argus.Pad.IME
{
    public sealed partial class VirtualSudoku : UserControl
    {
        public VirtualSudoku()
        {
            this.InitializeComponent();
            this.DataContextChanged += VirtualSudoku_DataContextChanged;
        }

        private void VirtualSudoku_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Debug.WriteLine("VirtualSudoku_DataContextChanged");
            //inputTextField.Text = "";
        }

        internal void Letter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            int cursorPosition = inputTextField.Text.Length;
            int selectionLength = inputTextField.SelectionLength;

            string tempText = inputTextField.Text;

            if (selectionLength > 0)
            { 
                tempText = tempText.Remove(inputTextField.SelectionStart, selectionLength);
                cursorPosition = inputTextField.SelectionStart;
            }
            if (tempButton.Name == "Backspace")
            {
                if (cursorPosition > 0)
                {
                    tempText = tempText.Remove(cursorPosition - 1, 1);
                    cursorPosition -= 1;
                }
            }
            else if (tempButton.Content.ToString() == "-")
            {
                if (tempText.Length == 0)
                {
                    tempText = "-";
                    cursorPosition += 1;
                }
                else if (tempText.Substring(0, 1) != "-")
                {
                    tempText = "-" + tempText;
                    cursorPosition += 1;
                }
            }
            else if (tempButton.Content.ToString() == ".")
            {
                if (tempText.Length == 0)
                {
                    tempText = "0.";
                    cursorPosition += 2;
                }
                else if (tempText.IndexOf('.') == -1)
                {
                    tempText += ".";
                    cursorPosition += 1;
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
        private void Return_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string textTemp = inputTextField.Text.ToString();
            if (textTemp.Length > 0)
            {
                if (textTemp.Substring(textTemp.Length - 1, 1) == ".")
                {
                    textTemp += "0";                    
                }
                if (textTemp.Substring(0, 1) == ".")
                {
                    textTemp = "0" + textTemp;
                }

                inputTextField.Text = textTemp;
            }
            if ((sender as Button).Name.CompareTo("OK") == 0)
                inputTextField.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            // in this example we assume the parent of the UserControl is a Popup 
            Popup p = this.Parent as Popup;

            // close the Popup
            if (p != null) { p.IsOpen = false; }
        }
    }
}

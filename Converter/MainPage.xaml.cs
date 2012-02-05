using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Converter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        enum NumberKind
        {
            Int32,
            Binary,
            Hexa
        }

        NumberKind inputKind = NumberKind.Binary;
        NumberKind outputKind = NumberKind.Int32;

        private void convert(object sender, RoutedEventArgs e) 
        { 
            Int32 intermediate = 0; 
            Boolean succeed = false;


            switch (inputKind)
            {
                case NumberKind.Binary:
                    try
                    {
                        intermediate = Convert.ToInt32(InputText.Text, 2);
                        succeed = true;
                    }
                    catch (Exception ex0)
                    {
                        succeed = false;
                    }
                    //succeed = Int32.TryParse(InputText.Text, NumberStyles.None, CultureInfo.InvariantCulture, out intermediate);
                    break;
                case NumberKind.Hexa:
                    succeed = Int32.TryParse(InputText.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out intermediate);
                    break;
                case NumberKind.Int32:
                    succeed = Int32.TryParse(InputText.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out intermediate);
                    break;
            }
            if(succeed){
                switch (outputKind)
                {
                    case NumberKind.Binary:
                        Result.Text = Convert.ToString(intermediate, 2);
                        break;
                    case NumberKind.Hexa:
                        Result.Text = intermediate.ToString("X", CultureInfo.InvariantCulture);
                        break;
                    case NumberKind.Int32:
                        Result.Text = intermediate.ToString("D", CultureInfo.InvariantCulture);
                        break;
                }
            } else {
                Result.Text = "Input invalid"; 
            }        
        }

       
        //Input Setters
        private void inputSetBin(object sender, RoutedEventArgs e)
        {
            inputKind = NumberKind.Binary;
        }

        private void inputSetHex(object sender, RoutedEventArgs e)
        {
            inputKind = NumberKind.Hexa;
        }

        private void inputSetInt(object sender, RoutedEventArgs e)
        {
            inputKind = NumberKind.Int32;
        }

        // Output Setters
        private void outputSetBin(object sender, RoutedEventArgs e)
        {
            outputKind = NumberKind.Binary;
        }
        
        private void outputSetHex(object sender, RoutedEventArgs e)
        {
            outputKind = NumberKind.Hexa;
        }

        private void outputSetInt(object sender, RoutedEventArgs e)
        {
            outputKind = NumberKind.Int32;
        }

        //Input Getter
        private bool inputGetBin(object sender, RoutedEventArgs e)
        {
            return inputKind == NumberKind.Binary; 
        }

        private bool inputGetHex(object sender, RoutedEventArgs e)
        {
            return inputKind == NumberKind.Hexa;
        }
        

        


        
    }


}
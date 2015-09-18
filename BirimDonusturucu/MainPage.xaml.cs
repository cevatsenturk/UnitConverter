using System;
using System.Collections.Generic;
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

namespace BirimDonusturucu
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        List<Unit> lengthUnits = new List<Unit>();
        List<Unit> weightUnits = new List<Unit>();
        List<Unit> temperatureUnits = new List<Unit>();
        List<Unit> memoryUnits = new List<Unit>();

        public MainPage()
        {
            InitializeComponent();
            
            lengthUnits.Add(new Unit { UnitName="Santimetre", MultiplayerToReference=100});
            lengthUnits.Add(new Unit { UnitName = "Metre", MultiplayerToReference = 1 });
            lengthUnits.Add(new Unit { UnitName = "Kilometre", MultiplayerToReference = 0.001 });
            lengthUnits.Add(new Unit { UnitName = "Inch", MultiplayerToReference = 100/2.54 });
            lengthUnits.Add(new Unit { UnitName = "Yard", MultiplayerToReference = 1.09361329833771 });
            lengthUnits.Add(new Unit { UnitName = "Mil", MultiplayerToReference = 0.000621371192237334 });
            lengthUnits.Add(new Unit { UnitName = "Deniz Mili", MultiplayerToReference = 0.000539956803455724 });
            lengthUnits.Add(new Unit { UnitName = "Feed", MultiplayerToReference = 3.28083989501312 });
            lengthUnits.Add(new Unit { UnitName = "Fersah", MultiplayerToReference = 0.000175901495162709 });

            lstLengthFrom.ItemsSource = lengthUnits;
            lstLengthFrom.DisplayMemberPath = "UnitName";

            lstLengthTo.ItemsSource = lengthUnits;
            lstLengthTo.DisplayMemberPath = "UnitName";


            weightUnits.Add(new Unit { UnitName = "Gram", MultiplayerToReference = 1000 });
            weightUnits.Add(new Unit { UnitName = "Kilogram", MultiplayerToReference = 1 });
            weightUnits.Add(new Unit { UnitName = "Galon", MultiplayerToReference = 0.264172052358148 });
            weightUnits.Add(new Unit { UnitName = "Kantar", MultiplayerToReference = 0.0177279818465466 });
            weightUnits.Add(new Unit { UnitName = "Okka", MultiplayerToReference = 0.78003120124805 });
            weightUnits.Add(new Unit { UnitName = "Ons", MultiplayerToReference = 35.2739619495804 });
            weightUnits.Add(new Unit { UnitName = "Pound", MultiplayerToReference = 2.20462262184878 });
            weightUnits.Add(new Unit { UnitName = "Ton", MultiplayerToReference = 0.001 });
            weightUnits.Add(new Unit { UnitName = "Zerre", MultiplayerToReference = 640000 });
            weightUnits.Add(new Unit { UnitName = "Dirhem", MultiplayerToReference = 564.383391197268 });

            lstWeightTo.ItemsSource = weightUnits;
            lstWeightTo.DisplayMemberPath = "UnitName";

            lstWeightFrom.ItemsSource = weightUnits;
            lstWeightFrom.DisplayMemberPath = "UnitName";


            temperatureUnits.Add(new Unit { UnitName="Celsius", MultiplayerToReference=1 });
            temperatureUnits.Add(new Unit { UnitName = "Kelvin", MultiplayerToReference = 1 });
            temperatureUnits.Add(new Unit { UnitName = "Fahrenheit", MultiplayerToReference = 1 });

            lstTemperatureFrom.ItemsSource = temperatureUnits;
            lstTemperatureFrom.DisplayMemberPath = "UnitName";

            lstTemperatureTo.ItemsSource = temperatureUnits;
            lstTemperatureTo.DisplayMemberPath = "UnitName";


            memoryUnits.Add(new Unit { UnitName="Bit", MultiplayerToReference=8290304 });
            memoryUnits.Add(new Unit { UnitName = "Byte", MultiplayerToReference = 1036288 });
            memoryUnits.Add(new Unit { UnitName = "Kilobit", MultiplayerToReference = 8192 });
            memoryUnits.Add(new Unit { UnitName = "Kilobyte", MultiplayerToReference = 1024 });
            memoryUnits.Add(new Unit { UnitName = "Megabit", MultiplayerToReference = 8 });
            memoryUnits.Add(new Unit { UnitName = "Megabyte", MultiplayerToReference = 1 });
            memoryUnits.Add(new Unit { UnitName = "Gigabit", MultiplayerToReference = 1.0/256 });
            memoryUnits.Add(new Unit { UnitName = "Gigabyte", MultiplayerToReference = 1.0/1024 });
            memoryUnits.Add(new Unit { UnitName = "Terabit", MultiplayerToReference = 1.0/131072 });
            memoryUnits.Add(new Unit { UnitName = "Terabyte", MultiplayerToReference = 1.0/1048576 });
            memoryUnits.Add(new Unit { UnitName = "Petabit", MultiplayerToReference = 1.0 / 134217728 });
            memoryUnits.Add(new Unit { UnitName = "Petabyte", MultiplayerToReference = 1.0 / 1073741824 });

            lstMemoryFrom.ItemsSource = memoryUnits;
            lstMemoryFrom.DisplayMemberPath = "UnitName";

            lstMemoryTo.ItemsSource = memoryUnits;
            lstMemoryTo.DisplayMemberPath = "UnitName";

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void lstLengthFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertLengthUnits();
        }

        private void lstLengthTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertLengthUnits();
        }

        private void ConvertLengthUnits()
        {
            double val;
            if (Double.TryParse(txtLengthFrom.Text, out val) && lstLengthFrom.SelectedItem != null && lstLengthTo.SelectedItem!=null)
                txtLengthTo.Text = (val / ((Unit)lstLengthFrom.SelectedItem).MultiplayerToReference * ((Unit)lstLengthTo.SelectedItem).MultiplayerToReference).ToString();
        }

        private void lstWeightthFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertWeightUnits();
        }

        private void ConvertWeightUnits()
        {
            double val;
            if (Double.TryParse(txtWeightFrom.Text, out val) && lstWeightFrom.SelectedItem != null && lstWeightTo.SelectedItem != null)
                txtWeightTo.Text = (val / ((Unit)lstWeightFrom.SelectedItem).MultiplayerToReference * ((Unit)lstWeightTo.SelectedItem).MultiplayerToReference).ToString();
        }

        private void lstWeightTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertWeightUnits();
        }

        private void ConvertMemorytUnits()
        {
            double val;
            if (Double.TryParse(txtMemoryFrom.Text, out val) && lstMemoryFrom.SelectedItem != null && lstMemoryTo.SelectedItem != null)
                txtMemoryTo.Text = (val / ((Unit)lstMemoryFrom.SelectedItem).MultiplayerToReference * ((Unit)lstMemoryTo.SelectedItem).MultiplayerToReference).ToString();
        }

        private void lstTemperatureFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertTemperatureUnits();
        }

        private void ConvertTemperatureUnits()
        {
            double val;
            if (Double.TryParse(txtTemperatureFrom.Text, out val) && lstTemperatureFrom.SelectedItem != null && lstTemperatureTo.SelectedItem != null)
            {
                if (lstTemperatureFrom.SelectedIndex == 0 && lstTemperatureTo.SelectedIndex == 1)
                    txtTemperatureTo.Text = (val + 273.15).ToString();
                else if (lstTemperatureFrom.SelectedIndex == 0 && lstTemperatureTo.SelectedIndex == 2)
                    txtTemperatureTo.Text = (val * 1.8 + 32).ToString();
                else if (lstTemperatureFrom.SelectedIndex == 1 && lstTemperatureTo.SelectedIndex == 0)
                    txtTemperatureTo.Text = (val - 273.15).ToString();
                else if (lstTemperatureFrom.SelectedIndex == 1 && lstTemperatureTo.SelectedIndex == 2)
                    txtTemperatureTo.Text = ((val - 273.15) * 1.8 + 32).ToString();
                else if (lstTemperatureFrom.SelectedIndex == 2 && lstTemperatureTo.SelectedIndex == 0)
                    txtTemperatureTo.Text = ((val - 32) / 1.8).ToString();
                else if (lstTemperatureFrom.SelectedIndex == 2 && lstTemperatureTo.SelectedIndex == 1)
                    txtTemperatureTo.Text = ((val - 32) / 1.8 + 273.15).ToString();
                else
                    txtTemperatureTo.Text = txtTemperatureFrom.Text;
            }
        }

        private void lstMemoryTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertMemorytUnits();
        }

        private void lstMemoryFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertMemorytUnits();
        }

        private void txtMemoryFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertMemorytUnits();
        }

        private void lstTemperatureTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertTemperatureUnits();
        }

        private void txtTemperatureFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertTemperatureUnits();
        }

        private void txtLengthFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertLengthUnits();
        }

        private void txtWeightFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertWeightUnits();
        }
    }
}
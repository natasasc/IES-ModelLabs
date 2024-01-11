﻿using FTN.Common;
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
using TelventDMS.Services.NetworkModelService.TestClient.Tests;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<long> allTypes;
        private const string noFilterMsg = "No filter";
        private TestGda tgda;

        public MainWindow()
        {
            IntializeTestGda();
            InitializeComponent();
        }

        private void IntializeTestGda()
        {
            allTypes = null;
            tgda = new TestGda();
        }


        #region GetValues
        
        private void comboBoxIdSelect_Initialized(object sender, EventArgs e)
        {
            GetAllTypes(sender);
        }

        private void listBoxProperties_Initialized(object sender, EventArgs e)
        {
            if (comboBoxIdSelect.Items.Count != 0)
                comboBoxIdSelect.SelectedItem = comboBoxIdSelect.Items[0];
        }

        private void comboBoxIdSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelResourcesDesc modelResources = new ModelResourcesDesc();
            ModelCode type = modelResources.GetModelCodeFromId((long)comboBoxIdSelect.SelectedItem);

            listBoxProperties.ItemsSource = modelResources.GetAllPropertyIds(type);
            listBoxProperties.UnselectAll();
        }

        private void btnGetValues_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxIdSelect.Items.Count == 0)
                return;

            List<ModelCode> props = new List<ModelCode>();
            foreach (var prop in listBoxProperties.SelectedItems)
            {
                props.Add((ModelCode)prop);
            }

            txtBlockOutput.Text = tgda.GetValues((long)comboBoxIdSelect.SelectedItem, props);
        }

        #endregion GetValues


        #region GetExtentValues

        private void comboBoxModelSelect_Initialized(object sender, EventArgs e)
        {
            List<ModelCode> modelCodes = new List<ModelCode>();

            foreach (DMSType type in Enum.GetValues(typeof(DMSType))) //depends on DMSType and ModelCode having the same string name, mozda iskoristi GetModelCodeFromType
            {
                if (type == DMSType.MASK_TYPE)
                    continue;
                
                modelCodes.Add((ModelCode)Enum.Parse(typeof(ModelCode), type.ToString()));
            }

            comboBoxModelSelect.ItemsSource = modelCodes;
        }

        private void listBoxPropertiesExtent_Initialized(object sender, EventArgs e)
        {
            if (comboBoxModelSelect.Items.Count != 0)
                comboBoxModelSelect.SelectedItem = comboBoxModelSelect.Items[0];
        }

        private void comboBoxModelSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelResourcesDesc modelResources = new ModelResourcesDesc();
            listBoxPropertiesExtent.ItemsSource = modelResources.GetAllPropertyIds((ModelCode)comboBoxModelSelect.SelectedItem);
            listBoxPropertiesExtent.UnselectAll();
        }

        private void btnExtentValues_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxModelSelect.Items.Count == 0)
                return;

            List<ModelCode> props = new List<ModelCode>();
            foreach (var prop in listBoxPropertiesExtent.SelectedItems)
            {
                props.Add((ModelCode)prop);
            }

            txtBlockOutput.Text = tgda.GetExtentValues((ModelCode)comboBoxModelSelect.SelectedItem, props);
        }

        #endregion GetExtentValues


        #region GetRelatedValues

        private void comboBoxIdSelectRelated_Initialized(object sender, EventArgs e)
        {
            GetAllTypes(sender);
        }

        private void comboBoxSelectAssType_Initialized(object sender, EventArgs e)
        {
            //comboBoxIdSelectRelated.SelectionChanged += comboBoxIdSelectRelated_SelectionChanged;
            if (comboBoxIdSelectRelated.Items.Count != 0)
                comboBoxIdSelectRelated.SelectedItem = comboBoxIdSelectRelated.Items[0];
        }

        private void comboBoxSelectAssFilter_Initialized(object sender, EventArgs e)
        {
            List<string> modelCodes = new List<string>();
            modelCodes.Add(noFilterMsg);

            foreach (DMSType type in Enum.GetValues(typeof(DMSType))) //depends on DMSType and ModelCode having the same string name, mozda iskoristi GetModelCodeFromType
            {
                if (type == DMSType.MASK_TYPE)
                    continue;

                modelCodes.Add(type.ToString());
            }

            comboBoxSelectAssFilter.ItemsSource = modelCodes;
        }

        private void listBoxPropertiesRelated_Initialized(object sender, EventArgs e)
        {
            if (comboBoxSelectAssFilter.Items.Count != 0)
                comboBoxSelectAssFilter.SelectedItem = comboBoxSelectAssFilter.Items[0];
        }

        private void comboBoxIdSelectRelated_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vrednosti model kodova
            var source = Enum.GetValues(typeof(ModelCode));

            ModelResourcesDesc modelResources = new ModelResourcesDesc();

            // Model kod za izabrani gid
            ModelCode modelCode = modelResources.GetModelCodeFromId((long)comboBoxIdSelectRelated.SelectedItem);

            // Heksadecimalna vrednost model koda za izabrani gid
            string concreteType = ((long)modelCode).ToString("x");

            // Lista model kodova koji imaju referencu na nas gid
            List<string> sourceString = new List<string>();
            foreach (ModelCode s in source)
            {
                // Heksadecimalna vrednost trenutnog model koda
                string temp = s.ToString("x");
                if (tgda.ModelCodeStringCompareHelper(concreteType, temp))      // provera da li je poslednji broj 9
                    sourceString.Add(temp);     // Ako je 9 (referenca), dodaj u listu
            }

            List<ModelCode> codes = new List<ModelCode>();
            foreach (string s in sourceString)
            {
                // Pretvoreni stringovi u heksadecimalne brojeve
                codes.Add((ModelCode)long.Parse(s, System.Globalization.NumberStyles.HexNumber));
            }

            // Smestamo model kodove objekata koji referenciraju izabrani gid u komboboks
            comboBoxSelectAssType.ItemsSource = codes;
            if (comboBoxSelectAssType.Items.Count != 0)
                comboBoxSelectAssType.SelectedItem = comboBoxSelectAssType.Items[0];
        }

        private void comboBoxSelectAssFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ModelCode> props = new List<ModelCode>();

            ModelResourcesDesc modelResources = new ModelResourcesDesc();
            if (comboBoxSelectAssFilter.SelectedItem.ToString() == noFilterMsg)
            {
                foreach (ModelCode code in Enum.GetValues(typeof(ModelCode)))
                {
                    // Sve propertije postavljamo u listu model kodova
                    props.AddRange(modelResources.GetAllPropertyIds(code));
                    props = props.Distinct().ToList();      // izbacujemo duplikate
                }
            }
            else
            {
                // Uzimamo samo propertije filtera
                props = modelResources.GetAllPropertyIds((ModelCode)Enum.Parse(typeof(ModelCode), comboBoxSelectAssFilter.SelectedItem.ToString()));
            }

            listBoxPropertiesRelated.ItemsSource = props;
        }

        private void btnGetRelatedValues_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSelectAssType.Items.Count == 0)
                return;

            Association ass = new Association();

            ass.PropertyId = (ModelCode)comboBoxSelectAssType.SelectedItem;
            if (comboBoxSelectAssFilter.SelectedItem.ToString() == noFilterMsg)
                ass.Type = 0;
            else
                ass.Type = (ModelCode)Enum.Parse(typeof(ModelCode), comboBoxSelectAssFilter.SelectedItem.ToString());
           
            List<ModelCode> props = new List<ModelCode>();
            foreach (var prop in listBoxPropertiesRelated.SelectedItems)
            {
                props.Add((ModelCode)prop);
            }

            try
            {
                txtBlockOutput.Text = tgda.GetRelatedValues((long)comboBoxIdSelectRelated.SelectedItem, ass, props);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Selected properties do not match found instances.\nAdditional message:" + ex.Message, "Incorrect querry",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        
        #endregion GetRelatedValues



        private void GetAllTypes(object sender)
        {
            if (allTypes != null)
            {
                ((ComboBox)sender).ItemsSource = allTypes;
            }
            else
            {
                try
                {
                    allTypes = tgda.TestGetExtentValuesAllTypes();
                }
                catch
                {
                    allTypes = new List<long>();
                }
                ((ComboBox)sender).ItemsSource = allTypes;
            }
        }



        //private void btnReconnect_Click(object sender, RoutedEventArgs e)
        //{
        //    IntializeTestGda();
        //    tgda.TestGetExtentValuesAllTypes();
        //}
    }
}

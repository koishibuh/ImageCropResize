using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ImageCropResize;

public partial class SaveSettings : Form
{
    public MainWindow _mainWindow;
    public bool selectByMouse = false;
    public const string SettingHowTo = "Type in desired settings below.\nThen click a preset button on the right to save the values.";

    public SaveSettings(MainWindow mainWindow)
    {
        InitializeComponent();
        LoadPresetLabels();

        SettingHowTo_Label.Text = SettingHowTo;
        
        _mainWindow = mainWindow;
    }    

    public void LoadPresetLabels()
    {
        Preset1_NameLabel.Text = Settings.Default.Preset1_Name;
        Preset1_XYLabel.Text = $"{Settings.Default.Preset1_XValue}x, {Settings.Default.Preset1_YValue}y";
        Preset1_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset1_Width}w x {Settings.Default.Preset1_Height}h";
        Preset1_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset1_ResizeWidth}w x {Settings.Default.Preset1_ResizeHeight}h";

        Preset2_NameLabel.Text = Settings.Default.Preset2_Name;
        Preset2_XYLabel.Text = $"{Settings.Default.Preset2_XValue}x, {Settings.Default.Preset2_YValue}y";
        Preset2_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset2_Width}w x {Settings.Default.Preset2_Height}h";
        Preset2_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset2_ResizeWidth}w x {Settings.Default.Preset2_ResizeHeight}h";

        Preset3_NameLabel.Text = Settings.Default.Preset3_Name;
        Preset3_XYLabel.Text = $"{Settings.Default.Preset3_XValue}x, {Settings.Default.Preset3_YValue}y";
        Preset3_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset3_Width}w x {Settings.Default.Preset3_Height}h";
        Preset3_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset3_ResizeWidth}w x {Settings.Default.Preset3_ResizeHeight}h";
    }

    // Highlights box content on mouse or tab
    private void SettingBox_HighlightEnter(object sender, EventArgs e)
    {
        NumericUpDown focusedBox = sender as NumericUpDown;
        focusedBox.Select();
        focusedBox.Select(0, focusedBox.Text.Length);
        if (MouseButtons == MouseButtons.Left)
        {
            selectByMouse = true;
        }
    }

    private void SettingBox_HighlightMouseDown(object sender, MouseEventArgs e)
    {
        NumericUpDown focusedBox = sender as NumericUpDown;
        if (selectByMouse)
        {
            focusedBox.Select(0, focusedBox.Text.Length);
            selectByMouse = false;
        }
    }

    // Enables Resize button if Width & Height is more than 0
    private void SettingWHBox_EnableResizeIfValid(object sender, EventArgs e)
    {
        if (SettingWidthBox.Value != 0 && SettingHeightBox.Value != 0)
        {
            EnableResizeCheckBox.Enabled = true;
        }
    }
    
    // Allows use of Resize Width & Height boxes
    private void ResizeCheckBox_EnableResize(object sender, MouseEventArgs e)
    {
        if (EnableResizeCheckBox.Checked == true)
        {
            SettingResizeWidthBox.ReadOnly = false;
            SettingResizeHeightBox.ReadOnly = false;
        }
        else
        {
            SettingResizeWidthBox.ReadOnly = true;
            SettingResizeHeightBox.ReadOnly = true;
        }
    }
    
    // Changes display of Resize depending on Resize Button value 
    private void ResizeCheckBox_Click(object sender, EventArgs e)
    {
        if (EnableResizeCheckBox.Text == "Enable Resize")
        {
            EnableResizeCheckBox.Text = "Disable Resize";
            ResizeWidthLabel.ForeColor = Color.Black;
            ResizeHeightLabel.ForeColor = Color.Black;
            SettingResizeWidthBox.Enabled = true;
            SettingResizeWidthBox.ReadOnly = false;
            SettingResizeHeightBox.Enabled = true;
            SettingResizeHeightBox.ReadOnly = false;
        }
        else
        {
            EnableResizeCheckBox.Text = "Enable Resize";
            ResizeWidthLabel.ForeColor = default;
            ResizeHeightLabel.ForeColor = default;
            SettingResizeWidthBox.Enabled = false;
            SettingResizeWidthBox.Value = 0;
            SettingResizeWidthBox.ReadOnly = true;
            SettingResizeHeightBox.Enabled = false;
            SettingResizeHeightBox.Value = 0;
            SettingResizeHeightBox.ReadOnly = true;
        }
        
    }

    // Aspect ratio for Resize Height & Width boxes when values changed, respectively
    private void SettingResizeHeightBox_AspectRatio(object sender, EventArgs e)
    {
        if (SettingWidthBox.Value == 0 || SettingHeightBox.Value == 0)
        {
            return;
        }

        if (SettingHeightBox.Value > SettingResizeHeightBox.Value)
        {
            Decimal imageWidth = SettingWidthBox.Value;
            Decimal imageHeight = SettingHeightBox.Value;
            Decimal quotient = (imageHeight / imageWidth);
            Decimal resizeWidthBoxValue = SettingResizeWidthBox.Value;
            SettingResizeHeightBox.Value = Decimal.Round((quotient * resizeWidthBoxValue));
        }
    }

    private void SettingResizeWidthBox_AspectRatio(object sender, EventArgs e)
    {
        if (SettingWidthBox.Value == 0 || SettingHeightBox.Value == 0)
        {
            return;
        }
        if (SettingWidthBox.Value > SettingWidthBox.Value)
        {
            Decimal imageWidth = SettingWidthBox.Value;
            Decimal imageHeight = SettingHeightBox.Value;
            Decimal quotient = (imageHeight / imageWidth);
            Decimal resizeWidthBoxValue = SettingResizeWidthBox.Value;
            SettingResizeHeightBox.Value = Decimal.Round((quotient * resizeWidthBoxValue));
        }
    }

    // Cancel button closes window
    private void CloseWindowButton_Click(object sender, EventArgs e)
    {
        Settings.Default.Save();
        _mainWindow.SaveNewSettingsButton.Enabled = true;
        _mainWindow.LoadPresetLabels();
        _mainWindow.EnableOrDisableButtons();

        Close();
    }

    // Settings save to or override preset buttons 

    private void Preset1Button_Click(object sender, EventArgs e)
    {
        if (SettingResizeHeightBox.Value > SettingHeightBox.Value || SettingResizeWidthBox.Value > SettingResizeWidthBox.Value)
        {
            MessageBox.Show("Resize values must be smaller than crop values");
            return;
        }

        if (Settings.Default.Preset1_XValue > 0)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to override your preset settings?", "Caption", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        Settings.Default.Preset1_Name = SettingNameTextBox.Text;
        Settings.Default.Preset1_XValue = ((int)SettingXBox.Value);
        Settings.Default.Preset1_YValue = ((int)SettingYBox.Value);
        Settings.Default.Preset1_Width = ((int)SettingWidthBox.Value);
        Settings.Default.Preset1_Height = ((int)SettingHeightBox.Value);

        if (EnableResizeCheckBox.Checked == true)
        {
            Settings.Default.Preset1_ResizeWidth = ((int)SettingResizeWidthBox.Value);
            Settings.Default.Preset1_ResizeHeight = ((int)SettingResizeHeightBox.Value);
            Settings.Default.Preset1_ResizeEnabled = true;
        }
        else
        {
            Settings.Default.Preset1_ResizeWidth = 0;
            Settings.Default.Preset1_ResizeHeight = 0;
            Settings.Default.Preset1_ResizeEnabled = false;
        }

        Settings.Default.Save();
        LoadPresetLabels();
    }

    private void Preset2Button_Click(object sender, EventArgs e)
    {
        if (SettingResizeHeightBox.Value > SettingHeightBox.Value || SettingResizeWidthBox.Value > SettingResizeWidthBox.Value)
        {
            MessageBox.Show("Resize values must be smaller than crop values");
            return;
        }

        if (Settings.Default.Preset2_XValue > 0)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to override your preset settings?", "Caption", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        
        Settings.Default.Preset2_Name = SettingNameTextBox.Text;
        Settings.Default.Preset2_XValue = ((int)SettingXBox.Value);
        Settings.Default.Preset2_YValue = ((int)SettingYBox.Value);
        Settings.Default.Preset2_Width = ((int)SettingWidthBox.Value);
        Settings.Default.Preset2_Height = ((int)SettingHeightBox.Value);

        if (EnableResizeCheckBox.Checked == true)
        {
            Settings.Default.Preset2_ResizeWidth = ((int)SettingResizeWidthBox.Value);
            Settings.Default.Preset2_ResizeHeight = ((int)SettingResizeHeightBox.Value);
            Settings.Default.Preset2_ResizeEnabled = true;
        }
        else
        {
            Settings.Default.Preset2_ResizeWidth = 0;
            Settings.Default.Preset2_ResizeHeight = 0;
            Settings.Default.Preset2_ResizeEnabled = false;
        }

        Settings.Default.Save();
        LoadPresetLabels();
    }

    private void Preset3Button_Click(object sender, EventArgs e)
    {
        if (SettingResizeHeightBox.Value > SettingHeightBox.Value || SettingResizeWidthBox.Value > SettingResizeWidthBox.Value)
        {
            MessageBox.Show("Resize values must be smaller than crop values");
            return;
        }

        if (Settings.Default.Preset3_XValue > 0)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to override your preset settings?", "Caption", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        Settings.Default.Preset3_Name = SettingNameTextBox.Text;
        Settings.Default.Preset3_XValue = ((int)SettingXBox.Value);
        Settings.Default.Preset3_YValue = ((int)SettingYBox.Value);
        Settings.Default.Preset3_Width = ((int)SettingWidthBox.Value);
        Settings.Default.Preset3_Height = ((int)SettingHeightBox.Value);

        if (EnableResizeCheckBox.Checked == true)
        {
            Settings.Default.Preset3_ResizeWidth = ((int)SettingResizeWidthBox.Value);
            Settings.Default.Preset3_ResizeHeight = ((int)SettingResizeHeightBox.Value);
            Settings.Default.Preset3_ResizeEnabled = true;
        }
        else
        {
            Settings.Default.Preset3_ResizeWidth = 0;
            Settings.Default.Preset3_ResizeHeight = 0;
            Settings.Default.Preset3_ResizeEnabled = false;
        }

        Settings.Default.Save();
        LoadPresetLabels();
    }

    private void Checkbox_CheckedChanged(object sender, EventArgs e)
    {
        if (Preset1Checkbox.Checked == true || Preset2Checkbox.Checked == true || Preset3Checkbox.Checked == true) 
        {
            ResetPresetsButton.Enabled = true;
        }
        else
        {
            ResetPresetsButton.Enabled = false;
        }
    }

    private void ResetPresetsButton_Click(object sender, EventArgs e)
    {
        if (Preset1Checkbox.Checked == true)
        {
            Settings.Default.Preset1_Name = "Save Preset 1";
            Settings.Default.Preset1_XValue = 0;
            Settings.Default.Preset1_YValue = 0;
            Settings.Default.Preset1_Width = 0;
            Settings.Default.Preset1_Height = 0;
            Settings.Default.Preset1_ResizeWidth = 0;
            Settings.Default.Preset1_ResizeHeight = 0;
            Settings.Default.Preset1_ResizeEnabled = false;

            Preset1Checkbox.Checked = false;
        }

        if (Preset2Checkbox.Checked == true)
        {
            Settings.Default.Preset2_Name = "Save Preset 2";
            Settings.Default.Preset2_XValue = 0;
            Settings.Default.Preset2_YValue = 0;
            Settings.Default.Preset2_Width = 0;
            Settings.Default.Preset2_Height = 0;
            Settings.Default.Preset2_ResizeWidth = 0;
            Settings.Default.Preset2_ResizeHeight = 0;
            Settings.Default.Preset2_ResizeEnabled = false;

            Preset2Checkbox.Checked = false;
        }

        if (Preset3Checkbox.Checked == true)
        {
            Settings.Default.Preset3_Name = "Save Preset 3";
            Settings.Default.Preset3_XValue = 0;
            Settings.Default.Preset3_YValue = 0;
            Settings.Default.Preset3_Width = 0;
            Settings.Default.Preset3_Height = 0;
            Settings.Default.Preset3_ResizeWidth = 0;
            Settings.Default.Preset3_ResizeHeight = 0;
            Settings.Default.Preset3_ResizeEnabled = false;

            Preset3Checkbox.Checked = false;
        }
        
        ResetPresetsButton.Enabled = false;
        
        LoadPresetLabels();
    }
}
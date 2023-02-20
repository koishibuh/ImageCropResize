using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageCropResize;

// TODO: Refactor ALL THE CODE

public partial class MainWindow : Form
{
    public Image OriginalImage;
    public SizeF OriginalImageDimensions;
    public SizeF ConvertedImageDimensions;
    public Bitmap imageConvertedToBitmap;
    public Bitmap CroppedImage;
    public Bitmap ResizedImage;
    string PresetName;
    int XValue;
    int YValue;
    int Width;
    int Height;
    int ResizeWidth;
    int ResizeHeight;
    bool ResizeEnabled;

    const string WaitingForClipboardImage_Message = "To begin, copy image the image you'd like to convert into clipboard.";
    const string SaveNewPresets_Message = "To begin, click New Settings and save preset settings.";
    const string ReadyToConvert_Message = "Image ready to convert! Select a preset button.";
    const string NotAnImage_Message = "Clipboard does not contain image.";
    const string Success_Message = "Image sucessfully converted and copied to clipboard.";
    const string Undo_Message = "Original image copied to clipboard, select preset button.";
    const string UnableToConvert_Message = "Unable to crop image, image is smaller than crop settings.";
    const string NoValuesSet_Message = "Unable to convert: No saved values set for this preset.";

    public MainWindow()
    {
        InitializeComponent();
        InitializeAppForm();        
    }

    public void InitializeAppForm()
    {
        LoadPresetLabels();
        EnableOrDisableButtons();

        FormClosing += AppFormClosingEventHandler;
    }

    public void LoadPresetLabels()
    {
        Preset1Button.Text = Settings.Default.Preset1_Name;
        Preset1_XYLabel.Text = $"{Settings.Default.Preset1_XValue}x, {Settings.Default.Preset1_YValue}y";
        Preset1_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset1_Width}w x {Settings.Default.Preset1_Height}h";
        Preset1_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset1_ResizeWidth}w x {Settings.Default.Preset1_ResizeHeight}h";

        Preset2Button.Text = Settings.Default.Preset2_Name;
        Preset2_XYLabel.Text = $"{Settings.Default.Preset2_XValue}x, {Settings.Default.Preset2_YValue}y";
        Preset2_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset2_Width}w x {Settings.Default.Preset2_Height}h";
        Preset2_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset2_ResizeWidth}w x {Settings.Default.Preset2_ResizeHeight}h";

        Preset3Button.Text = Settings.Default.Preset3_Name;
        Preset3_XYLabel.Text = $"{Settings.Default.Preset3_XValue}x, {Settings.Default.Preset3_YValue}y";
        Preset3_WidthHeightLabel.Text = $"Cropped: {Settings.Default.Preset3_Width}w x {Settings.Default.Preset3_Height}h";
        Preset3_ResizeWHLabel.Text = $"Resized: {Settings.Default.Preset3_ResizeWidth}w x {Settings.Default.Preset3_ResizeHeight}h";

        CheckIfReadyToConvert_Message();
    }

    public void EnableOrDisableButtons()
    {
        if (Settings.Default.Preset1_Width == 0)
        {
            Preset1Button.Enabled = false;
        }
        else
        {
            Preset1Button.Enabled = true;
        }

        if (Settings.Default.Preset2_Width == 0)
        {
            Preset2Button.Enabled = false;
        }
        else
        {
            Preset2Button.Enabled = true;
        }

        if (Settings.Default.Preset3_Width == 0)
        {
            Preset3Button.Enabled = false;
        }
        else
        {
            Preset3Button.Enabled = true;
        }


    }

    public void AppFormClosingEventHandler(object sender, FormClosingEventArgs e)
    {
        Settings.Default.Save();

        //TODO: If domain is not valid, do not save? Close? Something
    }

    private void MainWindow_Activated(object sender, EventArgs e)
    {
        CheckIfReadyToConvert_Message();
    }

    private void SaveNewSettingsButton_Click(object sender, EventArgs e)
    {
        SaveNewSettingsButton.Enabled = false;
        SaveSettings saveWindow = new SaveSettings(this);
        saveWindow.Show();
    }

    private void UndoButton_Click(object sender, EventArgs e)
    {
        ConvertedImageLabel.Text = "Converted Image";
        MessageLabel.Text = Undo_Message;
        Clipboard.SetImage(OriginalImage);
        CroppedImageBox.Image = null;
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Settings.Default.Save();
        Application.Exit();
    }

    private async void Preset1Button_Click(object sender, EventArgs e)
    {
        Preset1Button.Enabled = false;

        if (Settings.Default.Preset1_Width == 0)
        {
            NoValuesFound_Message();
            return;
        }

        await StorePreset1SettingsToVariables();

        await GrabImageFromClipboard();

        await Task.Delay(3000);
        Preset1Button.Enabled = true;
    }

    private async void Preset2Button_Click(object sender, EventArgs e)
    {
        Preset2Button.Enabled = false;

        if (Settings.Default.Preset2_Width == 0)
        {
            NoValuesFound_Message();
            return;
        }

        await StorePreset2SettingsToVariables();

        await GrabImageFromClipboard();

        await Task.Delay(3000);
        Preset2Button.Enabled = true;
    }

    private async void Preset3Button_Click(object sender, EventArgs e)
    {
        Preset3Button.Enabled = false;

        if (Settings.Default.Preset3_Width == 0)
        {
            NoValuesFound_Message();
            return;
        }

        await StorePreset3SettingsToVariables();

        await GrabImageFromClipboard();

        await Task.Delay(3000);
        Preset3Button.Enabled = true;
    }

    private async Task GrabImageFromClipboard()
    {
        if (!Clipboard.ContainsImage())
        {
            NoImageInClipboard_Message();
            return;
        }

        OriginalImage = Clipboard.GetImage();
        OriginalImageDimensions = OriginalImage.PhysicalDimension;

        imageConvertedToBitmap = new Bitmap(OriginalImage);

        OriginalImageBox.Image = imageConvertedToBitmap;
        OriginalImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

        OriginalImageLabel.Text = $"Original Image: {OriginalImageDimensions.Width}W x {OriginalImageDimensions.Height}H";

        await CropOriginalImage(imageConvertedToBitmap);
    }

    private async Task CropOriginalImage(Bitmap image)
    {
        //TODO: Check this if width/height switched, breaks at Clone
        if ((image.Width < Width) || (image.Height < Height)) 
        {
            UnableToConvertImage_Message();
            return;
        }

        try
        {
            Rectangle cropArea = new Rectangle(XValue, YValue, Width, Height);
            CroppedImage = image.Clone(cropArea, image.PixelFormat);

            CroppedImageBox.Image = CroppedImage;            
            CroppedImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        catch (Exception ex)
        {
            UnableToConvertImage_Message();
        }

        if (ResizeEnabled == false)
        {
            await CopyCroppedImageToClipboard();
        }

        await ResizeFinalImage(CroppedImage, ResizeWidth, ResizeHeight);
    }

    private async Task ResizeFinalImage(Image image, int width, int height)
    {
        Rectangle finalRectangle = new Rectangle(0, 0, width, height);
        ResizedImage = new Bitmap(width, height);

        ResizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (Graphics graphics = Graphics.FromImage(ResizedImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (ImageAttributes wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, finalRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        ConvertedImageDimensions = ResizedImage.PhysicalDimension;
        ConvertedImageLabel.Text = $"Converted Image: {ConvertedImageDimensions.Width}W x {ConvertedImageDimensions.Height}H";
        Clipboard.SetImage(ResizedImage);

        CompletedConversion_Message();
    }

    private async Task StorePreset1SettingsToVariables()
    {
        PresetName = Settings.Default.Preset1_Name;
        XValue = Settings.Default.Preset1_XValue;
        YValue = Settings.Default.Preset1_YValue;
        Width = Settings.Default.Preset1_Width;
        Height = Settings.Default.Preset1_Height;
        ResizeWidth = Settings.Default.Preset1_ResizeWidth;
        ResizeHeight = Settings.Default.Preset1_ResizeHeight;
        ResizeEnabled = Settings.Default.Preset1_ResizeEnabled;
    }

    private async Task StorePreset2SettingsToVariables()
    {
        PresetName = Settings.Default.Preset2_Name;
        XValue = Settings.Default.Preset2_XValue;
        YValue = Settings.Default.Preset2_YValue;
        Width = Settings.Default.Preset2_Width;
        Height = Settings.Default.Preset2_Height;
        ResizeWidth = Settings.Default.Preset2_ResizeWidth;
        ResizeHeight = Settings.Default.Preset2_ResizeHeight;
        ResizeEnabled = Settings.Default.Preset2_ResizeEnabled;
    }

    private async Task StorePreset3SettingsToVariables()
    {
        PresetName = Settings.Default.Preset3_Name;
        XValue = Settings.Default.Preset3_XValue;
        YValue = Settings.Default.Preset3_YValue;
        Width = Settings.Default.Preset3_Width;
        Height = Settings.Default.Preset3_Height;
        ResizeWidth = Settings.Default.Preset3_ResizeWidth;
        ResizeHeight = Settings.Default.Preset3_ResizeHeight;
        ResizeEnabled = Settings.Default.Preset3_ResizeEnabled;
    }

    private async Task CopyCroppedImageToClipboard()
    {
        ConvertedImageDimensions = CroppedImage.PhysicalDimension;
        ConvertedImageLabel.Text = $"Converted Image: {ConvertedImageDimensions.Width}W x {ConvertedImageDimensions.Height}H";
        Clipboard.SetImage(CroppedImage);
    }

    private void CompletedConversion_Message()
    {
        MessageLabel.Text = Success_Message;
        MessageLabel.ForeColor = Color.Green;
        UndoButton.Enabled = true;
    }

    private void NoImageInClipboard_Message()
    {
        MessageLabel.Text = NotAnImage_Message;
        MessageLabel.ForeColor = Color.Red;
    }

    private void CheckIfReadyToConvert_Message()
    {
        if (Preset1Button.Enabled == false && Preset2Button.Enabled == false && Preset3Button.Enabled == false)
        {
            MessageLabel.Text = SaveNewPresets_Message;
        }
        else
        {
            if (!Clipboard.ContainsImage())
            {
                MessageLabel.Text = WaitingForClipboardImage_Message;
                MessageLabel.ForeColor = Color.Red;
            }
            else
            {
                MessageLabel.Text = ReadyToConvert_Message;
                MessageLabel.ForeColor = Color.Green;
            }
        }        
    }

    private void NoValuesFound_Message()
    {
        MessageLabel.Text = NoValuesSet_Message;
        MessageLabel.ForeColor = Color.Red;
    }

    private void UnableToConvertImage_Message()
    {
        MessageLabel.Text = UnableToConvert_Message;
        ConvertedImageLabel.Text = "Converted Image";
        CroppedImageBox.Image = null;
        MessageLabel.ForeColor = Color.Red;
    } 

}
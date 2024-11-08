using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using System;
using System.IO;
using System.Timers;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using Azure.AI.Vision.ImageAnalysis;
using System.Collections;
using Azure;
using System.Runtime.InteropServices;


//In This All Code Our Team is representing Console Write Line in not exception error area, representing as Output Execution To Machine Client
//This Code Is using Azure Custom Vision To Create Solution Cheap making model classification with fourten positive tag image and 37 negative image
//This Code Is Representing Imagine Work System Input Output in Manufacturing Customer Good with 3 main function
//label teks packaging classification,
//Quality Control Automation with our team is using data from pepsi potato chips image to training model,
//Safety Checking Solution Using Azure AI Image Analysis,with simple solution  our team project algorithm using if result from image caption contain or not contain label safety rule adminnistration the output is execution exception to people is not using safety rule administration. 
namespace Pabrik
{
    public partial class MainPage : ContentPage
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
        private Timer captureTimer;
        private int captureInterval = 1000;
        private CustomVisionPredictionClient main;
        private ImageAnalysisClient ai;

        public MainPage()
        {
            InitializeComponent();
            captureTimer = new Timer(captureInterval);
            captureTimer.Interval = 1000;
            main = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(""))
            {
                Endpoint = ""
            };
            ai = new ImageAnalysisClient(new Uri(""), new Azure.AzureKeyCredential(""));
        }
        //this methode is for setting value capture time every second or more second time
        private void TimerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            captureTimer.Interval = TimerSlider.Value * 1000;
            TimerValueLabel.Text = TimerSlider.Value.ToString();
        }
        private async void OnStartCameraClicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed += OnKlasifikasiElapsed;
            captureTimer.Start();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }
        private void OnStopCameraClicked(object sender, EventArgs e)
        {
            //this methode is explain if stop button clicked all function is deactivated
            captureTimer.Elapsed += OnKlasifikasiElapsed;
            captureTimer.Elapsed += OnPrediksiElapsed;
            captureTimer.Elapsed += OnObjectClicked;
            captureTimer.Elapsed += OnLabelClicked;
            captureTimer.Elapsed += OnSafetyClicked;
            captureTimer.Stop();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed += OnKlasifikasiElapsed;
            captureTimer.Elapsed -= OnPrediksiElapsed;
            captureTimer.Elapsed -= OnObjectClicked;
            captureTimer.Elapsed -= OnLabelClicked;
            captureTimer.Elapsed -= OnSafetyClicked;
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed -= OnKlasifikasiElapsed;
            captureTimer.Elapsed += OnPrediksiElapsed;
            captureTimer.Elapsed -= OnObjectClicked;
            captureTimer.Elapsed -= OnLabelClicked;
            captureTimer.Elapsed -= OnSafetyClicked;
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed -= OnKlasifikasiElapsed;
            captureTimer.Elapsed -= OnPrediksiElapsed;
            captureTimer.Elapsed += OnObjectClicked;
            captureTimer.Elapsed -= OnLabelClicked;
            captureTimer.Elapsed -= OnSafetyClicked;
        }
        private void Button4_Clicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed -= OnKlasifikasiElapsed;
            captureTimer.Elapsed -= OnPrediksiElapsed;
            captureTimer.Elapsed -= OnObjectClicked;
            captureTimer.Elapsed += OnLabelClicked;
            captureTimer.Elapsed -= OnSafetyClicked;
        }
        private void Button5_Clicked(object sender, EventArgs e)
        {
            captureTimer.Elapsed -= OnKlasifikasiElapsed;
            captureTimer.Elapsed -= OnPrediksiElapsed;
            captureTimer.Elapsed -= OnObjectClicked;
            captureTimer.Elapsed -= OnLabelClicked;
            captureTimer.Elapsed += OnSafetyClicked;
        }
        private async void OnLabelClicked(object? sender, ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var image = await cameraView.CaptureAsync();
                    Stream stream = await image.OpenReadAsync(ScreenshotFormat.Png);
                    if (image != null)
                    {
                        var biner = BinaryData.FromStream(stream);
                        ImageAnalysisResult result = ai.Analyze(biner, VisualFeatures.Read | VisualFeatures.Read, new ImageAnalysisOptions { GenderNeutralCaption = true });
                        foreach (DetectedTextBlock block in result.Read.Blocks)
                            foreach (DetectedTextLine line in block.Lines)
                            {
                                //imagine this code is representing as Conveyor Packaging 
                                if (line.Text.Equals("Label Non Halal") && line.Text.Equals(""))
                                {
                                    await DisplayAlert("Pneumatik 2 Aktif", "Pneumatik 1 Aktif", "error");
                                }
                                if (line.Text.Equals("Label Non Halal") && line.Text.Equals(""))
                                {
                                    await DisplayAlert("Pneumatik 2 Aktif", "Pneumatik 2 Aktif", "error");
                                }
                                foreach (DetectedTextWord word in line.Words)
                                {
                                    if (word.Text.Equals("Label Non Halal") && word.Text.Equals(""))
                                    {
                                        await DisplayAlert("Pneumatik 2 Aktif", "Pneumatik 3 Aktif", "error");
                                    }
                                    if (word.Text.Equals("Label Non Halal") && word.Text.Equals(""))
                                    {
                                        await DisplayAlert("Pneumatik 2 Aktif", "Pneumatik 4 Aktif", "error");
                                    }
                                    if (word.Text.Equals("Label Non Halal") && word.Text.Equals(""))
                                    {
                                        await DisplayAlert("Pneumatik 2 Aktif", "Pneumatik 5 Aktif", "error");
                                    }
                                };
                            }
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            });
        }
        private async void OnSafetyClicked(object? sender, ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var image = await cameraView.CaptureAsync();
                    Stream stream = await image.OpenReadAsync(ScreenshotFormat.Png);
                    var biner = BinaryData.FromStream(stream);
                    ImageAnalysisResult result = ai.Analyze(biner, VisualFeatures.Caption, new ImageAnalysisOptions { GenderNeutralCaption = true });
                    var aturan = new ArrayList();
                    aturan.Add("Topi");
                    aturan.Add("Sepatu");
                    aturan.Add("Sarung Tangan");
                    aturan.Add("Mantel");
                    var output = result.Caption.Text;
                    if (output != aturan[0] && output != aturan[1])
                    {
                        indikator1.Color = Colors.Blue;
                        indikator2.Color = Colors.Blue;
                        indikator3.Color = Colors.Blue;
                        indikator4.Color = Colors.Blue;
                        indikator5.Color = Colors.Blue;
                        Console.WriteLine("Anda Tidak Diperbolehkan Masuk Dikarenaakan Belum Menggunakan Protokol Keselamatan Kerja");
                    }
                    if (output != aturan[2] && output != aturan[3])
                    {
                        await DisplayAlert("Anda Tidak Diperbolehkan Masuk Dikarenaakan Belum Menggunakan Protokol Keselamatan Kerja", "Anda Tidak Diperbolehkan Masuk Dikarenaakan Belum Menggunakan Protokol Keselamatan Kerja", "");
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            });
        }
        private async void OnObjectClicked(object? sender, ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var image = await cameraView.CaptureAsync();
                    Stream stream = await image.OpenReadAsync(ScreenshotFormat.Png);
                    var biner = BinaryData.FromStream(stream);
                    ImageAnalysisResult result = ai.Analyze(biner, VisualFeatures.Objects | VisualFeatures.Read, new ImageAnalysisOptions { GenderNeutralCaption = true });
                    foreach (DetectedObject detectedObject in result.Objects.Values)
                    {
                        if (detectedObject.Tags.Equals(""))
                        {
                            //imagine this indicator is representing as Machine Unit
                            indikator1.Color = Colors.Orange;
                            indikator2.Color = Colors.Orange;
                            indikator3.Color = Colors.Orange;
                            indikator4.Color = Colors.Orange;
                            indikator5.Color = Colors.Orange;
                        }
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            });
        }
        private async void OnPrediksiElapsed(object sender, ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var image = await cameraView.CaptureAsync();
                    if (image != null)
                    {
                        Stream stream = await image.OpenReadAsync(ScreenshotFormat.Png);
                        var analisis = main.ClassifyImage(Guid.Parse("e020c48a-99d7-44a8-a0b5-f22afd3acabe"), "Iteration1", stream);
                        var probabiliti = analisis.Predictions[0].Probability;
                        var TEKS = analisis.Predictions[0].TagName;
                        Result.Text = TEKS.ToString();
                        Probability.Text = probabiliti.ToString();
                        if (probabiliti > 10)
                        {
                            var hasil = analisis.Predictions[0].TagName;
                            Result.Text = hasil.ToString();
                            foreach (var item in hasil)
                            {
                                if (item > 100)
                                {
                                    // Update UI components
                                    indikator1.Color = Colors.Yellow;
                                    indikator2.Color = Colors.Yellow;
                                    indikator3.Color = Colors.Yellow;
                                    indikator4.Color = Colors.Yellow;
                                    indikator5.Color = Colors.Yellow;
                                    Console.WriteLine("Mesin Dimatikan");
                                }
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            });
        }
        private async void OnKlasifikasiElapsed(object sender, ElapsedEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var image = await cameraView.CaptureAsync();
                    if (image != null)
                    {
                        Stream stream = await image.OpenReadAsync(ScreenshotFormat.Png);
                        var analisis = main.ClassifyImage(Guid.Parse("e020c48a-99d7-44a8-a0b5-f22afd3acabe"), "Iteration1", stream);
                        foreach (var c in analisis.Predictions)
                        {
                            String TEKS = analisis.Predictions[0].TagName;
                            var probabiliti = analisis.Predictions[0].Probability;
                            if (probabiliti > 10)
                            {
                                String hasil = analisis.Predictions[0].TagName;
                                if (hasil.Equals("Rusak"))
                                {
                                    // Update UI components on the main thread
                                    indikator1.Color = Colors.Green;
                                    indikator2.Color = Colors.Green;
                                    indikator3.Color = Colors.Green;
                                    indikator4.Color = Colors.Green;
                                    indikator5.Color = Colors.Green;
                                    Console.WriteLine("Motor Servo Bekerja");
                                }
                                if (hasil.Equals("Tidak Rusak"))
                                {
                                    // Update UI components on the main thread
                                    indikator1.Color = Colors.Red;
                                    indikator2.Color = Colors.Red;
                                    indikator3.Color = Colors.Red;
                                    indikator4.Color = Colors.Red;
                                    indikator5.Color = Colors.Red;
                                    Console.WriteLine("Motor Servo Tidak Bekerja");
                                }
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            });
        }
    }
}
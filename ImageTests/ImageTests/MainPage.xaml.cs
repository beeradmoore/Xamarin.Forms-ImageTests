using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ByteSizeLib;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImageTests
{
    public partial class MainPage : ContentPage
    {
        readonly Random random = new Random();
        readonly Timer timer = new Timer();
        long peakMemory = 0;

        public MainPage()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                var usedMemory = GC.GetTotalMemory(false);

                if (usedMemory > peakMemory)
                    peakMemory = usedMemory;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Title = $"Stock - Used: {ByteSize.FromBytes(usedMemory).ToString("MB")}, Peak: {ByteSize.FromBytes(peakMemory).ToString("MB")}";
                });

            };
            timer.Start();


            BindingContext = GetPicsumImages(100).ToArray();
        }

        //IEnumerable<ImageSource> GetPicsumImages(int count)
        IEnumerable<string> GetPicsumImages(int count)
        {
            var width = (int)(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
            //var url = $"https://picsum.photos/{width}/200";
            
            for (int i = 0; i < count; i++)
            {
                yield return $"https://dummyimage.com/{width}x200/000/fff.png&text={i}";
                //yield return $"https://picsum.photos/id/{i}"; ///{width}/200?{random.Next()}";
            }
        }
    }
}


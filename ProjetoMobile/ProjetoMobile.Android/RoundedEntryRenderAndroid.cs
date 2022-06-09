using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjetoMobile;
using ProjetoMobile.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRenderAndroid))]

namespace ProjetoMobile.Droid
{
    [Obsolete]
    public class RoundedEntryRenderAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(10f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.DarkGray);
                gradientDrawable.SetColor(Android.Graphics.Color.DarkGray);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);
            }
        }
    }
}
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ElginM10MauiBlazor;
[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    // Contexto da Activity principal, torna-o acessível para os métodos que necessitam desse contexto.
    public static MainActivity mContext;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        mContext = this;
    }
}

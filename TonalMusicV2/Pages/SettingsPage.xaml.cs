using TonalMusicV2.PageModels;

namespace TonalMusicV2.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel settingsPageModel)
	{
		InitializeComponent();
        BindingContext = settingsPageModel;
    }
}
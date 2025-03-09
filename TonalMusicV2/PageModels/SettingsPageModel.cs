using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Globalization;
using TonalMusicV2.Resources.Languages;

namespace TonalMusicV2.PageModels
{
    public partial class SettingsPageModel : ObservableObject
    {
        private const string LanguagePreferenceKey = "AppLanguage";

        [ObservableProperty]
        private string settingsTitle;

        [ObservableProperty]
        private string languageLabel;

        [ObservableProperty]
        private string pickerPlaceholder;

        public ObservableCollection<string> AvailableLanguages { get; } =
            new ObservableCollection<string> { "Español", "English" };

        [ObservableProperty]
        private string selectedLanguage;

        public SettingsPageModel()
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            string savedLanguage = Preferences.Get(LanguagePreferenceKey, "Español");

            SelectedLanguage = savedLanguage;
            ApplyLanguage(savedLanguage);
        }

        partial void OnSelectedLanguageChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Preferences.Set(LanguagePreferenceKey, value);
                ApplyLanguage(value);
                ReloadShell();
            }
        }

        private void ReloadShell()
        {
            var current = Application.Current.MainPage;
            Application.Current.MainPage = new AppShell();
            current.Handler?.DisconnectHandler();
        }

        private void ApplyLanguage(string language)
        {
            if (language == "English")
            {
                CultureInfo.CurrentCulture = new CultureInfo("en");
                AppResources.Culture = CultureInfo.CurrentCulture;
                SettingsTitle = "Settings";
                LanguageLabel = "Select Language:";
                PickerPlaceholder = "Choose language";
            }
            else
            {
                CultureInfo.CurrentCulture = new CultureInfo("es");
                AppResources.Culture = CultureInfo.CurrentCulture;
                SettingsTitle = "Configuración";
                LanguageLabel = "Seleccionar idioma:";
                PickerPlaceholder = "Elige un idioma";
            }
        }
    }
}

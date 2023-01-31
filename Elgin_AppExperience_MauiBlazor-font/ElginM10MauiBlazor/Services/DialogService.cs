namespace ElginM10MauiBlazor.Services;
internal class DialogService : IDialogService
{
    public async Task DisplayAlert(string title, string message)
        => await Application.Current.MainPage.DisplayAlert(title, message, "OK");

    public async Task DisplayAlert(string title, string message, string cancel)
        => await Application.Current.MainPage.DisplayAlert(title, message, cancel);

    public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        => await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

    public async Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
    => await Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);

    public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        => await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
}

namespace ElginM10MauiBlazor.Services;

internal interface IDialogService
{
    Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    Task DisplayAlert(string title, string message);
    Task DisplayAlert(string title, string message, string cancel);
    Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "");
}
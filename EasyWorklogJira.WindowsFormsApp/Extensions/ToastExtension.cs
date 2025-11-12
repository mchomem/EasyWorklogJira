namespace EasyWorklogJira.WindowsFormsApp.Extensions;

public static class ToastExtension
{
    public static void ShowSuccess(this Form form, string message)
    {
        var toast = GlobalSetup(form);
        toast.ShowSuccess(message);
    }

    public static void ShowWarning(this Form form, string message)
    {
        var toast = GlobalSetup(form);
        toast.ShowWarning(message);
    }

    public static void ShowError(this Form form, string message)
    {
        var toast = GlobalSetup(form);
        toast.ShowError(message);
    }

    private static Toast GlobalSetup(Form form)
    {
        var toast = new Toast(ToastrPosition.TopLeft, duration: 3000, enableSoundEffect: true);
        toast.MdiParent = form.MdiParent;
        return toast;
    }
}

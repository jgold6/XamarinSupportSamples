namespace SearchSample
{
    public static class ControllerHelpers
    {
        public static void TitleCountUpdater(int count)
        {
            var title = AppDelegate.Self.MainNavController.NavigationBar.TopItem.Title;
            // Remove title count if one exists
            if (title.LastIndexOf('(') != -1)
            {
                title = title.Substring(0, title.LastIndexOf('(')).Trim();
            }
            title += " (" + count + ")";
            AppDelegate.Self.MainNavController.NavigationBar.TopItem.Title = title;
        }
    }
}
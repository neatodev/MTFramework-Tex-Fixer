namespace MTFRTexFix
{
    internal static class Program
    {
        /// <summary>
        /// @author github.com/neatodev
        /// </summary>

        private static Form1 App = new();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(App);
        }
    }
}
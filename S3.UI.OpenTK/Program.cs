using System;
using S3.Services;

namespace S3.UI.OpenTK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //var data = CommonService.GetData(@"TestData\D\", "D");
            var data = CommonService.GetData(@"TestData\E\", "E");

            var game = new GameOpenTK(800, 800, "Rubin Xiao - OpenTK")
            {
                DataModel = data
            };

            game.Run(30);
        }
    }
}

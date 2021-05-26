using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace UITest.Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        private AndroidApp _app;
        static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MyLabel").Text("Hello, Habrahabr!");
        static readonly Func<AppQuery, AppQuery> Button = c => c.Marked("MyButton");
        static readonly Func<AppQuery, AppQuery> DoneMessage = c => c.Marked("MyLabel").Text("Was clicked");

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
            //// Arrange - Nothing to do because the queries have already been initialized.
            //AppResult[] result = app.Query(InitialMessage);
            //Assert.IsTrue(result.Any(), "The initial message string isn't correct - maybe the app wasn't re-started?");

            //// Act
            //app.Tap(Button);
            //app.WaitForElement(DoneMessage, "Timeout", TimeSpan.FromSeconds(2));

            //// Assert
            //result = app.Query(DoneMessage);
            //Assert.IsTrue(result.Any(), "The 'clicked' message is not being displayed.");
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        public void SetUp()
        {

#if TestiOS

            Path = "path/to/app";
            _app = ConfigureApp.iOS
            .AppBundle(Path)
            //Xcode ->Window ->Devices -> Identifier
            .DeviceIdentifier("Identifier")             
            .StartApp();
#else
            Path = "path/to/apk";
            _app = ConfigureApp
                .Android
                .ApkFile(Path)
                //.EnableLocalScreenshots ()
                .StartApp();
#endif
        }

        public string Path { get; set; }
    }
}

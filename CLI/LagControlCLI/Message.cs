using System;
using System.Reflection;

namespace LagControlCLI
{
    public class Message
    {
        public static void OnStart()
        {
            var imageLag = $"::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}:::::L::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}::2::::::::::::::::::::::::::::::::::::::::::::::::2222222:::::::::::::::::::::::::::::::::::2L77GGGGG7L22::::::::::::::{Environment.NewLine}::::LGAAAAA@L2:::::::::::::::::::::::::::::::::::L@AAAAAAA@L::::::::::::::::::::::::::::27@AAAAAAAAAAAAAAAAA@L2:::::::::{Environment.NewLine}::::LGAAAAA@L2::::::::::::::::::::::::::::::::::LGAAAAAAAAAGL:::::::::::::::::::::::::L7AAAAAAAAAAAAAAAAAAAAAA@L::::::::{Environment.NewLine}::::LGAAAAA@L2:::::::::::::::::::::::::::::::::2G@AAAAAAAAAAGL:::::::::::::::::::::::7@AAAAAA@GL2:::::LGAAAAAAAA72::::::{Environment.NewLine}::::LGAAAAA@L2::::::::::::::::::::::::::::::::27AAAAAAGAAAAAAG2::::::::::::::::::::27AAAAAAA72::::::::::27AAAAAA@L::::::{Environment.NewLine}:L2:LGAAAAA@L2::::::::::::::22::::::::::2L2::27@AAAAAGLG@AAAAAG2:::::::::::::::2L2:7@AAAAA@7::::::::::::::::::::::::::::{Environment.NewLine}:::::LAAAAA@LLL2:::::::::::::::::::::::::::::2LGAAAA@L:22L@AAAA7LL2::::2:::::::::::2L@AAAAGLL222::::::::::::::::::::::::{Environment.NewLine}:227@AAAAGL2::::2:::::::::::::::::::::::::27@AAAAAGL:::7@AAAAGL2:::::::::::::::22LGAAAAAAL2::::::::::::::LAAAAAA7LL2::::{Environment.NewLine}:::7@AAAAA@L::::::::::::::::::::::::::::::L@AAAAA@L::::27@AAAAA@L2:::::::::::::::LGAAAAAA72:::::::::::::LGAAA@77L:::::::{Environment.NewLine}:::7@AAAAA@L:::::::::::::::::::::::::::::L@AAAAAA@GGGGGG@@AAAAAAGL::::2::::::::::2GAAAAAAG2:::::::::::::LGAAAAAA72::::::{Environment.NewLine}:::7@AAAAA@L::::::::::::::::::::::::::::L@AAAAAAAAAAAAAAAAAAAAAAAGL:::::::::::::::L@AAAAAA72::::::::::::LGAAAAAA72::::::{Environment.NewLine}:::7@AAAAA@L:::::::::::::::::::::::::::LGAAAAAAAAAAAAAAAAAAAAAAAAAG2:::::::::::::::7@AAAAAAGL:::::::::::LGAAAAAA72::::::{Environment.NewLine}:::7@AAAAA@7LLLLLLLLLLLLLL2222::::::::2GAAAAAAGL:::::::::::7GAAAAAA7L::::::::::::2::L@AAAAAAA@GL2::2L7@AAAAAAAAA72::::::{Environment.NewLine}:::7@AAAAAAAAAAAAAAAAAAAAAGL:::::::::27AAAAAA@L:::::::::::::7@AAAAAAG2:::::::::::::::2LGAAAAAAAAAAAAAAAAAAAAAAG72:::::::{Environment.NewLine}:::7@AAAAAAAAAAAAAAAAAAAAAG2::::::::27@AAAAAA7L2:::::::::::::7@AAAAAA72::::::::::::::::::LG@AAAAAAAAAAAAA@GL2:::::2:::::{Environment.NewLine}::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::{Environment.NewLine}::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::";
            Console.WriteLine(imageLag);
        }

        public static void Version()
        {
            var versionString = Assembly.GetEntryAssembly()?
                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                        .InformationalVersion
                        .ToString();

            Console.WriteLine(versionString);
        }
    }
}

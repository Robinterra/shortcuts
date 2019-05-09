using System.IO;

namespace Testing
{
    // =================================================================

    public static class ShortcutsTest
    {

        // -------------------------------------------------------------

        /**
         *
         */
        private static Shortcuts SC;

        /**
         *
         */
        private static string targetname = "C:\\temp\\test.txt";

        /**
         *
         */
        private static string arguments = "--foo --bar:\"hallo welt\" /?";

        /**
         *
         */
        private static string lnkname = "C:\\temp\\test.lnk";

        /**
         *
         */
        private static string iconLocation = "C:\\temp\\icon.ico";

        /**
         *
         */
        private static string workingDirectory = "C:\\temp\\";

        // -------------------------------------------------------------

        /**
         *
         */
        public static bool Run (  )
        {
            bool rc_bool = true;

            // -------------------------------

            rc_bool &= ShortcutsTest.TestTargetName (  );
            rc_bool &= ShortcutsTest.TestArguments (  );
            rc_bool &= ShortcutsTest.TestIconLocation (  );
            rc_bool &= ShortcutsTest.TestWorkingDirectory (  );

            // -------------------------------

            return rc_bool;
        }

        // -------------------------------------------------------------

        /**
         *
         */
        public static bool TestTargetName (  )
        {
            try
            {
                //Arrange
                ShortcutsTest.SC = new Shortcuts (  );

                //Act
                ShortcutsTest.SC.TargetPath = ShortcutsTest.targetname;
                ShortcutsTest.SC.Write ( ShortcutsTest.lnkname );

                ShortcutsTest.SC = new Shortcuts ( ShortcutsTest.lnkname );
                ShortcutsTest.SC.Read ( ShortcutsTest.lnkname );

                //Assert
                return ShortcutsTest.SC.TargetPath == ShortcutsTest.targetname;
            }
            catch
            {
                return false;
            }
        }

        // -------------------------------------------------------------

        /**
         *
         */
        public static bool TestArguments (  )
        {
            try
            {
                //Arrange
                ShortcutsTest.SC = new Shortcuts (  );

                //Act

                ShortcutsTest.SC.Arguments = ShortcutsTest.arguments;
                ShortcutsTest.SC.Write ( ShortcutsTest.lnkname );

                ShortcutsTest.SC = new Shortcuts ( ShortcutsTest.lnkname );
                ShortcutsTest.SC.Read ( ShortcutsTest.lnkname );

                //Assert
                return ShortcutsTest.SC.Arguments == ShortcutsTest.arguments;
            }
            catch
            {
                return false;
            }
        }

        // -------------------------------------------------------------

        /**
         *
         */
        public static bool TestIconLocation (  )
        {
            try
            {
                //Arrange
                ShortcutsTest.SC = new Shortcuts (  );

                //Act

                ShortcutsTest.SC.IconLocation = ShortcutsTest.iconLocation;
                ShortcutsTest.SC.Write ( ShortcutsTest.lnkname );

                ShortcutsTest.SC = new Shortcuts ( ShortcutsTest.lnkname );
                ShortcutsTest.SC.Read ( ShortcutsTest.lnkname );

                //Assert
                return ShortcutsTest.SC.IconLocation == ShortcutsTest.iconLocation;
            }
            catch
            {
                return false;
            }
        }

        // -------------------------------------------------------------

        /**
         *
         */
        public static bool TestWorkingDirectory (  )
        {
            try
            {
                //Arrange
                ShortcutsTest.SC = new Shortcuts (  );

                //Act

                ShortcutsTest.SC.WorkingDirectory = ShortcutsTest.workingDirectory;
                ShortcutsTest.SC.Write ( ShortcutsTest.lnkname );

                ShortcutsTest.SC = new Shortcuts ( ShortcutsTest.lnkname );
                ShortcutsTest.SC.Read ( ShortcutsTest.lnkname );

                //Assert
                return ShortcutsTest.SC.WorkingDirectory == ShortcutsTest.workingDirectory;
            }
            catch
            {
                return false;
            }
        }

        // -------------------------------------------------------------

    }

    // =================================================================
}
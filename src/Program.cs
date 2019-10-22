using System.IO;

namespace Shortcut
{
    public static class Program
    {

        #region vars

        private static string WorkingDirectory;

        private static string TargetPath;

        private static string SavePath;

        private static string Arguments;

        private static string IconLocation;

        private static bool Admin = false;

        private static bool IsCreate = false;

        #endregion vars

        #region methods

        public static int Main ( string[] args )
        {
            if (!Program.CheckArgs ( args )) return -1;

            foreach ( string arg in args )
            {
                if ( !Program.ParseCommandLine ( arg ) ) return -1;
            }

            if ( Program.IsCreate ) Program.CreateShortCut (  );

            return 0;
        }

        public static bool CreateShortCut (  )
        {
            Shortcuts neuerShortCut = new Shortcuts (  );

            if ( !string.IsNullOrEmpty ( Program.WorkingDirectory ) ) neuerShortCut.WorkingDirectory = Program.WorkingDirectory;
            if ( !string.IsNullOrEmpty ( Program.TargetPath ) ) neuerShortCut.TargetPath = Program.TargetPath;
            if ( !string.IsNullOrEmpty ( Program.Arguments ) ) neuerShortCut.Arguments = Program.Arguments;
            if ( !string.IsNullOrEmpty ( Program.IconLocation ) ) neuerShortCut.IconLocation = Program.IconLocation;
            neuerShortCut.StartWithAdmin = Program.Admin;

            if ( !string.IsNullOrEmpty ( Program.SavePath ) ) neuerShortCut.Write ( Program.SavePath );

            return true;
        }

        public static bool ParseCommandLine ( string arg )
        {
            if ( string.IsNullOrEmpty ( arg ) ) return false;

            if ( arg == "--create" ) return Program.IsCreate = true;

            if ( arg == "--Admin" ) return Program.Admin = true;

            if ( Program.TestArg ( arg, "--WorkingDirectory:", ref Program.WorkingDirectory ) ) return true;

            if ( Program.TestArg ( arg, "--TargetPath:", ref Program.TargetPath ) ) return true;

            if ( Program.TestArg ( arg, "--SavePath:", ref Program.SavePath ) ) return true;

            if ( Program.TestArg ( arg, "--Arguments:", ref Program.Arguments ) ) return true;

            if ( Program.TestArg ( arg, "--IconLocation:", ref Program.IconLocation ) ) return true;

            return false;
        }

        public static bool TestArg ( string arg, string para, ref string Variable )
        {
            string Test = arg.Replace ( para, string.Empty );
            if ( Test == arg ) return false;

            Variable = Test;

            return true;
        }

        private static bool CheckArgs ( string[] args )
        {
            if ( args == null ) return !Program.PrintHelp (  );
            if ( args.Length == 0 ) return !Program.PrintHelp (  );

            return true;
        }

        private static bool PrintHelp (  )
        {
            System.Console.WriteLine ( " program.exe --create --TargetPath:C:\\Program.exe \"--SavePath:C:\\Users\\Robin DAndrea\\Desktop\\program.lnk\" " );

            return true;
        }

        #endregion methods

    }
}

// -- [EOF] --
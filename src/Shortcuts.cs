using System.IO;
using System.Diagnostics;

namespace System.IO
{

    // =================================================================

    /**
     * Zum erstellen und auslesen von Verknüpfungen
     * @author Robin D'Andrea
     * @Date 2019.05.08
     */
    public class Shortcuts
    {

        #if (LOGLEVEL_DEBUG)
            public const string KLASSE = "Shortcuts";
        #endif

        // -------------------------------------------------------------

        #region const

        // -------------------------------------------------------------

        /** [CONST]
         * Gibt den Target Path einer Verknüpfung wieder
         */
        private const string TARGETPATH = "TargetPath";

        /** [CONST]
         * Gibt die Argumente einer Verknüpfung wieder
         */
        private const string ARGUMENTS = "Arguments";

        /** [CONST]
         * Gibt den Pfad zum Icon einer Verknüpfung wieder
         */
        private const string ICONLOCATION = "IconLocation";

        /** [CONST]
         * Gibt den Pfad wieder in dem das Ziel ausgeführt wird
         */
        private const string WORKINGDIRECTORY = "WorkingDirectory";

        /** [CONST]
         * Gibt den HotKey der Verknüpfung wieder
         */
        private const string HOTKEY = "HotKey";

        /** [CONST]
         * Gibt den WindowStyle wieder
         */
        private const string WINDOWSTYLE = "WindowStyle";

        /** [CONST]
         * Gibt den WScript Object wieder
         */
        private const string WSCRIPT = "WScript.Echo CreateObject (\"WScript.Shell\").CreateShortCut(WScript.Arguments(0)).";

        // -------------------------------------------------------------

        #endregion const

        // -------------------------------------------------------------

        #region vars

        // -------------------------------------------------------------

        /**
         * Die Url wohin die Verknüpfung zeigt
         */
        private string targetPath_string;

        /**
         * Die Argumente, die in der Verknüpfung hinterlegt worden
         */
        private string arguments_string;

        /**
         * Der Pfad zum Icon einer Verknüpfung
         */
        private string iconLocation_string;

        /**
         * Der Pfad in dem das Ziel ausgeführt wird
         */
        private string workingDirectory_string;

        /**
         * Der HotKey der Verknüpfung
         */
        private string hotKey_string;

        /**
         * Der WindowStyle
         */
        private string windowStyle_string;

        /** [STATIC]
         * Der Temppfad wo die VB Scripte abgelegt werden
         */
        private static string tempPath_string = Path.GetTempPath (  ) + "grimoire\\";

        // -------------------------------------------------------------

        #endregion vars

        // -------------------------------------------------------------

        #region get/set

        // -------------------------------------------------------------

        /**
         * Kann das Ziel der Verknüpfung setzen
         *
         * @return Gibt das Ziel der Verknüpfung wieder
         */
        public string TargetPath
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".TargetPath GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "targetPath_string", targetPath_string );
                #endif

                return this.targetPath_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".TargetPath SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "targetPath_string", targetPath_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                this.targetPath_string = value;
            }
        }

        // -------------------------------------------------------------

        /**
         * Die Argumente die in der Verknüpfung hinterlegt werden sollen
         *
         * @return Gibt die Argumente der Verknüpfung wieder
         */
        public string Arguments
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".Arguments GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "arguments_string", arguments_string );
                #endif

                return this.arguments_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".Arguments SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "arguments_string", arguments_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                this.arguments_string = value;
            }
        }

        // -------------------------------------------------------------

        /**
         * Setzt den Pfad zum Icon der Verknüpfung
         *
         * @return Gibt den Pfad zum Icon der Verknüpfung zurück
         */
        public string IconLocation
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".IconLocation GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "iconLocation_string", iconLocation_string );
                #endif

                return this.iconLocation_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".IconLocation SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "iconLocation_string", iconLocation_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                int posKomma = value.IndexOf ( "," );
                if ( posKomma != -1 )
                {
                    value = value.Substring ( 0, posKomma );
                }

                this.iconLocation_string = value;
            }
        }

        // -------------------------------------------------------------

        /**
         * Setzt den Pfad in dem das Ziel ausgeführt wird
         *
         * @return Gibt den Pfad in dem das Ziel ausgeführt wird zurück
         */
        public string WorkingDirectory
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".WorkingDirectory GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "workingDirectory_string", workingDirectory_string );
                #endif

                return this.workingDirectory_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".WorkingDirectory SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "workingDirectory_string", workingDirectory_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                this.workingDirectory_string = value;
            }
        }

        // -------------------------------------------------------------

        /**
         * Setzt den HotKey der Verknüpfung
         *
         * @return Gibt den HotKey der Verknüpfung wieder
         */
        public string HotKey
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".HotKey GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "hotKey_string", hotKey_string );
                #endif

                return this.hotKey_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".HotKey SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "hotKey_string", hotKey_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                this.hotKey_string = value;
            }
        }

        // -------------------------------------------------------------

        /**
         * Setzt den WindowStyle der Verknüpfung
         *
         * @return Gibt den WindowStyle der Verknüpfung wieder
         */
        public string WindowStyle
        {
            get
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".WindowStyle GET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "windowStyle_string", windowStyle_string );
                #endif

                return this.windowStyle_string;
            }
            set
            {
                #if (LOGLEVEL_DEBUG)
                    string methodeName = KLASSE + ".WindowStyle SET";
                    Logging.Trace ( methodeName );
                    Logging.Debug ( methodeName, "windowStyle_string", windowStyle_string );
                    Logging.Debug ( methodeName, "value", value );
                #endif

                this.windowStyle_string = value;
            }
        }

        // -------------------------------------------------------------

        #endregion get/set

        // -------------------------------------------------------------

        #region ctor

        // -------------------------------------------------------------

        /**
         * Konstuktor dieser Klasse
         */
        public Shortcuts ( string _Path_string ) : this (  )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = string.Format( "new {0} ( string _Path_string ) - Konstruktor", KLASSE );
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            // -------------------------------

            this.Read ( _Path_string );
        }

        // -------------------------------------------------------------

        /**
         * Konstuktor dieser Klasse
         */
        public Shortcuts (  )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = string.Format( "new {0} (  ) - Konstruktor", KLASSE );
                Logging.Trace ( methodeName );
            #endif

            // -------------------------------

            Shortcuts.CreateTempVBSFiles (  );
        }

        // -------------------------------------------------------------

        /**
         * Der Dekonstruktor zu dieser Klasse
         */
        ~Shortcuts (  )
        {
            #if (LOGLEVEL_DEBUG)
                Logging.Trace ( KLASSE + " - Dekonstruktor" );
            #endif

            // -------------------------------

            this.targetPath_string       = null;
            this.arguments_string        = null;
            this.iconLocation_string     = null;
            this.workingDirectory_string = null;
            this.hotKey_string           = null;
            this.windowStyle_string      = null;
        }

        // -------------------------------------------------------------

        #endregion ctor

        // -------------------------------------------------------------

        #region methods

        // -------------------------------------------------------------

        /**
         * Überschreibt eine vorhandene Verknüpfung mit neu gestzten werten, wenn keine existiert wird eine angelegt
         *
         * @param[in] _Path_string (string)
         *
         * @return (bool) Wenn true zurück gegeben wird gab es keine probleme. Bei false konnte keine Datei angelegt werden oder geupdatet werden
         */
        public bool Update ( string _Path_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".Update ( string _Path_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            if ( string.IsNullOrEmpty ( _Path_string ) ) return false;

            // -------------------------------

            Shortcuts.SetLNKValue ( _Path_string, this.TargetPath, VBSFileNames.SetTargetPath );

            Shortcuts.SetLNKValue ( _Path_string, this.Arguments, VBSFileNames.SetArguments );

            Shortcuts.SetLNKValue ( _Path_string, this.IconLocation, VBSFileNames.SetIconLocation );

            Shortcuts.SetLNKValue ( _Path_string, this.WorkingDirectory, VBSFileNames.SetWorkingDirectory );

            Shortcuts.SetLNKValue ( _Path_string, this.HotKey, VBSFileNames.SetHotKey );

            Shortcuts.SetLNKValue ( _Path_string, this.WindowStyle, VBSFileNames.SetWindowStyle );

            // -------------------------------

            _Path_string = null;

            return File.Exists ( _Path_string );
        }

        // -------------------------------------------------------------

        /**
         * Speichert die Verknüpfung, wenn diese bereits exestiert wird diese vorher gelöscht
         *
         * @param[in] _Path_string (string) Der Pfad wo die Verknüpfung gespeichert werden soll
         *
         * @return (bool) Wenn true zurück gegeben wird gab es keine probleme. Bei false konnte keine Datei angelegt werden
         */
        public bool Write ( string _Path_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".Write ( string _Path_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            if ( string.IsNullOrEmpty ( _Path_string ) ) return false;

            // -------------------------------

            if ( File.Exists ( _Path_string ) )
            {
                File.Delete ( _Path_string );
            }

            return this.Update ( _Path_string );
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Liest eine bereits vorhandene Verknüpfung ein
         *
         * @param[in] _Path_string (string) Der Pfad von wo die Verknüpfung eingelesen werden soll
         *
         * @return (bool) Wenn true zurück gegeben wird gab es keine probleme. Bei false konnte keine Datei eingelesen werden
         */
        public bool Read ( string _Path_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".Read ( string _Path_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            if ( string.IsNullOrEmpty ( _Path_string ) ) return false;
            if ( !File.Exists ( _Path_string ) ) return false;

            // -------------------------------

            this.TargetPath = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetTargetPath );

            this.Arguments = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetArguments );

            this.IconLocation = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetIconLocation );

            this.WorkingDirectory = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetWorkingDirectory );

            this.HotKey = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetHotKey );

            this.WindowStyle = Shortcuts.GetLNKValue ( _Path_string, VBSFileNames.GetWindowSytle );

            // -------------------------------

            _Path_string = null;

            return true;
        }

        // -------------------------------------------------------------

        /**
         * Startet eine VBS Datei
         *
         * @param[in] _Path_string      (string) Der Pfad zu der VBS Datei
         * @param[in] _Argumente_string (string) Die Argumente, die der VBS Datei übergeben werden sollen
         *
         * @return (string) Das Resultat, welches die VBS Datei zurück liefert
         */
        private static string RunVBSFile ( string _Path_string, string _Argumente_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".RunVBSFile ( string _Path_string, string _Argumente_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
                Logging.Debug ( methodeName, "_Argumente_string", _Argumente_string );
            #endif

            // -------------------------------

            string result_string = "";
            Process Type_Process = new Process (  );

            Type_Process.StartInfo.FileName               = "cscript";
            Type_Process.StartInfo.Arguments              = "//nologo \"" + _Path_string + "\" " + _Argumente_string;
            Type_Process.StartInfo.UseShellExecute        = false;
            Type_Process.StartInfo.RedirectStandardOutput = true;

            Type_Process.Start (  );
            result_string = Type_Process.StandardOutput.ReadToEnd (  );
            Type_Process.Close (  );

            result_string = result_string.Replace ( "\r\n", "" );

            // -------------------------------

            Type_Process      = null;
            _Path_string      = null;
            _Argumente_string = null;

            #if (LOGLEVEL_DEBUG)
                Logging.Debug ( methodeName, "result_string", result_string );
            #endif

            return result_string;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Gibt den TargetPath einer Verknüpfung wieder
         *
         * @param[in] _Path_string (string) Der Pfad zu der Verknüpfung
         *
         * @return (string) Der TargetPath
         */
        private static string GetLNKValue ( string _Path_string, string _ValueFile )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".GetTargetPath ( string _Path_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            // -------------------------------

            string result_string    = string.Empty;
            string Arguments_string = string.Format ( "\"{0}\"", _Path_string );
            string TempPath_string  = tempPath_string + _ValueFile;

            result_string = Shortcuts.RunVBSFile ( TempPath_string, Arguments_string );

            // -------------------------------

            _Path_string     = null;
            Arguments_string = null;
            TempPath_string  = null;

            return result_string;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Setzt den TargetPath einer Verknüpfung
         *
         * @param[in] _Path_string       (string) Der Pfad zu der Verknüpfung
         * @param[in] _TargetPath_string (string) Der TargetPath
         */
        private static bool SetLNKValue ( string _Path_string, string _TargetPath_string, string _ValueFile )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".SetTargetPath ( string _Path_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_Path_string", _Path_string );
            #endif

            if ( string.IsNullOrEmpty ( _TargetPath_string ) ) return false;

            // -------------------------------

            string Arguments_string = string.Format ( "\"{0}\" \"{1}\"", _Path_string, _TargetPath_string.Replace ( "\"", "\\'" ) );
            string TempPath_string  = tempPath_string + _ValueFile;

            Shortcuts.RunVBSFile ( TempPath_string, Arguments_string );

            // -------------------------------

            _Path_string       = null;
            _TargetPath_string = null;
            Arguments_string   = null;
            TempPath_string    = null;

            return true;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Erstellt alle nötigen VBS Dateien im Temp ordner
         */
        private static void CreateTempVBSFiles (  )
        {
            #if (LOGLEVEL_DEBUG)
                Logging.Trace ( KLASSE + ".CreateTempVBSFiles (  )" );
            #endif

            // -------------------------------

            string TempPath_string = Shortcuts.tempPath_string;
            bool PathNotExists = !Directory.Exists ( TempPath_string );

            if ( PathNotExists )
            {
                Directory.CreateDirectory ( TempPath_string );
            }

            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetTargetPath, Shortcuts.WSCRIPT + Shortcuts.TARGETPATH );
            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetArguments, Shortcuts.WSCRIPT + Shortcuts.ARGUMENTS );
            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetIconLocation, Shortcuts.WSCRIPT + Shortcuts.ICONLOCATION );
            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetWorkingDirectory , Shortcuts.WSCRIPT + Shortcuts.WORKINGDIRECTORY );
            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetHotKey, Shortcuts.WSCRIPT + Shortcuts.HOTKEY );
            Shortcuts.CreateVBSFile ( TempPath_string + VBSFileNames.GetWindowSytle, Shortcuts.WSCRIPT + Shortcuts.WINDOWSTYLE );

            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetTargetPath, Shortcuts.TARGETPATH );
            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetArguments, Shortcuts.ARGUMENTS );
            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetIconLocation, Shortcuts.ICONLOCATION );
            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetWorkingDirectory, Shortcuts.WORKINGDIRECTORY );
            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetHotKey, Shortcuts.HOTKEY );
            Shortcuts.CreateVBS_SETValue ( TempPath_string + VBSFileNames.SetWindowStyle, Shortcuts.WINDOWSTYLE );

            // -------------------------------

            TempPath_string = null;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Zum erstellen einer VBS Datei, wenn die Datei bereits exestiert wird diese nicht angelgt
         *
         * @param[in] _FilePath_string   (string) Der Pfad wo die VBS Datei angelegt werden soll
         * @param[in] _VBSContent_string (string) Der Inhalt der VBS Datei
         */
        private static bool CreateVBSFile ( string _FilePath_string, string _VBSContent_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".CreateVBSFile ( string _FilePath_string, string _VBSContent_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_FilePath_string", _FilePath_string );
                Logging.Debug ( methodeName, "_VBSContent_string", _VBSContent_string );
            #endif

            if ( File.Exists ( _FilePath_string ) )
            {
                #if (LOGLEVEL_DEBUG)
                    Logging.Trace ( methodeName + " - _FilePath_string exists" );
                #endif

                return true;
            }

            // -------------------------------

            #if (LOGLEVEL_DEBUG)
                Logging.Trace ( methodeName + " - _FilePath_string wird angelegt" );
            #endif

            File.WriteAllText ( _FilePath_string, _VBSContent_string );

            // -------------------------------

            _FilePath_string   = null;
            _VBSContent_string = null;

            return true;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Erstellt den Inhalt für eine VBS Datei.
         *
         * @param[in] _zusatz_string (string) Die Zeile, der zugehöhrigen set art
         *
         * @return (string) Der Inhalt für eine VBS Datei
         */
        private static string CreateVBS_ContentSave ( string _zusatz_string )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".CreateVBS_ContentSave ( string _zusatz_string )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_zusatz_string", _zusatz_string );
            #endif

            // -------------------------------

            string result_string;
            result_string  = "Set WshShell    = CreateObject(\"Wscript.shell\")\r\n";
            result_string += "Set derShortCut = WshShell.CreateShortcut(WScript.Arguments(0))\r\n";
            result_string += "derShortCut." + _zusatz_string + " = Replace(WScript.Arguments(1),\"\\'\",Chr(34))\r\n";
            result_string += "derShortCut.Save";

            // -------------------------------

            _zusatz_string = null;

            return result_string;
        }

        // -------------------------------------------------------------

        /** [STATIC]
         * Legt eine VBS Datei an, die den TargetPath aus einer Verknüpgunh festlegt
         *
         * @param[in] _FilePath_string (string) Der Pfad wo die VBS Datei liegen soll
         */
        private static void CreateVBS_SETValue ( string _FilePath_string, string _Value )
        {
            #if (LOGLEVEL_DEBUG)
                string methodeName = KLASSE + ".CreateVBS_SETValue ( string _FilePath_string, string _Value )";
                Logging.Trace ( methodeName );
                Logging.Debug ( methodeName, "_FilePath_string", _FilePath_string );
                Logging.Debug ( methodeName, "_Value", _Value );
            #endif

            // -------------------------------

            string VBS_Content_string = CreateVBS_ContentSave ( _Value );

            Shortcuts.CreateVBSFile ( _FilePath_string, VBS_Content_string );

            // -------------------------------

            _Value             = null;
            _FilePath_string   = null;
            VBS_Content_string = null;
        }

        // -------------------------------------------------------------

        public override string ToString (  )
        {
            #if (LOGLEVEL_DEBUG)
                Logging.Trace ( KLASSE + ".ToString (  )" );
            #endif

            // -------------------------------

            //return this.ToJSON (  );

            return base.ToString (  );
        }

        // -------------------------------------------------------------

        #endregion methods

        // -------------------------------------------------------------

    }

    // =================================================================

    /**
     * Die Dateinamen, der VBScripte
     * @author roan
     * @date 2018.02.28
     */
    struct VBSFileNames
    {
        public const string GetTargetPath       = "GetTargetPath.vbs";
        public const string GetArguments        = "GetArguments.vbs";
        public const string GetIconLocation     = "GetIconLocation.vbs";
        public const string GetWorkingDirectory = "GetWorkingDirectory.vbs";
        public const string GetHotKey           = "GetHotKey.vbs";
        public const string GetWindowSytle      = "GetWindowSytle.vbs";

        public const string SetTargetPath       = "SetTargetPath.vbs";
        public const string SetArguments        = "SetArguments.vbs";
        public const string SetIconLocation     = "SetIconLocation.vbs";
        public const string SetWorkingDirectory = "SetWorkingDirectory.vbs";
        public const string SetHotKey           = "SetHotKey.vbs";
        public const string SetWindowStyle      = "SetWindowStyle.vbs";
    }

    // =================================================================

}

// -- [EOF] --
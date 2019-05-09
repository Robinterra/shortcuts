namespace Testing
{

    // =================================================================

    /** [static]
     * Der Einstiegspunkt für die Anwendung
     * @author Robin D'Andrea
     * @Date 2019.05.08
     */
    public static class ProgramTest
    {

        // -------------------------------------------------------------

        /**
         * Der Einstiegpunkt fuer die Test Anwendung
         */
        public static int Main (  )
        {
            bool rc_bool = true;

            // -------------------------------

            rc_bool = rc_bool & ShortcutsTest.Run (  );

            // -------------------------------

            int result = 1000;
            if ( rc_bool )
            {
                result = 0;
            }
            return result;
        }

        // -------------------------------------------------------------

    }

    // =================================================================

}

// -- [EOF] --
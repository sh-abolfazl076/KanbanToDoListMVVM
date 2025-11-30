// System


// Internal

namespace KanbanToDoListMVVM.ViewModels.Utilities
{
    public class Validation
    {

        private const int MaxUsernameLength = 100;
        private const int MaxPasswordLength = 200;
        private const int MaxTitleLength = 200;
        private const int MaxInfoLength = 900;


        /// <summary>
        /// This method checks that username and password are not empty and have valid length.
        /// </summary>
        public static bool IsUsernameAndPasswordValid(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (username.Length > MaxUsernameLength || password.Length > MaxPasswordLength)
            {
                return false;
            }
            return true;
        }//End


        /// <summary>
        /// Checks if password and confirm password are the same.
        /// </summary>
        public static bool IsPasswordConfirmed(string password, string passwordChek)
        {
            return password == passwordChek;
        }//End


        /// <summary>
        /// This method checks that username and password are not empty and have valid length.
        /// Checks that duration is current and values ​​are numeric.
        /// </summary>
        public static bool IsCreateTaskFormValid(string title, string Info, string duration)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(Info))
            {
                return false;
            }
            if (title.Length > MaxTitleLength || Info.Length > MaxTitleLength)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(duration) && (!int.TryParse(duration, out int d) || d <= 0))
            {
                return false;
            }
            return true;
        }//End

        /// <summary>
        /// Checks: empty fields, valid lengths, and valid stage index.
        /// </summary>
        public static bool IsTaskFormValid(string title, string Info, int comboBoxStage)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(Info))
            {
                return false;
            }
            if (title.Length > MaxTitleLength || Info.Length > MaxInfoLength)
            {
                return false;
            }
            if (comboBoxStage < 0)
            {
                return false;
            }
            return true;
        }//End

    }
}

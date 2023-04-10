using System.Diagnostics;

namespace ExceptionHandling
{
    public class ExceptionExamples
    {
        public void TryCatchFinallyPattern()
        {
            try
            {
                // Code that might throw an exception
            }
            catch (ArgumentException ex)
            {
                // Handle the specific exception
            }
            catch (Exception ex)
            {
                // Handle other exceptions
            }
            finally
            {
                // Cleanup code, executed regardless of whether an exception occurred
            }
        }

        public void TryCatchFinallyWithExceptionFiltersPatter()
        {
            try
            {
                // Code that might throw an exception
            }
            catch (ArgumentException ex) when (ex.Message == "Invalid argument")
            {
                // Handle the specific exception
            }
            catch (Exception ex)
            {
                // Handle other exceptions
            }
            finally
            {
                // Cleanup code, executed regardless of whether an exception occurred
            }
        }

        public void ExceptionWrappingPattern()
        {
            try
            {
                // Code that might throw an exception
            }
            catch (ArgumentException ex)
            {
                throw new CustomException("Custom message", ex);
            }

        }

        public void ExceptionFiltersWithLogging()
        {
            try
            {
                throw new CustomException("Random error occurred here.", null);
            }
            catch (Exception ex) when (Log(ex, "An error occurred"))
            {
                // this catch block will never be reached
            }
        }

        public bool Log(Exception ex, string message, params object[] args)
        {
            Debug.Print(message, args);
            return false;
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
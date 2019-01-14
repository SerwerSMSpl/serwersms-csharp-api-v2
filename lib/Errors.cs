using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// Class handles Errors.
    /// </summary>
    public class Errors
	{
		private readonly SerwerSms _srv;

	    internal Errors( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// Preview error
        /// </summary>
        /// <param name="code">int code</param>
        /// <returns>
        /// array
		///      int "code"
		///      String "type"
		///      String "message"
        /// </returns>
        public string View( string code )
        {	
			var data = new Dictionary<string, string>();
            return _srv.Call("error/" + code, data);
	    }

        /// <summary>
        /// Preview error
        /// </summary>
        /// <param name="code">int code</param>
        /// <returns>
        /// array
		///      int "code"
		///      String "type"
		///      String "message"
        /// </returns>
        public async Task<string> ViewAsync(string code)
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("contacts/" + code, data);
        }
    }
	
}

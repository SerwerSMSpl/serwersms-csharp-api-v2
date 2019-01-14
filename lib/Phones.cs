using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Phones.
    /// </summary>
    public class Phones
	{
		private readonly SerwerSms _srv;

	    internal Phones( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// Checking phone in to HLR
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <param name="id">string id</param>
        /// <returns>
        /// array
		/// String "phone"
		/// String "status"
		/// int "imsi"
		/// String "network"
		/// bool "ported"
		/// String "network_ported"
        /// </returns>
        public string Check( string phone, string id = null )
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone },
                { "id", id }
            };
            return _srv.Call("phones/check", data);
        }

        /// <summary>
        /// Checking phone in to HLR
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <param name="id">string id</param>
        /// <returns>
        /// array
        /// String "phone"
        /// String "status"
        /// int "imsi"
        /// String "network"
        /// bool "ported"
        /// String "network_ported"
        /// </returns>
        public Task<string> CheckAsync(string phone, string id = null)
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone },
                { "id", id }
            };
            return _srv.CallAsync("phones/check", data);
        }

        /// <summary>
        /// Validating phone number
        /// </summary>
        /// <param name="phone">phone string.</param>
        /// <returns>bool "correct"</returns>
        public string Test( string phone )
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone }
            };
            return _srv.Call("phones/test", data);
	    }

        /// <summary>
        /// Validating phone number
        /// </summary>
        /// <param name="phone">phone string.</param>
        /// <returns>bool "correct"</returns>
        public async Task<string> TestAsync(string phone)
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone }
            };
            var response = await _srv.CallAsync("phones/test", data);
            return response;
        }
      
    }
	
}

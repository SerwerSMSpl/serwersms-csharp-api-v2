using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Senders.
    /// </summary>
    public class Senders
	{
		private readonly SerwerSms _srv;

	    internal Senders( SerwerSms srv )
		{
			_srv = srv;
		}

        /// <summary>
        /// Creating new Sender name
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>Boolean "success"</returns>
        public string Add(string name)
        {
            var data = new Dictionary<string, string>
            {
                { "name", name }
            };
            var response = _srv.Call("senders/add", data);
            return response;
        }

        /// <summary>
        /// Creating new Sender name
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>Boolean "success"</returns>
        public async Task<string> AddSendAsync(string name)
        {
            var data = new Dictionary<string, string>
            {
                { "name", name }
            };
            var response = await _srv.CallAsync("senders/add", data);
            return response;
        }

        /// <summary>
        /// Senders list
        /// </summary>
        /// <param name="data">
        /// Boolean "predefined",
	    /// string "sort" Values: name,
        /// string "order" Values: asc|desc
        /// </param>
        /// <returns>
        ///  array "items"
		///    string "name"
		///    string "agreement" delivered|required|not_required
        ///    string "status" pending_authorization|authorized|rejected|deactivated
        /// </returns>
        public string Index( Dictionary<string, string> data = null )
        {
            data = data ?? new Dictionary<string, string>();
            return _srv.Call("senders/index", data);
	    }

        /// <summary>
        /// Senders list
        /// </summary>
        /// <param name="data">
        /// Boolean "predefined",
        /// string "sort" Values: name,
        /// string "order" Values: asc|desc
        /// </param>
        /// <returns>
        ///  array "items"
        ///    string "name"
        ///    string "agreement" delivered|required|not_required
        ///    string "status" pending_authorization|authorized|rejected|deactivated
        /// </returns>
        public async Task<string> IndexAsync(Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            var response = await _srv.CallAsync("senders/index", data);
            return response;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Subaccounts.
    /// </summary>
    public class Subaccounts
	{
		private readonly SerwerSms _srv;

	    internal Subaccounts( SerwerSms srv )
		{
			_srv = srv;
        }
        
        /// <summary>
        /// Creating new subaccount
        /// </summary>
        /// <param name="subaccount_username">string</param>
        /// <param name="subaccount_password">string</param>
        /// <param name="subaccount_id">int</param>
        /// <param name="data">
        ///  string "name",
		///  string "phone",
		///  string "email"
        /// </param>
        /// <returns>
        /// type
        /// </returns>
        public string Add( string subaccount_username , string subaccount_password, string subaccount_id, Dictionary<string, string> data = null )
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("subaccount_username", subaccount_username);
            data.Add("subaccount_password", subaccount_password);
            data.Add("subaccount_id", subaccount_id);
            return _srv.Call("subaccounts/add", data);                    	    
	    }

        /// <summary>
        /// Creating new subaccount
        /// </summary>
        /// <param name="subaccount_username">string</param>
        /// <param name="subaccount_password">string</param>
        /// <param name="subaccount_id">int</param>
        /// <param name="data">
        ///  string "name",
        ///  string "phone",
        ///  string "email"
        /// </param>
        /// <returns>
        /// type
        // </returns>
        public async Task<string> AddAsync(string subaccount_username, string subaccount_password, string subaccount_id, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("subaccount_username", subaccount_username);
            data.Add("subaccount_password", subaccount_password);
            data.Add("subaccount_id", subaccount_id);
            var response = await _srv.CallAsync("subaccounts/add", data);
            return response;
        }
           
        /// <summary>
        /// List of subaccounts
        /// </summary>
        /// <returns>
        /// array "items"
		///     int "id"
		///     string "username"
        /// </returns>
        public string Index()
        {
			var data = new Dictionary<string, string>();
	        return _srv.Call("subaccounts/index", data);
        }

        /// <summary>
        /// List of subaccounts
        /// </summary>
        /// <returns>
        /// array "items"
        ///     int "id"
        ///     string "username"
        /// </returns>
        public async Task<string> IndexAsync()
        {
            var data = new Dictionary<string, string>();
            var response = await _srv.CallAsync("subaccounts/index", data);
            return response;
        }

        /// <summary>
        ///  View details of subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// array
		///  int "id"
		///  string "username"
		///  string "name"
		///  string "phone"
		///  string "email"
        /// </returns>
        public string View( string id )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return _srv.Call("subaccounts/view", data);
	    }

        /// <summary>
        ///  View details of subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// array
        ///  int "id"
        ///  string "username"
        ///  string "name"
        ///  string "phone"
        ///  string "email"
        /// </returns>
        public async Task<string> ViewAsync(string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            var response = await _srv.CallAsync("subaccounts/index", data);
            return response;
        }

        /// <summary>
        /// Setting the limit on subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="val">The value.</param>
        /// <returns>
        /// bool "success"
		/// int "id"
        /// </returns>
        public string Limit( string id, string type, string val )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id },
                { "type", type },
                { "value", val }
            };
            return _srv.Call("subaccounts/limit", data);
	    }

        /// <summary>
        /// Setting the limit on subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="val">The value.</param>
        /// <returns>
        /// bool "success"
        /// int "id"
        /// </returns>
        public async Task<string> LimitsAsync(string id, string type, string val)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id },
                { "type", type },
                { "value", val }
            };
            var response = await _srv.CallAsync("subaccounts/limit", data);
            return response;
        }

        /// <summary>
        /// Deleting a subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>bool "success"</returns>
        public string Delete( string id )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return _srv.Call("subaccounts/delete", data);
	    }

        /// <summary>
        /// Deleting a subaccount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>bool "success"</returns>
        public async Task<string> DeleteAsync(string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            var response = await _srv.CallAsync("subaccounts/delete", data);
            return response;
        }
     

    }
	
}

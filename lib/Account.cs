using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{

    /// <summary>
    /// This class handles operations on Accounts
    /// </summary>
    public class Account
	{
		private readonly SerwerSms _srv;
		
		internal Account( SerwerSms srv )
		{
			_srv = srv;
        }
        
        /// <summary>
        /// Register new account
        /// </summary>
        /// <param name="data">Data - Dictionary</param>
        /// <param> string "phone"
        /// string "email"
        /// string "first_name"
        /// string "last_name"
        /// string "company"</param>
        /// <returns>bool "success"</returns>
        public string Add( Dictionary<string, string> data)
        {
            return _srv.Call("account/add", data);	    
	    }
        /// <summary>
        /// Register new account
        /// </summary>
        /// <param name="data">
        /// string "phone"
        /// string "email"
        /// string "first_name"
        /// string "last_name"
        /// string "company"</param>
        /// <returns>bool "success"</returns>
        public async Task<string> AddAsync(Dictionary<string, string> data)
        {
            return await _srv.CallAsync("account/add", data);
        }

        
        /// <summary>
        /// Returns Limits SMS.
        /// </summary>
        /// <returns>
        /// array "items"
		///  string "type" Type of message
        ///  string "chars_limit" The maximum length of message
        ///  string "value" Limit messages
        /// </returns>
        public string Limits()
        {	        	
			var data = new Dictionary<string, string>();
            return _srv.Call("account/limits", data);
	    }

        /// <summary>
        /// Returns Limits SMS.
        /// </summary>
        /// <returns>
        /// array "items"
		///  string "type" Type of message
        ///  string "chars_limit" The maximum length of message
        ///  string "value" Limit messages
        /// </returns>
        public async Task<string> LimitsAsync()
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("account/limits", data);
        }
      
        /// <summary>
        /// Return contact details
        /// </summary>
        /// <returns>
        /// array "quardian_account"
        ///  string "name" 
        ///  string "email"
        ///  string "telephone"
        ///  string "photo"
        /// </returns>
        public string Help()
        {	        	
			var data = new Dictionary<string, string>();
            return _srv.Call("account/help", data);
	    }

        /// <summary>
        /// Return contact details
        /// </summary>
        /// <returns>
        /// array "quardian_account"
        ///  string "name" 
        ///  string "email"
        ///  string "telephone"
        ///  string "photo"
        /// </returns>
        public async Task<string> HelpAsync()
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("account/help", data);
        }
      
        /// <summary>
        /// Return messages from the administrator
        /// </summary>
        /// <returns>
        ///  bool "new"
        ///  string "message" 
        /// </returns>
        public string Messages()
        {	        	
			var data = new Dictionary<string, string>();
            return _srv.Call("account/messages", data);
	    }

        /// <summary>
        /// Return messages from the administrator
        /// </summary>
        /// <returns>
        ///  bool "new"
        ///  string "message" 
        /// </returns>
        public async Task<string> MessagesAsync()
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("account/messages", data);
        }
    }
	
}

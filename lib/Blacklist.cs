using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{

    /// <summary>
    /// This class handles operations on Blacklist.
    /// </summary>
    public class Blacklist
	{
		private readonly SerwerSms _srv;

	    internal Blacklist( SerwerSms srv )
		{
			_srv = srv;
        }
        
        /// <summary>
        /// Add phone to the blacklist
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>
        /// bool "success"
		/// int "id"
        /// </returns>
        public string Add( string phone )
        {
		    var data = new Dictionary<string, string> {{"phone", phone}};
            return _srv.Call("blacklist/add", data);        
	    }

	    /// <summary>
	    /// Add phone to the blacklist
	    /// </summary>
	    /// <param name="phone">The phone.</param>
	    /// <returns>
	    /// bool "success"
	    /// int "id"
	    /// </returns>
        public async Task<string> AddAsync(string phone)
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("blacklist/add", data);
        }

       
        /// <summary>
        /// List of blacklist phones
        /// </summary>
        /// <param name="phone">phone</param>
        /// <param name="data">
        ///    int "page"
		///    int "limit"
        /// </param>
        /// <returns>
        /// array "paging"
        ///        int "page" 
        ///        int "count" 
        /// array "items"
        ///        String "phone"
        ///        String "added" 
        /// </returns>
        public string Index(string phone = null, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string> {{ "phone", phone } };
            return _srv.Call("blacklist/index", data);	    
	    }
        /// <summary>
        /// List of blacklist phones
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="data">
        ///    int "page"
        ///    int "limit"
        /// </param>
        /// <returns>
        /// array "paging"
        ///        int "page" 
        ///        int "count" 
        /// array "items"
        ///        String "phone"
        ///        String "added" 
        /// </returns>
        public async Task<string> IndexAsync(string phone = null, Dictionary<string, string> data = null)
	    {
            data = data ?? new Dictionary<string, string> { { "phone", phone } };     
	        return await _srv.CallAsync("blacklist/index", data);
	    }

    
        /// <summary>
        /// Checking if phone is blacklisted
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>bool "exists"</returns>
        public string Check( string phone )
        {
            var data = new Dictionary<string, string> {{"phone", phone}};
            return _srv.Call("blacklist/check", data);
	    }
        /// <summary>
        /// Checking if phone is blacklisted
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>bool "exists"</returns>
        public async Task<string> CheckAsync(string phone = null)
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("blacklist/check", data);
        }

         
		 
        /// <summary>
        ///   Deleting phone from the blacklist
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>bool "success"</returns>
        public string Delete( string phone )
        {
            var data = new Dictionary<string, string> {{"phone", phone}};
            return _srv.Call("blacklist/delete", data);
        }
        /// <summary>
        ///   Deleting phone from the blacklist
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>bool "success"</returns>
        public async Task<string> DeleteAsync(string phone)
        {
            var data = new Dictionary<string, string> { { "phone", phone } };
            return await _srv.CallAsync("blacklist/delete", data);
        }
    }
	
}

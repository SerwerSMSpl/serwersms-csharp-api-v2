using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Premium SMS.
    /// </summary>
    public class Premium
	{
		private readonly SerwerSms _srv;

	    internal Premium( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// List of received SMS Premium
        /// </summary>
        /// <returns>
        /// array
		///  array "items"
		///  int "id"
		///  string "to_number" Premium number
		///  string "from_number" Sender phone number
        ///  string "date"
		///  int "limit" Limitation the number of responses
        ///  string "text" Message
        /// </returns>
        public string Index()
        {
	        var data = new Dictionary<string, string>();
            return _srv.Call("premium/index", data);
	    }
        
        /// <summary>
        /// List of received SMS Premium
        /// </summary>
        /// <returns>
        /// array
        ///  array "items"
        ///  int "id"
        ///  string "to_number" Premium number
        ///  string "from_number" Sender phone number
        ///  string "date"
        ///  int "limit" Limitation the number of responses
        ///  string "text" Message
        /// </returns>
        public async Task<string> IndexAsync()
        {
            var data = new Dictionary<string, string>();
            var response = await _srv.CallAsync("premium/index", data);
            return response;
        }

       
        /// <summary>
        /// Sending replies for received SMS Premium
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <param name="text">string text</param>
        /// <param name="gate">string gate</param>
        /// <param name="id">int id</param>
        /// <returns> bool "success"</returns>
        public string Send( string phone, string text, string gate, string id )
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone },
                { "text", text },
                { "gate", gate },
                { "id", id }
            };
            return _srv.Call("premium/send", data);
	    }

        /// <summary>
        /// Sending replies for received SMS Premium
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <param name="text">string text</param>
        /// <param name="gate">string gate</param>
        /// <param name="id">int id</param>
        /// <returns> bool "success"</returns>
        public async Task<string> SendAsync(string phone, string text, string gate, string id)
        {
            var data = new Dictionary<string, string>
            {
                { "phone", phone },
                { "text", text },
                { "gate", gate },
                { "id", id }
            };
            var response = await _srv.CallAsync("premium/send", data);
            return response;
        }

        /// <summary>
        /// View quiz results
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// array
        ///  int "id"
		///  string "name"
		///  array "items"
		///   int "id"
		///   int "count" Number of response
        /// </returns>
        public string Quiz( string id )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return _srv.Call("quiz/view", data);
	    }
        /// <summary>
        /// View quiz results
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// array
        ///  int "id"
		///  string "name"
		///  array "items"
		///   int "id"
		///   int "count" Number of response
        /// </returns>
        public async Task<string> QuizAsync(string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            var response = await _srv.CallAsync("quiz/view", data);
            return response;
        }
       

    }
	
}

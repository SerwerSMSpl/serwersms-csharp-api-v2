using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Stats.
    /// </summary>
    public class Stats
	{
		private readonly SerwerSms _srv;

	    internal Stats( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// Statistics an sending
        /// </summary>
        /// <param name="data">
        ///  String "type" eco|full|voice|mms,
		///  String "begin" Start date,
		///  String "end" End date
        /// </param>
        /// <returns>
		///   array "items",
		///    int "id",
		///    String "name",
		///    int "delivered",
		///    int "pending",
		///    int "undelivered",
		///    int "unsent",
		///    String "begin",
		///    String "end",
		///    String "text",
		///    String "type" eco|full|voice|mms
        /// </returns>
        public string Index( Dictionary<string, string> data = null )
        {
            data = data ?? new Dictionary<string, string>();
            return _srv.Call("stats/index", data);
	    }

        /// <summary>
        /// Statistics an sending
        /// </summary>
        /// <param name="data">
        ///  String "type" eco|full|voice|mms,
        ///  String "begin" Start date,
        ///  String "end" End date
        /// </param>
        /// <returns>
        ///   array "items",
        ///    int "id",
        ///    String "name",
        ///    int "delivered",
        ///    int "pending",
        ///    int "undelivered",
        ///    int "unsent",
        ///    String "begin",
        ///    String "end",
        ///    String "text",
        ///    String "type" eco|full|voice|mms
        /// </returns>
        public async Task<string> IndexAsync(Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            var response = await _srv.CallAsync("stats/index", data);
            return response;
        }

    }
	
}

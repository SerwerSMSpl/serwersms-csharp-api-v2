using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Files
    /// </summary>
    public class Files
	{
		private readonly SerwerSms _srv;

	    internal Files(SerwerSms srv)
        {
			_srv = srv;
		}

        /// <summary>
        /// Adds the specified type.
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <returns>
        /// Boolean "success"
        /// String "id"
        /// </returns>
        public string Add( string type, Dictionary<string, string> data = null )
        {
		    data = data ?? new Dictionary<string, string>();
		    data.Add("type", type);
            return _srv.Call("files/add", data);
	    }

        /// <summary>
        /// Adds the specified type.
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <returns>
        /// Boolean "success"
        /// String "id"
        /// </returns>
        public async Task<string> AddAsync(string type, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("type", type);
            return await _srv.CallAsync("files/add", data);
        }
              
        /// <summary>
        /// List of files
        /// </summary>
        /// <param name="type">mms|voice</param>
        /// <returns>
        /// array "items"
		///  String "id"
		///  String "name"
		///  int "size"
		///  String "type" - mms|voice
        ///  String "date"
        /// </returns>
        public string Index( string type )
        {
            var data = new Dictionary<string, string> {{"type", type}};
            return _srv.Call("files/index", data);
	    }

        /// <summary>
        /// List of files
        /// </summary>
        /// <param name="type">mms|voice</param>
        /// <returns>
        /// array "items"
		///  String "id"
		///  String "name"
		///  int "size"
		///  String "type" - mms|voice
        ///  String "date"
        /// </returns>
        public async Task<string> IndexAsync(string type)
        {
            var data = new Dictionary<string, string> { { "type", type } };
            return await _srv.CallAsync("files/index", data);
        }

        /// <summary>
        ///  View file
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="type">mms|voice</param>
        /// <returns>
        /// array
        ///   String "id"
		///   String "name"
		///   int "size"
		///   String "type" - mms|voice
        ///   String "date"
        /// </returns>
        public string View( string id, string type )
        {
            var data = new Dictionary<string, string> {{"type", type}, {"id", id}};
            return _srv.Call("files/view", data);  
	    }

        /// <summary>
        ///  View file
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="type">mms|voice</param>
        /// <returns>
        /// array
        ///   String "id"
		///   String "name"
		///   int "size"
		///   String "type" - mms|voice
        ///   String "date"
        /// </returns>
        public async Task<string> ViewAsync(string id, string type)
        {
            var data = new Dictionary<string, string> {{"type", type}, {"id", id}};
            return await _srv.CallAsync("files/view", data);
        }

        /// <summary>
        /// Deleting a file
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">mms|voice</param>
        /// <returns>Boolean "success"</returns>
        public string Delete( string id, string type )
        {
            var data = new Dictionary<string, string> {{"type", type}, {"id", id}};
            return _srv.Call("files/delete", data);
	    }

        /// <summary>
        /// Deleting a file
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">mms|voice</param>
        /// <returns>Boolean "success"</returns>
        public async Task<string> DeleteAsync(string id, string type)
        {
            var data = new Dictionary<string, string> {{"type", type}, {"id", id}};
            return await _srv.CallAsync("files/delete", data);
        }
    }
}

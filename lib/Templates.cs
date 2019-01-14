using System.Collections.Generic;
using System.Threading.Tasks;


namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Templates.
    /// </summary>
    public class Templates
	{
		private readonly SerwerSms _srv;

	    internal Templates( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        ///  Adding new template
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="text">string text</param>
        /// <returns>
        ///  bool "success"
		///  int "id"
        /// </returns>
        public string Add( string name, string text )
        {
            var data = new Dictionary<string, string>
            {
                { "name", name },
                { "text", text }
            };
            return _srv.Call("templates/add", data);         	    
	    }

        /// <summary>
        ///  Adding new template
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="text">string text</param>
        /// <returns>
        ///  bool "success"
        ///  int "id"
        /// </returns>
        public async Task<string> AddAsync(string name, string text)
        {
            var data = new Dictionary<string, string>();
            var response = await _srv.CallAsync("templates/add", data);
            return response;
        }

        /// <summary>
        ///  List of templates
        /// </summary>
        /// <param name="data">
        /// string "sort" Values: name,
	    ///  string "order" Values: asc|desc
        /// </param>
        /// <returns>int "id"
		/// string "name"
		/// string "text"</returns>
        public string Index( Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            return _srv.Call("templates/index", data);
	    }

        /// <summary>
        ///  List of templates
        /// </summary>
        /// <param name="data">
        /// string "sort" Values: name,
	    ///  string "order" Values: asc|desc
        /// </param>
        /// <returns>int "id"
		/// string "name"
		/// string "text"</returns>
        public async Task<string> IndexAsync(Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            var response = await _srv.CallAsync("templates/index", data);
            return response;
        }

        /// <summary>
        /// Editing a template
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="name">string name</param>
        /// <param name="text">string text</param>
        /// <returns>
        ///  bool "success"
		///  int "id"
        /// </returns>
        public string Edit( string id, string name, string text )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id },
                { "name", name },
                { "text", text }
            };
            var response = _srv.Call("templates/edit", data);
            return response;
	    }

        /// <summary>
        /// Editing a template
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="name">string name</param>
        /// <param name="text">string text</param>
        /// <returns>
        ///  bool "success"
        ///  int "id"
        /// </returns>
        public async Task<string> EditAsync(string id, string name, string text)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id },
                { "name", name },
                { "text", text }
            };
            var response = await _srv.CallAsync("templates/edit", data);
            return response;
        } 
        
        /// <summary>
        /// Deleting a template
        /// </summary>
        /// <param name="id">ind id</param>
        /// <returns> bool "success"</returns>
        public string Delete( string id )
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return _srv.Call("templates/delete", data);           	    
	    }

        /// <summary>
        /// Deleting a template
        /// </summary>
        /// <param name="id">ind id</param>
        /// <returns> bool "success"</returns>
        public async Task<string> DeleteAsync(string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            var response = await _srv.CallAsync("templates/delete", data);
            return response;
        }

    }
	
}

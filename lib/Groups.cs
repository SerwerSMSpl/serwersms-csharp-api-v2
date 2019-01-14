using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    ///  This class handles operations on Groups.
    /// </summary>
    public class Groups
	{
		private readonly SerwerSms _srv;

	    internal Groups( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// Add new group
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>
	    ///    array
	    ///      bool "success"
	    ///      int "id"
	    /// </returns>
        public string Add( string name )
        {
            var data = new Dictionary<string, string> {{"name", name}};
		    return _srv.Call("groups/add", data);
	    }

        /// <summary>Add new group</summary>
        /// <param name="name">string name</param>
        /// <returns>
        ///   array
        ///    bool "success"
        ///    int "id"
        /// </returns>
        public async Task<string> AddAsync(string name)
        {
            var data = new Dictionary<string, string> {{"name", name}};
            return await _srv.CallAsync("groups/add", data);
        }

        /// <summary>
        /// List of groups
        /// </summary>
        /// <param name="search">string search</param>
        /// <param name="data">dictionary data</param>
        /// <returns>array
        /// array "paging"
        /// int "page"
        /// int "id"
        /// array "items"
        /// int "id"
        /// string "name"
        /// int "count"
        /// </returns>
        public string Index( string search, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string> { { "search", search } };
            return _srv.Call("groups/index", data);    
	    }

        /// <summary>
        /// Add new group
        /// </summary>
        /// <param name="search">string search</param>
        /// <param name="data">dictionary data</param>
        /// <returns>array
        /// array "paging"
        /// int "page"
        /// int "id"
        /// array "items"
        /// int "id"
        /// string "name"
        /// int "count"
        /// </returns>
        public async Task<string> IndexAsync(string search, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string> { { "search", search } };
            return await _srv.CallAsync("groups/index", data);
        }

        /// <summary>View single group</summary>
        /// <param name="id">string id</param>
        /// <returns>
	    /// array
	    ///      string "name"
	    ///      int "id"
	    /// </returns>
        public string View( string id )
        {

            var data = new Dictionary<string, string> {{"id", id}};
            return _srv.Call("groups/view", data);       
	    }

        /// <summary>View single group</summary>
        /// <param name="id"></param>
        /// <returns>
	    /// array
	    ///      string "name"
	    ///      int "id"
	    /// </returns>
        public async Task<string> ViewAsync(string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return await _srv.CallAsync("groups/view", data);
        }

        /// <summary>Editing a group</summary>
        /// <param name="id">string id</param>
        /// <param name="name">string name</param>
        /// <returns>
        /// bool "success"
		/// int "id"
        /// </returns>
        public string Edit( string id, string name )
        {
            var data = new Dictionary<string, string> {{"id", id}, {"name", name}};
            return _srv.Call("groups/edit", data);         
	    }

        /// <summary>Editing a group</summary>
        /// <param name="id">string id</param>
        /// <param name="name">string name</param>
        /// <returns>
        /// bool "success"
        /// int "id"
        /// </returns>
        public async Task<string> EditAsync(string id, string name)
        {
            var data = new Dictionary<string, string> { { "id", id }, { "name", name } };
            return await _srv.CallAsync("groups/edit", data);
        }

        /// <summary>Delete Group</summary>
        /// <param name="id">int id</param>
        /// <returns>bool "success"</returns>
        public string Delete( string id ) {

            var data = new Dictionary<string, string> {{"id", id}};
            return _srv.Call("groups/delete", data);
	    }

        /// <summary>Delete Group</summary>
        /// <param name="id">int id</param>
        /// <returns>bool "success"</returns>
        public async Task<string> DeleteAsync(string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return await _srv.CallAsync("groups/delete", data);
        }

        /// <summary>Viewing a groups containing phone</summary>
        /// <param name="phone"></param>
        /// <returns>
        /// array
        /// int "id"
        /// int "group_id"
        /// string "group_name"
        /// </returns>
        public string Check( string phone )
        {
            var data = new Dictionary<string, string> {{"phone", phone}};
            return _srv.Call("groups/check", data);
        }

        /// <summary>
        /// Viewing a groups containing phone
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <returns>
        /// array
        /// int "id"
        /// int "group_id"
        /// string "group_name"
        /// </returns>
        public async Task<string> CheckAsync(string phone)
        {
            var data = new Dictionary<string, string> {{"phone", phone}};
            return await _srv.CallAsync("groups/check", data);
        }
    }
	
}

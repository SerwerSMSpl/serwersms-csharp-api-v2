using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{

    /// <summary>
    /// This class handles operations on Contacts
    /// </summary>
    public class Contacts
	{
		private readonly SerwerSms _srv;

	    internal Contacts( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// Add new contact
        /// </summary>
        /// <param name="group_id">The group identifier.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="data">The data:
        ///        string "email"
		///       string "first_name"
		///       string "last_name"
		///       string "company"
		///       string "tax_id"
		///       string "address"
		///       string "city"
        ///       string "description"
        /// </param>
        /// <returns>
        /// bool "success"
		/// int "id"
        /// </returns>
        public string Add(string group_id, string phone, Dictionary<string, string> data = null)
	    {
	        data = data ?? new Dictionary<string, string>();
	        data.Add("phone", phone);
	        data.Add("group_id", group_id);
	        return _srv.Call("contacts/add", data);
	    }

        /// <summary>
        /// Adds the specified group identifier.
        /// </summary>
        /// <param name="group_id">The group identifier.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="data">The data:
        ///       string "email"
        ///       string "first_name"
        ///       string "last_name"
        ///       string "company"
        ///       string "tax_id"
        ///       string "address"
        ///       string "city"
        ///       string "description"
        /// </param>
        /// <returns>
        /// bool "success"
        /// int "id"
        /// </returns>
        public async Task<string> AddAsync(string group_id, string phone, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("phone", phone);
            data.Add("group_id", group_id);
            return await _srv.CallAsync("contacts/add", data);
        }

        /// <summary>
        ///   List of contacts
        /// </summary>
        /// <param name="group_id">The group identifier.</param>
        /// <param name="search">The search.</param>
        /// <param name="data">
        /// int "page" 
		/// int "limit" 
	    /// string "sort" Values: first_name|last_name|phone|company|tax_id|email|address|city|description
        /// string "order" Values: asc|desc 
        /// </param>
        /// <returns>
        /// array "paging"
		/// int "page" The number of current page
        /// int "count" The number of all pages
        ///  array "items"
		///          int "id"
		///           string "phone"
		///           string "email"
		///           string "company"
		///           string "first_name"
		///           string "last_name"
		///           string "tax_id"
		///           string "address"
		///           string "city"
		///           string "description"
		///           bool "blacklist"
		///           int "group_id"
		///           string "group_name"
        /// </returns>
        public string Index(string group_id = null, string search = null,Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("group_id", group_id);
            data.Add("search", search);
            return _srv.Call("contacts/index", data); 
	    }

        /// <summary>
        ///   List of contacts
        /// </summary>
        /// <param name="group_id">The group identifier.</param>
        /// <param name="search">The search.</param>
        /// <param name="data">
        /// int "page" 
		/// int "limit" 
	    /// string "sort" Values: first_name|last_name|phone|company|tax_id|email|address|city|description
        /// string "order" Values: asc|desc 
        /// </param>
        /// <returns>
        /// array "paging"
		/// int "page" The number of current page
        /// int "count" The number of all pages
        ///  array "items"
		///          int "id"
		///           string "phone"
		///           string "email"
		///           string "company"
		///           string "first_name"
		///           string "last_name"
		///           string "tax_id"
		///           string "address"
		///           string "city"
		///           string "description"
		///           bool "blacklist"
		///           int "group_id"
		///           string "group_name"
        /// </returns>
        public async Task<string> IndexAsync(string group_id = null, string search = null, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("group_id", group_id);
            data.Add("search", search);
            return await _srv.CallAsync("contacts/index", data);
        }
        
        /// <summary>
        ///     View single contact.
        /// </summary>
        /// <param name="id">string id</param>
        /// <returns>
        /// array
		///   integer "id"
		///    string "phone"
		///    string "email"
		///    string "company"
		///    string "first_name"
		///    string "last_name"
	    ///    string "tax_id"
		///    string "address"
		///    string "city"
		///    string "description"
		///    bool "blacklist"
        /// 
        /// </returns>
        public string View( string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return _srv.Call("contacts/view", data);
	    }

        /// <summary>
        ///     View single contact.
        /// </summary>
        /// <param name="id">string id</param>
        /// <returns>
        /// array
		///   integer "id"
		///    string "phone"
		///    string "email"
		///    string "company"
		///    string "first_name"
		///    string "last_name"
	    ///    string "tax_id"
		///    string "address"
		///    string "city"
		///    string "description"
		///    bool "blacklist"
        /// 
        /// </returns>
        public async Task<string> ViewAsync(string id)
        {
            var data = new Dictionary<string, string> { { "id", id } };
            return await _srv.CallAsync("contacts/view", data);
        }

        /// <summary>
        ///  Editing a contact
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="group_id">int|array group_id</param>
        /// <param name="phone">string phone.</param>
        /// <param name="data">
        ///       string "email"
		///       string "first_name"
		///       string "last_name"
		///       string "company"
		///       string "tax_id"
		///       string "address"
		///       string "city"
		///       string "description"
        /// </param>
        /// <returns> 
        ///   bool "success"
		///   int "id"
        /// </returns>
        public string Edit( string id, string group_id, string phone ,Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("group_id", group_id);
            data.Add("phone", phone);
            data.Add("id", id);

            return _srv.Call("contacts/edit", data);
	    }

        /// <summary>
        ///  Editing a contact
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="group_id">int|array group_id</param>
        /// <param name="phone">string phone.</param>
        /// <param name="data">
        ///       string "email"
		///       string "first_name"
		///       string "last_name"
		///       string "company"
		///       string "tax_id"
		///       string "address"
		///       string "city"
		///       string "description"
        /// </param>
        /// <returns> 
        ///   bool "success"
		///   int "id"
        /// </returns>
        public async Task<string> EditAsync(string id, string group_id, string phone, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("group_id", group_id);
            data.Add("phone", phone);
            data.Add("id", id);
            return await _srv.CallAsync("contacts/edit", data);
        }

        /// <summary>
        /// Deleting a phone from contacts
        /// </summary>
        /// <param name="id">string id</param>
        /// <returns>bool "success"</returns>
        public string Delete( string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return _srv.Call("contacts/delete", data);       	    
	    }

        /// <summary>
        /// Deleting a phone from contacts
        /// </summary>
        /// <param name="id">string id</param>
        /// <returns>bool "success"</returns>
        public async Task<string> DeleteAsync(string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return await _srv.CallAsync("contacts/delete", data);
        }

        /// <summary>
        /// Import contact list
        /// </summary>
        /// <param name="name"> string name</param>
        /// <param name="contact">
        ///  string "phone"
		///  string "email"
		///  string "first_name"
		///  string "last_name"
		///  string "company"
        /// </param>
        /// <returns>System.String.
        /// array
		///     bool "success"
		///     int "id"
		///     int "correct" 
        ///     int "failed" 
        /// </returns>
        public string Import( string name, List<Dictionary<string, string>> contact)
        {
            var data = new Dictionary<string, string> {{"group_name", name}};
            string json = JsonConvert.SerializeObject(contact);
			data.Add("contact",json);
            return _srv.Call("contacts/import", data);   
	    }

        /// <summary>
        /// Import contact list
        /// </summary>
        /// <param name="name"> string name</param>
        /// <param name="contact">
        ///  string "phone"
		///  string "email"
		///  string "first_name"
		///  string "last_name"
		///  string "company"
        /// </param>
        /// <returns>System.String.
        /// array
		///     bool "success"
		///     int "id"
		///     int "correct" 
        ///     int "failed" 
        /// </returns>
        public async Task<string> ImportAsync(string name, List<Dictionary<string, string>> contact)
        {
            var data = new Dictionary<string, string> { { "group_name", name } };
            string json = JsonConvert.SerializeObject(contact);
            data.Add("contact", json);
            return await _srv.CallAsync("contacts/import", data);
        }

    }
	
}

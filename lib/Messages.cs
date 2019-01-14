using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    ///  This class handles operations on Templates
    /// </summary>
    public class Messages
	{
		private readonly SerwerSms _srv;

	    internal Messages(SerwerSms srv)
        {		
			_srv = srv;
        }

        /// <summary>
        ///  Sending messages
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="data">
        /// String "details" Show details of messages,
        /// String "utf" Change encoding to UTF-8 (Only for FULL SMS),
        /// String "flash",
        /// String "speed" Priority canal only for FULL SMS,
        /// String "test" Test mode,
        /// String "vcard" vCard message,
        /// String "wap_push" WAP Push URL address,
        /// String "date" Set the date of sending,
        /// String "group_id" Sending to the group instead of a phone number,
        /// String "contact_id" Sending to phone from contacts,
        /// String "unique_id" Own identifiers of messages
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public string SendSms( string phone, string text, string sender = null, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("phone", phone);
            data.Add("text", text);
            data.Add("sender", sender);
            return _srv.Call("messages/send_sms", data);   	    
	    }

        /// <summary>
        ///  Sending messages
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="data">
        /// String "details" Show details of messages,
        /// String "utf" Change encoding to UTF-8 (Only for FULL SMS),
        /// String "flash",
        /// String "speed" Priority canal only for FULL SMS,
        /// String "test" Test mode,
        /// String "vcard" vCard message,
        /// String "wap_push" WAP Push URL address,
        /// String "date" Set the date of sending,
        /// String "group_id" Sending to the group instead of a phone number,
        /// String "contact_id" Sending to phone from contacts,
        /// String "unique_id" Own identifiers of messages
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public async Task<string> SendSmsAsync(string phone, string text, string sender = null, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("phone", phone);
            data.Add("text", text);
            data.Add("sender", sender);
            return await _srv.CallAsync("messages/send_sms", data);
        }

	    /// <summary>
	    /// Sending personalized messages
	    /// </summary>
	    /// <param name="messages">The messages.</param>
	    /// <param name="sender">The sender.</param>
	    /// <param name="data">
	    /// String "details" Show details of messages
	    /// String "utf" Change encoding to UTF-8 (only for FULL SMS)
	    /// String "flash"
	    /// String "speed" Priority canal only for FULL SMS
	    /// String "test" Test mode
	    /// String "date" Set the date of sending
	    /// String "group_id" Sending to the group instead of a phone number
	    /// String "text" Message if is set group_id
	    /// String "uniqe_id" Own identifiers of messages
	    /// String "voice" Send VMS</param>
	    /// <returns>
	    ///  Boolean "success"
	    ///  int "queued" Number of queued messages
	    ///  int "unsent" Number of unsent messages
	    ///  array "items"
	    ///  String "id"
	    ///  String "phone"
	    ///  String "status" - queued|unsent
	    ///  String "queued" Date of enqueued
	    ///  int "parts" Number of parts a message
	    ///  int "error_code"
	    ///  String "error_message"
	    ///  String "text"
	    /// </returns>
	    public string SendPersonalized(List<Dictionary<string, string>> messages, string sender = null, Dictionary<string, string> data = null)
	    {
	        var smessages = "";
	        foreach (var message in messages)
	        {
	            smessages += $"{message["phone"]}:{message["text"]}]|[";
	        }
	        data = data ?? new Dictionary<string, string>();
	        data.Add("messages", smessages);
	        data.Add("sender", sender);
	        return _srv.Call("messages/send_personalized", data);
	    }

	    /// <summary>
        /// Sending personalized messages
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="data">
        /// String "details" Show details of messages
        /// String "utf" Change encoding to UTF-8 (only for FULL SMS)
        /// String "flash"
        /// String "speed" Priority canal only for FULL SMS
        /// String "test" Test mode
        /// String "date" Set the date of sending
        /// String "group_id" Sending to the group instead of a phone number
        /// String "text" Message if is set group_id
        /// String "uniqe_id" Own identifiers of messages
        /// String "voice" Send VMS</param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public async Task<string> SendSPersonalizedAsync(List<Dictionary<string, string>> messages, string sender = null, Dictionary<string, string> data = null)
        {
            var smessages = "";
            foreach (Dictionary<string, string> message in messages)
            {
                smessages += $"{message["phone"]}:{message["text"]}]|[";
            }
            data = data ?? new Dictionary<string, string>();
            data.Add("messages", smessages);
            data.Add("sender", sender);
            return await _srv.CallAsync("messages/send_personalized", data);         
        }

        /// <summary>
        /// Sends the voice.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="data">
        ///  String "text",
		///  String "file_id" File in base64 encoding,
		///  String "date" Set the date of sending,
        ///  String "test" Test mode,
		///  String "group_id" Sending to the group instead of a phone number,
        ///  String "contact_id" Sending to phone from contacts
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public string SendVoice( string phone,Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
			data.Add("phone",phone);				
            return _srv.Call("messages/send_voice", data);
	    }

        /// <summary>
        /// Sends the voice.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="data">
        ///  String "text",
        ///  String "file_id" File in base64 encoding,
        ///  String "date" Set the date of sending,
        ///  String "test" Test mode,
        ///  String "group_id" Sending to the group instead of a phone number,
        ///  String "contact_id" Sending to phone from contacts
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public async Task<string> SendVoiceAsync(string phone, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("phone", phone);            
            return await _srv.CallAsync("messages/send_voice", data);
        }
       
        /// <summary>
        /// Sends the MMS.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="title">The title.</param>
        /// <param name="data">
        ///  String "file_id",
		///  String "file" File in base64 encoding,
		///  String "date" Set the date of sending,
        ///  String "test" Test mode,
		///  String "group_id" Sending to the group instead of a phone number
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public string SendMms( string phone,string title,Dictionary<string, string> data = null) {
            data = data ?? new Dictionary<string, string>();
			data.Add("phone",phone);
			data.Add("title",title);				
            return _srv.Call("messages/send_mms", data);       
	    }

        /// <summary>
        /// Sends the MMS.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="title">The title.</param>
        /// <param name="data">
        ///  String "file_id",
        ///  String "file" File in base64 encoding,
        ///  String "date" Set the date of sending,
        ///  String "test" Test mode,
        ///  String "group_id" Sending to the group instead of a phone number,
        /// </param>
        /// <returns>
        ///  Boolean "success"
        ///  int "queued" Number of queued messages
        ///  int "unsent" Number of unsent messages
        ///  array "items"
        ///  String "id"
        ///  String "phone"
        ///  String "status" - queued|unsent
        ///  String "queued" Date of enqueued
        ///  int "parts" Number of parts a message
        ///  int "error_code"
        ///  String "error_message"
        ///  String "text"
        /// </returns>
        public async Task<string> SendMmsAsync(string phone, string title, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("phone", phone);
            data.Add("title", title);
            return await _srv.CallAsync("messages/send_mms", data);
        }

        /// <summary>
        /// View single message
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        ///  String "id"
		///  String "phone"
		///  String "status"
        ///  String "queued" Date of enqueued
        ///  String "sent" Date of sending
        ///  String "delivered" Date of deliver
        ///  String "sender"
        ///  String "type" - eco|full|mms|voice
        ///  String "text"
        ///  String "reason"
        /// array "contact"
        ///   String "first_name"
        ///   String "last_name"
        ///   String "company"
        ///   String "phone"
        ///   String "email"
        ///   String "tax_id"
        ///   String "city"
        ///   String "address"
        ///   String "description"
        /// </returns>
        public string View( string id,Dictionary<string, string> data = null) {
            data = data ?? new Dictionary<string, string>();
			data.Add("id",id);							
            return _srv.Call("messages/view", data);
        }

        /// <summary>
        /// View single message
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        ///  String "id"
        ///  String "phone"
        ///  String "status"
        ///  String "queued" Date of enqueued
        ///  String "sent" Date of sending
        ///  String "delivered" Date of deliver
        ///  String "sender"
        ///  String "type" - eco|full|mms|voice
        ///  String "text"
        ///  String "reason"
        /// array "contact"
        ///   String "first_name"
        ///   String "last_name"
        ///   String "company"
        ///   String "phone"
        ///   String "email"
        ///   String "tax_id"
        ///   String "city"
        ///   String "address"
        ///   String "description"
        /// </returns>
        public async Task<string> SViewAsync(string id, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("id", id);
            return await _srv.CallAsync("messages/view", data);
        }

        /// <summary>
        ///  Checking messages reports
        /// </summary>
        /// <param name="data">
        /// @option String|array "id" ID message,
        /// String|array "unique_id" ID message,
        /// String|array "phone",
        ///  String "date_from" The scope of the initial,
        ///  String "date_to" The scope of the final,
        ///  String "status" delivered|undelivered|pending|sent|unsent,
        ///  String "type" eco|full|mms|voice,
        /// int "stat_id" Id package messages,
        /// Boolean "show_contact" Show details of the recipient from the contacts,
        /// int "page" The number of the displayed page,
        /// int "limit" Limit items are displayed on the single page,
        /// String "order" asc|desc
        /// </param>
        /// <returns>
        ///array "paging"
        ///  int "page" The number of current page
        ///  int "count" The number of all pages
        ///  array items
        ///  String "id"
        ///  String "phone"
        ///  String "status"		 *             
        ///  String "queued" Date of enqueued
        ///  String "sent" Date of sending
        ///  String "delivered" Date of deliver
        ///  String "sender"
        ///  String "type" - eco|full|mms|voice
        ///  String "text"
        ///  String "reason"
        ///  "contact"
        ///   String "first_name"
        ///   String "last_name"
        ///   String "company"
        ///   String "phone"
        ///   String "email"
        ///   String "tax_id"
        ///   String "city"
        ///   String "address"
        ///   String "description"
        /// </returns>
        public string Reports( Dictionary<string, string> data )
        {
            return _srv.Call("messages/reports", data);                                 
	    }
        /// <summary>
        ///  Checking messages reports
        /// </summary>
        /// <param name="data">
        /// @option String|array "id" ID message,
        /// String|array "unique_id" ID message,
        /// String|array "phone",
        ///  String "date_from" The scope of the initial,
        ///  String "date_to" The scope of the final,
        ///  String "status" delivered|undelivered|pending|sent|unsent,
        ///  String "type" eco|full|mms|voice,
        /// int "stat_id" Id package messages,
        /// Boolean "show_contact" Show details of the recipient from the contacts,
        /// int "page" The number of the displayed page,
        /// int "limit" Limit items are displayed on the single page,
        /// String "order" asc|desc
        /// </param>
        /// <returns>
        ///array "paging"
        ///  int "page" The number of current page
        ///  int "count" The number of all pages
        ///  array items
        ///  String "id"
        ///  String "phone"
        ///  String "status"		 *             
        ///  String "queued" Date of enqueued
        ///  String "sent" Date of sending
        ///  String "delivered" Date of deliver
        ///  String "sender"
        ///  String "type" - eco|full|mms|voice
        ///  String "text"
        ///  String "reason"
        ///  "contact"
        ///   String "first_name"
        ///   String "last_name"
        ///   String "company"
        ///   String "phone"
        ///   String "email"
        ///   String "tax_id"
        ///   String "city"
        ///   String "address"
        ///   String "description"
        /// </returns>
        public async Task<string> ReportsAsync(Dictionary<string, string> data)
        {            
            return await _srv.CallAsync("messages/reports", data);            
        }

        /// <summary>
        /// Deleting message from the scheduler
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">unique_id</param>
        /// <returns>Boolean "success"</returns>
        public string Delete( string id,Dictionary<string, string> data = null) {
            data = data ?? new Dictionary<string, string>();			
			data.Add("id",id);				
            return _srv.Call("messages/delete", data);	    
	    }

        /// <summary>
        /// Deleting message from the scheduler
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">unique_id</param>
        /// <returns>Boolean "success"</returns>
        public async Task<string> DeleteAsync(string id, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("id", id);
            return await _srv.CallAsync("messages/delete", data);
        }

        /// <summary>
        /// List of received messages
        /// </summary>
        /// <param name="type">
        ///       - eco SMS ECO replies,
        ///       - nd Incoming messages to ND number,
        ///       - ndi Incoming messages to ND number,
        ///       - mms Incoming MMS 
        /// </param>
        /// <param name="data">
        ///  String "ndi" Filtering by NDI,
        ///  String "phone" Filtering by phone,
        ///  String "date_from" The scope of the initial,
        ///  String "date_to" The scope of the final,
        ///  Boolean "read" Mark as read,
        ///  int "page" The number of the displayed page,
        ///  int "limit" Limit items are displayed on the single page,
        ///  String "order" asc|desc
        /// </param>
        /// <returns>
        ///array "paging"
        ///  int "page" The number of current page
        ///  int "count" The number of all pages
        ///array "items"
        ///  int "id"
        ///  String "type" eco|nd|ndi|mms
        ///  String "phone"
        ///  String "recived" Date of received message
        ///  String "message_id" ID of outgoing message(only for ECO SMS)
        ///  Boolean "blacklist" Is the phone is blacklisted?
        ///  String "text" Message
        ///  String "to_number" Number of the recipient(for MMS)
        ///  String "title" Title of message(for MMS)
        ///array "attachments" (for MMS)
        ///  int "id"
        ///  String "name"
        ///  String "content_type"
        ///  String "data" File
        ///array "contact"
        ///  String "first_name"
        ///  String "last_name"
        ///  String "company"
        ///  String "phone"
        ///  String "email"
        ///  String "tax_id"
        ///  String "city"
        ///  String "address"
        ///  String "description"
        /// </returns>
        public string Received( string type,Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
			data.Add("type",type);
            return _srv.Call("messages/recived", data);
	    }

        /// <summary>
        /// List of received messages
        /// </summary>
        /// <param name="type">
        ///       - eco SMS ECO replies,
        ///       - nd Incoming messages to ND number,
        ///       - ndi Incoming messages to ND number,
        ///       - mms Incoming MMS 
        /// </param>
        /// <param name="data">
        ///  String "ndi" Filtering by NDI,
        ///  String "phone" Filtering by phone,
        ///  String "date_from" The scope of the initial,
        ///  String "date_to" The scope of the final,
        ///  Boolean "read" Mark as read,
        ///  int "page" The number of the displayed page,
        ///  int "limit" Limit items are displayed on the single page,
        ///  String "order" asc|desc
        /// </param>
        /// <returns>
        ///array "paging"
        ///  int "page" The number of current page
        ///  int "count" The number of all pages
        ///array "items"
        ///  int "id"
        ///  String "type" eco|nd|ndi|mms
        ///  String "phone"
        ///  String "recived" Date of received message
        ///  String "message_id" ID of outgoing message(only for ECO SMS)
        ///  Boolean "blacklist" Is the phone is blacklisted?
        ///  String "text" Message
        ///  String "to_number" Number of the recipient(for MMS)
        ///  String "title" Title of message(for MMS)
        ///array "attachments" (for MMS)
        ///  int "id"
        ///  String "name"
        ///  String "content_type"
        ///  String "data" File
        ///array "contact"
        ///  String "first_name"
        ///  String "last_name"
        ///  String "company"
        ///  String "phone"
        ///  String "email"
        ///  String "tax_id"
        ///  String "city"
        ///  String "address"
        ///  String "description"
        /// </returns>
        public async Task<string> ReceivedAsync(string type, Dictionary<string, string> data = null)
        {
            data = data ?? new Dictionary<string, string>();
            data.Add("type", type);
            return await _srv.CallAsync("messages/recived", data);         
        }
      
        /// <summary>
        /// Sending a message to an ND/SC
        /// </summary>
        /// <param name="phone">string phone</param>
        /// <param name="text">string text</param>
        /// <returns>Boolean "success"</returns>
        public string SendNd( string phone, string text)
        {
            var data = new Dictionary<string, string> {{"text", text}};
            return _srv.Call("messages/send_nd", data);
	    }

        /// <summary>
        /// Sending a message to an ND/SC
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        /// <returns>Boolean "success"</returns>
        public async Task<string> SendNdAsync(string phone)
        {
            var data = new Dictionary<string, string> {{"phone", phone}};
            return await _srv.CallAsync("messages/send_nd", data);
        }
    
        /// <summary>
        /// Sending a message to an NDI/SCI
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        /// <param name="ndi_number">The ndi number.</param>
        /// <returns>@option Boolean "success"</returns>
        public string SendNdi( string phone, string text, string ndi_number)
        {
            var data = new Dictionary<string, string> {{"text", text}, {"ndi_number", ndi_number}};
            return _srv.Call("messages/send_ndi", data);
	    }


        /// <summary>
        /// Sending a message to an NDI/SCI
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        /// <param name="ndi_number">The ndi number.</param>
        /// <returns>@option Boolean "success"</returns>
        public async Task<string> SendNdiAsync(string phone, string ndi_number)
        {
            var data = new Dictionary<string, string> {{"phone", phone}, {"ndi_number", ndi_number}};
            return await _srv.CallAsync("messages/send_nd", data);
        }
       

    }
}

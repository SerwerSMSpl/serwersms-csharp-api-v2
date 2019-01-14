using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SerwerSMS.Lib
{
    /// <summary>
    /// This class handles operations on Payments.
    /// </summary>
    public class Payments
	{
		private readonly SerwerSms _srv;

	    internal Payments( SerwerSms srv )
		{
			_srv = srv;
        }

        /// <summary>
        /// List of payments
        /// </summary>
        /// <returns>
        ///  int "id"
		///  string "number"
		///  string "state" paid|not_paid
        ///  float "paid"
		///  float "total"
		///  string "payment_to"
		///  string "url"
        ///  </returns>
        public string Index()
        {
	        var data = new Dictionary<string, string>();
	        return _srv.Call("payments/index",data);
	    }

        /// <summary>
        /// List of payments
        /// </summary>
        /// <returns>
        ///  int "id"
		///  string "number"
		///  string "state" paid|not_paid
        ///  float "paid"
		///  float "total"
		///  string "payment_to"
		///  string "url"
        ///  </returns>
        public async Task<string> IndexAsync()
        {
            var data = new Dictionary<string, string>();
            return await _srv.CallAsync("payments/index", data);
        }

        /// <summary>
        /// View single payment
        /// </summary>
        /// <param name="id">int The identifier.</param>
        /// <returns>
        /// int "id"
		/// string "number"
		/// string "state" paid|not_paid
        /// float "paid"
		/// float "total"
		/// string "payment_to"
		/// string "url"
        /// </returns>
        public string View( string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            return _srv.Call("payments/index", data);
        }

        /// <summary>
        /// View single payment
        /// </summary>
        /// <param name="id">int The identifier.</param>
        /// <returns>
        /// int "id"
        /// string "number"
        /// string "state" paid|not_paid
        /// float "paid"
        /// float "total"
        /// string "payment_to"
        /// string "url"
        /// </returns>
        public async Task<object> ViewAsync(string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return await _srv.CallAsync("payments/index", data);
        }

        /// <summary>
        /// Download invoice as PDF
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>resource.</returns>
        public Stream Invoice( string id)
        {
            var data = new Dictionary<string, string>
            {
                { "id", id }
            };
            return _srv.CallStream("payments/invoice", data);
        }

        /// <summary>
        /// Download invoice as PDF
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>resource.</returns>
        public async Task<Stream> InvoiceAsync(string id)
        {
            var data = new Dictionary<string, string> {{"id", id}};
            var result =  await _srv.CallStreamAsync("payments/invoice", data);
            return result;
        }

	    /// <summary>
	    /// Saves the file.
	    /// </summary>
	    /// <param name="stream">Stream stream</param>
	    /// <param name="path">string path</param>
	    public void SaveFile(Stream stream, string path)
	    {
	        using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
	        {
	            stream.CopyTo(fileStream);
	            fileStream.Close();
	        }
        }
	}
	
}

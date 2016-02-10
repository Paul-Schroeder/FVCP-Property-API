using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business
{
    [Serializable]
    public class ServiceResult<T>
    {
        private List<string> _errors = new List<string>();
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServiceResult{T}"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error identifier.
        /// </summary>
        /// <value>
        /// The error identifier.
        /// </value>
        public string ErrorID { get; set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<string> Errors
        {
            get
            {
                return _errors;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        public ServiceResult() : this(default(T), false, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public ServiceResult(T data, bool success) : this(data, success, null, null, null) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        /// <param name="errorID">The error identifier.</param>
        /// <param name="errors">The errors.</param>
        public ServiceResult(T data, bool success, string message, string errorID, IEnumerable<string> errors)
        {
            this.Data = data;
            this.Success = success;
            this.Message = message;
            this.ErrorID = errorID;
            if (errors != null)
                _errors.AddRange(errors);

        }
    }
}

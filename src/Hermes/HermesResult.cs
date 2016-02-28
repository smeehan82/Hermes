using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes
{
    public class HermesResult
    {
        private static readonly HermesResult _success = new HermesResult { Succeeded = true };
        private List<HermesError> _errors = new List<HermesError>();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of <see cref="HermesError"/>s containing an errors
        /// that occurred during the identity operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of <see cref="HermesError"/>s.</value>
        public IEnumerable<HermesError> Errors => _errors;

        /// <summary>
        /// Returns an <see cref="HermesResult"/> indicating a successful identity operation.
        /// </summary>
        /// <returns>An <see cref="HermesResult"/> indicating a successful operation.</returns>
        public static HermesResult Success => _success;

        /// <summary>
        /// Creates an <see cref="HermesResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="HermesError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="HermesResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static HermesResult Failed(params HermesError[] errors)
        {
            var result = new HermesResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        /// <summary>
        /// Converts the value of the current <see cref="HermesResult"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current <see cref="HermesResult"/> object.</returns>
        /// <remarks>
        /// If the operation was successful the ToString() will return "Succeeded" otherwise it returned 
        /// "Failed : " followed by a comma delimited list of error codes from its <see cref="Errors"/> collection, if any.
        /// </remarks>
        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }
}

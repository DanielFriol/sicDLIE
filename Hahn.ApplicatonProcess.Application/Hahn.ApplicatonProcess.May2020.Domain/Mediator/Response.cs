using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator
{
    public class Response
    {
        private readonly IList<string> _messages = new List<string>();

        public Response() => Errors = new ReadOnlyCollection<string>(_messages);
        public Response(dynamic result) : this() => Result = result;

        public IEnumerable<string> Errors { get; }
        public dynamic Result { get; }

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
